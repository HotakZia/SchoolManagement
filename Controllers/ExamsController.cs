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
        [HttpPost]
        public async Task<IActionResult> tackAction(Guid? ScheduleId,string Comment)
        {
            try
            {
                Guid userId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "userId").Value.ToString());
                string userRole = User.Claims.Where(x => x.Type == "Role").Select(x => x.Value).FirstOrDefault();
                //var approver = db.Teachers.Where(x => x.TeacherId == Guid.Empty).FirstOrDefault();
                var list = db.Exams.Where(x => x.SubJectId == ScheduleId).ToList();
                foreach (var item in list)
                {


                    if (item.TeacherApprover == null && (User.Claims.Where(x => x.Value == "Teacher").Select(x => x.Value).FirstOrDefault() == "Teacher" || userRole == "Admin"))
                    {
                        item.TeacherApprover = userId;
                        item.TeacherApprovalTime = DateTime.Now;
                        item.TeacherApproverName = User.Claims.FirstOrDefault(x => x.Type == "UserName").Value;
                        item.TeacherApprovalComment = Comment;
                        item.Status = false;
                    }
                    else if (item.DeanApprover == null && (User.Claims.Where(x => x.Value == "Dean").Select(x => x.Value).FirstOrDefault() == "Dean" || userRole == "Admin"))
                    {
                        item.DeanApprover = userId;
                        item.DeanApprovalTime = DateTime.Now;
                        item.DeanApproverName = User.Claims.FirstOrDefault(x => x.Type == "UserName").Value;
                        item.DeanApprovalComment = Comment;
                        item.Status = true;
                    }
                    else if (item.FinalApprover == null && (User.Claims.Where(x => x.Value == "Final").Select(x => x.Value).FirstOrDefault() == "Final" || userRole == "Admin"))
                    {
                        item.FinalApprover = userId;
                        item.FinalApprovalTime = DateTime.Now;
                        item.FinalApproverName = User.Claims.FirstOrDefault(x => x.Type == "UserName").Value;
                        item.FinalApprovalComment = Comment;
                        item.Status = true;
                    }
                    db.Exams.Update(item);
                }
                db.SaveChanges();

                showMessageString = new
                {
                    status = "true",
                    message = "Exam sheet has been approved.",
                    Id=ScheduleId

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

                              DeanApproverId = Exam.DeanApprover,
                              TeacherApproverId = Exam.TeacherApprover,
                              FinalApproverId=Exam.FinalApprover,

                              DeanApproverComment=Exam.DeanApprovalComment,
                              TeacherApproverComment = Exam.TeacherApprovalComment,
                              FinalApproverComment = Exam.FinalApprovalComment,

                              TeacherApprovalTime=Exam.TeacherApprovalTime,
                              FinalApprovalTime=Exam.FinalApprovalTime,
                              DearnApprovalTime=Exam.DeanApprovalTime,
                           
                              
                              StudentId = Exam.StudentId,
                           
                             
                              SecondExam = Exam.SecondExam,
                              FirstExam = Exam.FirstExam,
                              Result = Exam.Result,
                              TeacherId = Exam.TeacherId,
                      
                              HomeActivity = Exam.HomeActivity,

                          })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
            return PartialView("_index", list);
        }
        public async Task<IActionResult> Index(Guid? SubjectId,Guid? StudentId, Guid? ClassId,  Guid? TeacherId, int Year = 0)
        {
           
            IList<Models.Entities.Exam> list = new List<Models.Entities.Exam>();
            if (SubjectId == null && StudentId == null && ClassId == null && TeacherId == null && Year == 0)
            {
                return View(list);
            }
                // Initialize a base query
                var query = db.Exams.AsQueryable();

            // Add conditions dynamically before executing the query
        
            if (SubjectId != null && StudentId != null && ClassId != null && TeacherId != null && Year == 0)
            {
                // All filters present
                query = query.Where(x => x.SubJectId == SubjectId &&
                                         x.StudentId == StudentId &&
                                         x.ClassId == ClassId &&
                                         x.TeacherId == TeacherId &&
                                         x.Year == Year);
            }
            else if (SubjectId != null && StudentId != null && ClassId != null && TeacherId != null)
            {
                query = query.Where(x => x.SubJectId == SubjectId &&
                                         x.StudentId == StudentId &&
                                         x.ClassId == ClassId &&
                                         x.TeacherId == TeacherId);
            }
            else if (SubjectId != null && StudentId != null && TeacherId != null && Year == 0)
            {
                query = query.Where(x => x.SubJectId == SubjectId &&
                                         x.StudentId == StudentId &&
                                         x.TeacherId == TeacherId &&
                                         x.Year == Year);
            }
            else if (SubjectId != null && ClassId != null && TeacherId != null && Year == 0)
            {
                query = query.Where(x => x.SubJectId == SubjectId &&
                                         x.ClassId == ClassId &&
                                         x.TeacherId == TeacherId &&
                                         x.Year == Year);
            }
            else if (StudentId != null && ClassId != null && TeacherId != null && Year == 0)
            {
                query = query.Where(x => x.StudentId == StudentId &&
                                         x.ClassId == ClassId &&
                                         x.TeacherId == TeacherId &&
                                         x.Year == Year);
            }
            else if (SubjectId != null && StudentId != null)
            {
                query = query.Where(x => x.SubJectId == SubjectId && x.StudentId == StudentId);
            }
            else if (SubjectId != null && ClassId != null)
            {
                query = query.Where(x => x.SubJectId == SubjectId && x.ClassId == ClassId);
            }
            else if (StudentId != null && ClassId != null)
            {
                query = query.Where(x => x.StudentId == StudentId && x.ClassId == ClassId);
            }
            else if (TeacherId != null && Year == 0)
            {
                query = query.Where(x => x.TeacherId == TeacherId && x.Year == Year);
            }
            else if (SubjectId != null)
            {
                query = query.Where(x => x.SubJectId == SubjectId);
            }
            else if (StudentId != null)
            {
                query = query.Where(x => x.StudentId == StudentId);
            }
            else if (ClassId != null)
            {
                query = query.Where(x => x.ClassId == ClassId);
            }
            else if (TeacherId != null)
            {
                query = query.Where(x => x.TeacherId == TeacherId);
            }
            else if (Year == 0)
            {
                query = query.Where(x => x.Year == Year);
            }

            // Perform the join and projection
            list = await (from Exam in query
                           join Schulde in db.Schedules on Exam.SubJectId equals Schulde.Id
                           //join class_  in db.Classes on Schulde.ClassId equals class_.Id
                           join teacher in db.Teachers on Exam.TeacherId equals teacher.TeacherId
                           join student in db.Students on Exam.StudentId equals student.StudentId
                           //where Exam.StudentId == StudentId && Exam.SubJectId == SubjectId && Exam.Year == DateTime.Now.Year && Exam.ClassId == ClassId
                           select new Models.Entities.Exam
                           {

                               ClassId = Exam.ClassId,
                               Attachment = Exam.Attachment,
                               Status = Exam.Status,
                               Comment = Exam.Comment,
                               CreatedBy = Exam.CreatedBy,
                               ModifiedBy = Exam.ModifiedBy,
                               ModifiedDate = Exam.ModifiedDate,
                               SubjectName = Schulde.Subject,
                              
                               //SubJectId = Schulde.si.SubjectId,
                               CreatedDate = Exam.CreatedDate,
                               Id = Exam.Id,
                               SubJectId=Schulde.Id,
                               StudentName = student.FirstName + " " + student.LastName,
                               Number = Exam.Number,
                               TeacherName = teacher.FirstName + " " + teacher.LastName,
                               Year = Exam.Year,
                               Attendance = Exam.Attendance,
                               ClassActivity = Exam.ClassActivity,
                               StudentId = Exam.StudentId,
                             
                               SecondExam = Exam.SecondExam,
                               FirstExam = Exam.FirstExam,
                               Result = Exam.Result,
                               TeacherId = Exam.TeacherId,
                          
                               HomeActivity = Exam.HomeActivity,




                               DeanApproverId = Exam.DeanApprover,
                               TeacherApproverId = Exam.TeacherApprover,
                               FinalApproverId = Exam.FinalApprover,

                               DeanApproverComment = Exam.DeanApprovalComment,
                               TeacherApproverComment = Exam.TeacherApprovalComment,
                               FinalApproverComment = Exam.FinalApprovalComment,

                               TeacherApprovalTime = Exam.TeacherApprovalTime,
                               FinalApprovalTime = Exam.FinalApprovalTime,
                               DearnApprovalTime = Exam.DeanApprovalTime,

                               DeanApproverName=Exam.DeanApproverName,
                               FinalApproverName=Exam.FinalApproverName,
                               TeacherApproverName=Exam.TeacherApproverName
                           }).ToListAsync();

            // Return the result
            return PartialView("_index", list);


          

        }

        // GET: Exams/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           var list = await (from Exam in db.Exams
                              //join Schulde in db.Schedules on Exam.SubJectId equals Schulde.Id
                          //join Subject in db.Subjects on Exam.SubJectId equals Subject.Id
                          //join class_  in db.Classes on Schulde.ClassId equals class_.Id
                          //join teacher in db.Teachers on Subject.TeacherId equals teacher.TeacherId
                          join student in db.Students on Exam.StudentId equals student.StudentId
                          where Exam.SubJectId==id
                          select new Models.Entities.Exam
                          {

                              //ClassId = Schulde.ClassId,
                              Attachment = Exam.Attachment,
                              Status = Exam.Status,
                              Comment = Exam.Comment,
                              CreatedBy = Exam.CreatedBy,
                              ModifiedBy = Exam.ModifiedBy,
                              ModifiedDate = Exam.ModifiedDate,
                              //SubjectName = Subject.SubjectName,
                              //ClassName = class_.Name,
                              //SubJectId = Schulde.SubjectId,
                              CreatedDate = Exam.CreatedDate,
                              Id = Exam.Id,
                              StudentName = student.FatherName + " " + student.LastName+"/"+student.RoleNumber,
                              Number = Exam.Number,
                              //TeacherName = teacher.FirstName + " " + teacher.LastName,
                              Year = Exam.Year,
                              Attendance = Exam.Attendance,
                              ClassActivity = Exam.ClassActivity,

                              DeanApproverId = Exam.DeanApprover,
                              TeacherApproverId = Exam.TeacherApprover,
                              FinalApproverId = Exam.FinalApprover,

                              DeanApproverComment = Exam.DeanApprovalComment,
                              TeacherApproverComment = Exam.TeacherApprovalComment,
                              FinalApproverComment = Exam.FinalApprovalComment,

                              TeacherApprovalTime = Exam.TeacherApprovalTime,
                              FinalApprovalTime = Exam.FinalApprovalTime,
                              DearnApprovalTime = Exam.DeanApprovalTime,

                              TeacherApproverName=Exam.TeacherApproverName,
                              DeanApproverName=Exam.DeanApproverName,
                              FinalApproverName=Exam.FinalApproverName,
                              ClassId=Exam.ClassId,
                              


                              StudentId = Exam.StudentId,


                              SecondExam = Exam.SecondExam,
                              FirstExam = Exam.FirstExam,
                              Result = Exam.Result,
                              TeacherId = Exam.TeacherId,

                              HomeActivity = Exam.HomeActivity,

                          }).OrderByDescending(x => x.CreatedDate).ToListAsync();

            //var exam = await db.Exams.Where(x => x.SubJectId == id).ToListAsync();

            
            if (list == null)
            {
                return NotFound();
            }
            ViewBag.ScheduleId = id;

            return View(list);
        }

        // GET: Exams/Create
        public IActionResult Create(Guid? ScheduleId,Guid? ClassId)
        {
            try
            {
                var examList = new List<Exam>();
                if (ScheduleId != null)
                {
                    //var Subject = db.TimeTables.Where(x => x.Id == ScheduleId).FirstOrDefault();
                    var Assignee = db.Schedules.Where(x => x.Id == ScheduleId).FirstOrDefault();
                    var Students_ = db.Students.Where(x => x.ClassId == ClassId).ToList();
                    var CurrentExam = db.Exams.Where(x => x.SubJectId == Assignee.Id && x.ClassId == ClassId).ToList();
                    ViewBag.Subject = Assignee.Subject;

                    foreach (var stu in Students_)
                    {
                        examList.Add(new Exam
                        {
                            Result = stu.FirstName + " " + stu.LastName + " " + stu.RoleNumber,
                            StudentId = stu.StudentId,
                            SubJectId = Assignee.Id,
                            TeacherId = Assignee.TeacherId,
                            ClassId =ClassId,
                            Year = Assignee.Year,
                        });




                    }
                    foreach (var item in CurrentExam)
                    {
                        foreach (var item2 in examList)
                        {
                            if (item.StudentId == item2.StudentId)
                            {

                                item2.FirstExam = item.FirstExam;
                                item2.SecondExam = item.SecondExam;
                                item2.ClassActivity = item.ClassActivity;
                                item2.HomeActivity = item.HomeActivity;
                                item2.Attendance = item.Attendance;
                                item2.Comment = item.Comment;
                                item2.Status = item.Status;
                            }
                        }
                    }


                    return View(examList);
                }
                return View(examList);
            }
            catch (Exception ex)
            {

                throw;
            }
           
          
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
                Guid? Id = Guid.Empty;

                if (ModelState.IsValid)

                {
                    if (exam.FirstOrDefault().Status==true)
                    {
                        showMessageString = new
                        {
                            status = "false",
                            message = "the submited list can't be updated!",
                         
                        };
                    }
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

                        Id = item.SubJectId;
                        item.Id = Guid.NewGuid();
                        item.CreatedDate = DateTime.Now;
                        //item.Status = true;
                
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
                        message = "Exam sheet has been submited.",
                        Id=Id,
                    };
                        return Json(showMessageString);
                    //return RedirectToAction(nameof(Index));
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
