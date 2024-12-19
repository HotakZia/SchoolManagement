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
    public class SchedulesController : BaseController
    {
        //private readonly School_dbContext _context;

        //public SchedulesController(School_dbContext context)
        //{
        //    _context = context;
        //}

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            var list = await (from Schedule in db.Schedules
                              join class_ in db.Classes on Schedule.ClassId equals class_.Id
                              //join Subject in db.Subjects on Schedule.SubjectId equals Subject.Id
                              join teacher in db.Teachers on Schedule.TeacherId equals teacher.TeacherId
                              where Schedule.Status==true/* &&Schedule.Year==DateTime.Now.Year*/

                              select new Models.Entities.Schedual
                              {
                                  
                                  Shift=Schedule.Shift,
                                  ClassId = Schedule.ClassId,
                                 
                                  Attachment = Schedule.Attachment,
                                  
                                  Status = Schedule.Status,
                                 
                                  Comment = Schedule.Comment,
                                  CreatedBy = Schedule.CreatedBy,
                                 
                                  ModifiedBy = Schedule.ModifiedBy,
                                  ModifiedDate = Schedule.ModifiedDate,
                                 SubjecName=Schedule.Subject,
                                 ClassName=class_.Name,
                                 HourOfDay=Schedule.HourOfDay,
                                 DayOfWeek=Schedule.DayOfWeek,
                                 Subject=Schedule.Subject,
                                 CreatedDate=Schedule.CreatedDate,
                                 Id=Schedule.Id,
                                 Name=Schedule.Name,
                                  Number=Schedule.Number,
                                  StartTime=Schedule.StartTime,
                                  EndTime=Schedule.EndTime,
                                  TeacherName=teacher.FirstName+" "+teacher.LastName,
                                Year=Schedule.Year,
                                


                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
            return View(list);
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await db.Schedules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            try
            {
                ViewBag.SubjectId = new SelectList(db.Subjects.ToList(), "Id", "SubjectName");

                ViewBag.ClassId = new SelectList(db.Classes.ToList(), "Id", "Name");


            }
            catch (Exception ex)
            {

                throw;
            }
       
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherId,Year,StartTime, EndTime,Shift,Id,Name,ClassId,Subject,HourOfDay,DayOfWeek,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number")] Schedule schedule)
        {
            try
            {
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
                var checkDuplicate = db.Schedules.Where(x => x.HourOfDay == schedule.HourOfDay &&
                      x.DayOfWeek == schedule.DayOfWeek &&
                      x.Subject == schedule.Subject &&
                      x.ClassId == schedule.ClassId).FirstOrDefault();
                    if (checkDuplicate!=null)
                    {
                        showMessageString = new
                        {
                            status = "duplicate",
                            message = "Dupplicate Schedual."

                        };
                        return Json(showMessageString);
                    }
                    schedule.Id = Guid.NewGuid();
                    schedule.Status = true;
                    schedule.CreatedDate = DateTime.Now;
                    db.Add(schedule);
                    await db.SaveChangesAsync();
                    showMessageString = new
                    {
                        status = "true",
                        message = "Scheddules has been added."

                    };
                    return Json(showMessageString);
                   
          
                
          
                
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
            return RedirectToAction(nameof(Index));


        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await db.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TeacherId,Year,StartTime, EndTime,Shift,Id,Name,ClassId,Subject,HourOfDay,DayOfWeek,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number")] Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(schedule);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.Id))
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
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await db.Schedules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var schedule = await db.Schedules.FindAsync(id);
            db.Schedules.Remove(schedule);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(Guid id)
        {
            return db.Schedules.Any(e => e.Id == id);
        }
    }
}
