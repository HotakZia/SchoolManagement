using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using SchoolManagement.Models.db;
using System.Text;

namespace SchoolManagement.Controllers
{
    public class StudentsController : BaseController
    {
        //private readonly School_dbContext _context;

        //public StudentsController(School_dbContext context)
        //{
        //    _context = context;
        //}
        public async Task<IActionResult> LoadFile(Guid? Id)
        {
            var list = db.Files.Where(x => x.RelationId == Id).OrderByDescending(x => x.CreatedDate).ToList();
            ViewBag.RelationId = Id;
            ViewBag.FileList = list;
            return PartialView("_File", new Models.db.File());
        }
        [HttpPost]
        public async Task<IActionResult> AddFile(Models.db.File fille, Guid Id, IFormFile Image)
        {
            var list = new List<Parent>();
            try
            {
                ViewBag.RelationId = Id;
                if (Image != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {

                        Image.CopyToAsync(memoryStream);
                        Byte[] fileBytes = memoryStream.ToArray();
                        int maxFileSizeInBytes = 1 * 1024 * 1024 / 1; // 10MB (adjust as needed)
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
                                message = " Profile photo max size must be 1024 KB."
                            };
                            return Json(showMessageString);
                        }
                        else
                        {
                            fille.Attachment = fileBytes;

                        }
                    }
                }

                fille.Id = Guid.NewGuid();
                fille.CreatedDate = DateTime.Now;
                fille.RelationId = Id;
                db.Files.Add(fille);

                db.SaveChanges();
                ViewBag.FileList = db.Files.Where(x => x.RelationId == Id).OrderByDescending(x => x.CreatedDate).ToList();
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

            return PartialView("_File", fille);
        }
        public async Task<IActionResult> DeleteFiles(Guid? Id)
        {
            try
            {

                var list = db.Files.Where(x => x.Id == Id).FirstOrDefault();
                if (list == null)
                {
                    return NotFound();
                }
                Guid? RelationId = list.RelationId;
                ViewBag.RelationId = RelationId;
                db.Files.Remove(list);
                await db.SaveChangesAsync();

                ViewBag.FileList = db.Files.Where(x => x.RelationId == RelationId).OrderByDescending(x => x.CreatedDate).ToList();
            }
            catch (Exception ex)
            {

                showMessageString = new
                {
                    status = "false",
                    message = ex.InnerException.Message

                };
            }

            return PartialView("_File", new Models.db.File());
        }
 
        public async Task<IActionResult> LpadPerants(Guid? Id)
        {
            var list = db.Parents.Where(x => x.StudentId == Id).OrderByDescending(x => x.CreatedDate).ToList();
            ViewBag.StudentId = Id;
            ViewBag.ParentsList = list;
            return PartialView("_Parent",new Models.db.Parent());
        }
        public async Task<IActionResult> AddPerants(Parent parents,Guid Id)
        {
            var list = new List<Parent>();
            try
            {
                ViewBag.StudentId = Id;

                parents.Id = Guid.NewGuid();
                parents.CreatedDate = DateTime.Now;
                parents.StudentId = Id;
                    db.Parents.Add(parents);
              
                db.SaveChanges();
                ViewBag.ParentsList = db.Parents.Where(x => x.StudentId == Id).OrderByDescending(x=>x.CreatedDate).ToList();
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

            return PartialView("_Parent", parents);
        }
        public async Task<IActionResult> DeletePerants(Guid? Id)
        {
            try
            {

                var list = db.Parents.Where(x => x.Id == Id).FirstOrDefault();
                if (list == null)
                {
                    return NotFound();
                }
                Guid? StudentId = list.StudentId;
                ViewBag.StudentId = StudentId;
                db.Parents.Remove(list);
                await db.SaveChangesAsync();

                ViewBag.ParentsList = db.Parents.Where(x => x.StudentId == StudentId).OrderByDescending(x => x.CreatedDate).ToList();
            }
            catch (Exception ex)
            {

                showMessageString = new
                {
                    status = "false",
                    message = ex.InnerException.Message

                };
            }
          
            return PartialView("_Parent", new Models.db.Parent());
        }
     
        // GET: Students
        public async Task<IActionResult> GridListView(Guid? Id,int? Page)
        {
            IPagedList<Models.Entities.Student> list = new PagedList<Models.Entities.Student>(null, 1, 1);
            //if (Id == null)
            //{
            //    return View(list);
            //}
 
            list = await (from student in db.Students
                          join class_ in db.Classes on student.ClassId equals class_.Id

                          //where student.ClassId == Id

                          select new Models.Entities.Student
                          {
                              Shift=student.Shift,
                             
                              CreatedDate=student.CreatedDate,
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


                          }).AsNoTracking().ToPagedListAsync(Page ?? 1, 1);
            bool isAjaxRequest = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (!isAjaxRequest)
            {

                return View(list);
            }
            else
            {
                return PartialView("_GridList",list);
            }
            
        }
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
        public async Task<IActionResult> pass(Guid? Id)
        {
            ViewBag.Id = new SelectList(db.Classes.ToList(), "Id", "Name");
            ViewBag.ClassId = new SelectList(db.Classes.ToList(), "Id", "Name");
          
            IList<Models.Entities.Student> list = new List<Models.Entities.Student>();
            if (Id == null)
            {
                return View(list);
            }
            list = await (from student in db.Students
                          join class_ in db.Classes on student.ClassId equals class_.Id

                          where student.ClassId == Id

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
                              CreatedDate=student.CreatedDate,
                              Number=db.Exams.Where(x=>x.ClassId==class_.Id&&x.StudentId==student.StudentId&&x.Status==true).Count()

                          })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
     
            return PartialView("_pass", list);
        }
        [HttpPost]
        public async Task<IActionResult> getStudentByName(string term)
        {
      
            var list = await (from student in db.Students
                        

                          where student.FirstName.StartsWith(term)||student.LastName.StartsWith(term)

                          select new Models.Entities.Student
                          {
                             
                              StudentId = student.StudentId,
                              
                              FirstName = student.FirstName+" "+student.LastName +" /"+student.RoleNumber
                            


                          })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
            return Json(list);
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

            //var student = await db.Students
            //    .FirstOrDefaultAsync(m => m.StudentId == id);
            var data = await (from student in db.Students
                          join class_ in db.Classes on student.ClassId equals class_.Id

                          where student.StudentId == id

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
                              CreatedDate = student.CreatedDate,
                              Number = db.Exams.Where(x => x.ClassId == class_.Id && x.StudentId == student.StudentId && x.Status == true).Count()

                          }).FirstOrDefaultAsync();
            if (data == null)
            {
                return NotFound();
            }
            ViewBag.payments =(from sPayment in db.StudentPayments
                                           join Pay in db.Payments on sPayment.PaymentId equals Pay.Id

                                           where sPayment.StudentId==id

                                           select new Models.Entities.Payment
                                           {
                                             Id=sPayment.Id,
                                             PaymentName=Pay.Name,
                                             Amount=Pay.Amount,
                                             CreatedDate=Pay.CreatedDate
                                           }).OrderByDescending(x => x.CreatedDate).ToList();
            ViewBag.parents = db.Parents.Where(x => x.StudentId == id).ToList();
            ViewBag.files = db.Files.Where(x => x.RelationId == id).ToList();
            ViewBag.userId = id;
            return View(data);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewBag.Payment = new SelectList(db.Payments.ToList(), "Id", "Name");


            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Shift,Tazkira,FatherName, GfatherName,Contact,RoleNumber,StudentId,FirstName,LastName,DateOfBirth,Gender,Street,City,Province,Email,Phone,AdmissionDate,GuardianName,GuardianPhone,ClassId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,BloodGroup")] Student student,List<Guid> Payment,List<Models.db.Parent> Parent, IFormFile Image)
        {

            try
            {
                ViewBag.Payment = new SelectList(db.Payments.ToList(), "Id", "Name",selectedValue:student.StudentId);
                if (ModelState.IsValid)
                {
                    var checkduplicate = db.Students.Where(x => x.RoleNumber == student.RoleNumber &&x.Tazkira==student.Tazkira).FirstOrDefault();
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
                        tblUser.Name = student.FirstName + " " + student.LastName;
                    tblUser.Email = student.RoleNumber;
                        tblUser.Password = hashing.Encrypt("123@" + student.LastName);
                        tblUser.CanLogin = true;
                    tblUser.UserId = student.StudentId;
                    tblUser.Role = "Student";
                    tblUser.Image = student.Attachment;
                    tblUser.CreatedDate = DateTime.Now;
                        db.TblUsers.Add(tblUser);

                    ////////////////////////
                    ///Create role for user
                    TableRole tableRole = new TableRole();
                    tableRole.Id = Guid.NewGuid();
                    tableRole.RoleType = "Read-Only";
                    tableRole.UserRole = "Student";
                    tableRole.UserId = tblUser.Id;
                    db.TableRoles.Add(tableRole);

                     tableRole = new TableRole();
                    tableRole.Id = Guid.NewGuid();
                    tableRole.RoleType = "Authorize-Only";
                    tableRole.UserRole = "Authorize";
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
            ViewBag._class = db.Classes.Where(x => x.Id == student.ClassId).FirstOrDefault();
            ViewBag.Payment = new SelectList(db.Payments.ToList(), "Id", "Name");
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BloodGroup,Tazkira,Shift,RoleNumber,StudentId,FirstName,FatherName,GfatherName,LastName,DateOfBirth,Gender,Street,City,Province,Contact,AdmissionDate,GuardianName,GuardianPhone,ClassId,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status")] Student student, List<Guid> Payment, IFormFile Image)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }
            try
            {
                ViewBag.Payment = new SelectList(db.Payments.ToList(), "Id", "Name", selectedValue: student.StudentId);
                if (ModelState.IsValid)
                {
                    var checkduplicate = db.Students.Where(x => x.RoleNumber == student.RoleNumber&&x.Tazkira==student.Tazkira&&
                      x.StudentId!=student.StudentId).AsNoTracking().FirstOrDefault();
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
                            int maxFileSizeInBytes = 1 * 1024 * 1024 / 1; // 10MB (adjust as needed)
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
                                    message = " Profile photo max size must be 1024 KB."
                                };
                                return Json(showMessageString);
                            }
                            else
                            {
                                student.Attachment = fileBytes;

                            }
                        }
                    }
                    
                    student.ModifiedDate = DateTime.Now;
                    
                    db.Update(student);

                    ////////////////////////////////
                    ///Create payments for 
                    ///
               
                    if (Payment != null && Payment.Count != 0)
                    {
                        var payments = db.StudentPayments.Where(x => x.StudentId == student.StudentId).ToList();
                        if (payments.Count >= 1)
                        {
                            foreach (var item in payments)
                            {
                                db.Remove(item);
                            }

                        }
                        var pay = new StudentPayment();
                        foreach (var item in Payment)
                        {
                            pay = new StudentPayment();
                            pay.PaymentId = item;
                            pay.StudentId = id;
                            pay.Id = Guid.NewGuid();
                            pay.CreatedDate = DateTime.Now;
                            pay.Status = true;


                            db.StudentPayments.Add(pay);
                        }
                    }


                    ////////////
                    /// Create user account for new student

                    var tblUser = db.TblUsers.Where(x => x.UserId == id).FirstOrDefault();
                    if (tblUser!=null)
                    {
                        Models.Hashing hashing = new Models.Hashing();
                        tblUser.Name = student.FirstName + " " + student.LastName;
                        tblUser.Email = student.RoleNumber;
                        tblUser.Role = "Student";
                        tblUser.Image = student.Attachment;
                        db.Update(tblUser);
                    }


               
                    // Refresh the original values with the database values
                    await db.SaveChangesAsync();
                    showMessageString = new
                    {
                        status = "true",
                        message = student.FirstName + " " + student.LastName + " has been Updated.",
                        Id=student.StudentId

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
                    message = ex.ToString()

                };
                return Json(showMessageString);
            }
            StringBuilder errors = new StringBuilder();

            foreach (var modelError in ModelState.Values.SelectMany(v => v.Errors))
            {
                errors.Append(modelError.ErrorMessage).Append(" ");
            }
            showMessageString = new
            {
                status = "false",
                message = errors,

        };
            return Json(showMessageString);
     
            
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
