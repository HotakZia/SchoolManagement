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
    public class SalariesController : BaseController
    {
        //private readonly School_dbContext _context;

        //public SalariesController(School_dbContext context)
        //{
        //    _context = context;
        //}

        // GET: Salaries
        public async Task<IActionResult> Index()
        {
            var list = (from salary in db.Salaries
                      
                        join teacher in db.Teachers on salary.TeacherId equals teacher.TeacherId
                        where salary.Status == true 

                        select new Models.Entities.Salary
                        {
                            Amount=salary.Amount,
                            PaidBy=salary.PaidBy,
                            Date=salary.Date,
                            Attachment=teacher.Attachment,
                            Comment=salary.Comment,
                            CreatedBy=salary.CreatedBy,
                            CreatedDate=salary.CreatedDate,
                            ModifiedBy=salary.ModifiedBy,
                            ModifiedDate=salary.ModifiedDate,
                            Number=salary.Number,
                            TeacherId=salary.TeacherId,
                            Type=salary.Type,
                            
                            Status = salary.Status,
                          file=salary.Attachment,
                            Id = salary.Id,
                            TeacherName = teacher.FirstName + " " + teacher.LastName,
                            Year = salary.Year,
                           
                         


                        })/*.OrderByDescending(x => x.CreatedDate)*/.ToList();
            return View(list);
        }
        public ActionResult Index(Guid? ClassId, DateTime date)
        {
            ViewBag.ClassId = new SelectList(db.Classes.ToList(), "Id", "Name");
            IList<Models.Entities.Student> list = new List<Models.Entities.Student>();
            if (ClassId == null)
            {
                return View(list);
            }
            if (date == null)
            {
                date = DateTime.Now;
            }
            list = (from student in db.Students
                        //join fees in db.Fees on student.StudentId equals fees.StudentId
                    where student.ClassId == ClassId

                    select new Models.Entities.Student
                    {

                        StudentId = student.StudentId,
                        Tazkira = student.Tazkira,
                        RoleNumber = student.RoleNumber,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        FatherName = student.FatherName,
                        Attachment = student.Attachment,
                        Contact = student.Contact,
                        Status = student.Status,
                        AdmissionDate = student.AdmissionDate,
                        GuardianName = student.GuardianName,
                        GuardianPhone = student.GuardianPhone,
                        AssignFeesCount = db.StudentPayments.Where(x => x.StudentId == student.StudentId).Count(),
                        PayFeesCount = db.Fees.Where(x => x.StudentId == student.StudentId && x.Date.Value.Year == date.Year && x.Date.Value.Month == date.Month).Count(),
               


                    })/*.OrderByDescending(x => x.CreatedDate)*/.ToList();
            return PartialView("_index", list);
        }

        // GET: Salaries/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await db.Salaries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // GET: Salaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeacherId,Amount,Type,Date,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number,Year,PaidBy")] Salary salary, IFormFile Image)
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
                if (Image != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {

                        Image.CopyToAsync(memoryStream);
                        Byte[] fileBytes = memoryStream.ToArray();
                        int maxFileSizeInBytes = 1 * 1024 * 1024 / 2; // 10MB (adjust as needed)
                        if (
                   Image.ContentType.ToLower() != "image/jpg" &&
                   Image.ContentType.ToLower() != "image/jpeg" &&
                   Image.ContentType.ToLower() != "image/pjpeg" &&
                   Image.ContentType.ToLower() != "image/gif" &&
                   Image.ContentType.ToLower() != "image/x-png" &&
                   Image.ContentType.ToLower() != "image/png" &&
                   Image.ContentType.ToLower() != "image/svg"
               )
                        {

                            showMessageString = new
                            {
                                status = "false",
                                message = "Profile photo must be a JPEG, PNG or SVG format."
                            };
                            return Json(showMessageString);
                        }
                        if (Image.Length > maxFileSizeInBytes)
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
                            salary.Attachment = fileBytes;

                        }
                    }
                }
                salary.Id = Guid.NewGuid();
                salary.CreatedDate = DateTime.Now;
                db.Add(salary);
              
                await db.SaveChangesAsync();
                showMessageString = new
                {
                    status = "true",
                    message = "salary has been added."
                };
                return Json(showMessageString);
            }
            catch (Exception ex)
            {

                showMessageString = new
                {
                    status = "false",
                    message =ex.InnerException.Message
                };
                return Json(showMessageString);
            }
        
            
            return View(salary);
        }

        // GET: Salaries/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await db.Salaries.FindAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            return View(salary);
        }

        // POST: Salaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TeacherId,Amount,Type,Date,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number,Year,PaidBy")] Salary salary,IFormFile Image)
        {
            if (id != salary.Id)
            {
                return NotFound();
            }

           
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
                if (Image != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {

                        Image.CopyToAsync(memoryStream);
                        Byte[] fileBytes = memoryStream.ToArray();
                        int maxFileSizeInBytes = 1 * 1024 * 1024 / 2; // 10MB (adjust as needed)
                        if (
                   Image.ContentType.ToLower() != "image/jpg" &&
                   Image.ContentType.ToLower() != "image/jpeg" &&
                   Image.ContentType.ToLower() != "image/pjpeg" &&
                   Image.ContentType.ToLower() != "image/gif" &&
                   Image.ContentType.ToLower() != "image/x-png" &&
                   Image.ContentType.ToLower() != "image/png" &&
                   Image.ContentType.ToLower() != "image/svg"
               )
                        {

                            showMessageString = new
                            {
                                status = "false",
                                message = "Profile photo must be a JPEG, PNG or SVG format."
                            };
                            return Json(showMessageString);
                        }
                        if (Image.Length > maxFileSizeInBytes)
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
                            salary.Attachment = fileBytes;

                        }
                    }
                }
                salary.ModifiedDate = DateTime.Now;
                db.Update(salary);
                await db.SaveChangesAsync();
                showMessageString = new
                {
                    status = "true",
                    message = "salary has been updated."
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

        // GET: Salaries/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salary = await db.Salaries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var salary = await db.Salaries.FindAsync(id);
            db.Salaries.Remove(salary);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryExists(Guid id)
        {
            return db.Salaries.Any(e => e.Id == id);
        }
    }
}
