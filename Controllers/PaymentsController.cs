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
    public class PaymentsController : BaseController
    {
        //private readonly School_dbContext db;

        //public PaymentsController(School_dbContext context)
        //{
        //    db = context;
        //}

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            return View(await db.Payments.ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await db.Payments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Amount,Id,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Name,Type")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var duplicate = db.Payments.Where(x => x.Name ==payment.Name).FirstOrDefault();
                    if (duplicate!=null)
                    {
                        showMessageString = new
                        {
                            status = "duplicate",
                            message = payment.Name+" "+" is dupplicate name!"
                            
                        };
                        return Json(showMessageString);
                    }
                    payment.Id = Guid.NewGuid();
                    payment.CreatedDate = DateTime.Now;
                    payment.Status = true;

                    db.Add(payment);
                    await db.SaveChangesAsync();
                    showMessageString = new
                    {
                        status = "true",
                        message = "New payment has been saved."
                    };
                    return Json(showMessageString);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    showMessageString = new
                    {
                        status = "false",
                        message = ex.Message
                    };
                    return Json(showMessageString);
                }
         
            }
            return View(payment);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await db.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Amount,Id,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Name,Type")] Payment payment)
        {
            if (id != payment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var duplicate = db.Payments.Where(x => x.Name == payment.Name).FirstOrDefault();
                    if (duplicate != null)
                    {
                        showMessageString = new
                        {
                            status = "duplicate",
                            message = payment.Name + " " + " is dupplicate name!"

                        };
                        return Json(showMessageString);
                    }
              
                    payment.ModifiedDate = DateTime.Now;

                    db.Update(payment);
                    await db.SaveChangesAsync();
                    showMessageString = new
                    {
                        status = "true",
                        message = payment.Name+" payment has been updated."
                    };
                    return Json(showMessageString);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    showMessageString = new
                    {
                        status = "false",
                        message = ex.Message
                    };
                    return Json(showMessageString);
                }

            }
            return View(payment);
          
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await db.Payments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var payment = await db.Payments.FindAsync(id);
            db.Payments.Remove(payment);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(Guid id)
        {
            return db.Payments.Any(e => e.Id == id);
        }
    }
}
