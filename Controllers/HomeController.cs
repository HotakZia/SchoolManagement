using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QRCoder;
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
    
            public async Task<IActionResult> LoadIdCard(Guid? Id)
        {
            //PM> Install-Package QRCoder
            var list = new Models.Entities.IdCard();
            var student = db.Students.Where(x => x.StudentId == Id).FirstOrDefault();
            var teacher = new Models.db.Teacher();
            if (student==null)
            {
                teacher = db.Teachers.FirstOrDefault();
                list.Name = teacher.FirstName + " " + teacher.LastName;
                list.IdCardNumber = teacher.RoleNumber;
                list.Attachment = teacher.Attachment;
                list.Position = teacher.Position;
                list.ExpireDate = DateTime.Now.AddYears(2);
         
                    
            }
            else
            {
              
                list.Name = student.FirstName + " " + teacher.LastName;
                list.IdCardNumber = student.RoleNumber;
                list.Attachment = student.Attachment;
                list.Position = "Student";
                list.ExpireDate = DateTime.Now.AddYears(2);
            }
            ViewBag.SystemInfo = db.TableCompanies.FirstOrDefault();


            // Convert model data to JSON for QR code encoding
            string jsonData = JsonConvert.SerializeObject("Info: "+list.Name+list.IdCardNumber+list.Position+list.ExpireDate);

            // Generate QR code from the JSON data
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            //QRCodeData qrCodeData = qrGenerator.CreateQrCode("Hello, World!", QRCodeGenerator.ECCLevel.Q);
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(jsonData, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);

            using (MemoryStream stream = new MemoryStream())
            {
                qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                byte[] qrCodeImageBytes = stream.ToArray();

               list.QRcode = Convert.ToBase64String(qrCodeImageBytes);
            }
            return PartialView("_IdCard",list);
        }
        public async Task<IActionResult> LoadClassIdCards(Guid? Id)
        {
            var list = new List<Models.Entities.IdCard>();
            var student = db.Students.Where(x => x.ClassId == Id).ToList();

            foreach (var item in student)
            {



                list.Add(new Models.Entities.IdCard { Attachment = item.Attachment, IdCardNumber = item.RoleNumber,

                     Name = item.FirstName + " " + item.LastName, ExpireDate = DateTime.Now.AddYears(2), Position = "Student" });


             
            }
            foreach (var item in list)
            {
                // Convert model data to JSON for QR code encoding
                string jsonData = JsonConvert.SerializeObject("Info: " + item.Name + item.IdCardNumber + item.Position + item.ExpireDate);
                // Generate QR code from the JSON data
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                //QRCodeData qrCodeData = qrGenerator.CreateQrCode("Hello, World!", QRCodeGenerator.ECCLevel.Q);
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(jsonData, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(10);

                using (MemoryStream stream = new MemoryStream())
                {
                    qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] qrCodeImageBytes = stream.ToArray();

                    item.QRcode = Convert.ToBase64String(qrCodeImageBytes);
                }
            }

              
            
            ViewBag.SystemInfo = db.TableCompanies.FirstOrDefault();
            return PartialView("_IdCardsList", list);
        }
        public async Task<IActionResult> Setting()
        {
            var list = db.TableCompanies.FirstOrDefault();
            return View(list);
        }
      
     public async Task<IActionResult> SettingSave(Models.db.TableCompany  company, IFormFile Image)
        {
            try
            {


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
                            company.Logo = fileBytes;

                        }
                    }
                }
                var setting = db.TableCompanies.FirstOrDefault();
                db.TableCompanies.Remove(setting);
             
                company.Creator = Guid.Empty;
     
                db.TableCompanies.Add(company);
             
                db.SaveChanges();
                showMessageString = new
                {
                    status = "true",
                    message = "the setting info has been update."

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
        public async Task<IActionResult> getActiveScedule()
        {
            string day = DateTime.Now.DayOfWeek.ToString();
            int year = DateTime.Now.Year;
            var list = (from subject in db.TimeTables
                              join class_ in db.Classes on subject.ClassId equals class_.Id
                              join assignee in db.Schedules on subject.SubjectId equals assignee.Id
                              join teacher in db.Teachers on assignee.TeacherId equals teacher.TeacherId
                              where assignee.Status == true&&subject.Status==true &&subject.Year==year&&subject.DayOfWeek==day

                              select new Models.Entities.Schedual
                              {
                                  Shift = assignee.Shift,                                
                                  Status = assignee.Status,
                                  SubjecName = assignee.Subject,
                                  Id = teacher.TeacherId,
                                  TeacherName = teacher.FirstName + " " + teacher.LastName,
                                  Year = subject.Year,
                                  HourOfDay=subject.HourOfDay,
                                  DayOfWeek=subject.DayOfWeek,
                                  ClassName=class_.Name,
                                  ClassId=class_.Id,
                                 

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
                                        //where Schedule.ClassId == class_.Id
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
            Guid Id =Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "userId").Value.ToString());



ViewBag.hourCount = (from subject in db.TimeTables
                  join assignee in db.Schedules on subject.SubjectId equals assignee.Id
                  join teacher in db.Teachers on assignee.TeacherId equals teacher.TeacherId
                  where subject.Status == true
                  select new
                  {
                     
                  }).Count();

 



            ViewBag.subjectCount = db.Schedules.Where(x => x.TeacherId == Id).Count();
            ViewBag.classCount = (from class_ in db.Classes
                                  join assignee in db.Schedules on class_.Grad equals assignee.Grad
                                  join teacher in db.Teachers on assignee.TeacherId equals teacher.TeacherId
                                  where assignee.Status == true

                                  select new 
                                  {



                                  }).Count();
            ViewBag.studentCount = db.Students.Count();
            var list = (from class_ in db.TimeTables
                                  join shc in db.Schedules on class_.SubjectId equals shc.Id
                                  join teacher in db.Teachers on shc.TeacherId equals teacher.TeacherId
                        join classlist in db.Classes on class_.ClassId equals classlist.Id
                        where shc.TeacherId == Id

                                  select new Models.Entities.TimeTable
                                  {
                                      Id = class_.Id,
                                      ClassId = class_.Id,
                                      ClassName=classlist.Name,
                                      Subject = shc.Subject,
                                      SubjectId = shc.Id,
                                      DayOfWeek = class_.DayOfWeek,
                                      HourOfDay = class_.HourOfDay,
                                      CreatedBy = class_.CreatedBy,
                                      CreatedDate = class_.CreatedDate,
                                      ModifiedBy = class_.ModifiedBy,
                                      ModifiedDate = class_.ModifiedDate,
                                      Number = class_.Number,
                                      Status = class_.Status,
                                      Year = class_.Year,
                                      Teacher = teacher.FirstName + " " + teacher.LastName,
                                  }).ToList();
            return View(list);

        }
        [Route("student")]

        [Authorize(Roles = ("Student"))]
        public IActionResult Student()
        {
            Guid Id = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "userId").Value.ToString());
            var Student = db.Students.Where(x => x.StudentId == Id).FirstOrDefault();
            var classs = db.Classes.Where(x => x.Id == Student.ClassId).FirstOrDefault();
            ViewBag.Subject = db.Schedules.Where(x => x.Grad == classs.Grad).Count();
            ViewBag.Exam = db.Exams.Where(x => x.StudentId == Id).Count();
            ViewBag.Fees = db.Transactions.Where(x => x.RelationId == Id).Count();
           
            var list = (from class_ in db.TimeTables
                        join shc in db.Schedules on class_.SubjectId equals shc.Id
                        join teacher in db.Teachers on shc.TeacherId equals teacher.TeacherId
                        where class_.ClassId == Student.ClassId

                        select new Models.Entities.TimeTable
                        {
                            Id = class_.Id,
                            ClassId = class_.Id,
                            Subject = shc.Subject,
                            SubjectId = shc.Id,
                            DayOfWeek = class_.DayOfWeek,
                            HourOfDay = class_.HourOfDay,
                            CreatedBy = class_.CreatedBy,
                            CreatedDate = class_.CreatedDate,
                            ModifiedBy = class_.ModifiedBy,
                            ModifiedDate = class_.ModifiedDate,
                            Number = class_.Number,
                            Status = class_.Status,
                            Year = class_.Year,
                            Teacher = teacher.FirstName + " " + teacher.LastName,
                        }).ToList();
            return View(list);
        }
        [Route("dashboard")]

        [Authorize(Roles = ("Admin"))]
        public IActionResult Index()
        {
            ViewBag.Student = db.Students.Where(x => x.Status == true).Count();
            ViewBag.Class = db.Classes.Where(x => x.Status == true).Count();
            ViewBag.Staff = db.Teachers.Where(x => x.Status == true).Count();
            ViewBag.Subject = db.Schedules.Where(x => x.Status == true).Count();
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
