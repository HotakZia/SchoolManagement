#pragma checksum "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c05e3e553daeb0ae0c95e9a373db6f4f4617d5b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Classes_Details), @"mvc.1.0.view", @"/Views/Classes/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c05e3e553daeb0ae0c95e9a373db6f4f4617d5b", @"/Views/Classes/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd7bb3185fcd2acd35edeafe38ac740e76555db5", @"/Views/_ViewImports.cshtml")]
    public class Views_Classes_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SchoolManagement.Models.Entities.Class_>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Students", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm bg-danger-light"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"




<div class=""content container-fluid"">


    <div class=""row"">

        <div class=""col-sm-12"">

            <div class=""card comman-shadow"">
                <div class=""card-body"">
                    <div class=""row"">
                        <div class=""col-lg-3""><strong>Name:</strong> ");
#nullable restore
#line 17 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                                                Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        <div class=\"col-lg-3\"><strong>Teacher:</strong> ");
#nullable restore
#line 18 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                                                   Write(Model.TeacherName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        <div class=\"col-lg-2\"><strong>Shift:</strong> ");
#nullable restore
#line 19 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                                                 Write(Model.Shift);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        <div class=\"col-lg-2\"><strong>Grad</strong> ");
#nullable restore
#line 20 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                                               Write(Model.Grad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        <div class=\"col-lg-2\"><strong>Year</strong> ");
#nullable restore
#line 21 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                                               Write(Model.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>

                        <hr />
                        <div class=""table-responsive"">
                            <table id=""studentTable"" class=""table border-0 star-student table-hover table-center mb-0 datatable table-striped"">
                                <thead class=""student-thread"">
                                    <tr>

                                        <th>ID</th>
                                        <th>Name</th>

                                        <th>Guardian</th>
                                        <th>Contact</th>

                                        <th class=""text-end"">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 39 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                     if (ViewBag.Student != null)
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                         foreach (var item in ViewBag.Student)
                                        {
                                            string Imge = "";


#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n\r\n\r\n\r\n                                                <td>");
#nullable restore
#line 49 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                               Write(item.RoleNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 51 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                                 if (item.Attachment != null)
                                                {
                                                    Imge = Convert.ToBase64String(item.Attachment);

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <td>\r\n\r\n                                                        <img");
            BeginWriteAttribute("src", " src=\"", 2287, "\"", 2343, 1);
#nullable restore
#line 56 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
WriteAttributeValue("", 2293, string.Format("data:image/jpeg;base64,{0}", Imge), 2293, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid avatar-lg rounded\" />\r\n");
#nullable restore
#line 57 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                                         if (item.Status == true)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <i class=\"fa fa-check-circle\"></i>\r\n                                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c05e3e553daeb0ae0c95e9a373db6f4f4617d5b9956", async() => {
                WriteLiteral("   ");
#nullable restore
#line 60 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                                                                                                                           Write(item.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 60 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                                                                                                                                           Write(item.LastName);

#line default
#line hidden
#nullable disable
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
#line 60 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
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
            WriteLiteral("\r\n");
#nullable restore
#line 61 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"


                                                        }
                                                        else
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <i class=\"fa fa-delete-left\"></i>\r\n                                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c05e3e553daeb0ae0c95e9a373db6f4f4617d5b13670", async() => {
                WriteLiteral("   ");
#nullable restore
#line 67 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                                                                                                                           Write(item.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 67 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                                                                                                                                           Write(item.LastName);

#line default
#line hidden
#nullable disable
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
#line 67 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
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
            WriteLiteral("\r\n");
#nullable restore
#line 68 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"


                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </td>\r\n");
#nullable restore
#line 72 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                                <td>");
#nullable restore
#line 75 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                               Write(item.GfatherName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 75 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                                                   Write(item.GuardianPhone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 76 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                               Write(item.Contact);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n                                                <td class=\"text-end\">\r\n                                                    <div class=\"actions\">\r\n\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c05e3e553daeb0ae0c95e9a373db6f4f4617d5b18625", async() => {
                WriteLiteral("\r\n                                                            <i class=\"feather-edit\"></i>\r\n                                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 82 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                                                                                         WriteLiteral(item.StudentId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                        <a");
            BeginWriteAttribute("onclick", " onclick=\'", 4142, "\'", 4182, 3);
            WriteAttributeValue("", 4152, "LoadPerants(\"", 4152, 13, true);
#nullable restore
#line 85 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
WriteAttributeValue("", 4165, item.StudentId, 4165, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4180, "\")", 4180, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm bg-danger-light\">\r\n                                                            <i class=\"feather-users\"></i>\r\n                                                        </a>\r\n                                                        <a");
            BeginWriteAttribute("onclick", " onclick=\'", 4432, "\'", 4470, 3);
            WriteAttributeValue("", 4442, "LoadFiles(\"", 4442, 11, true);
#nullable restore
#line 88 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
WriteAttributeValue("", 4453, item.StudentId, 4453, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4468, "\")", 4468, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm bg-danger-light\">\r\n                                                            <i class=\"fa fa-file\"></i>\r\n                                                        </a>\r\n                                                        <a");
            BeginWriteAttribute("onclick", " onclick=\'", 4717, "\'", 4762, 3);
            WriteAttributeValue("", 4727, "getResult(\"", 4727, 11, true);
#nullable restore
#line 91 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
WriteAttributeValue("", 4738, item.StudentId, 4738, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4753, "\",\"2024\")", 4753, 9, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-sm bg-danger-light"">
                                                            <i class=""fa fa-certificate""></i>
                                                        </a>
                                                    </div>
                                                </td>
                                            </tr>
");
#nullable restore
#line 97 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 97 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"
                                         
                                    }
                                    else
                                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr><td colspan=\"10\" align=\"center\"><p>0 students assign to this class</p></td></tr>\r\n");
#nullable restore
#line 103 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\Details.cshtml"


                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>
                            </table>
                        </div>



                    </div>
                </div>
            </div>
        </div>

    </div>

</div>


    <script>

        function OnBegin() {
            $('.page-loader').show();

        }
        function OnSuccess(data) {
            $('#AModelBody').html(data);
        }
        function OnComplete() {
            $('.page-loader').hide();

        }
    </script>



<script>

    function getResult(Id, Year) {
        $('.page-loader').show();

        $.ajax({


            type: ""POST"",
            async: true,
            url: ""/Students/getResult"", //url to load partial view
            //data: ""{term:'"" + SearchText + ""'}"",
            data: { ""Id"": Id, ""Year"": Year },
            //contentType: ""application/json;characterset=utf-8"",
            success: function (response) {
                $('#AModelBody').html(response);
         ");
            WriteLiteral(@"       $('#AModel').modal('show');

            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }

        });
        $('.page-loader').hide();
    }
    function LoadFiles(Id) {

        $('.page-loader').show();

        $.ajax({


            type: ""POST"",
            async: true,
            url: ""/Students/LoadFile"", //url to load partial view
            //data: ""{term:'"" + SearchText + ""'}"",
            data: { ""Id"": Id },
            //contentType: ""application/json;characterset=utf-8"",
            success: function (response) {
                $('#AModelBody').html(response);
                $('#AModel').modal('show');

            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.re");
            WriteLiteral(@"sponseText);
            }

        });
        $('.page-loader').hide();
    }
    function DeleteFile(Id) {
        $('.page-loader').show();

        $.ajax({


            type: ""POST"",
            async: true,
            url: ""/Students/DeleteFiles"", //url to load partial view
            //data: ""{term:'"" + SearchText + ""'}"",
            data: { ""Id"": Id },
            //contentType: ""application/json;characterset=utf-8"",
            success: function (response) {
                $('#AModelBody').html(response);
                $('#AModel').modal('show');

            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
        $('.page-loader').hide();
    }
    function LoadPerants(Id) {

        $('.page-loader').show();

        $.ajax({


            type: ""POST"",
            async: true,
    ");
            WriteLiteral(@"        url: ""/Students/LpadPerants"", //url to load partial view
            //data: ""{term:'"" + SearchText + ""'}"",
            data: { ""Id"": Id },
            //contentType: ""application/json;characterset=utf-8"",
            success: function (response) {

                $('#AModelBody').html(response);
                $('#AModel').modal('show');

            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }

        });
        $('.page-loader').hide();
    }
    function DeletePerants(Id) {
        $('.page-loader').show();

        $.ajax({


            type: ""POST"",
            async: true,
            url: ""/Students/DeletePerants"", //url to load partial view
            //data: ""{term:'"" + SearchText + ""'}"",
            data: { ""Id"": Id },
            //contentType: ""application/json;characterset=utf-8"",
         ");
            WriteLiteral(@"   success: function (response) {
                $('#AModelBody').html(response);
                $('#AModel').modal('show');

            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
        $('.page-loader').hide();
    }
</script>


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SchoolManagement.Models.Entities.Class_> Html { get; private set; }
    }
}
#pragma warning restore 1591
