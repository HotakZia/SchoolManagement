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
    public class StaffsController : BaseController
    {
        //private readonly School_dbContext _context;

        //public StaffsController(School_dbContext context)
        //{
        //    _context = context;
        //}

        // GET: Staffs
        public async Task<IActionResult> Index()
        {
            return View(await db.TableStaffs.ToListAsync());
        }

        // GET: Staffs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableStaff = await db.TableStaffs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableStaff == null)
            {
                return NotFound();
            }

            return View(tableStaff);
        }

        // GET: Staffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Email,Password,Created,Modefied,Creator,Status")] TableStaff tableStaff, IFormFile Image)
        {
            dynamic showMessageString = string.Empty;
            if (ModelState.IsValid)
            {
                tableStaff.Id = Guid.NewGuid();
                tableStaff.Created = DateTime.Now;
                tableStaff.Status = true;
                

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
                            tableStaff.Image = fileBytes;

                        }
                    }
                }
                db.Add(tableStaff);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tableStaff);
        }

        // GET: Staffs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableStaff = await db.TableStaffs.FindAsync(id);
            if (tableStaff == null)
            {
                return NotFound();
            }
            return View(tableStaff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,UserName,Email,Password,Created,Modefied,Creator,Status")] TableStaff tableStaff)
        {
            if (id != tableStaff.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(tableStaff);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableStaffExists(tableStaff.Id))
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
            return View(tableStaff);
        }

        // GET: Staffs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableStaff = await db.TableStaffs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tableStaff == null)
            {
                return NotFound();
            }

            return View(tableStaff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tableStaff = await db.TableStaffs.FindAsync(id);
            db.TableStaffs.Remove(tableStaff);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableStaffExists(Guid id)
        {
            return db.TableStaffs.Any(e => e.Id == id);
        }
    }
}
