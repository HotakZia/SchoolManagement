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
    public class HostelsController : BaseController
    {
        //private readonly School_dbContext _context;

        //public HostelsController(School_dbContext context)
        //{
        //    _context = context;
        //}

        // GET: Hostels
        public async Task<IActionResult> Index()
        {
            var list = await (from Hostel in db.Hostels
                                  join student in db.Students on Hostel.StudentId equals student.StudentId

                                  //where assign.RelationId==

                              select new Models.Entities.Hostel
                              {
                                  Id = Hostel.Id,
                                  CreatedBy = Hostel.CreatedBy,
                                  ModifiedBy = Hostel.ModifiedBy,
                                  ModifiedDate = Hostel.ModifiedDate,
                                  Name = Hostel.Name,
                                
                                  RoomType = Hostel.RoomType,
                                  Room=Hostel.Room,
                                  Block=Hostel.Block,
                                  Student=student.FirstName+" "+student.LastName+"/ "+student.RoleNumber,
                                  Number = Hostel.Number,
                                  StudentId=student.StudentId,
                                  CostPerBed=Hostel.CostPerBed,
                                  NoOfBed=Hostel.NoOfBed,
                                  RoomNo=Hostel.RoomNo,
                                  Attachment = Hostel.Attachment,
                                  Comment = Hostel.Comment,
                                  CreatedDate = Hostel.CreatedDate,
                                  Status = Hostel.Status,
                                 

                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToListAsync();
            return View(list);
        }

        // GET: Hostels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostel = await db.Hostels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hostel == null)
            {
                return NotFound();
            }

            return View(hostel);
        }

        // GET: Hostels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hostels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number,Block,Room,RoomNo,RoomType,CostPerBed,NoOfBed")] Hostel hostel, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var duplicate = db.Hostels.Where(x => x.Name == hostel.Name && x.StudentId == hostel.StudentId).FirstOrDefault();
                    if (duplicate != null)
                    {
                        showMessageString = new
                        {
                            status = "duplicate",
                            message = hostel.Name + " " + " is dupplicate name!"

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
                                hostel.Attachment = fileBytes;

                            }
                        }
                    }
                    hostel.Id = Guid.NewGuid();
                    hostel.CreatedDate = DateTime.Now;
                    hostel.Status = true;
                    db.Add(hostel);
                    await db.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    showMessageString = new
                    {
                        status = "true",
                        message = hostel.Name + " has been added."

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
            return View(hostel);
            return View(hostel);
        }

        // GET: Hostels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostel = await db.Hostels.FindAsync(id);
            if (hostel == null)
            {
                return NotFound();
            }
            return View(hostel);
        }

        // POST: Hostels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Number,Block,Room,RoomNo,RoomType,CostPerBed,NoOfBed")] Hostel hostel)
        {
            if (id != hostel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(hostel);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HostelExists(hostel.Id))
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
            return View(hostel);
        }

        // GET: Hostels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hostel = await db.Hostels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hostel == null)
            {
                return NotFound();
            }

            return View(hostel);
        }

        // POST: Hostels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var hostel = await db.Hostels.FindAsync(id);
            db.Hostels.Remove(hostel);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HostelExists(Guid id)
        {
            return db.Hostels.Any(e => e.Id == id);
        }
    }
}
