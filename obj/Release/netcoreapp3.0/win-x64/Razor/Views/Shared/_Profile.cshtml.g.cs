#pragma checksum "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "806bb319682799c1439e8ff95a1c4b1f52c8b8ce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Profile), @"mvc.1.0.view", @"/Views/Shared/_Profile.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"806bb319682799c1439e8ff95a1c4b1f52c8b8ce", @"/Views/Shared/_Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd7bb3185fcd2acd35edeafe38ac740e76555db5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SchoolManagement.Models.db.TblUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "userUpdate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-success", new global::Microsoft.AspNetCore.Html.HtmlString("userUpdateOnSuccess"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-begin", new global::Microsoft.AspNetCore.Html.HtmlString("OnBegin"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-complete", new global::Microsoft.AspNetCore.Html.HtmlString("OnComplete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-failure", new global::Microsoft.AspNetCore.Html.HtmlString("OnFailure"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "https://code.jquery.com/jquery-3.7.1.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("integrity", new global::Microsoft.AspNetCore.Html.HtmlString("sha256-eKhayi8LEQwp4NKxN+CfCh+3qOVUtJn3QNZ0TciWLP4="), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("crossorigin", new global::Microsoft.AspNetCore.Html.HtmlString("anonymous"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/jquery-ui-1.14.1/jquery-ui.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_15 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/jquery-ui-1.14.1/jquery-ui.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 5 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
   string Imge = ""; string file = ""; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n<div class=\"content container-fluid\">\r\n\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "806bb319682799c1439e8ff95a1c4b1f52c8b8ce9678", async() => {
                WriteLiteral("\r\n        <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 437, "\"", 454, 1);
#nullable restore
#line 18 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
WriteAttributeValue("", 445, Model.Id, 445, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" id=\"UserId_\" name=\"userId\" />\r\n\r\n\r\n        ");
#nullable restore
#line 21 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"




    
        <div class=""card"">
            <div class=""card-body"">
                <div class=""row"">
                    <div class=""col-md-12"">
                        <div class=""about-info"">
                            <h4>Profile <span><a href=""javascript:;""><i class=""feather-more-vertical""></i></a></span></h4>
                        </div>
                        <div class=""student-profile-head"">
                            <div class=""row"">
                                <div class=""col-lg-4 col-md-4"">
                                    <div class=""profile-user-box"">
                                        <div class=""profile-user-img"">



");
#nullable restore
#line 42 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                             if (Model.Image != null)
                                            {
                                                Imge = Convert.ToBase64String(Model.Image);


#line default
#line hidden
#nullable disable
                WriteLiteral("                                                <img");
                BeginWriteAttribute("src", " src=\"", 1473, "\"", 1529, 1);
#nullable restore
#line 46 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
WriteAttributeValue("", 1479, string.Format("data:image/jpeg;base64,{0}", Imge), 1479, 50, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" height=\"150\" width=\"100\" />\r\n");
#nullable restore
#line 47 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"

                                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        </div>\r\n                                        <div class=\"names-profiles\">\r\n");
#nullable restore
#line 52 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                             if (Model.CanLogin == true)
                                            {


#line default
#line hidden
#nullable disable
                WriteLiteral("                                                <h4>");
#nullable restore
#line 55 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                               Write(Model.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("     <i class=\"fa fa-check-circle\"></i></h4>\r\n                                                <h5 style=\"text-align:center;\">(<small class=\"text-danger\">");
#nullable restore
#line 56 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                                                                                      Write(Model.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("</small>) </h5>\r\n");
#nullable restore
#line 57 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                            }
                                            else if (Model.CanLogin == false)
                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                <h4>");
#nullable restore
#line 60 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                               Write(Model.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("     <i class=\"fa fa-delete-left\"></i></h4>\r\n                                                <h5 style=\"text-align:center;\">(<small class=\"text-danger\">");
#nullable restore
#line 61 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                                                                                      Write(Model.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("</small>) </h5>\r\n");
#nullable restore
#line 62 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"


                                        </div>
                                    </div>
                                </div>
                                <div class=""col-lg-7 col-md-7 d-flex align-items-center"">
                                    <div class=""follow-group"">


                                        <div class=""students-follows"">
                                            <h5>Last Login</h5>
                                            <h5>");
#nullable restore
#line 75 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                           Write(Model.LastLogin);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n\r\n                                        </div>\r\n\r\n                                        <div class=\"students-follows\">\r\n                                            <h5>Created Date</h5>\r\n                                            <h5>");
#nullable restore
#line 81 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                           Write(Model.CreatedDate);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h5>

                                        </div>
                                        <div class=""students-follows login-danger"">
                                            <h5>Password</h5>
                                            <h5 id=""_Password"">");
#nullable restore
#line 86 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                                          Write(Model.Password);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n\r\n                                        </div>\r\n                                        <div class=\"students-follows login-danger\">\r\n                                            <h5>Can Login</h5>\r\n\r\n");
#nullable restore
#line 92 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                             if (Model.CanLogin == true)
                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                <input type=\"checkbox\"  name=\"CanLogin_\" checked />\r\n");
#nullable restore
#line 95 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                <input type=\"checkbox\"  name=\"CanLogin_\" />\r\n");
#nullable restore
#line 99 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                        </div>\r\n\r\n                                    </div>\r\n                                </div>\r\n");
                WriteLiteral(@"                            </div>
                        </div>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-lg-4"">

                        <div class=""student-personals-grp"">
                            <div class=""card mb-0"">
                                <div class=""card-body"">
                                    <div class=""heading-detail"">
                                        <h4>Assigned Role:</h4>
                                    </div>
                                    <div class=""skill-blk"">

");
#nullable restore
#line 126 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                         if (ViewBag.Role != null && ViewBag.dbRole != null)
                                        {
                                            int number = 1;
                                            foreach (var dbRole in ViewBag.dbRole)
                                            {
                                                bool roleMatched = false;
                                                foreach (var userRole in ViewBag.Role)
                                                {
                                                    if (dbRole.ToString() == userRole.UserRole.ToString()) // Compare enum values as strings
                                                    {
                                                        roleMatched = true;
                                                        break;
                                                    }
                                                }



#line default
#line hidden
#nullable disable
                WriteLiteral("                                                <div class=\"skill-statistics\">\r\n                                                    <div class=\"skills-head\">\r\n                                                        <h5>");
#nullable restore
#line 144 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                                       Write(dbRole);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5> <!-- Display the enum value directly -->\r\n                                                        <input type=\"checkbox\" name=\"Role\"");
                BeginWriteAttribute("value", " value=\"", 6822, "\"", 6837, 1);
#nullable restore
#line 145 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
WriteAttributeValue("", 6830, dbRole, 6830, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" ");
#nullable restore
#line 145 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                                                                                       Write(roleMatched ? "checked" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(" />\r\n                                                    </div>\r\n                                                </div>\r\n");
#nullable restore
#line 148 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                                number++;
                                            }
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"


                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""col-lg-8"">
                        <div class=""student-personals-grp"">
                            <div class=""card mb-0"">
                                <div class=""card-body"">

                                    <div class=""hello-park"">
                                        <h5>");
#nullable restore
#line 165 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
                                       Write(Model.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("  Review</h5>\r\n                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "806bb319682799c1439e8ff95a1c4b1f52c8b8ce23266", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 166 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                        <hr />


                                        <div class=""form-group local-forms"">
                                            <label>Select User <span class=""login-danger"">*</span></label>

                                            <input class=""form-control"" id=""txtClass"" type=""text"" placeholder=""Enter User Name"" autofocus style=""border-style:dashed"">

                                            <hr />
                                            <div class=""row"">


                                                <div class=""col-12 col-sm-6"">
                                                    <div class=""form-group local-forms"">
                                                        <label>New Password <span class=""login-danger"">*</span></label>
                                                        <input class=""form-control"" type=""password"" name=""NewPassword"" maxlength=""20"" placeholder=""******"">

                                            ");
                WriteLiteral(@"        </div>
                                                </div>
                                                <div class=""col-12 col-sm-6"">
                                                    <div class=""form-group local-forms"">
                                                        <label>Confirm Password <span class=""login-danger"">*</span></label>
                                                        <input class=""form-control"" type=""password"" name=""ConfirmPassword"" maxlength=""20"" placeholder=""******"">
");
                WriteLiteral(@"                                                    </div>
                                                </div>


                                                <div class=""col-12"">
                                                    <div class=""student-submit"">
                                                        <button type=""submit"" class=""btn btn-primary"">Submit</button>
                                                    </div>
                                                </div>
                                            </div>





                                        </div>




                                    </div>


                                </div>


                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "806bb319682799c1439e8ff95a1c4b1f52c8b8ce29593", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
#nullable restore
#line 228 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Profile.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "806bb319682799c1439e8ff95a1c4b1f52c8b8ce31374", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "806bb319682799c1439e8ff95a1c4b1f52c8b8ce32491", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_15);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script>

    function OnBegin() {

        $('.page-loader').show();

    }
    function userUpdateOnSuccess(data) {

        //swal(""Saved!"",  data.message, ""success"");



        $('#userUpdateDiv').html(data); // Replace the list with the updated content


    }
    function OnComplete() {
        $('.page-loader').hide();

    }
</script>




<script>

    $('#txtClass').autocomplete({

        minlength: 1,
        source: function (request, response) {


            var SearchText = $('#txtClass').val();

            $('#txtClass').removeClass('notfound');
            $('#txtClass').addClass('loading');

            $.ajax({

                type: ""POST"",
                async: true,
                url: ""/Account/getUserByName"",
                //data: ""{term:'"" + SearchText + ""'}"",
                data: { ""term"": SearchText },
                //contentType: ""application/json;characterset=utf-8"",

                success: function (data) {
           ");
            WriteLiteral(@"         if (data.length == 0) {

                        $('#txtClass').removeClass('loading');
                        $('#txtClass').addClass('notfound');


                    }
                    else {
                        $('#txtClass').removeClass('loading');


                    }

                    response($.map(data, function (item) {
                        return { label: item.Name, value: item.UserId };
                    }))

                },

                error: function (result) {
                    debugger

                    console.log(result);
                }
            });



        },

        select: function (event, ui) {

            $('#txtClass').val(ui.item.label);

            $('#UserId_').val(ui.item.value);
            $('#txtClass').removeClass('notfound');
            $('#txtClass').addClass('checked');
            $('.page-loader').show();
            $.ajax({

                type: ""POST"",
                async:");
            WriteLiteral(@" true,
                url: ""/Account/getUserPassword"",
                //data: ""{term:'"" + SearchText + ""'}"",
                data: { ""term"": ui.item.value },
                //contentType: ""application/json;characterset=utf-8"",

                success: function (data) {
                    $('.page-loader').hide();

                    //$(""#_Password"").text(data.Password);
                    //$(""#Password"").val(data.Password);

                    $('#userUpdateDiv').html(data); // Replace the list with the updated content



                },

                error: function (result) {
                    debugger

                    console.log(result);
                }
            });

            return false;

        },



    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SchoolManagement.Models.db.TblUser> Html { get; private set; }
    }
}
#pragma warning restore 1591