#pragma checksum "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\TimeTable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a68053a84650e10f1dd26b2a34af28341169cb1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Classes_TimeTable), @"mvc.1.0.view", @"/Views/Classes/TimeTable.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a68053a84650e10f1dd26b2a34af28341169cb1", @"/Views/Classes/TimeTable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd7bb3185fcd2acd35edeafe38ac740e76555db5", @"/Views/_ViewImports.cshtml")]
    public class Views_Classes_TimeTable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<SchoolManagement.Models.Entities.TimeTable>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"



<div class=""content container-fluid"">


    <div class=""row"">

        <div class=""col-sm-12"">

            <div class=""card comman-shadow"">
                <div class=""card-body"">
            
                    <div class=""row"">
                        <div class=""row"">
                            <div class=""col-lg-3""><strong>Name:</strong> ");
#nullable restore
#line 18 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\TimeTable.cshtml"
                                                                    Write(ViewBag.Class.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <div class=\"col-lg-3\"><strong>Teacher:</strong> ");
#nullable restore
#line 19 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\TimeTable.cshtml"
                                                                       Write(ViewBag.Class.TeacherName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <div class=\"col-lg-2\"><strong>Shift:</strong> ");
#nullable restore
#line 20 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\TimeTable.cshtml"
                                                                     Write(ViewBag.Class.Shift);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <div class=\"col-lg-2\"><strong>Grad</strong> ");
#nullable restore
#line 21 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\TimeTable.cshtml"
                                                                   Write(ViewBag.Class.Grad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            <div class=\"col-lg-2\"><strong>Year</strong> ");
#nullable restore
#line 22 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\TimeTable.cshtml"
                                                                   Write(ViewBag.Class.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>

                            <hr />
                            <div class=""col-12 col-sm-12"">
                                <table class=""table table-bordered"" border=""1"">
                                    <thead>
                                        <tr style=""text-align:center"">
                                            <th style=""text-align:left"">Day</th>
                                            <th>1H</th>
                                            <th>2H</th>
                                            <th>3H</th>
                                            <th>4H</th>
                                            <th>5H</th>
                                            <th>6H</th>
                                        </tr>
                                    </thead>

                                    <tbody>
");
#nullable restore
#line 40 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\TimeTable.cshtml"
                                         foreach (MyEnums.DayOfWeek day in Enum.GetValues(typeof(MyEnums.DayOfWeek)))
                                        {
                                            int numer = 1;


#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <th align=\"center\" style=\"vertical-align: middle\">");
#nullable restore
#line 45 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\TimeTable.cshtml"
                                                                                             Write(day);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\r\n");
#nullable restore
#line 47 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\TimeTable.cshtml"
                                                 foreach (MyEnums.ShiftHours hour in Enum.GetValues(typeof(MyEnums.ShiftHours)))
                                                {

                                                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <td align=\"center\">\r\n                                                        <p>\r\n                                                            ");
#nullable restore
#line 55 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\TimeTable.cshtml"
                                                       Write(Model.Where(x => x.DayOfWeek == day.ToString() && x.HourOfDay == ((int)hour).ToString()).Select(x => x.Subject).FirstOrDefault());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                        </p>
                                                        <hr />
                                                        <small style=""color:orangered;font-size:smaller"">
                                                            ");
#nullable restore
#line 59 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\TimeTable.cshtml"
                                                       Write(Model.Where(x => x.DayOfWeek == day.ToString() && x.HourOfDay == ((int)hour).ToString()).Select(x => x.Teacher).FirstOrDefault());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </small>\r\n                                                    </td>\r\n");
#nullable restore
#line 77 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\TimeTable.cshtml"
                                       


                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                            </tr>\r\n");
#nullable restore
#line 84 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\TimeTable.cshtml"

                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </tbody>
                                </table>
                            </div>



                        </div>

                    </div>
            </div>
        </div>

    </div>

</div>


");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<SchoolManagement.Models.Entities.TimeTable>> Html { get; private set; }
    }
}
#pragma warning restore 1591