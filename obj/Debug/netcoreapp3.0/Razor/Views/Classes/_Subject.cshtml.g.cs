#pragma checksum "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\_Subject.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "34c0327fdb0e58d0604900a5b13858ad7cdcab99"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Classes__Subject), @"mvc.1.0.view", @"/Views/Classes/_Subject.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"34c0327fdb0e58d0604900a5b13858ad7cdcab99", @"/Views/Classes/_Subject.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd7bb3185fcd2acd35edeafe38ac740e76555db5", @"/Views/_ViewImports.cshtml")]
    public class Views_Classes__Subject : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SchoolManagement.Models.Entities.Schedual>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Exams", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm bg-info-light"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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

            <div class=""card card-table"">
                <div class=""card-body"">

                    <!-- Page Header -->
                    <div class=""page-header"">
                        <div class=""row align-items-center"">
                            <div class=""col"">
                                <h3 class=""page-title"">Assigned Subjects</h3>
                            </div>
                   
                        </div>
                    </div>
                    <!-- /Page Header -->

                    <div class=""table-responsive"">
                        <table class=""table border-0 star-student table-hover table-center mb-0 datatable table-striped"">
                            <thead class=""student-thread"">
                                <tr>

                                    <th>Number#</th>
                                    <th>Name</th>
              ");
            WriteLiteral(@"                      <th>Comment</th>


                                    <th>Exam</th>
                                    <th>Exam</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 39 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\_Subject.cshtml"
                                 foreach (var item in Model)
                                {
                                 


#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n\r\n                                    <td>");
#nullable restore
#line 45 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\_Subject.cshtml"
                                   Write(item.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                    <td>");
#nullable restore
#line 47 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\_Subject.cshtml"
                                   Write(item.SubjecName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                    <td>");
#nullable restore
#line 49 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\_Subject.cshtml"
                                   Write(item.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n\r\n                                    <td>\r\n                                        <div class=\"actions\">\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34c0327fdb0e58d0604900a5b13858ad7cdcab997278", async() => {
                WriteLiteral("\r\n                                                <i class=\"feather-alert-circle\"></i>\r\n\r\n                                            ");
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
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-ClassId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 55 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\_Subject.cshtml"
                                                                                                 WriteLiteral(item.ClassId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ClassId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-ClassId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ClassId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 55 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\_Subject.cshtml"
                                                                                                                                      WriteLiteral(item.Subject);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ScheduleId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-ScheduleId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ScheduleId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                           
                                    </td>

                                    <td class=""text-end"">
                                        <div class=""actions"">
                                        
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "34c0327fdb0e58d0604900a5b13858ad7cdcab9911083", async() => {
                WriteLiteral("\r\n                                                <i class=\"fa fa-certificate\"></i>\r\n\r\n                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 65 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\_Subject.cshtml"
                                                                                             WriteLiteral(item.Subject);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </div>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 72 "D:\Projects\SchoolManagement\SchoolManagement\SchoolManagement\Views\Classes\_Subject.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>



<script>

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
                alert(response.responseText);
            }

        });
        $('.page-loader').hide();
    }
    function DeleteFile(Id) {
   ");
            WriteLiteral(@"     $('.page-loader').show();

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

</script>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"




    <script>

        function OnBegin() {
            $('.page-loader').show();

        }
        function OnSuccess(data) {
            $('#AModelBody').html(data);
               swal(""Saved!"",  data.message, ""success"");
        }
        function OnComplete() {
            $('.page-loader').hide();

        }
    </script>
");
            }
            );
            WriteLiteral(@"<div class=""modal fade bd-example-modal-lg"" id=""AModel"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-body"" id=""AModelBody"">
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                <button type=""button"" class=""btn btn-success"" onclick=""printDiv()""><i class=""fa fa-print""></i> Print</button>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SchoolManagement.Models.Entities.Schedual>> Html { get; private set; }
    }
}
#pragma warning restore 1591