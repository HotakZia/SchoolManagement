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
    public class TblUsersController : BaseController
    {
        //private readonly School_dbContext _context;

        //public TblUsersController(School_dbContext context)
        //{
        //    _context = context;
        //}

        // GET: TblUsers
        public async Task<IActionResult> Index()
        {
            return View(await db.TblUsers.ToListAsync());
        }

        // GET: TblUsers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await db.TblUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblUser == null)
            {
                return NotFound();
            }

            return View(tblUser);
        }

        // GET: TblUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Name,Email,Password,CanLogin")] TblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                tblUser.Id = Guid.NewGuid();
                db.Add(tblUser);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblUser);
        }

        // GET: TblUsers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await db.TblUsers.FindAsync(id);
            if (tblUser == null)
            {
                return NotFound();
            }
            return View(tblUser);
        }

        // POST: TblUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Role,Created,Id,UserId,Name,Email,Password,CanLogin")] TblUser tblUser)
        {
            if (id != tblUser.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var duplicate = db.TblUsers.Where(x => x.Email == tblUser.Email && x.Id!=tblUser.Id).FirstOrDefault();
                    if (duplicate != null)
                    {
                        showMessageString = new
                        {
                            status = "duplicate",
                            message = tblUser + " " + " is dupplicate user!"

                        };
                        return Json(showMessageString);
                    }
                  
                    
                    db.Update(tblUser);
                    await db.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    showMessageString = new
                    {
                        status = "true",
                        message = tblUser.Email + " has been updated."

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
            return View(tblUser);
          
        }

        // GET: TblUsers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUser = await db.TblUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblUser == null)
            {
                return NotFound();
            }

            return View(tblUser);
        }

        // POST: TblUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblUser = await db.TblUsers.FindAsync(id);
            db.TblUsers.Remove(tblUser);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUserExists(Guid id)
        {
            return db.TblUsers.Any(e => e.Id == id);
        }
    }
}
