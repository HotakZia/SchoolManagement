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
    public class SubjectsController : BaseController
    {
        //private readonly School_dbContext _context;

        //public SubjectsController(School_dbContext context)
        //{
        //    _context = context;
        //}

        // GET: Subjects
        public async Task<IActionResult> Index()
        {
            var list = await (from Subject in db.Subjects
                              join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                           

                              //where Schedule.Status==true

                              select new Models.Entities.Subjetc
                              {
                                  SubjectName=Subject.SubjectName,
                                  SubjectId=Subject.Id,
                                  CreatedDate=Subject.CreatedDate,
                                  Grade=Subject.Grade,
                                  TeacherId=Subject.TeacherId,
                                  Number=Subject.Number,
                                  TeacherName=teacher.FirstName+" "+teacher.LastName,
                                  Year=Subject.Year,
                                 Attachment=Subject.Attachment,
                                 Comment=Subject.Comment,
                                 CreatedBy=Subject.CreatedBy,
                                 ModifiedBy=Subject.ModifiedBy,
                                 ModifiedDate=Subject.ModifiedDate,
                                 Status=Subject.Status
                                  

                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
            return View(list);
        }

        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await db.Subjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects/Create
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

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherId,Id,SubjectName,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number,Grade")] Subject subject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var checkDuplicate = db.Subjects.Where(x => x.SubjectName == subject.SubjectName).FirstOrDefault();
                    if (checkDuplicate!=null)
                    {
                        showMessageString = new
                        {
                            status = "flase",
                            message = "Dupplicate subject."

                        };
                        return Json(showMessageString);
                    }
                    subject.Id = Guid.NewGuid();
                    db.Add(subject);
                    await db.SaveChangesAsync();
                    showMessageString = new
                    {
                        status = "true",
                        message = subject.SubjectName+"  has been added."

                    };
                    return Json(showMessageString);
                    return RedirectToAction(nameof(Index));
                }
                return View(subject);
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

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await db.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TeacherId,Id,SubjectName,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number,Grade")] Subject subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(subject);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.Id))
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
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await db.Subjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var subject = await db.Subjects.FindAsync(id);
            db.Subjects.Remove(subject);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(Guid id)
        {
            return db.Subjects.Any(e => e.Id == id);
        }
    }
}
