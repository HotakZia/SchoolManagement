#pragma checksum "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_LoginPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "228c3caa8b3684886cf90944fba8f2a94fe55360"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LoginPartial), @"mvc.1.0.view", @"/Views/Shared/_LoginPartial.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\_ViewImports.cshtml"
using SchoolManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\_ViewImports.cshtml"
using SchoolManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"228c3caa8b3684886cf90944fba8f2a94fe55360", @"/Views/Shared/_LoginPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd7bb3185fcd2acd35edeafe38ac740e76555db5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LoginPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SchoolManagement.Models.Users>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n\r\n<script src=\'https://www.google.com/recaptcha/api.js\'></script>\r\n\r\n<div style=\"  display: flex;\r\n      justify-content: center;\">\r\n    ");
#nullable restore
#line 10 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_LoginPartial.cshtml"
Write(Html.ValidationSummary(true, "", new { @class = "text-danger text-align:center" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "228c3caa8b3684886cf90944fba8f2a94fe553604172", async() => {
                WriteLiteral("\r\n    <div class=\"form-group\">\r\n        <label>Username <span class=\"login-danger\">*</span></label>\r\n        <input class=\"form-control\"");
                BeginWriteAttribute("value", "  value=\"", 428, "\"", 455, 1);
#nullable restore
#line 16 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_LoginPartial.cshtml"
WriteAttributeValue("", 437, ViewBag.loginName, 437, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" type=""text"" name=""EmailId"">
        <span class=""profile-views""><i class=""fas fa-user-circle""></i></span>
    </div>
    <div class=""form-group"">
        <label>Password <span class=""login-danger"">*</span></label>
        <input value=""123456"" class=""form-control pass-input"" type=""text"" name=""Password"">
        <span class=""profile-views feather-eye toggle-password""></span>
    </div>
");
#nullable restore
#line 24 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_LoginPartial.cshtml"
     if (ViewBag.Connection == true)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"login_footer form-group d-flex justify-content-between\">\r\n            <div id=\"rR\" class=\"g-recaptcha\" data-sitekey=\"6LcCtQIqAAAAAEXZkytzq7UtrWm8dXANLxfZ9PZo\"></div>\r\n\r\n\r\n\r\n        </div>\r\n");
#nullable restore
#line 32 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_LoginPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    <div class=""forgotpass"">
        <div class=""remember-me"">
            <label class=""custom_check mr-2 mb-0 d-inline-flex remember-me"">
                Remember me
                <input type=""checkbox"" name=""RememberMe"">
                <span class=""checkmark""></span>
            </label>
        </div>
        <a href=""forgot-password.html"">Forgot Password?</a>
    </div>
    <div class=""form-group"">
        <button class=""btn btn-primary btn-block"" type=""submit"">Login</button>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SchoolManagement.Models.Users> Html { get; private set; }
    }
}
#pragma warning restore 1591