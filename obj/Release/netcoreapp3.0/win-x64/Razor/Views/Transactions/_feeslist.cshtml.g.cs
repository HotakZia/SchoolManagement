#pragma checksum "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "229a09a957c618f66b0f930d34dbc3cfbd02beae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transactions__feeslist), @"mvc.1.0.view", @"/Views/Transactions/_feeslist.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"229a09a957c618f66b0f930d34dbc3cfbd02beae", @"/Views/Transactions/_feeslist.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd7bb3185fcd2acd35edeafe38ac740e76555db5", @"/Views/_ViewImports.cshtml")]
    public class Views_Transactions__feeslist : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SchoolManagement.Models.Entities.Student>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Teachers", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- Datatables CSS -->
<div class=""table-responsive"">
    <table class=""table border-0 star-student table-hover table-center mb-0 datatable table-striped"">
        <thead class=""student-thread"">
            <tr>

                <th>ID</th>
                <th>Student Name</th>
                <th>GuardianName</th>
                <th>Paid</th>



                <th class=""text-end"">Action</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 19 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
             foreach (var item in Model)
            {
                string Imge = "";
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                 if (item.PayFeesCount >= 1 && item.PayFeesCount == item.AssignFeesCount)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n\r\n\r\n\r\n                        <td>");
#nullable restore
#line 28 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                       Write(item.RoleNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 30 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                         if (item.Attachment != null)
                        {
                            Imge = Convert.ToBase64String(item.Attachment);

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "229a09a957c618f66b0f930d34dbc3cfbd02beae5677", async() => {
                WriteLiteral("\r\n\r\n\r\n\r\n                                    <img");
                BeginWriteAttribute("src", " src=\"", 1171, "\"", 1226, 1);
#nullable restore
#line 38 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
WriteAttributeValue("", 1177, string.Format("data:image/jpeg;base64,{0}",Imge), 1177, 49, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"img-fluid avatar-lg rounded\" />\r\n                                    ");
#nullable restore
#line 39 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                               Write(item.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 39 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                                               Write(item.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                                                                                    WriteLiteral(item.StudentId);

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
            WriteLiteral("\r\n                            </td>\r\n");
#nullable restore
#line 42 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "229a09a957c618f66b0f930d34dbc3cfbd02beae9655", async() => {
                WriteLiteral("\r\n                                    ");
#nullable restore
#line 47 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                               Write(item.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 47 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                                               Write(item.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 46 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                                                                                    WriteLiteral(item.StudentId);

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
            WriteLiteral("\r\n                            </td>\r\n");
#nullable restore
#line 50 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>");
#nullable restore
#line 51 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                       Write(item.GuardianName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 51 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                                            Write(item.GuardianPhone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 57 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                       Write(item.AssignFeesCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 57 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                                               Write(item.PayFeesCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (Paid)\r\n");
            WriteLiteral("                        </td>\r\n\r\n                        <td class=\"text-end\">\r\n                            <div class=\"actions\">\r\n\r\n                                <a href=\"#\"");
            BeginWriteAttribute("onclick", " onclick=\'", 2548, "\'", 2606, 5);
            WriteAttributeValue("", 2558, "loadRecipt(\"", 2558, 12, true);
#nullable restore
#line 69 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
WriteAttributeValue("", 2570, item.StudentId, 2570, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2585, "\",\"", 2585, 3, true);
#nullable restore
#line 69 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
WriteAttributeValue("", 2588, ViewBag.feeDate, 2588, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2604, "\")", 2604, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm bg-danger-light\">\r\n                                    <i class=\"fa fa-receipt\"></i>\r\n                                </a>\r\n                            </div>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 75 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                }
                else if (item.PayFeesCount == 0 || item.PayFeesCount < item.AssignFeesCount)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr style=\"border-color:orangered\">\r\n\r\n\r\n\r\n            <td>");
#nullable restore
#line 82 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
           Write(item.RoleNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 84 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
             if (item.Attachment != null)
            {
                Imge = Convert.ToBase64String(item.Attachment);

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "229a09a957c618f66b0f930d34dbc3cfbd02beae16587", async() => {
                WriteLiteral("\r\n\r\n\r\n\r\n                        <img");
                BeginWriteAttribute("src", " src=\"", 3324, "\"", 3379, 1);
#nullable restore
#line 92 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
WriteAttributeValue("", 3330, string.Format("data:image/jpeg;base64,{0}",Imge), 3330, 49, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"img-fluid avatar-lg rounded\" />\r\n                        ");
#nullable restore
#line 93 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                   Write(item.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 93 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                                   Write(item.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 88 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                                              WriteLiteral(item.StudentId);

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
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 96 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "229a09a957c618f66b0f930d34dbc3cfbd02beae20190", async() => {
                WriteLiteral("\r\n                        ");
#nullable restore
#line 101 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                   Write(item.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 101 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                                   Write(item.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 100 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                                              WriteLiteral(item.StudentId);

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
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 104 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>");
#nullable restore
#line 105 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
           Write(item.GuardianName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 105 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                                Write(item.GuardianPhone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 111 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
           Write(item.AssignFeesCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 111 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                                   Write(item.PayFeesCount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (Un Paid)\r\n");
            WriteLiteral("            </td>\r\n\r\n            <td class=\"text-end\">\r\n                <div class=\"actions\">\r\n\r\n                    <a href=\"#\"");
            BeginWriteAttribute("onclick", " onclick=\'", 4338, "\'", 4396, 5);
            WriteAttributeValue("", 4348, "loadRecipt(\"", 4348, 12, true);
#nullable restore
#line 123 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
WriteAttributeValue("", 4360, item.StudentId, 4360, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4375, "\",\"", 4375, 3, true);
#nullable restore
#line 123 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
WriteAttributeValue("", 4378, ViewBag.feeDate, 4378, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4394, "\")", 4394, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm bg-danger-light\">\r\n                        <i class=\"fa fa-receipt\"></i>\r\n                    </a>\r\n                </div>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 129 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 129 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Transactions\_feeslist.cshtml"
                 

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </tbody>\r\n    </table>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SchoolManagement.Models.Entities.Student>> Html { get; private set; }
    }
}
#pragma warning restore 1591
