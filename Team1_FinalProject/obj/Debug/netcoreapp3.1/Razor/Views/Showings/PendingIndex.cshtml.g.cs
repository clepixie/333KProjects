#pragma checksum "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b61bb26e8afa2d4d6b5fcea56d261b72efddce91"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Team1_FinalProject.Views.Showings.Views_Showings_PendingIndex), @"mvc.1.0.view", @"/Views/Showings/PendingIndex.cshtml")]
namespace Team1_FinalProject.Views.Showings
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b61bb26e8afa2d4d6b5fcea56d261b72efddce91", @"/Views/Showings/PendingIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2ef1d2052bcd3deffeffaa001f504a0a44dbb64", @"/Views/_ViewImports.cshtml")]
    public class Views_Showings_PendingIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Team1_FinalProject.Models.Showing>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Publish", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CopySchedule", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Movies", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditPending", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
  
    ViewData["Title"] = "PendingIndex";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
  
    List<List<Showing>> alldays = new List<List<Showing>>();
    List<Showing> sunday = Model.Where(m => m.StartDateTime.DayOfWeek == DayOfWeek.Sunday).ToList();
    alldays.Add(sunday);
    List<Showing> monday = Model.Where(m => m.StartDateTime.DayOfWeek == DayOfWeek.Monday).ToList();
    alldays.Add(monday);
    List<Showing> tuesday = Model.Where(m => m.StartDateTime.DayOfWeek == DayOfWeek.Tuesday).ToList();
    alldays.Add(tuesday);
    List<Showing> wednesday = Model.Where(m => m.StartDateTime.DayOfWeek == DayOfWeek.Wednesday).ToList();
    alldays.Add(wednesday);
    List<Showing> thursday = Model.Where(m => m.StartDateTime.DayOfWeek == DayOfWeek.Thursday).ToList();
    alldays.Add(thursday);
    List<Showing> friday = Model.Where(m => m.StartDateTime.DayOfWeek == DayOfWeek.Friday).ToList();
    alldays.Add(friday);
    List<Showing> saturday = Model.Where(m => m.StartDateTime.DayOfWeek == DayOfWeek.Saturday).ToList();
    alldays.Add(saturday);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Pending Showings</h1>\r\n<h4>For the week of ");
#nullable restore
#line 26 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
               Write(ViewBag.Week);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n<p>\r\n");
#nullable restore
#line 28 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
     if (User.Identity.IsAuthenticated)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
         if (User.IsInRole("Manager"))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b61bb26e8afa2d4d6b5fcea56d261b72efddce917465", async() => {
                WriteLiteral("Create New");
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
            WriteLiteral(" <span>|</span>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b61bb26e8afa2d4d6b5fcea56d261b72efddce918651", async() => {
                WriteLiteral("Publish Showings");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" <span>|</span>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b61bb26e8afa2d4d6b5fcea56d261b72efddce919843", async() => {
                WriteLiteral("Quick Copy");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 35 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
         
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 38 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
Write(Html.ValidationSummary(true, "", new { @style = "color: red" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 39 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
 foreach (int value in new List<int> { 5, 6, 0, 1, 2, 3, 4 })
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4>");
#nullable restore
#line 41 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
    Write((DayOfWeek)value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    Date\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 49 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
               Write(Html.DisplayNameFor(model => model.StartDateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 52 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
               Write(Html.DisplayNameFor(model => model.EndDateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 55 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
               Write(Html.DisplayNameFor(model => model.Room));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 58 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
               Write(Html.DisplayNameFor(model => model.Movie.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    Actions\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 66 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
             foreach (Showing item in alldays[value])
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        <b>");
#nullable restore
#line 70 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
                      Write(item.StartDateTime.ToString("MM/dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                    </td>\r\n                    <td>\r\n                        <b>");
#nullable restore
#line 73 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
                      Write(Html.DisplayFor(modelItem => item.StartDateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                    </td>\r\n                    <td>\r\n                        <b>");
#nullable restore
#line 76 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
                      Write(Html.DisplayFor(modelItem => item.EndDateTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 79 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Room));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 82 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Movie.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b61bb26e8afa2d4d6b5fcea56d261b72efddce9116201", async() => {
                WriteLiteral("Showing Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 85 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
                                                  WriteLiteral(item.ShowingID);

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
            WriteLiteral(" |\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b61bb26e8afa2d4d6b5fcea56d261b72efddce9118424", async() => {
                WriteLiteral("Movie Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 86 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
                                                                          WriteLiteral(item.Movie.MovieID);

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
            WriteLiteral(" |\r\n");
#nullable restore
#line 87 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
                         if (User.Identity.IsAuthenticated)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 89 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
                             if (User.IsInRole("Manager"))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b61bb26e8afa2d4d6b5fcea56d261b72efddce9121489", async() => {
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
#line 91 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
                                                              WriteLiteral(item.ShowingID);

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
            WriteLiteral(" <span> | </span>");
#nullable restore
#line 91 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
                                                                                                                    ;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b61bb26e8afa2d4d6b5fcea56d261b72efddce9124063", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 92 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
                                                         WriteLiteral(item.ShowingID);

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
#line 93 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 93 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 97 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 100 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Showings\PendingIndex.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Team1_FinalProject.Models.Showing>> Html { get; private set; }
    }
}
#pragma warning restore 1591
