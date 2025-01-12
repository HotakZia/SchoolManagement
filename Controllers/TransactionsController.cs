using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SchoolManagement.Models.db;
using SchoolManagement.Models;
namespace SchoolManagement.Controllers
{
    public class TransactionsController : BaseController
    {
        //private readonly School_dbContext _context;

        //public TransactionsController(School_dbContext context)
        //{
        //    _context = context;
        //}
        public async Task<IActionResult> Closing()
        {
            ViewBag.TransactionList = db.Transactions.Where(x => x.Status != true).ToList();

            return View();
        }
        public async Task<IActionResult> ClosingList()
        {
            var list = db.Closings.ToList();
            return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClosingSave(Closing closing)
        {

            try
            {

            
            var checkDuplicate = db.Closings.Where(x => x.CreatedDate.Value.Year == DateTime.Now.Year && x.CreatedDate.Value.Month == DateTime.Now.Month &&
              x.CreatedDate.Value.Day == DateTime.Now.Day).FirstOrDefault();
            if (checkDuplicate!=null)
            {
                showMessageString = new
                {
                    status = "duplicate",
                    message = "Already closing done today!"

                };
                return Json(showMessageString);
            }
            var list = db.Transactions.Where(x => x.Status != true).ToList();
            decimal? totalCredit = 0;
            decimal? totalDebit = 0;
            
            if (list.Count()>=1)
            {
                
                foreach (var item in list)
                {
                    item.Status = true;
                    //db.Transactions.Update(item);
                    if (item.Drcr=="Credit")
                    {
                        totalCredit += item.Amount;
                    }
                    else if (item.Drcr == "Debit")
                    {
                        totalDebit += item.Amount;
                    }
                        db.Transactions.Update(item);
                        db.Entry(item).Property("Number").IsModified = false;

                    }
                }
            else
            {
                showMessageString = new
                {
                    status = "false",
                    message = "you don't have new records!"

                };
                return Json(showMessageString);
            }
                closing.Credit = totalCredit;
                closing.Debit = totalDebit;
               
          
                var lastClosing = db.Closings.OrderByDescending(x => x.CreatedDate).Select(x=>x.Amount).FirstOrDefault()??0;
                closing.Amount = totalCredit - (totalDebit + lastClosing);
            closing.Id = Guid.NewGuid();
            closing.CreatedDate = DateTime.Now;
            db.Closings.Add(closing);
            db.SaveChanges();
                ViewBag.TransactionList = db.Transactions.Where(x => x.Status != true).ToList();
                showMessageString = new
                {
                    status = "true",
                    message = "the closing has been done."

                };
                return Json(showMessageString);

            }
            catch (Exception ex)
            {
                showMessageString = new
                {
                    status = "false",
                    message = ex.InnerException.Message

                };
                return Json(showMessageString);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> lineChart(string Date)
        {
            DateTime startDate = DateTime.Now.AddMonths(-1);
            DateTime toDate = DateTime.Now;
            if (!string.IsNullOrEmpty(Date))
            {
                string[] From_To_Dates = Date.Split(new Char[] { '-',/* '\n', '\t', ' ', ',', '.'*/ });
                startDate = DateTime.Parse(From_To_Dates[0].ToString());
                toDate = DateTime.Parse(From_To_Dates[1].ToString());
            }
            List<Models.DataPoint> dataPointsCredit = new List<Models.DataPoint>();
            List<Models.DataPoint> dataPointsDebit = new List<Models.DataPoint>();
            var credit = db.Transactions.Where(x=>x.Drcr=="Credit").GroupBy(c => c.Date.Value.Month).
                 Select(g => new Models.GroupByResult
                 {
                     Key = g.Key.ToString(),
                     decimalValue = g.Sum(x => x.Amount)
                 }).ToList();
            //var creditByDate =  db.Transactions.Select(item => new { Label = item.Date.Value.Month, Value = item.Amount.ToString() }).ToList();
            foreach (var item in credit)
            {
                dataPointsCredit.Add(new Models.DataPoint(item.Key, double.Parse(item.decimalValue.ToString())));
            }
            ViewBag.DataPointsCredit = JsonConvert.SerializeObject(dataPointsCredit);
            //ViewBag.DataPointsDebit = JsonConvert.SerializeObject(dataPointsDebit);




            return PartialView("");
        }
        public async Task<IActionResult> Sales()
        {
            return View();
        }
        [RequireHttps]
        public async Task<IActionResult> SalesCreate(List<Transaction> transactions,Guid? StudentId, string Comment,string PaidBy,DateTime Date)
        {

            try
            {
                if (!ModelState.IsValid)
                {

                    showMessageString = new
                    {
                        status = "false",
                        message = ModelState.ErrorCount

                    };
                    return Json(showMessageString);
                }
                if (transactions.Count()==0)
                {
                    showMessageString = new
                    {
                        status = "false",
                        message ="atleast 1 row required1"

                    };
                    return Json(showMessageString);
                }

                var tr = new Transaction();
                foreach (var item in transactions)
                {
                    tr = new Transaction();
                    tr.Id = Guid.NewGuid();
                    tr.CreatedDate = DateTime.Now;
                    tr.RelationId = StudentId;
                    tr.Drcr = "Credit";
                    tr.Type = item.Type;
                    tr.PaidBy = PaidBy;
                    tr.Comment = Comment;
                    tr.Date = Date;
                    tr.Amount = item.Amount;
                    db.Transactions.Add(tr);

                }
                db.SaveChanges();
                //return PartialView("_ReciptInvoice", fee);
                showMessageString = new
                {
                    status = "true",
                    message = "payments have been added.",
                    Id = StudentId,
                    Date = Date,
                };
   
                return Json(showMessageString);
            }
            catch (Exception ex)
            {

                showMessageString = new
                {
                    status = "false",
                    message = ex.InnerException.Message

                };
                return Json(showMessageString);
            }

        }
        [HttpPost]
        public async Task<IActionResult> getStudentPayments(Guid Id)
        {

            var list1 = await (from spayments in db.StudentPayments

                               join payment in db.Payments on spayments.PaymentId equals payment.Id


                               where spayments.StudentId == Id

                               select new Models.Entities.Payment
                               {

                                   Id = payment.Id,
                                   PaymentName = payment.Name,
                                   Amount = payment.Amount ?? 0,
                                   Total = 0,
                                   StudentId = spayments.StudentId,
                                   PaymentId = spayments.PaymentId,

                               }).ToListAsync();
            var list = new List<Models.db.Transaction>();
            foreach (var item in list1)
            {
                list.Add(new Transaction {  RelationId = item.StudentId, Amount = item.Amount, Type = item.PaymentName });
            }
            return PartialView("_paymentlist", list);
        }
        // GET: Transactions/recipt
        public async Task<IActionResult> Recipt(Guid? Id, DateTime? feeDate)
        {
            //if (Id == null)
            //{
            //    return NotFound();
            //}
        
            int year = int.Parse(feeDate.Value.ToString("yyyy"));
            int month = int.Parse(feeDate.Value.ToString("MM"));
            var fees = await (from fee in db.Transactions


                              join student in db.Students on fee.RelationId equals student.StudentId
                              //join class_ in db.Classes on student.ClassId equals class_.Id
                              where fee.RelationId == Id && fee.Date.Value.Year == year && fee.Date.Value.Month == month

                              select new Models.Entities.Transection
                              {
                                  PaidBy = fee.PaidBy,
                                  Type = fee.Type,
                                  //ClassId = class_.Id,
                                  CreatedDate = fee.CreatedDate,
                                  Date = fee.Date,
                                  Id = fee.Id,
                                  RelationId = fee.RelationId,
                                  Amount = fee.Amount,
                                  RelationName = student.FirstName + " " + student.LastName,
                                  Status = fee.Status,
                                  Comment = fee.Comment,
                                  CreatedBy = fee.CreatedBy,
                                  Attachment = fee.Attachment,
                                  ModifiedBy = fee.ModifiedBy,
                                  Number = fee.Number,
                                  //PaymentId = fee.PaymentId,
                                  Year = fee.Year,
                                  ModifiedDate = fee.ModifiedDate,
                                  //ClassName = class_.Name,
                               

                                  DRCR=fee.Drcr,
                                  

                              }).ToListAsync();


            ViewBag.systemInfo = db.TableCompanies.FirstOrDefault();



            return PartialView("_recipt", fees);
        }

        // GET: Transactions
        public async Task<IActionResult> Index(string Date)
        {
            DateTime fromDate = DateTime.Now.AddMonths(-1);
            DateTime toDate = DateTime.Now;
            if (!string.IsNullOrEmpty(Date))
            {
                string[] From_To_Dates = Date.Split(new Char[] { '-',/* '\n', '\t', ' ', ',', '.'*/ });
                toDate = DateTime.Parse(From_To_Dates[0].ToString());
                toDate = DateTime.Parse(From_To_Dates[1].ToString());
            }
            var list = db.Transactions.Where(x=>x.Date>=fromDate&&x.Date<=toDate).ToList();
            bool isAjaxRequest = Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjaxRequest)
            {
                return PartialView("_index", list);

            }
            return View(list);
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(string? Date)
        {
            DateTime startDate = DateTime.Now.AddMonths(-1);
            DateTime toDate = DateTime.Now;
            if (!string.IsNullOrEmpty(Date))
            {
                string[] From_To_Dates = Date.Split(new Char[] { '-',/* '\n', '\t', ' ', ',', '.'*/ });
               startDate = DateTime.Parse(From_To_Dates[0].ToString());
               toDate = DateTime.Parse(From_To_Dates[1].ToString());
            }
           
     
            ViewBag.Credit = db.Transactions.Where(x=>x.Drcr=="Credit" && x.Date >= startDate && x.Date <= toDate)
                .GroupBy(t => t.Type)
                .Select(g => new Models.GroupBy
                {
                    Name = g.Key,
                    Value = g.Sum(t => t.Amount)
                })
                .ToList();
            ViewBag.Debit = db.Transactions.Where(x => x.Drcr == "Debit"&&x.Date>=startDate&&x.Date<=toDate)
                .GroupBy(t => t.Type)
                .Select(g => new Models.GroupBy
                {
                    Name = g.Key,
                    Value = g.Sum(t => t.Amount)
                })
                .ToList();


            ////////////////////////////
            ///

         
            if (!string.IsNullOrEmpty(Date))
            {
                string[] From_To_Dates = Date.Split(new Char[] { '-',/* '\n', '\t', ' ', ',', '.'*/ });
                startDate = DateTime.Parse(From_To_Dates[0].ToString());
                toDate = DateTime.Parse(From_To_Dates[1].ToString());
            }
            List<Models.DataPoint> dataPointsCredit = new List<Models.DataPoint>();
            List<Models.DataPoint> dataPointsDebit = new List<Models.DataPoint>();
            var credit = db.Transactions.Where(x => x.Drcr == "Credit").GroupBy(c => c.Date.Value.Month).
                 Select(g => new Models.GroupByResult
                 {
                     Key = g.Key.ToString(),
                     decimalValue = g.Sum(x => x.Amount)
                 }).ToList();
            //var creditByDate =  db.Transactions.Select(item => new { Label = item.Date.Value.Month, Value = item.Amount.ToString() }).ToList();
            foreach (var item in credit)
            {
                dataPointsCredit.Add(new Models.DataPoint(item.Key, double.Parse(item.decimalValue.ToString())));
            }
            ViewBag.DataPointsCredit = JsonConvert.SerializeObject(dataPointsCredit);
            //ViewBag.DataPointsDebit = JsonConvert.SerializeObject(dataPointsDebit);





   
            return View();
        }
       
    
        // GET: Transactions/feeslist
        public IActionResult Fees()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Fees([Bind("RelationId,Id,Amount,Type,Comment,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Attachment,Status,Number,Date,PaidBy,Year")] IEnumerable <Transaction> transaction, IFormFile Image)
        {

            try
            {

                foreach (var item in transaction)
                {

                    //var assignFee = db.StudentPayments.ToList();

                    var checkDuplicate = db.Transactions.Where(x => x.Date.Value.Month == item.Date.Value.Month
                    && x.Date.Value.Year == item.Date.Value.Year
                    && x.Type == item.Type
                    && x.RelationId == item.RelationId).FirstOrDefault();
                    if (checkDuplicate != null)
                    {
                        showMessageString = new
                        {
                            status = "duplicate",
                            message = "duplicatefor " + item.Type + item.Date.Value.Month + "-" + item.Date.Value.Year

                        };
                        return Json(showMessageString);

                    }


                    var transection = new Transaction();
           

                    ///////////////
                    transection.Id = Guid.NewGuid();
                    transection.CreatedDate = item.Date;
                    transection.Amount = item.Amount;
                    transection.Comment = transaction.FirstOrDefault().Comment;
                    transection.PaidBy = transaction.FirstOrDefault().PaidBy;
                    transection.Drcr = "Credit";
                    transection.Type =item.Type;
                    transection.RelationId = item.RelationId;
                    transection.Date = item.Date;
                    db.Transactions.Add(transection);

                }


                db.SaveChangesAsync();
                //return PartialView("_ReciptInvoice", fee);
                showMessageString = new
                {
                    status = "true",
                    message = "payments have been added.",
                    Id =transaction.FirstOrDefault().RelationId,
                    Date = transaction.FirstOrDefault().Date,
                };
                return Json(showMessageString);
            }


            catch (Exception ex)
            {

                showMessageString = new
                {
                    status = "false",
                    message = ex.InnerException.Message

                };
                return Json(showMessageString);
            }
          
            return View(transaction);
        }

        public ActionResult FeesList(Guid? ClassId, DateTime feedate,Guid? StudentId)
        {
            ViewBag.ClassId = new SelectList(db.Classes.ToList(), "Id", "Name");
          
            IList<Models.Entities.Student> list = new List<Models.Entities.Student>();
            if (ClassId == null &&StudentId==null)
            {
                return View("FeesList",list);
            }
            if (feedate == null)
            {
                feedate = DateTime.Now;
            }
            int year =int.Parse(feedate.ToString("yyyy"));
            int month = int.Parse(feedate.ToString("MM"));
            ViewBag.feeDate = feedate;


            var query = db.Students.AsQueryable();
           
             if(ClassId!=null)
            {
                list = (from student in db.Students
                            //join fees in db.Fees on student.StudentId equals fees.StudentId
                        where student.ClassId == ClassId

                        select new Models.Entities.Student
                        {

                            StudentId = student.StudentId,
                            Tazkira = student.Tazkira,
                            RoleNumber = student.RoleNumber,
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            FatherName = student.FatherName,
                            Attachment = student.Attachment,
                            Contact = student.Contact,
                            Status = student.Status,
                            AdmissionDate = student.AdmissionDate,
                            GuardianName = student.GuardianName,
                            GuardianPhone = student.GuardianPhone,
                            AssignFeesCount = db.StudentPayments.Where(x => x.StudentId == student.StudentId).Count(),
                            PayFeesCount = db.Transactions.Where(x => x.RelationId == student.StudentId && x.Date.Value.Year == year && x.Date.Value.Month == month).Count(),



                        })/*.OrderByDescending(x => x.CreatedDate)*/.ToList();
            }
            else if (StudentId != null)
            {
                list = (from student in db.Students
                            //join fees in db.Fees on student.StudentId equals fees.StudentId
                        where student.StudentId == StudentId

                        select new Models.Entities.Student
                        {

                            StudentId = student.StudentId,
                            Tazkira = student.Tazkira,
                            RoleNumber = student.RoleNumber,
                            FirstName = student.FirstName,
                            LastName = student.LastName,
                            FatherName = student.FatherName,
                            Attachment = student.Attachment,
                            Contact = student.Contact,
                            Status = student.Status,
                            AdmissionDate = student.AdmissionDate,
                            GuardianName = student.GuardianName,
                            GuardianPhone = student.GuardianPhone,
                            AssignFeesCount = db.StudentPayments.Where(x => x.StudentId == student.StudentId).Count(),
                            PayFeesCount = db.Transactions.Where(x => x.RelationId == student.StudentId && x.Date.Value.Year == year && x.Date.Value.Month == month).Count(),



                        })/*.OrderByDescending(x => x.CreatedDate)*/.ToList();
            }

            return PartialView("_feeslist", list);
        }

      
        public async Task<IActionResult> FeesEdit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/salary
        public IActionResult Salary()
        {
            return View();
        }
        // GET: Transactions/salarylist
        
            public ActionResult SalaryList(DateTime? feedate)
            {

                IList<Models.Entities.Teacher> list = new List<Models.Entities.Teacher>();

            if (feedate == null)
            {
                feedate = DateTime.Now;
            }
            int year = int.Parse(feedate.Value.ToString("yyyy"));
            int month = int.Parse(feedate.Value.ToString("MM"));
            ViewBag.salaryDate = feedate;


                var query = db.Students.AsQueryable();

        
            

               list = (from teacher in db.Teachers
                                // join teacher in db.Teachers on transection.RelationId equals teacher.TeacherId
                            //where teacher.TeacherId == TeacherId //&& transection.Date.Value.Year == year && transection.Date.Value.Month == month

                            select new Models.Entities.Teacher
                            {

                                TeacherId = teacher.TeacherId,
                                FirstName = teacher.FirstName,
                                LastName = teacher.LastName,
                                RoleNumber = teacher.RoleNumber,
                                ModifiedBy = teacher.ModifiedBy,
                                Comment = teacher.Comment,
                                CreatedBy = teacher.Comment,
                                CreatedDate = teacher.CreatedDate,
                                ModifiedDate = teacher.ModifiedDate,
                                Attachment = teacher.Attachment,
                                Status = teacher.Status,
                                Position=teacher.Position,
                                Salary = db.Transactions.Where(t => t.RelationId == teacher.TeacherId && t.Date.Value.Year == year && t.Date.Value.Month == month).Sum(s=>s.Amount),



                            })/*.OrderByDescending(x => x.CreatedDate)*/.ToList();
            bool isAjaxRequest = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjaxRequest)
            {
                return PartialView("_salarylist", list);
               
            }
            return View("SalaryList", list);



        }

            public async Task<IActionResult> SalaryEdit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Drcr,RelationId,Id,Amount,Type,Comment,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Attachment,Status,Number,Date,PaidBy,Year")] Transaction transaction, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var duplicate = new Transaction();
                    if (transaction.Type=="Teacher-Salary"|| transaction.Type == "Student-Fees")
                    {
                         duplicate = db.Transactions.Where(x => x.RelationId == transaction.RelationId &&
                         x.Date.Value.Year==transaction.Date.Value.Year&&
                         x.Date.Value.Month==transaction.Date.Value.Month).FirstOrDefault();
                        if (duplicate != null)
                        {
                            showMessageString = new
                            {
                                status = "duplicate",
                                message = "already paid for "+transaction.Date.Value.ToString("MMMM-yy") + ".  dupplicate record!"

                            };
                            return Json(showMessageString);
                        }
                    }
           
        
                    if (Image != null)
                    {
                        using (var memoryStream = new MemoryStream())
                        {

                            Image.CopyToAsync(memoryStream);
                            Byte[] fileBytes = memoryStream.ToArray();
                            int maxFileSizeInBytes = 1 * 1024 * 1024 / 2; // 10MB (adjust as needed)
                            if (
                       Image.ContentType.ToLower() != "image/jpg" &&
                       Image.ContentType.ToLower() != "image/jpeg" &&
                       Image.ContentType.ToLower() != "image/pjpeg" &&
                       Image.ContentType.ToLower() != "image/gif" &&
                       Image.ContentType.ToLower() != "image/x-png" &&
                       Image.ContentType.ToLower() != "image/png" &&
                       Image.ContentType.ToLower() != "image/svg"
                   )
                            {

                                showMessageString = new
                                {
                                    status = "false",
                                    message = " file must be a JPEG, PNG or SVG format."
                                };
                                return Json(showMessageString);
                            }
                            if (Image.Length > maxFileSizeInBytes)
                            {

                                showMessageString = new
                                {
                                    status = "false",
                                    message = " file photo max size must be 512 KB."
                                };
                                return Json(showMessageString);
                            }
                            else
                            {
                                transaction.Attachment = fileBytes;

                            }
                        }
                    }
                    transaction.Id = Guid.NewGuid();
                    transaction.CreatedDate = DateTime.Now;
                    transaction.Status = true;
                    db.Add(transaction);
                    await db.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    showMessageString = new
                    {
                        status = "true",
                        message = transaction.Amount + " has been added."

                    };
                    return Json(showMessageString);
                }
                catch (Exception ex)
                {

                    showMessageString = new
                    {
                        status = "false",
                        message = ex.InnerException.Message

                    };
                    return Json(showMessageString);
                }

            }
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await db.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Drcr,RelationId,Id,Amount,Type,Comment,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Attachment,Status,Date,PaidBy,Year")] Transaction transaction, IFormFile Image)
        {
            if (id != transaction.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {

                showMessageString = new
                {
                    status = "false",
                    message = string.Join("; ", ModelState.Values
                                   .SelectMany(x => x.Errors)
                                   .Select(x => x.ErrorMessage)),
                };
                return Json(showMessageString);
            }
            try
            {
                if (Image != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {

                        Image.CopyToAsync(memoryStream);
                        Byte[] fileBytes = memoryStream.ToArray();
                        int maxFileSizeInBytes = 1 * 1024 * 1024 / 2; // 10MB (adjust as needed)
                        if (
                   Image.ContentType.ToLower() != "image/jpg" &&
                   Image.ContentType.ToLower() != "image/jpeg" &&
                   Image.ContentType.ToLower() != "image/pjpeg" &&
                   Image.ContentType.ToLower() != "image/gif" &&
                   Image.ContentType.ToLower() != "image/x-png" &&
                   Image.ContentType.ToLower() != "image/png" &&
                   Image.ContentType.ToLower() != "image/svg"
               )
                        {

                            showMessageString = new
                            {
                                status = "false",
                                message = "Profile photo must be a JPEG, PNG or SVG format."
                            };
                            return Json(showMessageString);
                        }
                        if (Image.Length > maxFileSizeInBytes)
                        {

                            showMessageString = new
                            {
                                status = "false",
                                message = " Profile photo max size must be 512 KB."
                            };
                            return Json(showMessageString);
                        }
                        else
                        {
                            transaction.Attachment = fileBytes;

                        }
                    }
                }
                transaction.ModifiedDate = DateTime.Now;
                db.Update(transaction);
                // Exclude the 'Number' property from being updated
                db.Entry(transaction).Property("Number").IsModified = false;
         
                await db.SaveChangesAsync();
                showMessageString = new
                {
                    status = "true",
                    message = "salary has been updated."
                };
                return Json(showMessageString);
            }
            catch (Exception ex)
            {

                showMessageString = new
                {
                    status = "false",
                    message = ex.InnerException.Message
                };
                return Json(showMessageString);
            }
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await db.Transactions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var transaction = await db.Transactions.FindAsync(id);
            db.Transactions.Remove(transaction);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(Guid id)
        {
            return db.Transactions.Any(e => e.Id == id);
        }
    }
}
