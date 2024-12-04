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

        [HttpPost]
        public async Task<IActionResult> getStudentPayments(Guid Id)
        {

            var list = await (from spayments in db.StudentPayments
                          
                                 join payment in db.Payments on spayments.PaymentId equals payment.Id


                              where spayments.StudentId==Id

                              select new Models.db.Payment
                              {

                                  Id = payment.Id,
                                  Name=payment.Name,
                                  Amount=payment.Amount,
                               

                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
            return Json(list);
        }
        // GET: Fees
        public ActionResult Index(Guid? Id, DateTime date)
        {
            ViewBag.Id = new SelectList(db.Classes.ToList(), "Id", "Name");
            IList<Models.Entities.Student> list = new List<Models.Entities.Student>();
            if (Id == null)
            {
                return View(list);
            }
            if (date==null)
            {
                date = DateTime.Now;
            }
             list =  (from student in db.Students
                          join class_ in db.Classes on student.ClassId equals class_.Id
                          join fees in db.Fees on student.StudentId equals fees.StudentId
                          where student.ClassId == Id

                          select new Models.Entities.Student
                          {
                              ClassId = student.ClassId,
                              StudentId = student.StudentId,
                              Tazkira = student.Tazkira,
                              RoleNumber = student.RoleNumber,
                              FirstName = student.FirstName,
                              LastName = student.LastName,
                              FatherName = student.FatherName,
                              ClassName = class_.Name,
                              Attachment = student.Attachment,
                              Contact = student.Contact,
                              Status = student.Status,
                           
                              AdmissionDate = student.AdmissionDate,
                          
                              GuardianName = student.GuardianName,
                              GuardianPhone = student.GuardianPhone,
                              studentFeesPayments = (from sfees in db.StudentPayments
                                                    join payment in db.Payments on sfees.PaymentId equals payment.Id
                                                    where sfees.StudentId==student.StudentId
                                                    select new Models.Entities.Payment
                                                    {
                                                        PaymentName = payment.Name,
                                                        Amount = payment.Amount
                                                    }).ToList()
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
        public async Task<IActionResult> Create([Bind("Id,StudentId,Amount,FeeType,Date,PaymentId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number")] Fee fee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var studentAssignPayments = await (from spayments in db.StudentPayments

                                                       join payment in db.Payments on spayments.PaymentId equals payment.Id

                                                       where spayments.StudentId == fee.StudentId

                                      select new Models.db.Payment
                                      {

                                          Id = payment.Id,
                                          Name = payment.Name,
                                          Amount = payment.Amount,
                                          

                                      })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
                    //var studentAssignPayments = db.StudentPayments.Where(x => x.StudentId == fee.StudentId).ToList();
                    if (studentAssignPayments!=null)
                    {
                      
                     
                            var duplicate = db.Fees.Where(x => x.StudentId == fee.StudentId
                   && fee.Date.Value.Month == fee.Date.Value.Month
                   && x.Date.Value.Year == fee.Date.Value.Year
                   ).FirstOrDefault();
                            if (duplicate != null)
                            {
                                showMessageString = new
                                {
                                    status = "duplicate",
                                    message = "student already paid for the"+" "+fee.Date.Value.Month+"-"+fee.Date.Value.Year

                                };
                                return Json(showMessageString);
                            }
                            
                            fee.Id = Guid.NewGuid();
                            fee.Status = true;
                            fee.CreatedDate = DateTime.Now;
                            db.Fees.Add(fee);
                        

                    }
                   
                   

                
                    await db.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    showMessageString = new
                    {
                        status = "true",
                        message =  "payments have been added."

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
