#pragma checksum "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Reports/DisplayCustomerReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd915e44cd43303d905feebb37a07aa85e55ecea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Team1_FinalProject.Views.Reports.Views_Reports_DisplayCustomerReport), @"mvc.1.0.view", @"/Views/Reports/DisplayCustomerReport.cshtml")]
namespace Team1_FinalProject.Views.Reports
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
#line 2 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/_ViewImports.cshtml"
using Team1_FinalProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd915e44cd43303d905feebb37a07aa85e55ecea", @"/Views/Reports/DisplayCustomerReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93cc52cd3ac3b23b29f94468f5592c506515b598", @"/Views/_ViewImports.cshtml")]
    public class Views_Reports_DisplayCustomerReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Team1_FinalProject.Models.CustomerReportViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Reports/DisplayCustomerReport.cshtml"
  
    ViewData["Title"] = "DisplayCustomerReport";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Display Customer Report</h1>

    <hr />
    <table class=""table"">
        <thead>
            <tr>
                <th>
                    OrderID
                </th>
                <th>
                    Customer Name
                </th>
                <th>
                    Order Date
                </th>
                <th>
                    Order Total
                </th>
                <th>
                    Popcorn Points Used
                </th>
                <th>
                    Order History
                </th>
            </tr>
        </thead>

        <tbody>
");
#nullable restore
#line 35 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Reports/DisplayCustomerReport.cshtml"
             foreach (Order o  in ViewBag.CustomerOrders)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td>\n                    ");
#nullable restore
#line 39 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Reports/DisplayCustomerReport.cshtml"
               Write(Html.DisplayFor(modelItem => o.OrderID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 42 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Reports/DisplayCustomerReport.cshtml"
               Write(Html.DisplayFor(model => o.Customer.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 45 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Reports/DisplayCustomerReport.cshtml"
               Write(Html.DisplayFor(modelItem => o.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 48 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Reports/DisplayCustomerReport.cshtml"
               Write(Html.DisplayFor(modelItem => o.PostDiscount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 51 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Reports/DisplayCustomerReport.cshtml"
               Write(Html.DisplayFor(modelItem => o.PopcornPointsUsed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                    ");
#nullable restore
#line 54 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Reports/DisplayCustomerReport.cshtml"
               Write(Html.DisplayFor(modelItem => o.OrderHistory));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n            </tr>\n");
#nullable restore
#line 57 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Reports/DisplayCustomerReport.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>

    <div class=""row"">
        <div class=""col-md-8"">
            <h5>Customer Summary</h5>
            <table class=""table table-sm table-bordered"" style=""width:30%"">

                <tr>
                    <td>Total Seats Sold:</td>
                    <td>");
#nullable restore
#line 68 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Reports/DisplayCustomerReport.cshtml"
                   Write(Html.DisplayFor(model => model.SeatsSold));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                </tr>\n                <tr>\n                    <td>Total Revenue:</td>\n                    <td>");
#nullable restore
#line 72 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Reports/DisplayCustomerReport.cshtml"
                   Write(Html.DisplayFor(model => model.TotalRevenue));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                </tr>\n                <tr>\n                    <td>Popcorn Points Used:</td>\n                    <td>");
#nullable restore
#line 76 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Reports/DisplayCustomerReport.cshtml"
                   Write(Html.DisplayFor(model => model.PopcornPointsUsed));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                </tr>\n            </table>\n        </div>\n    </div>\n\n\n\n<div>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd915e44cd43303d905feebb37a07aa85e55ecea8641", async() => {
                WriteLiteral("Create a New Report");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd915e44cd43303d905feebb37a07aa85e55ecea9795", async() => {
                WriteLiteral("Back to Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Team1_FinalProject.Models.CustomerReportViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
