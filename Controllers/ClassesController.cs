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
    public class ClassesController : BaseController
    {
        //private readonly School_dbContext db;

        //public ClassesController(School_dbContext context)
        //{
        //    db = context;
        //}

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            return View(await db.Classes.ToListAsync());
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await db.Classes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@class == null)
            {
                return NotFound();
            }
            // Update the SelectList to include both first name and last name
            var teacherList = db.Teachers.Select(t => new {
                Id = t.TeacherId,
                FullName = t.FirstName + " " + t.LastName
            }).ToList();

            ViewBag.TeacherId = new SelectList(teacherList, "Id", "FullName");
            return View(@class);
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            // Update the SelectList to include both first name and last name
            var teacherList = db.Teachers.Select(t => new {
                Id = t.TeacherId,
                FullName = t.FirstName + " " + t.LastName
            }).ToList();

            ViewBag.TeacherId = new SelectList(teacherList, "Id", "FullName");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Grad,TeacherId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Shift,Year,Number,Room")] Class @class)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkduplicate = db.Classes.Where(x => x.Name == @class.Name && x.Year == @class.Year).FirstOrDefault();
                    if (checkduplicate!=null)
                    {
                        showMessageString = new
                        {
                            status = "duplicate",
                            message = checkduplicate.Name+" is dupplicate class."

                        };
                        return Json(showMessageString);
                    }
                    @class.Id = Guid.NewGuid();
                    @class.CreatedDate = DateTime.Now;
                    @class.Status = true;
                    db.Add(@class);
                    await db.SaveChangesAsync();
                    showMessageString = new
                    {
                        status = "true",
                        message = @class.Name +" has been added."

                    };
                    return Json(showMessageString);
                    return RedirectToAction(nameof(Index));
                }
                return View(@class);
            }
            catch (Exception ex)
            {

                showMessageString = new
                {
                    status = "false",
                    message = ex.ToString()

                };
                return Json(showMessageString);
            }
          
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await db.Classes.FindAsync(id);

            if (@class == null)
            {
                return NotFound();
            }
            return View(@class);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Grad,TeacherId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Shift,Year,Number,Room")] Class @class)
        {
            if (id != @class.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    @class.ModifiedDate = DateTime.Now;
                    db.Update(@class);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(@class.Id))
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
            return View(@class);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await db.Classes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var @class = await db.Classes.FindAsync(id);
            db.Classes.Remove(@class);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(Guid id)
        {
            return db.Classes.Any(e => e.Id == id);
        }
    }
}
