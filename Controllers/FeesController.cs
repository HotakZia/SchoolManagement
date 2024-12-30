using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models.db;

namespace SchoolManagement.Controllers
{
    public class FeesController : BaseController
    {
        //private readonly School_dbContext _context;

        //public FeesController(School_dbContext context)
        //{
        //    _context = context;
        //}
        //[HttpPost]

            public async Task<IActionResult> ReciptInvoice(Guid? Id,DateTime Date)
            {
                if (Id == null)
            {
               
            }

            var fees = await (from fee in db.Fees


                        join student in db.Students on fee.StudentId equals student.StudentId
                        join class_ in db.Classes on student.ClassId equals class_.Id
                        where fee.StudentId == Id&&fee.Date.Value.Year==Date.Year&&fee.Date.Value.Month==Date.Month

                        select new Models.Entities.Fees
                        {
                            PaidBy=fee.PaidBy,
                            FeeType = fee.FeeType,
                            ClassId = fee.ClassId,
                            CreatedDate = fee.CreatedDate,
                            Date = fee.Date,
                            Id = fee.Id,
                            StudentId = fee.StudentId,
                            Amount = fee.Amount,
                            StudentName = student.FirstName + " " + student.LastName,
                            Status = fee.Status,
                            Comment = fee.Comment,
                            CreatedBy = fee.CreatedBy,
                            Attachment = fee.Attachment,
                            ModifiedBy = fee.ModifiedBy,
                            Number = fee.Number,
                            PaymentId = fee.PaymentId,
                            Year = fee.Year,
                            ModifiedDate = fee.ModifiedDate,
                            ClassName = class_.Name,
                            FatherName = student.FatherName,
                            GrandFatherName = student.GfatherName,
                            RollId = student.RoleNumber,
                            


                        }).ToListAsync();
   

            ViewBag.systemInfo = db.TableCompanies.FirstOrDefault();



            return PartialView("_ReciptInvoice", fees);
        }

        [HttpPost]
        public async Task<IActionResult> getStudentPayments(Guid Id)
        {

            var list1 = await (from spayments in db.StudentPayments
                          
                                 join payment in db.Payments on spayments.PaymentId equals payment.Id
                                

                              where spayments.StudentId==Id

                              select new Models.Entities.Payment
                              {

                                  Id = payment.Id,
                                  PaymentName=payment.Name,
                                  Amount=payment.Amount??0,
                               Total=0,
                               StudentId=spayments.StudentId,
                               PaymentId=spayments.PaymentId,

                              }).ToListAsync();
            var list = new List<Models.db.Fee>();
            foreach (var item in list1)
            {
                list.Add(new Fee { PaymentId = item.PaymentId, StudentId = item.StudentId, Amount = item.Amount,FeeType=item.PaymentName });
            }
            return PartialView("_paymentlist", list);
        }
        // GET: Fees
        public ActionResult Index(Guid? ClassId, DateTime date)
        {
            ViewBag.ClassId = new SelectList(db.Classes.ToList(), "Id", "Name");
            IList<Models.Entities.Student> list = new List<Models.Entities.Student>();
            if (ClassId == null)
            {
                return View(list);
            }
            if (date==null)
            {
                date = DateTime.Now;
            }
             list =  (from student in db.Students
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
                              AssignFeesCount=db.StudentPayments.Where(x=>x.StudentId==student.StudentId).Count(),
                              PayFeesCount=db.Fees.Where(x => x.StudentId == student.StudentId && x.Date.Value.Year == date.Year && x.Date.Value.Month == date.Month).Count(),
                              //studentFeesPayments = (from sfees in db.StudentPayments
                              //                      join payment in db.Payments on sfees.PaymentId equals payment.Id
                              //                      where sfees.StudentId==student.StudentId
                              //                      select new Models.Entities.Payment
                              //                      {
                              //                          PaymentName = payment.Name,
                              //                          Amount = payment.Amount
                              //                      }).ToList()
            //db.StudentPayments.Where(x=>x.StudentId==student.StudentId).ToList()


        })/*.OrderByDescending(x => x.CreatedDate)*/.ToList();
            return PartialView("_index", list);
        }

        // GET: Fees/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fee = await db.Fees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fee == null)
            {
                return NotFound();
            }

            return View(fee);
        }

        // GET: Fees/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: Fees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public async Task<IActionResult> Create(IEnumerable<Fee> fee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                  
                    foreach (var item in fee)
                    {
                      
                        //var assignFee = db.StudentPayments.ToList();

                        var checkDuplicate = db.Fees.Where(x => x.Date.Value.Month == item.Date.Value.Month
                        && x.Date.Value.Year == item.Date.Value.Year
                        && x.PaymentId == item.PaymentId
                        && x.StudentId == item.StudentId).FirstOrDefault();
                        if (checkDuplicate != null)
                        {
                            showMessageString = new
                            {
                                status = "duplicate",
                                message = "duplicatefor " + item.FeeType + item.Date.Value.Month + "-" + item.Date.Value.Year

                            };
                            return Json(showMessageString);

                        }

                        /////////
                        ///  
                        /// 
                        /// 
                        var feesPay = new Models.db.Fee();
                        var transection = new Transaction();
                        feesPay.Id = Guid.NewGuid();
                        feesPay.CreatedDate = DateTime.Now;
                        feesPay.Amount = item.Amount;
                        feesPay.FeeType = item.FeeType;
                        feesPay.PaidBy = item.PaidBy;
                        feesPay.Date = item.Date;
                        feesPay.Status = true;
                        feesPay.ClassId = item.ClassId;
                        feesPay.StudentId = item.StudentId;
                        feesPay.PaymentId = item.PaymentId;
                        feesPay.Comment = item.Comment;
                        db.Fees.Add(feesPay);

                        ///////////////
                        transection.Id = Guid.NewGuid();
                        transection.CreatedDate = DateTime.Now;
                        transection.Amount = item.Amount;
                        transection.Comment = item.FeeType;
                        transection.PaidBy = "Fees";
                        transection.Type = "Credit";
                        transection.RelationId = item.Id;
                        db.Transactions.Add(transection);

                    }


                     db.SaveChangesAsync();
                 //return PartialView("_ReciptInvoice", fee);
                    showMessageString = new
                    {
                        status = "true",
                        message = "payments have been added.",
                        Id= fee.FirstOrDefault().StudentId,Date=fee.FirstOrDefault().Date,
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
            return View(fee);
        }

        // GET: Fees/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fee = await db.Fees.FindAsync(id);
            if (fee == null)
            {
                return NotFound();
            }
            return View(fee);
        }

        // POST: Fees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,StudentId,Amount,FeeType,Date,PaymentId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number")] Fee fee)
        {
            if (id != fee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(fee);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeeExists(fee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fee);
        }

        // GET: Fees/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fee = await db.Fees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fee == null)
            {
                return NotFound();
            }

            return View(fee);
        }

        // POST: Fees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fee = await db.Fees.FindAsync(id);
            db.Fees.Remove(fee);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeeExists(Guid id)
        {
            return db.Fees.Any(e => e.Id == id);
        }
    }
}
