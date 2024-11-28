using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobBoard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Models.db;
using SchoolManagement.Models;
using System.Net.Http;

namespace SchoolManagement.Controllers
{
    public class AccountController : Controller
    {
        public SchoolManagement.Models.db.School_dbContext db = new Models.db.School_dbContext();
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        //public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //}

        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            ViewBag.pTitle = "Join Us: Register for Exclusive Access and Benefits in Afghanistan";


            return View();
        }

        [HttpPost]
       
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        public async Task<IActionResult> LogOut( )
        {
           await AuthenticationHttpContextExtensions.SignOutAsync(HttpContext
                   , CookieAuthenticationDefaults.AuthenticationScheme);
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //HttpContext.Response.Cookies.Delete(".AspNetCore.Cookies"); // Clear authentication cookies
            return RedirectToAction("Login", "Account");

        }
       //[Route("login")]
        public async Task<IActionResult> LoginAsync(string returnUrl)
        {
            return RedirectToAction("Index", "Home");
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.pTitle = "Welcome Back: Log in for Access to Exclusive Content";

            dynamic showMessageString = string.Empty;
            bool connection = false;

            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync("http://www.google.com"))
                    {
                        connection = true;
                    }
                }
            }
            catch (Exception ex)
            {

                connection=false;
            }
           
            ViewBag.Connection = connection;
            var checkuser = db.TblUsers.Count();
            
            if (checkuser <= 0)
            {
                try
                {


                   Models.db.TableCompany tbl_Company  = new TableCompany();
                    tbl_Company.Id = Guid.NewGuid();
                    tbl_Company.Location = "Kabul, Afghanistan";
                    tbl_Company.Name = "Hadaf.AF";
                    tbl_Company.CreateTime = DateTime.Now;
                    tbl_Company.Description = "nil";
                    tbl_Company.Email = "info@hadaf.af";
                    tbl_Company.FacebookName = "nil";
                    tbl_Company.PhoneNumber = "93700339966";
                    tbl_Company.TwitterName = "nil";
                    tbl_Company.Website = "nil";
                    tbl_Company.Type = "administrator";
                    tbl_Company.TwitterName = "nil";
                    tbl_Company.TagLine = "ICT Solutions";
                    tbl_Company.LogoName = "";
                    tbl_Company.LogoType = "";
                    db.TableCompanies.Add(tbl_Company);


                    Models.db.TblUser tbl_User = new TblUser();
                    tbl_User.Id = Guid.Empty;
                    tbl_User.Name = "Administrator";
                    Hashing hashing = new Hashing();
                    tbl_User.Password = hashing.Encrypt("MyPasswordIs!123");
                    tbl_User.CanLogin = true;
                    //tbl_User.Posation = "Administrator";
                    //tbl_User.Phone = "0700 339966";
                    //tbl_User.CreateTime = DateTime.Now;
                    //tbl_User.CompanyId = tbl_Company.Id;
                    tbl_User.Email = "info@hadaf.af";
                    db.TblUsers.Add(tbl_User);

                    TableRole tbl_Role = new TableRole();
                    tbl_Role.Id = Guid.NewGuid();
                    tbl_Role.RoleType = "Administrator Users";
                    tbl_Role.UserId = tbl_User.Id;
                    tbl_Role.UserRole = "admin";
                    db.TableRoles.Add(tbl_Role);
                    tbl_Role = new TableRole();
                    tbl_Role.Id = Guid.NewGuid();
                    tbl_Role.RoleType = "Authorize";
                    tbl_Role.UserId = tbl_User.Id;
                    tbl_Role.UserRole = "Authorize";
                    db.TableRoles.Add(tbl_Role);

                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            ClaimsPrincipal claimsPrincipal = HttpContext.User;
            if (claimsPrincipal.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

      
   
        public static CaptchaResponse ValidateCaptcha(string response)
        {
            string secret = "6LcCtQIqAAAAADCN9kR2nXeX_KITR_TBCzmrc8St";
            var client = new WebClient();
            var jsonResult = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            return JsonConvert.DeserializeObject<CaptchaResponse>(jsonResult.ToString());
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind] Users model)
        {
            
            dynamic showMessageString = string.Empty;
            bool connection = false;
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response =  client.GetAsync("http://www.google.com"))
                    {
                        connection = true;
                    }
                }
            }
            catch (Exception ex)
            {

                connection=false;
            }
           
           
        

            ViewBag.email = model.EmailId;
            if (connection)
            {
                CaptchaResponse response = ValidateCaptcha(Request.Form["g-recaptcha-response"]);
                if (response.Success != true)
                {
                    showMessageString = new
                    {
                        status = "rFalse",
                        message = response.ErrorMessage
                    };
                    ModelState.AddModelError("", "verify that you are not robot.");
                    return PartialView("_LoginPartial", model);
                }
            }
            var user = db.TblUsers.Where(x => x.Email == model.EmailId).FirstOrDefault();/* new Users().GetUsers().Where(u => u.UserName == userModel.UserName).SingleOrDefault();*/

            var s = db.TblUsers.FirstOrDefault();

            if (user != null)
            {

                var decod = new Models.Hashing();
                string password = decod.Decrypt(user.Password);
                if (model.Password != decod.Decrypt(user.Password))
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                    return PartialView("_LoginPartial", model);
                }
                if (user.CanLogin != true)
                {
                    ModelState.AddModelError("", "Account is block.");
                    return PartialView("_LoginPartial", model);
                }
                var userClaims = new List<Claim>()
                {
                    new Claim("UserName",user.Name),
                    new Claim("userId", user.Id.ToString()),
                     new Claim("Email", user.Email),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    //new Claim(ClaimTypes.DateOfBirt,DateTime.Parse(user.CreateTime).ToString()),
                    //new Claim(ClaimTypes.Role,db.TblRole.Where(x=>x.UserId==user.Id).Select(x=>x.UserRole).FirstOrDefault())
                 };
                // Get the roles from the database for the user
                var userRoles = db.TableRoles.Where(x => x.UserId == user.Id).Select(x => x.UserRole).ToList();

                // Add role claims to userClaims
                userClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));
                userClaims.AddRange(userRoles.Select(role => new Claim("Roles", role)));
                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                HttpContext.SignInAsync(userPrincipal);

                showMessageString = new
                {
                    status = "true",
                    message = "success"
                };

                //return Json("true");
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Inviled user or password.");
                return PartialView("_LoginPartial", model);
            }
           
        }

        [HttpGet]
        [Route("Account/AccessDenied")]
        [Route("AccessDenied")]
        public ActionResult AccessDenied()
        {
            ViewBag.pTitle = "IT Solutions in Afghanistan | Jobs, Projects, Workers";
            return View();
        }

        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}
    }
}