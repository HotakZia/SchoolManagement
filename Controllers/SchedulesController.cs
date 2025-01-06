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

                    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> createTimeTable(List<TimeTable> timeTables)
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
            try
            {
                int number = 0;
                foreach (var item in timeTables)
                {
                    if (item.SubjectId != null)
                    {
                        var dupplicate = db.TimeTables.Where(x => x.ClassId == item.ClassId
                        && x.DayOfWeek == item.DayOfWeek
                        && x.HourOfDay == item.HourOfDay
                        && x.Status == true 
                        && x.SubjectId == item.SubjectId
                        &&x.Year==item.Year).FirstOrDefault();
                   
                        if (dupplicate != null)
                        {
                            //showMessageString = new
                            //{
                            //    status = "false",
                            //    message ="in "+ item.DayOfWeek +" "+ item.HourOfDay + " hour is duplicate record!"
                            //};
                            //return Json(showMessageString);
                            db.TimeTables.Update(dupplicate);
                            db.Entry(dupplicate).Property("Number").IsModified = false;
                        }
                        item.Id = Guid.NewGuid();
                        item.CreatedDate = DateTime.Now;
                        item.Status = true;
                        db.TimeTables.Add(item);
                        number++;
                    }
                    
                }
                db.SaveChanges();
                showMessageString = new
                {
                    status = "true",
                    message =number+" recods have been added"
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
            return Json(showMessageString);
        }
        [HttpPost]
        public async Task<IActionResult> getSubjectByName(string term)
        {

            var list = await (from Subject in db.Schedules


                              where Subject.Subject.StartsWith(term)

                              select new Models.Entities.Class_
                              {

                                  Id = Subject.Id,

                                  Name = Subject.Subject+" "+Subject.Shift +" "+ Subject.Year



                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
            return Json(list);
        }
        // GET: Schedules
        public async Task<IActionResult> Index(int grad)
        {
            var list = new List<Models.Entities.Schedual>();
          
                list = await (from Schedule in db.Schedules
                                  //join class_ in db.Classes on Schedule.ClassId equals class_.Id
                                  //join Subject in db.Subjects on Schedule.SubjectId equals Subject.Id
                              join teacher in db.Teachers on Schedule.TeacherId equals teacher.TeacherId
                              where Schedule.Status == true /*&&Schedule.Grad==grad*/

                              select new Models.Entities.Schedual
                              {

                                  Shift = Schedule.Shift,
                                  Attachment = Schedule.Attachment,
                                  Status = Schedule.Status,
                                  Comment = Schedule.Comment,
                                  CreatedBy = Schedule.CreatedBy,
                                  ModifiedBy = Schedule.ModifiedBy,
                                  ModifiedDate = Schedule.ModifiedDate,
                                  SubjecName = Schedule.Subject,
                                  // ClassName=class_.Name,

                                  Subject = Schedule.Subject,
                                  CreatedDate = Schedule.CreatedDate,
                                  Id = Schedule.Id,

                                  Number = Schedule.Number,
                                  Grad=Schedule.Grad,
                                  TeacherName = teacher.FirstName + " " + teacher.LastName,
                                  Year = Schedule.Year,



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

       
            var singleSchedule =  (from Schedule in db.Schedules
                              join teacher in db.Teachers on Schedule.TeacherId equals teacher.TeacherId
                              where Schedule.Id == id&&Schedule.Status==true/* &&Schedule.Year==DateTime.Now.Year*/

                              select new Models.Entities.Schedual
                              {

                                  Shift = Schedule.Shift,
                                  Attachment = Schedule.Attachment,

                                  Status = Schedule.Status,
                                  Grad=Schedule.Grad,
                                  Comment = Schedule.Comment,
                                  CreatedBy = Schedule.CreatedBy,

                                  ModifiedBy = Schedule.ModifiedBy,
                                  ModifiedDate = Schedule.ModifiedDate,
                                  SubjecName = Schedule.Subject,

                                  Subject = Schedule.Subject,
                                  CreatedDate = Schedule.CreatedDate,
                                  Id = Schedule.Id,

                                  Number = Schedule.Number,

                                  TeacherName = teacher.FirstName + " " + teacher.LastName,
                                  Year = Schedule.Year,
                                  


                              }).FirstOrDefault();
            if (singleSchedule == null)
            {
                return NotFound();
            }
            ViewBag.Subjec = singleSchedule;

            ViewBag.ClassId = new SelectList(db.Schedules.Where(x=>x.Grad==singleSchedule.Grad&&x.Status==true).ToList(), "Id", "Name");

            return View();
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            try
            {
                //ViewBag.SubjectId = new SelectList(db.Subjects.ToList(), "Id", "SubjectName");

                //ViewBag.ClassId = new SelectList(db.Classes.ToList(), "Id", "Name");


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
        public async Task<IActionResult> Create([Bind("Grad,TeacherId,Year,Shift,Id,Subject,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number")] Schedule schedule)
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
                var checkDuplicate = db.Schedules.Where(x => x.TeacherId == schedule.TeacherId&&x.Subject==schedule.Subject&&x.Year==schedule.Year&&x.Shift==schedule.Shift).FirstOrDefault();
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Grad,TeacherId,Year,Shift,Id,Subject,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number")] Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                showMessageString = new
                {
                    status = "false",
                    message = "modelstat is no valid"

                };
                return Json(showMessageString);
            }
                try
                {
                var checkDuplicate = db.Schedules.Where(x => x.TeacherId == schedule.TeacherId && x.Subject == schedule.Subject && x.Year == schedule.Year && x.Shift == schedule.Shift&&x.Id!=schedule.Id).FirstOrDefault();
                if (checkDuplicate != null)
                {
                    showMessageString = new
                    {
                        status = "duplicate",
                        message = "Dupplicate Schedual."

                    };
                    return Json(showMessageString);
                }
                schedule.ModifiedDate = DateTime.Now;
                    db.Update(schedule);
                    await db.SaveChangesAsync();
                showMessageString = new
                {
                    status = "true",
                    message = "TimeTable has been updated.",
                    Id=schedule.Id

                };
                return Json(showMessageString);
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
