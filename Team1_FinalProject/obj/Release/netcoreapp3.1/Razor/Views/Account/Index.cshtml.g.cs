#pragma checksum "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "40d2b1cccead4872d12fd9f9c8da79bb1b69b02c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Team1_FinalProject.Views.Account.Views_Account_Index), @"mvc.1.0.view", @"/Views/Account/Index.cshtml")]
namespace Team1_FinalProject.Views.Account
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40d2b1cccead4872d12fd9f9c8da79bb1b69b02c", @"/Views/Account/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2ef1d2052bcd3deffeffaa001f504a0a44dbb64", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "IndexCustomer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
  
    ViewBag.Title = "Change Info";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 6 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</h1>\r\n\r\n<div>\r\n    <h4>Change your account settings</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n\r\n        <dt>First Name:</dt>\r\n        <dd>");
#nullable restore
#line 14 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
       Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n        <dt>Last Name:</dt>\r\n        <dd>");
#nullable restore
#line 17 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
       Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n        <dt>User Name:</dt>\r\n        <dd>");
#nullable restore
#line 20 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
       Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n        <dt>Email:</dt>\r\n        <dd>");
#nullable restore
#line 23 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
       Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n\r\n        <dt>Birthday:</dt>\r\n        <dd>");
#nullable restore
#line 26 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
        Write((Model.Birthdate).ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n        <dd>\r\n            [");
#nullable restore
#line 28 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
        Write(Html.ActionLink("Change your birthdate", "ChangeBirthdate", new { email = Model.Email }));

#line default
#line hidden
#nullable disable
            WriteLiteral("]\r\n        </dd>\r\n\r\n        <dt>Address:</dt>\r\n        <dd>");
#nullable restore
#line 32 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
       Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n        <dd>\r\n            [");
#nullable restore
#line 34 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
        Write(Html.ActionLink("Change your address", "ChangeAddress", new { email = Model.Email }));

#line default
#line hidden
#nullable disable
            WriteLiteral("]\r\n        </dd>\r\n\r\n        <dt>Phone Number:</dt>\r\n        <dd>");
#nullable restore
#line 38 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
       Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n        <dd>\r\n            [");
#nullable restore
#line 40 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
        Write(Html.ActionLink("Change your phone number", "ChangePhoneNumber", new { email = Model.Email }));

#line default
#line hidden
#nullable disable
            WriteLiteral("]\r\n        </dd>\r\n\r\n        <dt>Password:</dt>\r\n        <dd>\r\n            [");
#nullable restore
#line 45 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
        Write(Html.ActionLink("Change your password", "ChangePassword"));

#line default
#line hidden
#nullable disable
            WriteLiteral("]\r\n        </dd>\r\n");
#nullable restore
#line 47 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
         if (User.IsInRole("Customer"))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dt>Popcorn Points:</dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 51 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
           Write(ViewBag.UserInfo.PopcornPoints);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n");
#nullable restore
#line 53 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </dl>\r\n</div>\r\n");
#nullable restore
#line 56 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
 if (User.IsInRole("Employee"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40d2b1cccead4872d12fd9f9c8da79bb1b69b02c9110", async() => {
                WriteLiteral("Customer Master List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-email", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 58 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
                                                                                        WriteLiteral(Model.Email);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["email"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-email", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["email"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 59 "C:\Users\alice\Documents\UT\333K\333KProjects\Team1_FinalProject\Views\Account\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
