﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;



namespace SchoolManagement.Controllers
{
    //[Authorize(Roles = ("Authorize"))]

    public class BaseController : Controller
    {
      
        public dynamic showMessageString = string.Empty;
        #region Localization
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });
            return Redirect(Request.Headers["Referer"].ToString());
        }
        #endregion
        public SchoolManagement.Models.db.School_dbContext db = new SchoolManagement.Models.db.School_dbContext();
       
    }

}