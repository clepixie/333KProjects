#pragma checksum "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e09fd54ce33e48909d150f8bb0e24efdcc0fc5b"
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
#line 2 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/_ViewImports.cshtml"
using Team1_FinalProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e09fd54ce33e48909d150f8bb0e24efdcc0fc5b", @"/Views/Account/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93cc52cd3ac3b23b29f94468f5592c506515b598", @"/Views/_ViewImports.cshtml")]
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
#line 2 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
  
    ViewBag.Title = "Change Info";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>");
#nullable restore
#line 6 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(".</h1>\n\n<div>\n    <h4>Change your account settings</h4>\n    <hr />\n    <dl class=\"dl-horizontal\">\n\n        <dt>First Name:</dt>\n        <dd>");
#nullable restore
#line 14 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
       Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\n\n        <dt>Last Name:</dt>\n        <dd>");
#nullable restore
#line 17 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
       Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\n\n        <dt>User Name:</dt>\n        <dd>");
#nullable restore
#line 20 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
       Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\n\n        <dt>Email:</dt>\n        <dd>");
#nullable restore
#line 23 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
       Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\n\n        <dt>Birthday:</dt>\n        <dd>");
#nullable restore
#line 26 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
       Write(Model.Birthdate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\n        <dd>\n            [");
#nullable restore
#line 28 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
        Write(Html.ActionLink("Change your birthdate", "ChangeBirthdate"));

#line default
#line hidden
#nullable disable
            WriteLiteral("]\n        </dd>\n\n        <dt>Address:</dt>\n        <dd>");
#nullable restore
#line 32 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
       Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\n        <dd>\n            [");
#nullable restore
#line 34 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
        Write(Html.ActionLink("Change your address", "ChangeAddress"));

#line default
#line hidden
#nullable disable
            WriteLiteral("]\n        </dd>\n\n        <dt>Phone Number:</dt>\n        <dd>");
#nullable restore
#line 38 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
       Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\n        <dd>\n            [");
#nullable restore
#line 40 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
        Write(Html.ActionLink("Change your phone number", "ChangePhoneNumber"));

#line default
#line hidden
#nullable disable
            WriteLiteral("]\n        </dd>\n\n        <dt>Password:</dt>\n        <dd>\n            [");
#nullable restore
#line 45 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
        Write(Html.ActionLink("Change your password", "ChangePassword"));

#line default
#line hidden
#nullable disable
            WriteLiteral("]\n        </dd>\n");
#nullable restore
#line 47 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
         if (User.IsInRole("Customer"))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dt>Popcorn Points:</dt>\n            <dd>\n                ");
#nullable restore
#line 51 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
           Write(ViewBag.UserInfo.PopcornPoints);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </dd>\n");
#nullable restore
#line 53 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </dl>\n</div>\n");
#nullable restore
#line 56 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
 if (User.IsInRole("Employee"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e09fd54ce33e48909d150f8bb0e24efdcc0fc5b8691", async() => {
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
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 59 "/Users/ericlin/Documents/GitHub/333KProjects/Team1_FinalProject/Views/Account/Index.cshtml"
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
