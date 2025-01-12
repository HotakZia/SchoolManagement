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
    public class BooksController : BaseController
    {
        //private readonly School_dbContext _context;

        //public BooksController(School_dbContext context)
        //{
        //    _context = context;
        //}

        
             [HttpPost]
        public async Task<IActionResult> getBookByName(string term)
        {

            var list = await (from book in db.Books


                              where book.Name.StartsWith(term) || book.Type.StartsWith(term)

                              select new Models.Entities.Book
                              {

                                  Id = book.Id,

                                  BookName = book.Name + " " + book.Type



                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
            return Json(list);
        }
        // GET: Books
        [HttpPost]
        public async Task<IActionResult> getStudentByName(string term)
        {

            var list = await (from student in db.Students


                              where student.FirstName.StartsWith(term) || student.LastName.StartsWith(term)

                              select new Models.Entities.Student
                              {

                                  StudentId = student.StudentId,

                                  FirstName = student.FirstName + " " + student.LastName + " /" + student.RoleNumber



                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
            if (list.Count==0)
            {
                list = await (from teacher in db.Teachers


                              where teacher.FirstName.StartsWith(term) || teacher.LastName.StartsWith(term)

                              select new Models.Entities.Student
                              {

                                  StudentId = teacher.TeacherId,

                                  FirstName = teacher.FirstName + " " + teacher.LastName + " /" + teacher.RoleNumber



                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
            }
            return Json(list);
        }
        public async Task<IActionResult> Index()
        {
            var list = await (from book in db.Books
                              //join book in db.Books on assign.BookId equals book.Id

                              //where assign.RelationId==

                              select new Models.Entities.Book
                              {
                                  Id=book.Id,
                                  CreatedBy=book.CreatedBy,
                                  ModifiedBy=book.ModifiedBy,
                                  ModifiedDate=book.ModifiedDate,
                                  BookName=book.Name,
                                  BookId=book.Id,
                                  Type=book.Type,
                                  Number=book.Number,
                                
                                  Attachment=book.Attachment,
                                  Comment=book.Comment,
                                  CreatedDate=book.CreatedDate,
                                  Status = book.Status,
                                  BookAssignee = (from assign in db.BookAssignees
                                                 join student in db.Students on assign.RelationId equals student.StudentId
                                                 where assign.BookId==book.Id
                                                 select new Models.Entities.Book
                                                 {
                                                     RelationId = assign.RelationId,
                                                     StartDate = assign.StartDate,
                                                     EndDate = assign.EndDate,
                                                     Status=assign.Status,
                                                    AssigneeName=student.FirstName+" "+student.LastName+ "/" +student.RoleNumber
                                                 }).ToList(),
                              
                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
            return View(list);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await db.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        // GET: Books/Create
        public IActionResult Assign()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Assign([Bind("Id,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number,RelationId,BookId,StartDate,EndDate")] BookAssignee book, IFormFile Image, string date)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Split authors separated by a comma followed by space
                    string[] From_To_Dates = date.Split(new Char[] { '-',/* '\n', '\t', ' ', ',', '.'*/ });
                    var StartDate = DateTime.Parse(From_To_Dates[0].ToString());
                    var EndDate = DateTime.Parse(From_To_Dates[1].ToString());
                    var duplicate = db.BookAssignees.Where(x => x.Id == book.Id && x.StartDate == book.StartDate&&x.EndDate==book.EndDate&&x.RelationId==book.RelationId&&x.Status==true).FirstOrDefault();
                    if (duplicate != null)
                    {
                        showMessageString = new
                        {
                            status = "duplicate",
                            message = "dupplicate assignee"

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
                                book.Attachment = fileBytes;

                            }
                        }
                    }
                    book.Id = Guid.NewGuid();
                    book.CreatedDate = DateTime.Now;
                    book.Status = true;
                    db.Add(book);
                    await db.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    showMessageString = new
                    {
                        status = "true",
                        message = "book has been assigned."

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
            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number,Name,Type")] Book book,IFormFile Image)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    var duplicate = db.Books.Where(x => x.Name == book.Name && x.Type == book.Type).FirstOrDefault();
                    if (duplicate!=null)
                    {
                        showMessageString = new
                        {
                            status = "duplicate",
                            message = book.Name + " " + " is dupplicate name!"

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
                                book.Attachment = fileBytes;

                            }
                        }
                    }
                    book.Id = Guid.NewGuid();
                    book.CreatedDate = DateTime.Now;
                    book.Status = true;
                    db.Add(book);
                    await db.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    showMessageString = new
                    {
                        status = "true",
                        message = book.Name +" has been added."

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
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number,Name,Type")] Book book, IFormFile Image)
        {
           
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var duplicate = db.Books.Where(x => x.Name == book.Name && x.Id != book.Id).FirstOrDefault();
                    if (duplicate != null)
                    {
                        showMessageString = new
                        {
                            status = "duplicate",
                            message = book.Name + " " + " is dupplicate name!"

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
                                book.Attachment = fileBytes;

                            }
                        }
                    }
                    book.Id = Guid.NewGuid();
                    book.CreatedDate = DateTime.Now;
                    book.Status = true;
                    db.Add(book);
                    await db.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    showMessageString = new
                    {
                        status = "true",
                        message = book.Name + " has been added."

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
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await db.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var book = await db.Books.FindAsync(id);
            db.Books.Remove(book);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(Guid id)
        {
            return db.Books.Any(e => e.Id == id);
        }
    }
}
