#pragma checksum "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "430d6de539035ed6fd8c6f43e57e2d9691bf412f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Team1_FinalProject.Views.Orders.Views_Orders_Review), @"mvc.1.0.view", @"/Views/Orders/Review.cshtml")]
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
#line 2 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/_ViewImports.cshtml"
using Team1_FinalProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"430d6de539035ed6fd8c6f43e57e2d9691bf412f", @"/Views/Orders/Review.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93cc52cd3ac3b23b29f94468f5592c506515b598", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_Review : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Team1_FinalProject.Models.Order>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Confirmation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Checkout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
  
    ViewData["Title"] = "Review";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 10 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
  
    int count = 2;

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\n<h1>Review Your Order</h1>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "430d6de539035ed6fd8c6f43e57e2d9691bf412f5330", async() => {
                WriteLiteral(@"
    <table class=""table"">
        <thead>
            <tr>
                <th>
                    Movie Title
                </th>
                <th>
                    Starting Time
                </th>
                <th>
                    Seat Number
                </th>
                <th>
                    Price Per Ticket
                </th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 34 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
             foreach (Ticket t in Model.Tickets)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\n                    <td>\n                        ");
#nullable restore
#line 38 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                   Write(Html.DisplayFor(model => t.Showing.Movie.Title));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    </td>\n                    <td>\n                        ");
#nullable restore
#line 41 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                   Write(Html.DisplayFor(model => t.Showing.StartDateTime));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    </td>\n                    <td>\n                        ");
#nullable restore
#line 44 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                   Write(Html.DisplayFor(model => t.SeatNumber));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    </td>\n                    <td>\n                        ");
#nullable restore
#line 47 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                   Write(Html.DisplayFor(model => t.Showing.Price.PriceValue));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                        <br />\n");
#nullable restore
#line 49 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                         if (ViewBag.DiscountTotal != null && count != 0 && t.Showing.SpecialEvent == false)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <b style=\"color:red\">");
#nullable restore
#line 51 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                                            Write(ViewBag.Discount);

#line default
#line hidden
#nullable disable
                WriteLiteral("</b>\n");
#nullable restore
#line 52 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                            count -= 1;
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </td>\n                </tr>\n");
#nullable restore
#line 56 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\n    </table>\n    <table class=\"table\">\n        <thead>\n            <tr>\n                <th>\n                    ");
#nullable restore
#line 63 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
               Write(Html.DisplayNameFor(model => model.OrderSubtotal));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </th>\n                <th>\n                    Discount:\n                </th>\n");
#nullable restore
#line 68 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                 if (ViewBag.DiscountTax != null)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <th>\n                        Discount Subtotal:\n                    </th>\n");
#nullable restore
#line 73 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                <th>\n                    ");
#nullable restore
#line 75 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
               Write(Html.DisplayNameFor(model => model.Tax));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </th>\n                <th>\n                    ");
#nullable restore
#line 78 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
               Write(Html.DisplayNameFor(model => model.OrderTotal));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </th>\n            </tr>\n        </thead>\n        <tbody>\n            <tr>\n                <td>\n                    ");
#nullable restore
#line 85 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
               Write(Html.DisplayFor(model => model.OrderSubtotal));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                </td>\n                <td>\n");
#nullable restore
#line 88 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                     if (count == 0)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                   Write(ViewBag.DiscountDouble);

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                                               
                    }
                    else
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 94 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                   Write(ViewBag.Discount);

#line default
#line hidden
#nullable disable
#nullable restore
#line 94 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                                         
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </td>\n");
#nullable restore
#line 97 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                 if (ViewBag.DiscountTax != null)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <td>\n                        ");
#nullable restore
#line 100 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                   Write(ViewBag.DiscountDiff);

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    </td>\n");
#nullable restore
#line 102 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                <td>\n");
#nullable restore
#line 104 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                     if (ViewBag.DiscountTax != null)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 106 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                   Write(ViewBag.DiscountTax);

#line default
#line hidden
#nullable disable
#nullable restore
#line 106 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                                            
                    }
                    else
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 110 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                   Write(Html.DisplayFor(model => model.Tax));

#line default
#line hidden
#nullable disable
#nullable restore
#line 110 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                                                            
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </td>\n                <td>\n");
#nullable restore
#line 114 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                     if (ViewBag.DiscountTotal != null)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 116 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                   Write(ViewBag.DiscountTotal);

#line default
#line hidden
#nullable disable
#nullable restore
#line 116 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                                              
                    }
                    else
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 120 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                   Write(Html.DisplayFor(model => model.OrderTotal));

#line default
#line hidden
#nullable disable
#nullable restore
#line 120 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                                                                   
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </td>
            </tr>
        </tbody>
    </table>

    <h5>Review Order Details</h5>
    <table class=""table table-sm table-bordered"" style=""width:30%"">
        <tr>
            <th colspan=""2"" style=""text-align:center"">Review Order Details</th>
        </tr>
        <tr>
            <td>Popcorn Points Used:</td>
            <td class=""text-right"">");
#nullable restore
#line 134 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                              Write(Html.DisplayFor(model => model.PopcornPointsUsed));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n        </tr>\n        <tr>\n            <td>Was this a Gift Order?</td>\n            <td class=\"text-right\">");
#nullable restore
#line 138 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
                              Write(Html.DisplayFor(model => model.GiftOrder));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n        </tr>\n    </table>\n\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "430d6de539035ed6fd8c6f43e57e2d9691bf412f16978", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 142 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.OrderID);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "430d6de539035ed6fd8c6f43e57e2d9691bf412f18672", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 143 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.OrderNumber);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "430d6de539035ed6fd8c6f43e57e2d9691bf412f20370", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 144 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Orders/Review.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.PopcornPointsUsed);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    <div class=\"form-group\">\n        <input type=\"submit\" value=\"Confirm\" class=\"btn btn-primary\" />\n    </div>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "430d6de539035ed6fd8c6f43e57e2d9691bf412f23548", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "430d6de539035ed6fd8c6f43e57e2d9691bf412f24694", async() => {
                WriteLiteral("Edit Order");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n\n");
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
