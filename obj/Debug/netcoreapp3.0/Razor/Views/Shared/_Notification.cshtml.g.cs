#pragma checksum "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Notification.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cfaaf6128e8eb81c00ab90f80d6d9cc88b7d1857"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Notification), @"mvc.1.0.view", @"/Views/Shared/_Notification.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfaaf6128e8eb81c00ab90f80d6d9cc88b7d1857", @"/Views/Shared/_Notification.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd7bb3185fcd2acd35edeafe38ac740e76555db5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Notification : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SchoolManagement.Models.db.Notice>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("avatar-img rounded-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("User Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/template/assets/img/speaker.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Notices", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    <ul class=\"notification-list\">\r\n");
#nullable restore
#line 3 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Notification.cshtml"
         foreach (var item in Model)
        {
            item.Comment = new string(item.Comment?.Take(20).ToArray());


            // Calculate the time difference from the past date to the current date
            TimeSpan timeDifference = DateTime.Now - item.CreatedDate.Value;

            // Extract days, hours, and minutes from the time difference
            int daysDifference = timeDifference.Days;
            int hoursDifference = timeDifference.Hours;
            int minutesDifference = timeDifference.Minutes;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"notification-message\">\r\n\r\n\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cfaaf6128e8eb81c00ab90f80d6d9cc88b7d18575890", async() => {
                WriteLiteral("\r\n                    <div class=\"media d-flex\">\r\n                        <span class=\"avatar avatar-sm flex-shrink-0\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "cfaaf6128e8eb81c00ab90f80d6d9cc88b7d18576300", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </span>\r\n                        <div class=\"media-body flex-grow-1\">\r\n                            <p class=\"noti-details\"><span class=\"noti-title\">");
#nullable restore
#line 24 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Notification.cshtml"
                                                                        Write(item.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>");
#nullable restore
#line 24 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Notification.cshtml"
                                                                                          Write(item.RegisterNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <span class=\"noti-title\">");
#nullable restore
#line 24 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Notification.cshtml"
                                                                                                                                        Write(item.Comment);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></p>\r\n                            <p class=\"noti-time\">\r\n                                <span class=\"notification-time\">\r\n                                    ");
#nullable restore
#line 27 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Notification.cshtml"
                                Write(daysDifference > 1 ? $"{daysDifference} days, " : "");

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    ");
#nullable restore
#line 28 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Notification.cshtml"
                                Write(hoursDifference > 1 ? $"{hoursDifference} hours, " : "");

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    ");
#nullable restore
#line 29 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Notification.cshtml"
                                Write(minutesDifference > 1 ? $"{minutesDifference} minutes ago" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </span>\r\n                            </p>                        </div>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 18 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Notification.cshtml"
                                                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </li>\r\n");
#nullable restore
#line 35 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Shared\_Notification.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n       \r\n    </ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SchoolManagement.Models.db.Notice>> Html { get; private set; }
    }
}
#pragma warning restore 1591