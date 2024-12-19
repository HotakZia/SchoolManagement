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
    public class ExamsController : BaseController
    {
        //private readonly School_dbContext _context;

        //public ExamsController(School_dbContext context)
        //{
        //    _context = context;
        //}

        // GET: Exams
        [HttpPost]
        public async Task<IActionResult> getExamByStudentName(string term)
        {


            IList<Models.Entities.Exam> list = new List<Models.Entities.Exam>();
         
            list = await (from Exam in db.Exams
                              //join Schulde in db.Schedules on Exam.SubJectId equals Schulde.Id
                          join Subject in db.Subjects on Exam.SubJectId equals Subject.Id
                          //join class_  in db.Classes on Schulde.ClassId equals class_.Id
                          //join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                          join student in db.Students on Exam.StudentId equals student.StudentId
                           where student.FirstName.StartsWith(term)/* &&Exam.Year==DateTime.Now.Year*/
                          select new Models.Entities.Exam
                          {

                              //ClassId = Schulde.ClassId,
                              Attachment = Exam.Attachment,
                              Status = Exam.Status,
                              Comment = Exam.Comment,
                              CreatedBy = Exam.CreatedBy,
                              ModifiedBy = Exam.ModifiedBy,
                              ModifiedDate = Exam.ModifiedDate,
                              SubjectName = Subject.SubjectName,
                              //ClassName = class_.Name,
                              //SubJectId = Schulde.SubjectId,
                              CreatedDate = Exam.CreatedDate,
                              Id = Exam.Id,
                              StudentName = student.FatherName + " " + student.LastName,
                              Number = Exam.Number,
                              //TeacherName = teacher.FirstName + " " + teacher.LastName,
                              Year = Exam.Year,
                              Attendance = Exam.Attendance,
                              ClassActivity = Exam.ClassActivity,
                              FirstApproval = Exam.FirstApproval,
                              StudentId = Exam.StudentId,
                              SecondApproval = Exam.SecondApproval,
                              SecondApprovalTime = Exam.SecondApprovalTime,
                              SecondExam = Exam.SecondExam,
                              FirstExam = Exam.FirstExam,
                              Result = Exam.Result,
                              TeacherId = Exam.TeacherId,
                              ThiredApproval = Exam.ThiredApproval,
                              FirstApprovalTime = Exam.FirstApprovalTime,
                              ThiredApprovalTime = Exam.ThiredApprovalTime,
                              HomeActivity = Exam.HomeActivity,

                          })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
            return PartialView("_index", list);
        }
        public async Task<IActionResult> Index(Guid? SubjectId,Guid? StudentId)
        {
            ViewBag.SubjectId = new SelectList(db.Subjects.ToList(), "Id", "SubjectName");

            IList<Models.Entities.Exam> list = new List<Models.Entities.Exam>();
            if (SubjectId == null && StudentId == null)
            {
                return View(list);
            }
            else if (StudentId != null && SubjectId != null)
            {
                list = await (from Exam in db.Exams
                                  //join Schulde in db.Schedules on Exam.SubJectId equals Schulde.Id
                              join Subject in db.Subjects on Exam.SubJectId equals Subject.Id
                              //join class_  in db.Classes on Schulde.ClassId equals class_.Id
                              //join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                              join student in db.Students on Exam.StudentId equals student.StudentId
                              where Exam.StudentId == StudentId && Exam.SubJectId == SubjectId/* &&Exam.Year==DateTime.Now.Year*/
                              select new Models.Entities.Exam
                              {

                                  //ClassId = Schulde.ClassId,
                                  Attachment = Exam.Attachment,
                                  Status = Exam.Status,
                                  Comment = Exam.Comment,
                                  CreatedBy = Exam.CreatedBy,
                                  ModifiedBy = Exam.ModifiedBy,
                                  ModifiedDate = Exam.ModifiedDate,
                                  SubjectName = Subject.SubjectName,
                                  //ClassName = class_.Name,
                                  //SubJectId = Schulde.SubjectId,
                                  CreatedDate = Exam.CreatedDate,
                                  Id = Exam.Id,
                                  StudentName = student.FirstName + " " + student.LastName,
                                  Number = Exam.Number,
                                  //TeacherName = teacher.FirstName + " " + teacher.LastName,
                                  Year = Exam.Year,
                                  Attendance = Exam.Attendance,
                                  ClassActivity = Exam.ClassActivity,
                                  FirstApproval = Exam.FirstApproval,
                                  StudentId = Exam.StudentId,
                                  SecondApproval = Exam.SecondApproval,
                                  SecondApprovalTime = Exam.SecondApprovalTime,
                                  SecondExam = Exam.SecondExam,
                                  FirstExam = Exam.FirstExam,
                                  Result = Exam.Result,
                                  TeacherId = Exam.TeacherId,
                                  ThiredApproval = Exam.ThiredApproval,
                                  FirstApprovalTime = Exam.FirstApprovalTime,
                                  ThiredApprovalTime = Exam.ThiredApprovalTime,
                                  HomeActivity = Exam.HomeActivity,

                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
                return PartialView("_index", list);
            }
            else if (StudentId != null)
            {
                list = await (from Exam in db.Exams
                                  //join Schulde in db.Schedules on Exam.SubJectId equals Schulde.Id
                              join Subject in db.Subjects on Exam.SubJectId equals Subject.Id
                              //join class_  in db.Classes on Schulde.ClassId equals class_.Id
                              //join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                              join student in db.Students on Exam.StudentId equals student.StudentId
                              where  Exam.StudentId == StudentId/* &&Exam.Year==DateTime.Now.Year*/
                              select new Models.Entities.Exam
                              {

                                  //ClassId = Schulde.ClassId,
                                  Attachment = Exam.Attachment,
                                  Status = Exam.Status,
                                  Comment = Exam.Comment,
                                  CreatedBy = Exam.CreatedBy,
                                  ModifiedBy = Exam.ModifiedBy,
                                  ModifiedDate = Exam.ModifiedDate,
                                  SubjectName = Subject.SubjectName,
                                  //ClassName = class_.Name,
                                  //SubJectId = Schulde.SubjectId,
                                  CreatedDate = Exam.CreatedDate,
                                  Id = Exam.Id,
                                  StudentName = student.FirstName + " " + student.LastName,
                                  Number = Exam.Number,
                                  //TeacherName = teacher.FirstName + " " + teacher.LastName,
                                  Year = Exam.Year,
                                  Attendance = Exam.Attendance,
                                  ClassActivity = Exam.ClassActivity,
                                  FirstApproval = Exam.FirstApproval,
                                  StudentId = Exam.StudentId,
                                  SecondApproval = Exam.SecondApproval,
                                  SecondApprovalTime = Exam.SecondApprovalTime,
                                  SecondExam = Exam.SecondExam,
                                  FirstExam = Exam.FirstExam,
                                  Result = Exam.Result,
                                  TeacherId = Exam.TeacherId,
                                  ThiredApproval = Exam.ThiredApproval,
                                  FirstApprovalTime = Exam.FirstApprovalTime,
                                  ThiredApprovalTime = Exam.ThiredApprovalTime,
                                  HomeActivity = Exam.HomeActivity,

                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
                return PartialView("_index", list);
            }
            else if (SubjectId != null)
            {
                list = await (from Exam in db.Exams
                                  //join Schulde in db.Schedules on Exam.SubJectId equals Schulde.Id
                              join Subject in db.Subjects on Exam.SubJectId equals Subject.Id
                              //join class_  in db.Classes on Schulde.ClassId equals class_.Id
                              //join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                              join student in db.Students on Exam.StudentId equals student.StudentId
                              where Exam.SubJectId == SubjectId/* &&Exam.Year==DateTime.Now.Year*/
                              select new Models.Entities.Exam
                              {

                                  //ClassId = Schulde.ClassId,
                                  Attachment = Exam.Attachment,
                                  Status = Exam.Status,
                                  Comment = Exam.Comment,
                                  CreatedBy = Exam.CreatedBy,
                                  ModifiedBy = Exam.ModifiedBy,
                                  ModifiedDate = Exam.ModifiedDate,
                                  SubjectName = Subject.SubjectName,
                                  //ClassName = class_.Name,
                                  //SubJectId = Schulde.SubjectId,
                                  CreatedDate = Exam.CreatedDate,
                                  Id = Exam.Id,
                                  StudentName = student.FirstName + " " + student.LastName,
                                  Number = Exam.Number,
                                  //TeacherName = teacher.FirstName + " " + teacher.LastName,
                                  Year = Exam.Year,
                                  Attendance = Exam.Attendance,
                                  ClassActivity = Exam.ClassActivity,
                                  FirstApproval = Exam.FirstApproval,
                                  StudentId = Exam.StudentId,
                                  SecondApproval = Exam.SecondApproval,
                                  SecondApprovalTime = Exam.SecondApprovalTime,
                                  SecondExam = Exam.SecondExam,
                                  FirstExam = Exam.FirstExam,
                                  Result = Exam.Result,
                                  TeacherId = Exam.TeacherId,
                                  ThiredApproval = Exam.ThiredApproval,
                                  FirstApprovalTime = Exam.FirstApprovalTime,
                                  ThiredApprovalTime = Exam.ThiredApprovalTime,
                                  HomeActivity = Exam.HomeActivity,

                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
                return PartialView("_index", list);
            }
          
            else 
            {
                list = await (from Exam in db.Exams
                                  //join Schulde in db.Schedules on Exam.SubJectId equals Schulde.Id
                              join Subject in db.Subjects on Exam.SubJectId equals Subject.Id
                              //join class_  in db.Classes on Schulde.ClassId equals class_.Id
                              //join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                              join student in db.Students on Exam.StudentId equals student.StudentId
                              where Exam.Year==DateTime.Now.Year
                              select new Models.Entities.Exam
                              {

                                  //ClassId = Schulde.ClassId,
                                  Attachment = Exam.Attachment,
                                  Status = Exam.Status,
                                  Comment = Exam.Comment,
                                  CreatedBy = Exam.CreatedBy,
                                  ModifiedBy = Exam.ModifiedBy,
                                  ModifiedDate = Exam.ModifiedDate,
                                  SubjectName = Subject.SubjectName,
                                  //ClassName = class_.Name,
                                  //SubJectId = Schulde.SubjectId,
                                  CreatedDate = Exam.CreatedDate,
                                  Id = Exam.Id,
                                  StudentName = student.FirstName + " " + student.LastName,
                                  Number = Exam.Number,
                                  //TeacherName = teacher.FirstName + " " + teacher.LastName,
                                  Year = Exam.Year,
                                  Attendance = Exam.Attendance,
                                  ClassActivity = Exam.ClassActivity,
                                  FirstApproval = Exam.FirstApproval,
                                  StudentId = Exam.StudentId,
                                  SecondApproval = Exam.SecondApproval,
                                  SecondApprovalTime = Exam.SecondApprovalTime,
                                  SecondExam = Exam.SecondExam,
                                  FirstExam = Exam.FirstExam,
                                  Result = Exam.Result,
                                  TeacherId = Exam.TeacherId,
                                  ThiredApproval = Exam.ThiredApproval,
                                  FirstApprovalTime = Exam.FirstApprovalTime,
                                  ThiredApprovalTime = Exam.ThiredApprovalTime,
                                  HomeActivity = Exam.HomeActivity,

                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
                return PartialView("_index", list);
            }

            return View(await db.Exams.ToListAsync());
        }

        // GET: Exams/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await db.Exams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // GET: Exams/Create
        public IActionResult Create(Guid? ScheduleId)
        {
            var examList = new List<Exam>();
            if (ScheduleId != null)
            {
                var subject_= db.Schedules.Where(x => x.Id == ScheduleId).FirstOrDefault();
               var Students_ = db.Students.Where(x => x.ClassId == subject_.ClassId).ToList();
                var CurrentExam = db.Exams.Where(x => x.SubJectId == ScheduleId&&x.ClassId==subject_.ClassId).ToList();
                ViewBag.Subject = subject_.Subject;
                foreach (var stu in Students_)
                {
                    examList.Add(new Exam{Result=stu.FirstName+" "+stu.LastName+" "+stu.RoleNumber,
                        StudentId=stu.StudentId,
                        SubJectId=subject_.Id,
                        TeacherId=subject_.TeacherId,
                        ClassId=subject_.ClassId,
                        Year=subject_.Year,
                    });
                    



                }
                foreach (var item in CurrentExam)
                {
                    foreach (var item2 in examList)
                    {
                        if (item.StudentId==item2.StudentId)
                        {
                          
                            item2.FirstExam=item.FirstExam;
                            item2.SecondExam = item.SecondExam;
                            item2.ClassActivity = item.ClassActivity;
                            item2.HomeActivity = item.HomeActivity;
                            item2.Attendance = item.Attendance;
                            item2.Comment = item.Comment;
                        }
                    }
                }
                
               
                return View(examList);
            }
            return View(examList);
          
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeacherId,Year,Id,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number,FirstExam,SecondExam,ClassActivity,HomeActivity,Attendance,ThiredApproval,SecondApproval,FirstApproval,SubJectId,StudentId,ThiredApprovalTime,SecondApprovalTime,FirstApprovalTime,Result,ClassId")] List<Exam> exam)
        {
            try
            {
                if (ModelState.IsValid)

                {
                    var oldList = db.Exams.Where(x => x.ClassId == exam.FirstOrDefault().ClassId&& x.SubJectId == exam.FirstOrDefault().SubJectId).ToList();
                    if (oldList.Count>=1)
                    {
                        foreach (var item in oldList)
                        {
                            db.Exams.Remove(item);

                        }
                      
                    }
        
                    foreach (var item in exam)
                    {


                        item.Id = Guid.NewGuid();
                        item.CreatedDate = DateTime.Now;
                        item.Status = true;

                        if (item.FirstExam+item.SecondExam+item.ClassActivity+item.HomeActivity+item.Attendance>=60)
                        {
                            item.Result = "Pass";
                        }
                        else
                        {
                            item.Result = "Fail";
                        }
                        db.Add(item);
                    }
                    await db.SaveChangesAsync();

                    showMessageString = new
                    {
                        status = "true",
                        message = "Exam sheet has been submited."

                    };
                        return Json(showMessageString);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

                showMessageString = new
                {
                    status = "false",
                    message = ex.InnerException.Message.ToString()

                };
                return Json(showMessageString);
            }
           
           
            return View(exam);
        }

        // GET: Exams/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await db.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TeacherId,Year,Id,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number,FirstExam,SecondExam,ClassActivity,HomeActivity,Attendance,ThiredApproval,SecondApproval,FirstApproval,SubJectId,StudentId,ThiredApprovalTime,SecondApprovalTime,FirstApprovalTime,Result")] Exam exam)
        {
            if (id != exam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(exam);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamExists(exam.Id))
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
            return View(exam);
        }

        // GET: Exams/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await db.Exams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var exam = await db.Exams.FindAsync(id);
            db.Exams.Remove(exam);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamExists(Guid id)
        {
            return db.Exams.Any(e => e.Id == id);
        }
    }
}
