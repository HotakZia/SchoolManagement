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
    public class NoticesController : BaseController
    {
        //private readonly School_dbContext _context;

        //public NoticesController(School_dbContext context)
        //{
        //    _context = context;
        //}

        // GET: Notices
        public async Task<IActionResult> Index()
        {
            string role = User.Claims.FirstOrDefault(x => x.Type == "Role")?.Value;
      
            var list =await db.Notices.Where(x => x.Date >= DateTime.Now && x.Status == true && (x.Type == role || x.Type == "All")).ToListAsync();
            if (role=="Admin")
            {
                list =await db.Notices.ToListAsync();
            }
            return View(list);
        }

        // GET: Notices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notice = await db.Notices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }

        // GET: Notices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,RegisterNumber,Id,Title,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number,Year,Type")] Notice notice,string NoticeBody)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                    //var duplicate = db.Notices.Where(x => x.Title == notice.Title && x.CreatedDate == notice.CreatedDate).FirstOrDefault();
                    //if (duplicate != null)
                    //{
                    //    showMessageString = new
                    //    {
                    //        status = "duplicate",
                    //        message = notice.Title + " " + " is dupplicate notice!"

                    //    };
                    //    return Json(showMessageString);
                    //}
                    notice.Id = Guid.NewGuid();
                    notice.CreatedDate = DateTime.Now;
                    notice.Status = true;
                   
                    db.Add(notice);
                    await db.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    showMessageString = new
                    {
                        status = "true",
                        message = notice.Title + " has been added."

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
        
            return View(notice);
        }

        // GET: Notices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notice = await db.Notices.FindAsync(id);
            if (notice == null)
            {
                return NotFound();
            }
            return View(notice);
        }

        // POST: Notices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Date,RegisterNumber,Id,Title,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number,Year,Type")] Notice notice)
        {
            if (id != notice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    notice.ModifiedDate = DateTime.Now;
                    db.Update(notice);

                    await db.SaveChangesAsync();
                    showMessageString = new
                    {
                        status = "true",
                        message = notice.Title + " has been added."

                    };
                    return Json(showMessageString);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!NoticeExists(notice.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        showMessageString = new
                        {
                            status = "false",
                            message = ex.Message

                        };
                        return Json(showMessageString);
                    }
                }
                
            }
            return View(notice);
        }

        // GET: Notices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notice = await db.Notices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notice == null)
            {
                return NotFound();
            }

            return View(notice);
        }

        // POST: Notices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var notice = await db.Notices.FindAsync(id);
            db.Notices.Remove(notice);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoticeExists(Guid id)
        {
            return db.Notices.Any(e => e.Id == id);
        }
    }
}
