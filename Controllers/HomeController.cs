using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{


    public class HomeController : BaseController
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public async Task<IActionResult> getActiveScedule()
        {
            string day = DateTime.Now.DayOfWeek.ToString();
            var list = (from Schedule in db.Schedules
                              join class_ in db.Classes on Schedule.ClassId equals class_.Id
                              //join Subject in db.Subjects on Schedule.SubjectId equals Subject.Id
                              join teacher in db.Teachers on Schedule.TeacherId equals teacher.TeacherId
                              where Schedule.Status == true&&Schedule.DayOfWeek==day

                              select new Models.Entities.Schedual
                              {
                                  Shift = Schedule.Shift,
                                  ClassId = Schedule.ClassId,

                                  Attachment = Schedule.Attachment,

                                  Status = Schedule.Status,

                                  Comment = Schedule.Comment,
                                  CreatedBy = Schedule.CreatedBy,

                                  ModifiedBy = Schedule.ModifiedBy,
                                  ModifiedDate = Schedule.ModifiedDate,
                                  SubjecName = Schedule.Subject,
                                  ClassName = class_.Name,
                                  HourOfDay = Schedule.HourOfDay,
                                  DayOfWeek = Schedule.DayOfWeek,
                                  //SubjectId = Schedule.SubjectId,
                                  CreatedDate = Schedule.CreatedDate,
                                  Id = Schedule.Id,
                                  Name = Schedule.Name,
                                  Number = Schedule.Number,
                                  StartTime = Schedule.StartTime,
                                  EndTime = Schedule.EndTime,
                                  TeacherName = teacher.FirstName + " " + teacher.LastName,
                                  Year = Schedule.Year,


                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToList();
            return PartialView("_Schedule",list);
        }
        public  ActionResult GetActiveClasses()
        {



            var list = (from class_ in db.Classes
                    join teacher in db.Teachers on class_.TeacherId equals teacher.TeacherId

                    where class_.Status==true

                    select new Models.Entities.Class_
                    {
                        Id = class_.Id,
                        TeacherId = class_.TeacherId,
                        Room = class_.Room,
                        Name = class_.Name,
                        Comment = class_.Comment,
                        CreatedBy = class_.CreatedBy,
                        CreatedDate = class_.CreatedDate,
                        Grad = class_.Grad,
                        ModifiedBy = class_.ModifiedBy,
                        ModifiedDate = class_.ModifiedDate,
                        Number = class_.Number,
                        Attachment = class_.Attachment,
                        Shift = class_.Shift,
                        Status = class_.Status,
                        //Year = class_.Year,
                        TeacherName = teacher.FirstName + " " + teacher.LastName + " " + teacher.RoleNumber,
                        SchedualList = (from Schedule in db.Schedules
                                        //join Subject in db.Subjects on Schedule.SubjectId equals Subject.Id
                                        where Schedule.ClassId == class_.Id
                                        select new Models.Entities.Subjetc
                                        {
                                            SubjectName = Schedule.Subject,
                                            
                                        }).ToList()

                    }).ToList();
            return PartialView("_Class",list);
        }
        [HttpGet]
        public ActionResult GetNotifications()
        { string role = User.Claims.FirstOrDefault(x => x.Type == "Role")?.Value;

            var data = db.Notices.Where(x => x.Status == true &&x.Date>=DateTime.Now&& (x.Type == role ||x.Type=="All") ).Take(10).ToList();


            if (role == "Admin")
            {
                 data = db.Notices.Where(x => x.Status == true && x.Date >= DateTime.Now).Take(20).ToList();
            }
                //var data = db.Table_Notification.Select(x=>new {x.Id,x.Created,x.Item_Image,x.URL,x.NotiHeader }).ToList() ;




                return PartialView("_Notification",data);
        }
        [Route("teacher")]

        [Authorize(Roles = ("Teacher"))]
        public IActionResult Teacher()
        {
            return View();

        }
        [Route("student")]

        [Authorize(Roles = ("Student"))]
        public IActionResult Student()
        {
            return View();
        }
        [Route("dashboard")]

        [Authorize(Roles = ("Admin"))]
        public IActionResult Index()
        {
            ViewBag.Student = db.Students.Where(x => x.Status == true).Count();
            ViewBag.Class = db.Classes.Where(x => x.Status == true).Count();
            ViewBag.Staff = db.staff.Where(x => x.Status == true).Count();
            ViewBag.Subject = db.Subjects.Where(x => x.Status == true).Count();
            ViewBag._Class = db.Classes.Where(x=>x.Status==true).ToList();


            //////////////////
            ///

            List<DataPoint> dataPoints = new List<DataPoint>();
            List<DataPoint> dataPoints2 = new List<DataPoint>();
            List<DataPoint> dataPoints1 = new List<DataPoint>();
            var studentByGender = db.Students.GroupBy(c => c.Gender).
                  Select(g => new Models.GroupByResult
                  {
                      Key = g.Key.ToString(),
                      decimalValue = g.Count()
                  }).ToList();
            var feesResult = db.Fees.GroupBy(c => c.CreatedDate.Value.Month).
                      Select(g => new Models.GroupByResult
                      {
                          Key = g.Key.ToString(),
                          decimalValue = g.Sum(x => x.Amount)
                      }).ToList();
            var studentByGroup = db.Students.GroupBy(c => c.Shift).
                      Select(g => new Models.GroupByResult
                      {
                          Key = g.Key.ToString(),
                          Value = g.Count().ToString()
                      })/*.OrderByDescending(i => i.Value)*//*.Take(10)*/.ToList();
            foreach (var item in studentByGender)
            {
                dataPoints1.Add(new DataPoint(item.Key, double.Parse(item.decimalValue.ToString())));
            }
            foreach (var item in feesResult)
            {
                dataPoints.Add(new DataPoint(item.Key, double.Parse(item.decimalValue.ToString())));
            }

            foreach (var item in studentByGroup)
            {
                dataPoints2.Add(new DataPoint(item.Key, double.Parse(item.Value.ToString())));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints1);
            ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        [Route("httpError")]
        public IActionResult httpError(int code)
        {
            ViewBag.pTitle = "Oops! Something Went Wrong";

            if (code == 404)
            {
                ViewBag.ErrorMessage = "The requested page not found.";
            }
            else if (code == 500)
            {
                ViewBag.ErrorMessage = "My custom 500 error message.";
            }
            else
            {
                ViewBag.ErrorMessage = "An error occurred while processing your request.";
            }

            ViewBag.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            ViewBag.ShowRequestId = !string.IsNullOrEmpty(ViewBag.RequestId);
            ViewBag.ErrorStatusCode = code;

            return View();
        }
        [Route("Unauthorized")]
        public IActionResult Unauthorized(int code)
        {
            ViewBag.pTitle = "Oops! Something Went Wrong";

            if (code == 404)
            {
                ViewBag.ErrorMessage = "The requested page not found.";
            }
            else if (code == 500)
            {
                ViewBag.ErrorMessage = "My custom 500 error message.";
            }
            else
            {
                ViewBag.ErrorMessage = "An error occurred while processing your request.";
            }

            ViewBag.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            ViewBag.ShowRequestId = !string.IsNullOrEmpty(ViewBag.RequestId);
            ViewBag.ErrorStatusCode = code;

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
