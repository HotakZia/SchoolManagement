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
            //return RedirectToAction("Index", "Home");
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
                    tbl_Company.PhoneNumber = "93700";
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
                    tbl_User.UserId = Guid.Empty;
                    tbl_User.Name = "Administrator";
                    Hashing hashing = new Hashing();
                    tbl_User.Password = hashing.Encrypt("admin");
                    tbl_User.CanLogin = true;
                    //tbl_User.Posation = "Administrator";
                    //tbl_User.Phone = "0700 339966";
                    //tbl_User.CreateTime = DateTime.Now;
                    //tbl_User.CompanyId = tbl_Company.Id;
                    tbl_User.Email = "school@hadaf.af";
                    tbl_User.Role = "Admin";
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
            ViewBag.loginName = model.EmailId;
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


            if (user != null)
            {

                var decod = new Models.Hashing();
                string password = decod.Decrypt(user.Password);
                if (model.Password != decod.Decrypt(user.Password))
                {
                    ModelState.AddModelError("", "invalid username or password. please try again");
                    return PartialView("_LoginPartial", model);
                }
                if (user.CanLogin != true)
                {
                    ModelState.AddModelError("", "account is disabled contact your administrator.");
                    return PartialView("_LoginPartial", model);
                }
                string base64Image = "na";
                if (user.Image!=null)
                {
                     base64Image = Convert.ToBase64String(user.Image);
                }
               
                var userClaims = new List<Claim>()
                {
                    new Claim("UserName",user.Name),
                    new Claim("userId", user.UserId.ToString()),
                     new Claim("Email", user.Email),
                     //new Claim("Image", base64Image),
                     //new Claim("profil",base64Image),
                new Claim("Role", user.Role),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    //new Claim(ClaimTypes.DateOfBirt,DateTime.Parse(user.CreateTime).ToString()),
                    //new Claim(ClaimTypes.Role,db.TblRole.Where(x=>x.UserId==user.Id).Select(x=>x.UserRole).FirstOrDefault())
                 };
                // Get the roles from the database for the user
                var userRoles = db.TableRoles.Where(x => x.UserId == user.Id).Select(x => x.UserRole).ToList();

                // Add role claims to userClaims
                //userClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));
                userClaims.AddRange(userRoles.Select(role => new Claim("Roles", role)));
                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                HttpContext.SignInAsync(userPrincipal);

                showMessageString = new
                {
                    status = "true",
                    message = "success",
                    role=user.Role,
                };
                user.LastLogin = DateTime.Now;
                db.Update(user);
                db.SaveChanges();
                if (model.RememberMe)
                {
                    // Extend the cookie expiration time for "Remember Me" option
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.Now.AddDays(7) // Extend expiration by 7 days
                    };

                     HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(userIdentity), authProperties);
                }
                return Json(showMessageString);
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
        public ActionResult Profile(Guid Id)
        {
    
            return View();
        }
        public ActionResult PasswordReset (ResetPasswordModel model,Guid userId, string OldPassword)
        {
            var hashing = new Models.Hashing();
        
            if (ModelState.IsValid)
            {
                var user = db.TblUsers.Where(x => x.UserId == userId).FirstOrDefault();

                if (OldPassword==hashing.Decrypt(user.Password))
                {
                    user.Password = hashing.Encrypt(model.Password);
                    db.TblUsers.Update(user);
                    db.SaveChanges();
                    
                    ModelState.AddModelError("", "the password has been changed.");
                    return PartialView("_PasswordReset", model);
                }
                else
                {
                    ModelState.AddModelError("","Wrong user and passowrd!");
                    return PartialView("_PasswordReset", model);
                }
               

                
            }
          
            return PartialView("_PasswordReset",model);
        }

        public ActionResult userUpdate(TblUser model, Guid userId, string NewPassword, string ConfirmPassword,string CanLogin_, List<string> Role)
        {
            var hashing = new Models.Hashing();
            ViewBag.Role = db.TableRoles.Where(x => x.UserId == userId).ToList();
            ViewBag.dbRole = Enum.GetValues(typeof(MyEnums.UserLoginRule)).Cast<MyEnums.UserLoginRule>().ToList();
            if (ModelState.IsValid)
            { }
            if (CanLogin_=="on")
            {
                model.CanLogin = true;
            }
            else
            {
                model.CanLogin = false;
            }
                var user = db.TblUsers.Where(x => x.Id == userId).FirstOrDefault();

                if (!string.IsNullOrEmpty(NewPassword))
                {
                    if (NewPassword==ConfirmPassword)
                    {
                        user.Password = hashing.Encrypt(NewPassword);
                       
                        
                    }
                    else
                    {
                        ModelState.AddModelError("", "The new password and confirmation password do not match.");
                    return PartialView("_Profile", user);
                }
                }

            user.CanLogin = model.CanLogin;
            db.TblUsers.Update(user);
            if (Role.Count>=1)
                {
                    var userRole = db.TableRoles.Where(x => x.UserId == userId).ToList();
                    foreach (var item in userRole)
                    {
                        db.TableRoles.Remove(item);
                    }
                    var newRole = new TableRole();
                    foreach (var item in Role)
                    {
                        newRole = new TableRole();
                        newRole.Id = Guid.NewGuid();
                        newRole.UserId = userId;
                        newRole.UserRole = item;
                        newRole.RoleType = item;
                        db.TableRoles.Add(newRole);
                    }
                }
              
                    db.SaveChanges();

            ViewBag.Role = db.TableRoles.Where(x => x.UserId == userId).ToList();
            ViewBag.dbRole = Enum.GetValues(typeof(MyEnums.UserLoginRule)).Cast<MyEnums.UserLoginRule>().ToList();
            user.Password = hashing.Decrypt(user.Password);
            ModelState.AddModelError("", "the user has been updated.");
                    return PartialView("_Profile", user);
           



            

            return PartialView("_PasswordReset", model);
        }

        
                 [HttpPost]
        public async Task<IActionResult> getUserByName(string term)
        {

            var list =  (from user_ in db.TblUsers


                              where user_.Name.StartsWith(term)

                              select new Models.db.TblUser
                              {

                                  UserId = user_.Id,

                                  Name = user_.Name + " - " +user_.Role +" / "+user_.Email,



                              })/*.OrderByDescending(x => x.CreatedDate)*/.ToList();
            return Json(list);
        }
        [HttpPost]
        public async Task<IActionResult> getUserPassword(Guid term)
        {

            var user = db.TblUsers.Where(x => x.Id == term).FirstOrDefault();
            Hashing hashing = new Hashing();
            user.Password = hashing.Decrypt(user.Password);


         

            ViewBag.Role = db.TableRoles.Where(x => x.UserId == user.Id).ToList();
            ViewBag.dbRole = Enum.GetValues(typeof(MyEnums.UserLoginRule)).Cast<MyEnums.UserLoginRule>().ToList();

            return PartialView("_Profile", user);
        }
        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}
    }
}