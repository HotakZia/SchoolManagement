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
