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
    public class SportsController : BaseController
    {
        //private readonly School_dbContext _context;

        //public SportsController(School_dbContext context)
        //{
        //    _context = context;
        //}

        // GET: Sports
        public async Task<IActionResult> Index()
        {
            var list = await (from sport in db.Sports
                              join student in db.Students on sport.StudentId equals student.StudentId

                              //where assign.RelationId==

                              select new Models.Entities.Sport
                              {
                                  Id = sport.Id,
                                  CreatedBy = sport.CreatedBy,
                                  ModifiedBy = sport.ModifiedBy,
                                  ModifiedDate = sport.ModifiedDate,
                                  Name = sport.Name,
                                  Postition=sport.Postition,
                                  TeacherId=sport.TeacherId,
                                  
                                  Student = student.FirstName + " " + student.LastName + "/ " + student.RoleNumber,
                                  Number = sport.Number,
                                  StudentId = student.StudentId,
                                  
                                  Attachment = sport.Attachment,
                                  Comment = sport.Comment,
                                  CreatedDate = sport.CreatedDate,
                                  Status = sport.Status,


                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
            return View(list);
        }

        // GET: Sports/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sport = await db.Sports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sport == null)
            {
                return NotFound();
            }

            return View(sport);
        }

        // GET: Sports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number,StudentId,TeacherId,Postition")] Sport sport, IFormFile Image)
        {
    
            if (ModelState.IsValid)
            {
                try
                {
                    var duplicate = db.Sports.Where(x => x.Name == sport.Name && x.StudentId==sport.StudentId).FirstOrDefault();
                    if (duplicate != null)
                    {
                        showMessageString = new
                        {
                            status = "duplicate",
                            message = sport.Name + " " + " is dupplicate name!"

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
                                sport.Attachment = fileBytes;

                            }
                        }
                    }
                    sport.Id = Guid.NewGuid();
                    sport.CreatedDate = DateTime.Now;
                    sport.Status = true;
                    db.Add(sport);
                    await db.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    showMessageString = new
                    {
                        status = "true",
                        message = sport.Name + " has been added."

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
            return View(sport);
        }

        // GET: Sports/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sport = await db.Sports.FindAsync(id);
            if (sport == null)
            {
                return NotFound();
            }
            return View(sport);
        }

        // POST: Sports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number,StudentId,TeacherId,Postition")] Sport sport)
        {
            if (id != sport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(sport);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SportExists(sport.Id))
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
            return View(sport);
        }

        // GET: Sports/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sport = await db.Sports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sport == null)
            {
                return NotFound();
            }

            return View(sport);
        }

        // POST: Sports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var sport = await db.Sports.FindAsync(id);
            db.Sports.Remove(sport);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SportExists(Guid id)
        {
            return db.Sports.Any(e => e.Id == id);
        }
    }
}
