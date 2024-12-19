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
    public class TeachersController : BaseController
    {
        //private readonly School_dbContext _context;

        //public TeachersController(School_dbContext context)
        //{
        //    _context = context;
        //}

        // GET: Classes
        [HttpPost]
        public async Task<IActionResult> getTeacherByName(string term)
        {

            var list = await (from Teacher in db.Teachers


                              where Teacher.FirstName.StartsWith(term)||Teacher.LastName.StartsWith(term)

                              select new Models.Entities.Class_
                              {

                                  Id = Teacher.TeacherId,

                                  Name = Teacher.FirstName+ " / " + Teacher.LastName+ " / " + Teacher.RoleNumber



                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
            return Json(list);
        }
        // GET: Teachers
        public async Task<IActionResult> Index()
        {
            return View(await db.Teachers.ToListAsync());
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = await db.Teachers
                .FirstOrDefaultAsync(m => m.TeacherId == id);
            if (data == null)
            {
                return NotFound();
            }
      
           
            ViewBag.files = db.Files.Where(x => x.RelationId == id).ToList();
            ViewBag.userId = id;
            return View(data);

           
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tazkira,TeacherId,FirstName,LastName,DateOfBirth,Gender,Street,City,Province,Email,Phone,HireDate,Salary,SubjectTaught,Department,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number,RoleNumber,Position")] Teacher teacher, IFormFile Image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var duplicate = db.Teachers.Where(x => x.Email == teacher.Email||x.Tazkira==teacher.Tazkira).FirstOrDefault();

                    if (duplicate!=null)
                    {
                        showMessageString = new
                        {
                            status = "duplicate",
                            message = teacher.FirstName + " " + teacher.LastName + " is a duplicate teacher."

                        };
                        return Json(showMessageString);
                    }
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
                                    message = " ads image must be a JPEG, PNG or SVG format."
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
                                teacher.Attachment = fileBytes;

                            }
                        }
                    }
                    teacher.TeacherId = Guid.NewGuid();
                    teacher.CreatedDate = DateTime.Now;
                    teacher.Status = true;
                    db.Add(teacher);
                
                        Models.Hashing hashing = new Models.Hashing();
                        var tbluser = new TblUser();

                        tbluser.Email = teacher.RoleNumber;
                        tbluser.Name = teacher.FirstName + " " + teacher.LastName;
                    tbluser.Password = hashing.Encrypt("123@" + teacher.LastName);
                    tbluser.UserId = teacher.TeacherId;
                        tbluser.CanLogin = true;
                    tbluser.Role = "Teacher";
                        tbluser.Id = Guid.NewGuid();
                    tbluser.Image = teacher.Attachment;
                    tbluser.CreatedDate = DateTime.Now;
                    db.TblUsers.Add(tbluser);

                    ////////////////////////
                    ///Create role for user
                    TableRole tableRole = new TableRole();
                    tableRole.Id = Guid.NewGuid();
                    tableRole.RoleType = "Teacher-Read-Only";
                    tableRole.UserRole = "Teacher";
                    tableRole.UserId = tbluser.Id;
                    db.TableRoles.Add(tableRole);

                    tableRole = new TableRole();
                    tableRole.Id = Guid.NewGuid();
                    tableRole.RoleType = "Teacher-Authorize";
                    tableRole.UserRole = "Authorize";
                    tableRole.UserId = tbluser.Id;
                    db.TableRoles.Add(tableRole);

                    await db.SaveChangesAsync();
                    showMessageString = new
                    {
                        status = "true",
                        message = teacher.FirstName+" "+teacher.LastName + " has been added."

                    };
                    return Json(showMessageString);
                    return RedirectToAction(nameof(Index));
                }
                return View(teacher);
            }
            catch (Exception ex)
            {

                showMessageString = new
                {
                    status = "true",
                    message = ex.ToString()

                };
                return Json(showMessageString);
            }
          
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await db.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Tazkira,TeacherId,FirstName,LastName,DateOfBirth,Gender,Street,City,Province,Email,Phone,HireDate,Salary,SubjectTaught,Department,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number,RoleNumber,Position")] Teacher teacher,IFormFile Image)
        {
            if (id != teacher.TeacherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var checkDuplicate = db.Teachers.Where(x =>x.TeacherId != teacher.TeacherId&&
                    (x.Tazkira == teacher.Tazkira ||x.Email==teacher.Email )).FirstOrDefault();

                    if (checkDuplicate!=null)
                    {
                        showMessageString = new
                        {
                            status = "true",
                            message = "Dupplicate record."

                        };
                        return Json(showMessageString);
                    }
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
                                    message = " ads image must be a JPEG, PNG or SVG format."
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
                                teacher.Attachment = fileBytes;

                            }
                        }
                    }
                    var hashing = new Models.Hashing();
                    teacher.ModifiedDate = DateTime.Now;

                    var user = db.TblUsers.Where(x => x.UserId == teacher.TeacherId).FirstOrDefault();
                    if (user!= null)
                    {


                        user.Name = teacher.FirstName + " " + teacher.LastName;
                        user.Email = teacher.RoleNumber;
                        user.Role = "Teacher";
                        user.Image = teacher.Attachment;

                        db.Update(user);
                    }
                    db.Update(teacher);
                    await db.SaveChangesAsync();
                    showMessageString = new
                    {
                        status = "true",
                        message = "record has been updated.",
                        Id=teacher.TeacherId

                    };
                    return Json(showMessageString);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.TeacherId))
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
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await db.Teachers
                .FirstOrDefaultAsync(m => m.TeacherId == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var teacher = await db.Teachers.FindAsync(id);
            db.Teachers.Remove(teacher);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(Guid id)
        {
            return db.Teachers.Any(e => e.TeacherId == id);
        }
    }
}
