#pragma checksum "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b4b9d0159fcb2f9643371f8face4c44d9a96db39"
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
#line 2 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\_ViewImports.cshtml"
using Team1_FinalProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4b9d0159fcb2f9643371f8face4c44d9a96db39", @"/Views/Orders/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2ef1d2052bcd3deffeffaa001f504a0a44dbb64", @"/Views/_ViewImports.cshtml")]
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
  
    ViewData["Title"] = "Order Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("<style>\r\n    input[type=\"checkbox\"] {\r\n        position: relative;\r\n        left: 3px;\r\n        margin-left: 20px;\r\n    }\r\n</style>\r\n<h4>Order Details</h4>\r\n<div>\r\n\r\n<hr />\r\n<dl class=\"row\">\r\n    <dt class=\"col-sm-2\">\r\n        ");
#nullable restore
#line 19 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.OrderID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-10\">\r\n        ");
#nullable restore
#line 22 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
   Write(Html.DisplayFor(model => model.OrderID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-2\">\r\n        ");
#nullable restore
#line 25 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-10\">\r\n        ");
#nullable restore
#line 28 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
   Write(Html.DisplayFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-2\">\r\n        ");
#nullable restore
#line 31 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
   Write(Html.DisplayNameFor(model => model.PopcornPointsUsed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dt>\r\n    <dd class=\"col-sm-10\">\r\n        ");
#nullable restore
#line 34 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
   Write(Html.DisplayFor(model => model.PopcornPointsUsed));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n    <dt class=\"col-sm-2\">\r\n        Gift?\r\n    </dt>\r\n    <dd class=\"col-sm-10\">\r\n        ");
#nullable restore
#line 40 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
   Write(Html.DisplayFor(model => model.GiftOrder));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 41 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
   Write(Html.DisplayFor(model => model.GiftEmail));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </dd>\r\n</dl>\r\n</div>\r\n<h5>Tickets on this Order</h5>\r\n<table class=\"table table-primary\">\r\n    <tr>\r\n        <th>Movie Title</th>\r\n        <th>Showing Time</th>\r\n        <th>Ticket Price</th>\r\n        <th>Seat Number</th>\r\n    </tr>\r\n");
#nullable restore
#line 53 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
 foreach (Ticket t in Model.Tickets)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td>");
#nullable restore
#line 56 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(ModelItem => t.Showing.Movie.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 57 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
        Write(t.Showing.StartDateTime.ToString("MM/dd/yyyy hh:mm tt"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>-</span>");
#nullable restore
#line 57 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
                                                                                Write(t.Showing.EndDateTime.ToString("hh:mm tt"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 58 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(ModelItem => t.Showing.Price.PriceValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        <td>");
#nullable restore
#line 59 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(ModelItem => t.SeatNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n");
#nullable restore
#line 61 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n<h5>Order Summary</h5>\r\n<table class=\"table table-sm table-bordered\" style=\"width:30%\">\r\n    <tr>\r\n        <th colspan=\"2\" style=\"text-align:center\">Order Summary</th>\r\n    </tr>\r\n    <tr>\r\n        <td>Tickets Ordered:</td>\r\n        <td>");
#nullable restore
#line 71 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
       Write(ViewBag.ticketcounter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Order Subtotal:</td>\r\n        <td>");
#nullable restore
#line 75 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(model => model.OrderSubtotal));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Discount:</td>\r\n");
#nullable restore
#line 79 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
         if (Model.Discount == null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>N/A</td>\r\n");
#nullable restore
#line 82 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
        }
        else if (Model.Tickets.Where(t => t.Showing.SpecialEvent == false).Count() >= 2)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>");
#nullable restore
#line 85 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
           Write(string.Format("{0:C}", (Model.Discount.PriceValue * 2)));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 86 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
        }
        else if (Model.Tickets.Where(t => t.Showing.SpecialEvent == false).Count() == 1)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>");
#nullable restore
#line 89 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
           Write(string.Format("{0:C}", Model.Discount.PriceValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 90 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>N/A</td>\r\n");
#nullable restore
#line 94 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tr>\r\n    <tr>\r\n        <td>Sales Tax:</td>\r\n        <td>");
#nullable restore
#line 98 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
       Write(ViewBag.DiscountTax);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n    <tr>\r\n        <td>Order Total:</td>\r\n        <td>");
#nullable restore
#line 102 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Orders\Details.cshtml"
       Write(Html.DisplayFor(model => model.PostDiscount));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n    </tr>\r\n\r\n</table>\r\n<div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b4b9d0159fcb2f9643371f8face4c44d9a96db3912219", async() => {
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
            WriteLiteral("\r\n</div>");
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
