using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models.db;
using SchoolManagement.Models.Entities;

namespace SchoolManagement.Controllers
{
    public class EventsController : BaseController
    {
        //private readonly School_dbContext _context;

        //public EventsController(School_dbContext context)
        //{
        //    _context = context;
        //}

            //[HttpPost]
        public JsonResult Calendar(DateTime? startDate, DateTime? endDate)
        {


            var list = db.Events/*.Where(x => x.StartDate >= start && x.EndDate <= end)*/.ToList();


         
            Events singleEvents = new Events();
            IList<Models.Entities.Events> evntsList = new List<Events>();
            foreach (var item in list)
            {
              
                singleEvents = new Events();
                singleEvents.title = item.Name;
                singleEvents.backroundColor = "#00a65a";
                singleEvents.boderColor = "#00a65a";
                singleEvents.allDay = item.Allday;
                singleEvents.Color = item.Color;
                singleEvents.start = item.StartDate.Value.ToShortDateString();
                singleEvents.end = item.EndDate.Value.ToShortDateString();
                evntsList.Add(singleEvents);
            }
            
   


            return Json(evntsList);
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            return View(await db.Events.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var @event = await db.Events
                .Where(x=>x.StartDate>=DateTime.Now&&x.EndDate<=DateTime.Now).ToListAsync();
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Color,Allday,Id,Name,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Year,Number,StartDate,EndDate")] Event @event,string date)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Split authors separated by a comma followed by space
                    string[] From_To_Dates = date.Split(new Char[] { '-',/* '\n', '\t', ' ', ',', '.'*/ });
                    @event.StartDate = DateTime.Parse(From_To_Dates[0].ToString());
                    @event.EndDate = DateTime.Parse(From_To_Dates[1].ToString());
                    @event.StartDate = DateTime.ParseExact(@event.StartDate.Value.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.GetCultureInfo("en-US"));
                    @event.EndDate = DateTime.ParseExact(@event.EndDate.Value.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.GetCultureInfo("en-US"));

                    var duplicate = db.Events.Where(x => x.Name == @event.Name && x.StartDate==@event.StartDate&&@event.EndDate == @event.EndDate).FirstOrDefault();
                    if (duplicate != null)
                    {
                        showMessageString = new
                        {
                            status = "duplicate",
                            message = @event.Name + " " + " is dupplicate name!"

                        };
                        return Json(showMessageString);
                    }
                    @event.Id = Guid.NewGuid();
                    @event.CreatedDate = DateTime.Now;
                    @event.Status = true;
                    db.Add(@event);
                    await db.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    showMessageString = new
                    {
                        status = "true",
                        message = @event.Name + " has been added."

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
           
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await db.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Color,Allday,Id,Name,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,Comment,Attachment,Status,Year,Number,StartDate,EndDate")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(@event);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
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
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await db.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var @event = await db.Events.FindAsync(id);
            db.Events.Remove(@event);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(Guid id)
        {
            return db.Events.Any(e => e.Id == id);
        }
    }
}
