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
    public class StudentsController : BaseController
    {
        //private readonly School_dbContext _context;

        //public StudentsController(School_dbContext context)
        //{
        //    _context = context;
        //}

        // GET: Students
        public async Task<IActionResult> Index(Guid?Id)
        {
            ViewBag.Id = new SelectList(db.Classes.ToList(), "Id", "Name");
            IList<Models.Entities.Student> list = new List<Models.Entities.Student>();
            if (Id==null)
            {
                return View(list);
            }
             list= await(from student in db.Students
             join class_ in db.Classes on student.ClassId equals class_.Id

             where student.ClassId==Id

             select new Models.Entities.Student
             {
                  ClassId= student.ClassId,
                 StudentId=student.StudentId,
                 Tazkira=student.Tazkira,
                 RoleNumber=student.RoleNumber,
                 FirstName=student.FirstName,
                 LastName=student.LastName,
                 FatherName=student.FatherName,
                 ClassName=class_.Name,
                 DateOfBirth=student.DateOfBirth,
                 Attachment=student.Attachment,
                 Contact=student.Contact,
                 Status=student.Status,
                 BloodGroup=student.BloodGroup,
                 City=student.City,
                 AdmissionDate=student.AdmissionDate,
                 Street=student.Street,
                 Comment=student.Comment,
                 CreatedBy=student.CreatedBy,
                 Gender=student.Gender,
                 GfatherName=student.GfatherName,
                 GuardianName=student.GuardianName,
                 GuardianPhone=student.GuardianPhone,
                 ModifiedBy=student.ModifiedBy,
                 ModifiedDate=student.ModifiedDate,
                 Province=student.Province,
 

             })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
            return PartialView("_index",list);
        }
        [HttpPost]
        public async Task<IActionResult> getStudentByName(string term)
        {
      
            var list = await (from student in db.Students
                          join class_ in db.Classes on student.ClassId equals class_.Id

                          where student.FirstName.StartsWith(term)||student.LastName.StartsWith(term)

                          select new Models.Entities.Student
                          {
                              ClassId = student.ClassId,
                              StudentId = student.StudentId,
                              Tazkira = student.Tazkira,
                              RoleNumber = student.RoleNumber,
                              FirstName = student.FirstName,
                              LastName = student.LastName,
                              FatherName = student.FatherName,
                              ClassName = class_.Name,
                              DateOfBirth = student.DateOfBirth,
                              Attachment = student.Attachment,
                              Contact = student.Contact,
                              Status = student.Status,
                              BloodGroup = student.BloodGroup,
                              City = student.City,
                              AdmissionDate = student.AdmissionDate,
                              Street = student.Street,
                              Comment = student.Comment,
                              CreatedBy = student.CreatedBy,
                              Gender = student.Gender,
                              GfatherName = student.GfatherName,
                              GuardianName = student.GuardianName,
                              GuardianPhone = student.GuardianPhone,
                              ModifiedBy = student.ModifiedBy,
                              ModifiedDate = student.ModifiedDate,
                              Province = student.Province,


                          })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
            return PartialView("_index", list);
        }
        [HttpPost]
        public JsonResult Get_Supplier(string term)
        {
            // return Json result using LINQ to SQL 


            var data = (from student in db.Students
                        where student.FirstName.StartsWith(term)
                        select new
                        {
                            Name = student.FirstName + "  " + student.LastName+" / "+ student.RoleNumber,
                            Id = student.StudentId
                        }).ToList();


            return Json(data/*, JsonRequestBehavior.AllowGet*/);
        }
        // GET: Students/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await db.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            ViewBag.Payments =(from Payment in db.Payments
                                           join sPay in db.StudentPayments on Payment.Id equals sPay.PaymentId

                                           //where post.Name.ToLower().Contains(term)

                                           select new Models.Entities.Payment
                                           {
                                             Id=sPay.Id,
                                             PaymentName=Payment.Name,
                                             Amount=Payment.Amount,
                                             CreatedDate=Payment.CreatedDate
                                            

                                           }).OrderByDescending(x => x.CreatedDate).ToList();

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewBag.Payment = new SelectList(db.Payments.ToList(), "Id", "Name");
            ViewBag.ClassId = new SelectList(db.Classes.ToList(), "Id", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Shift,Tazkira,FatherName, GFatherName,Contact,RoleNumber,StudentId,FirstName,LastName,DateOfBirth,Gender,Street,City,Province,Email,Phone,AdmissionDate,GuardianName,GuardianPhone,ClassId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,BloodGroup")] Student student,List<Guid> Payment, IFormFile Image)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var checkduplicate = db.Students.Where(x => x.RoleNumber == student.RoleNumber || (x.FirstName == student.FirstName &&
                      x.LastName == x.LastName && x.FatherName == x.FatherName && x.GfatherName == student.GfatherName)).FirstOrDefault();
                    if (checkduplicate != null)
                    {
                        showMessageString = new
                        {
                            status = "dupplicate",
                            message = student.FirstName + " " + student.LastName + " is dupplicate."

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
                                student.Attachment = fileBytes;

                            }
                        }
                    }
                    student.StudentId = Guid.NewGuid();
                    student.CreatedDate = DateTime.Now;
                    student.Status = true;
                    db.Add(student);

                    ////////////////////////////////
                    ///Create payments for 
                    if (Payment != null&&Payment.Count!=0)
                    {
                        var pay = new StudentPayment();
                        foreach (var item in Payment)
                        {
                            pay = new StudentPayment();
                            pay.PaymentId = item;
                            pay.StudentId = student.StudentId;
                            pay.Id = Guid.NewGuid();
                            pay.CreatedDate = DateTime.Now;
                            pay.Status = true;
                            
                            db.StudentPayments.Add(pay);
                        }
                    }

                    ////////////
                    /// Create user account for new student

                    TblUser tblUser = new TblUser();
                        Models.Hashing hashing = new Models.Hashing();
                        tblUser.Id = Guid.NewGuid();
                        tblUser.Name = student.FirstName + student.LastName;
                        tblUser.Email = student.FirstName + student.LastName;
                        tblUser.Password = hashing.Encrypt("123@" + student.LastName);
                        tblUser.CanLogin = true;
                        db.TblUsers.Add(tblUser);

                    ////////////////////////
                    ///Create role for user
                    TableRole tableRole = new TableRole();
                    tableRole.Id = Guid.NewGuid();
                    tableRole.RoleType = "Read-Only";
                    tableRole.UserRole = "Student";
                    tableRole.UserId = tblUser.Id;
                    db.TableRoles.Add(tableRole);
                    
                    await db.SaveChangesAsync();
                    showMessageString = new
                    {
                        status = "true",
                        message = student.FirstName + " " + student.LastName + " has been added."

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
                    message = ex.ToString()

                };
                return Json(showMessageString);
            }
            return View(student);

        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Shift,RoleNumber,StudentId,FirstName,LastName,DateOfBirth,Gender,Street,City,Province,Email,Phone,AdmissionDate,GuardianName,GuardianPhone,ClassId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(student);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await db.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var student = await db.Students.FindAsync(id);
            db.Students.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(Guid id)
        {
            return db.Students.Any(e => e.StudentId == id);
        }
    }
}
