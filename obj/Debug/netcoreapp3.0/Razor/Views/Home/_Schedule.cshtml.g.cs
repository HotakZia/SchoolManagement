#pragma checksum "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Schedule.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "02540a651a40b8e383622b42191739ccdf489828"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__Schedule), @"mvc.1.0.view", @"/Views/Home/_Schedule.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02540a651a40b8e383622b42191739ccdf489828", @"/Views/Home/_Schedule.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd7bb3185fcd2acd35edeafe38ac740e76555db5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__Schedule : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SchoolManagement.Models.Entities.Schedual>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Schedule.cshtml"
   int number = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"card flex-fill student-space comman-shadow\">\r\n    <div class=\"card-header d-flex align-items-center\">\r\n        <h5 class=\"card-title\">Today Schedule ");
#nullable restore
#line 6 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Schedule.cshtml"
                                         Write(DateTime.Now.DayOfWeek.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
        <ul class=""chart-list-out student-ellips"">
            <li class=""star-menus""><a href=""javascript:;""><i class=""fas fa-ellipsis-v""></i></a></li>
        </ul>
    </div>
    <div class=""card-body"">

        <div class=""table-responsive"">
            <table class=""table border-0 star-student table-hover table-center mb-0 datatable table-striped"">
                <thead class=""student-thread"">
                    <tr>
                        <th>#</th>


                        <th>Class</th>
                        <th>Teacher</th>
                        <th>Subject</th>


                        <th>Shift</th>
                        <th>Hour</th>

                    </tr>
                </thead>
                <tbody>

");
#nullable restore
#line 32 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Schedule.cshtml"
                     foreach (var item in Model)
                    {
                        string Imge = "";


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 37 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Schedule.cshtml"
                           Write(number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 38 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Schedule.cshtml"
                           Write(item.ClassName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 39 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Schedule.cshtml"
                           Write(item.TeacherName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 40 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Schedule.cshtml"
                           Write(item.SubjecName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 41 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Schedule.cshtml"
                           Write(item.Shift);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 42 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Schedule.cshtml"
                           Write(item.HourOfDay);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 47 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Schedule.cshtml"
                        number++;
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SchoolManagement.Models.Entities.Schedual>> Html { get; private set; }
    }
}
#pragma warning restore 1591