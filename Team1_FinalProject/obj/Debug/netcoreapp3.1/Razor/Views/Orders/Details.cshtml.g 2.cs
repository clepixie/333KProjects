#pragma checksum "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b90c6439cc2e50b3b6bd62991b54ed2f0f6ae60b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Team1_FinalProject.Views.Orders.Views_Orders_Details), @"mvc.1.0.view", @"/Views/Orders/Details.cshtml")]
namespace Team1_FinalProject.Views.Orders
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
#line 2 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/_ViewImports.cshtml"
using Team1_FinalProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b90c6439cc2e50b3b6bd62991b54ed2f0f6ae60b", @"/Views/Orders/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93cc52cd3ac3b23b29f94468f5592c506515b598", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Team1_FinalProject.Models.Order>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
  
    ViewData["Title"] = "Order Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h4>Order Details</h4>\n<div>\n\n<hr />\n<dl class=\"row\">\n    <dt class=\"col-sm-2\">\n        ");
#nullable restore
#line 13 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
   Write(Html.DisplayNameFor(model => model.OrderID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </dt>\n    <dd class=\"col-sm-10\">\n        ");
#nullable restore
#line 16 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
   Write(Html.DisplayFor(model => model.OrderID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </dd>\n    <dt class=\"col-sm-2\">\n        ");
#nullable restore
#line 19 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </dt>\n    <dd class=\"col-sm-10\">\n        ");
#nullable restore
#line 22 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
   Write(Html.DisplayFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </dd>\n    <dt class=\"col-sm-2\">\n        ");
#nullable restore
#line 25 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
   Write(Html.DisplayNameFor(model => model.PopcornPointsUsed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </dt>\n    <dd class=\"col-sm-10\">\n        ");
#nullable restore
#line 28 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
   Write(Html.DisplayFor(model => model.PopcornPointsUsed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </dd>\n</dl>\n</div>\n<h5>Tickets on this Order</h5>\n<table class=\"table table-primary\">\n    <tr>\n        <th>Movie Title</th>\n        <th>Showing Time</th>\n        <th>Ticket Price</th>\n        <th>Seat Number</th>\n    </tr>\n");
#nullable restore
#line 40 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
 foreach (Ticket t in Model.Tickets)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\n        <td>");
#nullable restore
#line 43 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
       Write(Html.DisplayFor(ModelItem => t.Showing.Movie.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td>");
#nullable restore
#line 44 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
        Write(t.Showing.StartDateTime.ToString("MM/dd/yyyy hh:mm tt"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>-</span>");
#nullable restore
#line 44 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
                                                                                Write(t.Showing.EndDateTime.ToString("hh:mm tt"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td>");
#nullable restore
#line 45 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
       Write(Html.DisplayFor(ModelItem => t.Showing.Price.PriceValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td>");
#nullable restore
#line 46 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
       Write(Html.DisplayFor(ModelItem => t.SeatNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    </tr>\n");
#nullable restore
#line 48 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\n\n<h5>Order Summary</h5>\n<table class=\"table table-sm table-bordered\" style=\"width:30%\">\n    <tr>\n        <th colspan=\"2\" style=\"text-align:center\">Order Summary</th>\n    </tr>\n    <tr>\n        <td>Tickets Ordered:</td>\n        <td>");
#nullable restore
#line 58 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
       Write(ViewBag.ticketcounter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    </tr>\n    <tr>\n        <td>Order Subtotal:</td>\n        <td>");
#nullable restore
#line 62 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
       Write(Html.DisplayFor(model => model.OrderSubtotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    </tr>\n    <tr>\n        <td>Discount:</td>\n");
#nullable restore
#line 66 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
         if (Model.Discount == null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>N/A</td>\n");
#nullable restore
#line 69 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
        }
        else if (Model.Tickets.Where(t => t.Showing.SpecialEvent == false).Count() >= 2)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>");
#nullable restore
#line 72 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
           Write(string.Format("{0:C}", (Model.Discount.PriceValue * 2)));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 73 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>");
#nullable restore
#line 76 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
           Write(string.Format("{0:C}", Model.Discount.PriceValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n");
#nullable restore
#line 77 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tr>\n    <tr>\n        <td>Sales Tax:</td>\n        <td>");
#nullable restore
#line 81 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
       Write(ViewBag.DiscountTax);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    </tr>\n    <tr>\n        <td>Order Total:</td>\n        <td>");
#nullable restore
#line 85 "/Users/nadiabaig/Desktop/mis 333k/333KProjects/Team1_FinalProject/Views/Orders/Details.cshtml"
       Write(Html.DisplayFor(model => model.PostDiscount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    </tr>\n\n</table>\n<div>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b90c6439cc2e50b3b6bd62991b54ed2f0f6ae60b10710", async() => {
                WriteLiteral("Back to List");
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
            WriteLiteral("\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Team1_FinalProject.Models.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
