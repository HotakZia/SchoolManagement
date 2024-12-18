using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolManagement.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
        public string[] bannedWords = { "arse", "arsehead", "arsehole", "ass", "ass hole", "asshole", "bastard", "bitch", "bloody", "bollocks", 
            "brotherfucker", "bugger", "bullshit", "child-fucker", "Christ on a bike", "Christ on a cracker", "cock", "cocksucker", 
            "crap", "cunt", "dammit", "damn", "damn it", "damned", "dick", "dick-head", "dickhead", "dumb ass", "dumb-ass", "dumbass", 
            "dyke", "father-fucker", "fatherfucker", "frigger", "fuck", "fucker", "fucking", "god dammit", "God damn", "god damn",
            "goddammit", "goddamn", "Goddamn", "goddamned", "goddamnit", "godsdamn", "hell", "holy shit", "horseshit", "in shit",
            "jack-ass", "jackarse", "jackass", "Jesus Christ", "Jesus fuck", "Jesus H. Christ", "Jesus Harold Christ", "Jesus," +
                " Mary and Joseph", "Jesus wept", "kike", "mother fucker", "mother-fucker", "motherfucker", "nigga", "nigra", 
            "pigfucker", "piss", "prick", "pussy", "shit", "shit ass", "shite", "sibling fucker", "sisterfuck", "sisterfucker", 
            "slut", "son of a whore", "son of a bitch", "spastic", "sweet Jesus", "twat", "wanker", "ارامونى", "اراموني", "ارمني",
            "ارمنی", "ارمونى", "پيشي", "پیشی", "تي", "تی", "حرامونى", "حراموني", "حرمنى", "حیوان", "خبيث", "خبيس", "خبيص", "خر",
            "خرکوس", "خرې", "خری", "دله", "رنډۍ", "رنډياني", "رنډی", "سپي", "سپی", "سمبۍ", "سومبې", "سومبۍ", "سومبى", "سومبي",
            "غرتک", "غنړ", "غڼ", "غول", "غونکى", "غونکي", "غوول", "غوولى", "غوولى", "غوولي", "غوونکي", "غوونکی", "غېم", "غيم",
            "غئم", "کوس", "کوستيزن", "کوسمادر", "کوناټي", "کوناټی", "کونه", "کوني", "کونی", "لعنت", "لعنتی", "لغنتي", "مردار",
            "مرداري", "مرداری", "ملعون", "منډل", "منډونکي", "منډونکی", "ومنډم", "بړوه" ,
        "رامش خاطر", "صلح", "ارمنی", "ارمنی", "هارمونی", "اشتغال", "گربه", "بر", "تی", "ممنوع", "ممنوع", 
            "پناهگاه من", "حیوان", "بد", "خوب", "خبیس ها", "الاغ", "خارکوس", "خر", "خر", "قلب", "راندی", 
            "رندیانی", "رندی", "سگ ها", "سگ", "سامبی", "دوشنبه", "زامبی ها", "زامبی", "زامبی", "غارتک", 
            "محکوم کردن", "ترانه", "غول", "خواننده", "خواننده ها", "برای خوردن", "غول", "غول", "مسخره", "خواران", 
            "خواننده", "غم", "غم و اندوه", "گوهر", "Cos", "هزینه دار", "مادر کیهانی", "کوناتی", "کوناتی", "آرنج", 
            "انجام دادن", "کانی", "لعنت", "نفرین شده", "لاغناتی", "مرده", "مرگ", "مرگ و میر", "نفرین شده", "ماندال",
            "دونده ها", "دونده", "من می خواهم", "بزرگ", "ذہنی سکون", "امن", "آرمینیائی", "آرمینیائی", "ہم آہنگی", 
            "پیشہ", "کیٹ", "پر", "ٹی", "ممنوعہ", "ممنوعہ", "میری پناہ گاہ", "جانور", "برائی", "اچھی", "خبیث",
            "گدھا", "کھڑکوس", "گدھا", "گدھا", "دل", "رنڈی","فوشته","جغاله"
        };

    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
      
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<SelectListItem> Providers { get; set; }
    }
}