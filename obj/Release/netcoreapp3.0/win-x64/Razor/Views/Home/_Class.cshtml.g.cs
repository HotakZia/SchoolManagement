#pragma checksum "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Class.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3a699366b17e79ce6b0d8bd4d360cef7adc8fe4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home__Class), @"mvc.1.0.view", @"/Views/Home/_Class.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3a699366b17e79ce6b0d8bd4d360cef7adc8fe4", @"/Views/Home/_Class.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd7bb3185fcd2acd35edeafe38ac740e76555db5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home__Class : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SchoolManagement.Models.Entities.Class_>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            WriteLiteral("<!-- Datatables CSS -->\r\n\r\n\r\n    <div class=\"card flex-fill student-space comman-shadow\">\r\n        <div class=\"card-header d-flex align-items-center\">\r\n            <h5 class=\"card-title\">");
#nullable restore
#line 9 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Class.cshtml"
                              Write(DateTime.Now.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Active Classes</h5>\r\n            <ul class=\"chart-list-out student-ellips\">\r\n                <li class=\"star-menus\"><a href=\"javascript:;\"><i class=\"fas fa-ellipsis-v\"></i></a></li>\r\n            </ul>\r\n        </div>\r\n        <div class=\"card-body\">\r\n \r\n");
            WriteLiteral(@"                <div class=""table-responsive"">
                    <table class=""table border-0 star-student table-hover table-center mb-0 datatable table-striped"">
                        <thead class=""student-thread"">
                            <tr>
                              
                                <th>Class</th>
                                <th>Teacher</th>
                                <th>Shift</th>
                                <th>Rome</th>

                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 30 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Class.cshtml"
                             if (Model.Count() >= 1)
                            {
                                foreach (var item in Model)
                                {
                                    string Imge = "";


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n\r\n                                <td>");
#nullable restore
#line 38 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Class.cshtml"
                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 39 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Class.cshtml"
                               Write(item.TeacherName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                             \r\n                                <td>");
#nullable restore
#line 41 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Class.cshtml"
                               Write(item.Shift);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                <td>");
#nullable restore
#line 42 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Class.cshtml"
                               Write(item.Room);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n\r\n                            </tr>\r\n");
#nullable restore
#line 45 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Class.cshtml"
                                }
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr><td colspan=\"10\"> <h5 style=\"text-align:center;color:orangered\">0 recods founded!</h5></td></tr>\r\n");
#nullable restore
#line 50 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Home\_Class.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n\r\n           \r\n        </div>\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SchoolManagement.Models.Entities.Class_>> Html { get; private set; }
    }
}
#pragma warning restore 1591
