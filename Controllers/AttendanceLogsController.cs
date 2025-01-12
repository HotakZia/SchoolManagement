using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models.db;

namespace SchoolManagement.Controllers
{
    public class AttendanceLogsController : BaseController
    {
        //private readonly School_dbContext _context;

        //public AttendanceLogsController(School_dbContext context)
        //{
        //    _context = context;
        //}

        // GET: AttendanceLogs
 
        public async Task<IActionResult> Index(Guid? ClassId, Guid? StudentId,DateTime?fromDate,DateTime? toDate)
        {
            //if (fromDate==null)
            //{
            //    fromDate = DateTime.Now.AddMonths(-1);
            //}
            //if (toDate==null)
            //{
            //    toDate = DateTime.Now;
            //}

            IList<Models.Entities.Attendance> list = new List<Models.Entities.Attendance>();
            if (ClassId == null && StudentId == null&&fromDate==null&&toDate==null)
            {
                return View(list);
            }
            else if (StudentId != null && ClassId != null && fromDate != null&&toDate!=null)
            {
                list = await (from attend in db.AttendanceLogs



                                  //join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                              join student in db.Students on attend.StudentId equals student.StudentId
                              join class_ in db.Classes on student.ClassId equals class_.Id
                              where attend.StudentId == StudentId && attend.ClassId == ClassId && attend.Date >= fromDate&&attend.Date<=toDate/* &&attend.Year==DateTime.Now.Year*/
                              select new Models.Entities.Attendance
                              {

                                  //ClassId = Schulde.ClassId,
                                  Attachment = attend.Attachment,
                                  Status = attend.Status,
                                  Comment = attend.Comment,
                                  CreatedBy = attend.CreatedBy,
                                  ModifiedBy = attend.ModifiedBy,
                                  ModifiedDate = attend.ModifiedDate,

                                  ClassName = class_.Name,

                                  CreatedDate = attend.CreatedDate,
                                  Id = attend.Id,
                                  StudentName = student.FirstName + " " + student.LastName,
                                  Number = attend.Number,
                                  //TeacherName = teacher.FirstName + " " + teacher.LastName,

                                  StudentId = attend.StudentId,

                                  TeacherId = attend.TeacherId,

                                  ClassId = attend.ClassId,
                                  Date = attend.Date,
                                  In = attend.In,
                                  Name = attend.Name,
                                  Out = attend.Out,
                                  TeacherName = student.FirstName

                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
                return PartialView("_index", list);
            }
            else if (StudentId != null && ClassId != null&&fromDate!=null)
            {
                list = await (from attend in db.AttendanceLogs
                                  
                             
                             
                              //join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                              join student in db.Students on attend.StudentId equals student.StudentId
                              join class_ in db.Classes on student.ClassId equals class_.Id
                              where attend.StudentId == StudentId && attend.ClassId == ClassId&& attend.Date>=fromDate/* &&attend.Year==DateTime.Now.Year*/
                              select new Models.Entities.Attendance
                              {

                                  //ClassId = Schulde.ClassId,
                                  Attachment = attend.Attachment,
                                  Status = attend.Status,
                                  Comment = attend.Comment,
                                  CreatedBy = attend.CreatedBy,
                                  ModifiedBy = attend.ModifiedBy,
                                  ModifiedDate = attend.ModifiedDate,
                                
                                  ClassName = class_.Name,
                                  
                                  CreatedDate = attend.CreatedDate,
                                  Id = attend.Id,
                                  StudentName = student.FirstName + " " + student.LastName,
                                  Number = attend.Number,
                                  //TeacherName = teacher.FirstName + " " + teacher.LastName,
                                 
                                  StudentId = attend.StudentId,
                                 
                                  TeacherId = attend.TeacherId,
                               
                                  ClassId=attend.ClassId,
                                  Date=attend.Date,
                                  In=attend.In,
                                  Name=attend.Name,
                                  Out=attend.Out,
                                  TeacherName=student.FirstName

                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
                return PartialView("_index", list);
            }
            else if (StudentId != null && ClassId != null && toDate != null)
            {
                list = await (from attend in db.AttendanceLogs



                                  //join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                              join student in db.Students on attend.StudentId equals student.StudentId
                              join class_ in db.Classes on student.ClassId equals class_.Id
                              where attend.StudentId == StudentId && attend.ClassId == ClassId && attend.Date <= fromDate/* &&attend.Year==DateTime.Now.Year*/
                              select new Models.Entities.Attendance
                              {

                                  //ClassId = Schulde.ClassId,
                                  Attachment = attend.Attachment,
                                  Status = attend.Status,
                                  Comment = attend.Comment,
                                  CreatedBy = attend.CreatedBy,
                                  ModifiedBy = attend.ModifiedBy,
                                  ModifiedDate = attend.ModifiedDate,

                                  ClassName = class_.Name,

                                  CreatedDate = attend.CreatedDate,
                                  Id = attend.Id,
                                  StudentName = student.FirstName + " " + student.LastName,
                                  Number = attend.Number,
                                  //TeacherName = teacher.FirstName + " " + teacher.LastName,

                                  StudentId = attend.StudentId,

                                  TeacherId = attend.TeacherId,

                                  ClassId = attend.ClassId,
                                  Date = attend.Date,
                                  In = attend.In,
                                  Name = attend.Name,
                                  Out = attend.Out,
                                  TeacherName = student.FirstName

                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
                return PartialView("_index", list);
            }
            else if (StudentId!=null&& fromDate != null && toDate != null)
            {
                list = await (from attend in db.AttendanceLogs



                                  //join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                              join student in db.Students on attend.StudentId equals student.StudentId
                              join class_ in db.Classes on student.ClassId equals class_.Id
                              where attend.StudentId == StudentId&& attend.Date >= fromDate && attend.Date <= toDate/* &&attend.Year==DateTime.Now.Year*/
                              select new Models.Entities.Attendance
                              {

                                  //ClassId = Schulde.ClassId,
                                  Attachment = attend.Attachment,
                                  Status = attend.Status,
                                  Comment = attend.Comment,
                                  CreatedBy = attend.CreatedBy,
                                  ModifiedBy = attend.ModifiedBy,
                                  ModifiedDate = attend.ModifiedDate,

                                  ClassName = class_.Name,

                                  CreatedDate = attend.CreatedDate,
                                  Id = attend.Id,
                                  StudentName = student.FirstName + " " + student.LastName,
                                  Number = attend.Number,
                                  //TeacherName = teacher.FirstName + " " + teacher.LastName,

                                  StudentId = attend.StudentId,

                                  TeacherId = attend.TeacherId,

                                  ClassId = attend.ClassId,
                                  Date = attend.Date,
                                  In = attend.In,
                                  Name = attend.Name,
                                  Out = attend.Out,
                                  TeacherName = student.FirstName

                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
                return PartialView("_index", list);
            }
            else if ( ClassId != null && fromDate != null && toDate != null)
            {
                list = await (from attend in db.AttendanceLogs



                                  //join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                              join student in db.Students on attend.StudentId equals student.StudentId
                              join class_ in db.Classes on student.ClassId equals class_.Id
                              where  attend.ClassId == ClassId && attend.Date >= fromDate && attend.Date <= toDate/* &&attend.Year==DateTime.Now.Year*/
                              select new Models.Entities.Attendance
                              {

                                  //ClassId = Schulde.ClassId,
                                  Attachment = attend.Attachment,
                                  Status = attend.Status,
                                  Comment = attend.Comment,
                                  CreatedBy = attend.CreatedBy,
                                  ModifiedBy = attend.ModifiedBy,
                                  ModifiedDate = attend.ModifiedDate,

                                  ClassName = class_.Name,

                                  CreatedDate = attend.CreatedDate,
                                  Id = attend.Id,
                                  StudentName = student.FirstName + " " + student.LastName,
                                  Number = attend.Number,
                                  //TeacherName = teacher.FirstName + " " + teacher.LastName,

                                  StudentId = attend.StudentId,

                                  TeacherId = attend.TeacherId,

                                  ClassId = attend.ClassId,
                                  Date = attend.Date,
                                  In = attend.In,
                                  Name = attend.Name,
                                  Out = attend.Out,
                                  TeacherName = student.FirstName

                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
                return PartialView("_index", list);
            }
            else if ( fromDate != null && toDate != null)
            {
                list = await (from attend in db.AttendanceLogs



                                  //join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                              join student in db.Students on attend.StudentId equals student.StudentId
                              join class_ in db.Classes on student.ClassId equals class_.Id
                              where  attend.Date >= fromDate && attend.Date <= toDate/* &&attend.Year==DateTime.Now.Year*/
                              select new Models.Entities.Attendance
                              {

                                  //ClassId = Schulde.ClassId,
                                  Attachment = attend.Attachment,
                                  Status = attend.Status,
                                  Comment = attend.Comment,
                                  CreatedBy = attend.CreatedBy,
                                  ModifiedBy = attend.ModifiedBy,
                                  ModifiedDate = attend.ModifiedDate,

                                  ClassName = class_.Name,

                                  CreatedDate = attend.CreatedDate,
                                  Id = attend.Id,
                                  StudentName = student.FirstName + " " + student.LastName,
                                  Number = attend.Number,
                                  //TeacherName = teacher.FirstName + " " + teacher.LastName,

                                  StudentId = attend.StudentId,

                                  TeacherId = attend.TeacherId,

                                  ClassId = attend.ClassId,
                                  Date = attend.Date,
                                  In = attend.In,
                                  Name = attend.Name,
                                  Out = attend.Out,
                                  TeacherName = student.FirstName

                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
                return PartialView("_index", list);
            }
            else if (StudentId != null)
            {
                list = await (from attend in db.AttendanceLogs



                                  //join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                              join student in db.Students on attend.StudentId equals student.StudentId
                              join class_ in db.Classes on student.ClassId equals class_.Id
                              where attend.StudentId == StudentId /* &&attend.Year==DateTime.Now.Year*/
                              select new Models.Entities.Attendance
                              {
// ClassId = Schulde.ClassId,
                                  Attachment = attend.Attachment,
                                  Status = attend.Status,
                                  Comment = attend.Comment,
                                  CreatedBy = attend.CreatedBy,
                                  ModifiedBy = attend.ModifiedBy,
                                  ModifiedDate = attend.ModifiedDate,

                                  ClassName = class_.Name,

                                  CreatedDate = attend.CreatedDate,
                                  Id = attend.Id,
                                  StudentName = student.FirstName + " " + student.LastName,
                                  Number = attend.Number,
                                  //TeacherName = teacher.FirstName + " " + teacher.LastName,

                                  StudentId = attend.StudentId,

                                  TeacherId = attend.TeacherId,

                                  ClassId = attend.ClassId,
                                  Date = attend.Date,
                                  In = attend.In,
                                  Name = attend.Name,
                                  Out = attend.Out,
                                  TeacherName = student.FirstName

                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
                return PartialView("_index", list);
            }
            else if (ClassId != null)
            {
                list = await (from attend in db.AttendanceLogs



                                  //join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                              join student in db.Students on attend.StudentId equals student.StudentId
                              join class_ in db.Classes on student.ClassId equals class_.Id
                              where attend.ClassId == ClassId/* &&attend.Year==DateTime.Now.Year*/
                              select new Models.Entities.Attendance
                              {

                               //ClassId = Schulde.ClassId,
                                  Attachment = attend.Attachment,
                                  Status = attend.Status,
                                  Comment = attend.Comment,
                                  CreatedBy = attend.CreatedBy,
                                  ModifiedBy = attend.ModifiedBy,
                                  ModifiedDate = attend.ModifiedDate,

                                  ClassName = class_.Name,

                                  CreatedDate = attend.CreatedDate,
                                  Id = attend.Id,
                                  StudentName = student.FirstName + " " + student.LastName,
                                  Number = attend.Number,
                                  //TeacherName = teacher.FirstName + " " + teacher.LastName,

                                  StudentId = attend.StudentId,

                                  TeacherId = attend.TeacherId,

                                  ClassId = attend.ClassId,
                                  Date = attend.Date,
                                  In = attend.In,
                                  Name = attend.Name,
                                  Out = attend.Out,
                                  TeacherName = student.FirstName


                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
                return PartialView("_index", list);
            }
            else if (fromDate != null)
            {
                list = await (from attend in db.AttendanceLogs



                                  //join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                              join student in db.Students on attend.StudentId equals student.StudentId
                              join class_ in db.Classes on student.ClassId equals class_.Id
                              where attend.Date>=fromDate/* &&attend.Year==DateTime.Now.Year*/
                              select new Models.Entities.Attendance
                              {

                                  //ClassId = Schulde.ClassId,
                                  Attachment = attend.Attachment,
                                  Status = attend.Status,
                                  Comment = attend.Comment,
                                  CreatedBy = attend.CreatedBy,
                                  ModifiedBy = attend.ModifiedBy,
                                  ModifiedDate = attend.ModifiedDate,

                                  ClassName = class_.Name,

                                  CreatedDate = attend.CreatedDate,
                                  Id = attend.Id,
                                  StudentName = student.FirstName + " " + student.LastName,
                                  Number = attend.Number,
                                  //TeacherName = teacher.FirstName + " " + teacher.LastName,

                                  StudentId = attend.StudentId,

                                  TeacherId = attend.TeacherId,

                                  ClassId = attend.ClassId,
                                  Date = attend.Date,
                                  In = attend.In,
                                  Name = attend.Name,
                                  Out = attend.Out,
                                  TeacherName = student.FirstName


                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
                return PartialView("_index", list);
            }
            else if (toDate != null)
            {
                list = await (from attend in db.AttendanceLogs



                                  //join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                              join student in db.Students on attend.StudentId equals student.StudentId
                              join class_ in db.Classes on student.ClassId equals class_.Id
                              where attend.Date <=toDate/* &&attend.Year==DateTime.Now.Year*/
                              select new Models.Entities.Attendance
                              {

                                  //ClassId = Schulde.ClassId,
                                  Attachment = attend.Attachment,
                                  Status = attend.Status,
                                  Comment = attend.Comment,
                                  CreatedBy = attend.CreatedBy,
                                  ModifiedBy = attend.ModifiedBy,
                                  ModifiedDate = attend.ModifiedDate,

                                  ClassName = class_.Name,

                                  CreatedDate = attend.CreatedDate,
                                  Id = attend.Id,
                                  StudentName = student.FirstName + " " + student.LastName,
                                  Number = attend.Number,
                                  //TeacherName = teacher.FirstName + " " + teacher.LastName,

                                  StudentId = attend.StudentId,

                                  TeacherId = attend.TeacherId,

                                  ClassId = attend.ClassId,
                                  Date = attend.Date,
                                  In = attend.In,
                                  Name = attend.Name,
                                  Out = attend.Out,
                                  TeacherName = student.FirstName


                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
                return PartialView("_index", list);
            }

            else
            {
                list = await (from attend in db.AttendanceLogs



                                  //join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                              join student in db.Students on attend.StudentId equals student.StudentId
                              join class_ in db.Classes on student.ClassId equals class_.Id
                              where attend.Date==DateTime.Now/* &&attend.Year==DateTime.Now.Year*/
                              select new Models.Entities.Attendance
                              {

                                  // ClassId = Schulde.ClassId,
                                  Attachment = attend.Attachment,
                                  Status = attend.Status,
                                  Comment = attend.Comment,
                                  CreatedBy = attend.CreatedBy,
                                  ModifiedBy = attend.ModifiedBy,
                                  ModifiedDate = attend.ModifiedDate,

                                  ClassName = class_.Name,

                                  CreatedDate = attend.CreatedDate,
                                  Id = attend.Id,
                                  StudentName = student.FirstName + " " + student.LastName,
                                  Number = attend.Number,
                                  //TeacherName = teacher.FirstName + " " + teacher.LastName,

                                  StudentId = attend.StudentId,

                                  TeacherId = attend.TeacherId,

                                  ClassId = attend.ClassId,
                                  Date = attend.Date,
                                  In = attend.In,
                                  Name = attend.Name,
                                  Out = attend.Out,
                                  TeacherName = student.FirstName


                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
                return PartialView("_index", list);
            }

            return View(await db.Exams.ToListAsync());
        }

        // GET: AttendanceLogs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceLog = await db.AttendanceLogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendanceLog == null)
            {
                return NotFound();
            }

            return View(attendanceLog);
        }

        // GET: AttendanceLogs/Create
        public IActionResult Create( Guid? ClassId)
        {
            if (ClassId != null)
            {
                
                ViewBag.Students = db.Students.Where(x => x.ClassId == ClassId).ToList();


            }
            return View();
        }

        // POST: AttendanceLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,ClassId,Date,Status,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Number,In,Out,Name,TeacherId")] List< AttendanceLog> attendanceLog,List< IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    foreach (var item in attendanceLog)
                    {
                        var duplicate = db.AttendanceLogs.Where(x => x.StudentId == item.StudentId && x.Date == item.Date).FirstOrDefault();
                        if (duplicate != null)
                        {
                            showMessageString = new
                            {
                                status = "duplicate",
                                message = "dupplicate attendance"

                            };
                            return Json(showMessageString);
                        }



                        if (Image.Count()>=1)
                        {
                            foreach (var file in Image)
                            {
                                using (var memoryStream = new MemoryStream())
                                {

                                    file.CopyToAsync(memoryStream);
                                    Byte[] fileBytes = memoryStream.ToArray();
                                    int maxFileSizeInBytes = 1 * 1024 * 1024 / 2; // 10MB (adjust as needed)
                                    if (
                               file.ContentType.ToLower() != "image/jpg" &&
                               file.ContentType.ToLower() != "image/jpeg" &&
                               file.ContentType.ToLower() != "image/pjpeg" &&
                               file.ContentType.ToLower() != "image/gif" &&
                               file.ContentType.ToLower() != "image/x-png" &&
                               file.ContentType.ToLower() != "image/png" &&
                               file.ContentType.ToLower() != "image/svg"
                           )
                                    {

                                        showMessageString = new
                                        {
                                            status = "false",
                                            message = "Profile photo must be a JPEG, PNG or SVG format."
                                        };
                                        return Json(showMessageString);
                                    }
                                    if (file.Length > maxFileSizeInBytes)
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
                                        item.Attachment = fileBytes;

                                    }
                                }
                            }

                        }
                        item.Id = Guid.NewGuid();
                        item.CreatedDate = DateTime.Now;
                        item.Status = true;
                        db.Add(item);

                    }
                    await db.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    showMessageString = new
                    {
                        status = "true",
                        message = "attendanceLog has been assigned."

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
            showMessageString = new
            {
                status = "false",
                message = ModelState.Values.SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage)
    .ToList()

        };
            return Json(showMessageString);
        }

        // GET: AttendanceLogs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceLog = await db.AttendanceLogs.FindAsync(id);
            if (attendanceLog == null)
            {
                return NotFound();
            }
            return View(attendanceLog);
        }

        // POST: AttendanceLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,SudentId,Date,Status,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status1,Number,In,Out,Name,TeacherId")] AttendanceLog attendanceLog)
        {
            if (id != attendanceLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(attendanceLog);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceLogExists(attendanceLog.Id))
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
            return View(attendanceLog);
        }

        // GET: AttendanceLogs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendanceLog = await db.AttendanceLogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendanceLog == null)
            {
                return NotFound();
            }

            return View(attendanceLog);
        }

        // POST: AttendanceLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var attendanceLog = await db.AttendanceLogs.FindAsync(id);
            db.AttendanceLogs.Remove(attendanceLog);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceLogExists(Guid id)
        {
            return db.AttendanceLogs.Any(e => e.Id == id);
        }
    }
}
