#pragma checksum "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b53d2f0186b95151c8b999a25159ff4cedba6750"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Team1_FinalProject.Views.Movies.Views_Movies_Details), @"mvc.1.0.view", @"/Views/Movies/Details.cshtml")]
namespace Team1_FinalProject.Views.Movies
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b53d2f0186b95151c8b999a25159ff4cedba6750", @"/Views/Movies/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93cc52cd3ac3b23b29f94468f5592c506515b598", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Team1_FinalProject.Models.Movie>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ReviewsIndex", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "MovieReviews", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Tickets", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 7 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral(" Details</h2>\r\n\r\n<div>\r\n    \r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.MovieNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
       Write(Html.DisplayFor(model => model.MovieNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
       Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            Movie Rating\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 29 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
             if (@Model.AverageRating == null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span>No ratings.</span>\r\n");
#nullable restore
#line 32 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b53d2f0186b95151c8b999a25159ff4cedba67507649", async() => {
#nullable restore
#line 35 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
                                                                                            Write(Html.DisplayFor(model => model.AverageRating));

#line default
#line hidden
#nullable disable
                WriteLiteral("/5");
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
#line 35 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
                                                                     WriteLiteral(Model.MovieID);

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
#line 36 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Genre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
       Write(Html.DisplayFor(model => model.Genre.GenreName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Tagline));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
       Write(Html.DisplayFor(model => model.Tagline));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 57 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.MPAA));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
       Write(Html.DisplayFor(model => model.MPAA));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 63 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Actors));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 66 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
       Write(Html.DisplayFor(model => model.Actors));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 69 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Runtime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 72 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
       Write(Html.DisplayFor(model => model.Runtime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<table class=\"table table-bordered\">\r\n    <tr>\r\n        <th>Showing Date</th>\r\n        <th>Showing Time</th>\r\n        <th>Tickets Available</th>\r\n");
#nullable restore
#line 81 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
         if (User.Identity.IsAuthenticated)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
             if (User.IsInRole("Customer"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <th>Purchase Ticket</th>\r\n");
#nullable restore
#line 86 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tr>\r\n");
#nullable restore
#line 89 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
     if (Model.Showings.Count() == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td colspan = \"4\">None this week!</td>\r\n        </tr>\r\n");
#nullable restore
#line 94 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 95 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
     foreach (Showing s in Model.Showings)
    {   
        if (s.StartDateTime < DateTime.Now)
        {
            continue;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 102 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
            Write(s.StartDateTime.ToString("MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 103 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
            Write(s.StartDateTime.ToString("hh:mm tt"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>-</span>");
#nullable restore
#line 103 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
                                                                 Write(s.EndDateTime.ToString("hh:mm tt"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 104 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
           Write(Html.DisplayFor(ModelItem => s.TicketCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("/20</td>\r\n");
#nullable restore
#line 105 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
             if (User.Identity.IsAuthenticated)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 107 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
                 if (User.IsInRole("Customer"))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b53d2f0186b95151c8b999a25159ff4cedba675018136", async() => {
                WriteLiteral("Purchase Tickets");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-showingID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 109 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
                                                                                 WriteLiteral(s.ShowingID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["showingID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-showingID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["showingID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n");
#nullable restore
#line 110 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 110 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n");
#nullable restore
#line 113 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n");
            WriteLiteral("<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b53d2f0186b95151c8b999a25159ff4cedba675021338", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 118 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Movies/Details.cshtml"
                           WriteLiteral(Model.MovieID);

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
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b53d2f0186b95151c8b999a25159ff4cedba675023468", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Team1_FinalProject.Models.Movie> Html { get; private set; }
    }
}
#pragma warning restore 1591
