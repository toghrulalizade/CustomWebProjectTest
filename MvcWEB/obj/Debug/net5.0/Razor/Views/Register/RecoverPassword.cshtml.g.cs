#pragma checksum "C:\Users\Hashimov\Desktop\WebProject\MvcWEB\Views\Register\RecoverPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33348fd1ad129581f1f96cec5d863c36b7632150"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Register_RecoverPassword), @"mvc.1.0.view", @"/Views/Register/RecoverPassword.cshtml")]
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
#line 1 "C:\Users\Hashimov\Desktop\WebProject\MvcWEB\Views\_ViewImports.cshtml"
using MvcWEB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Hashimov\Desktop\WebProject\MvcWEB\Views\_ViewImports.cshtml"
using MvcWEB.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Hashimov\Desktop\WebProject\MvcWEB\Views\Register\RecoverPassword.cshtml"
using Core.Entities.Dto;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33348fd1ad129581f1f96cec5d863c36b7632150", @"/Views/Register/RecoverPassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6a7a9dc9f35cf7039f0a1705dae37196a1213c5", @"/Views/_ViewImports.cshtml")]
    public class Views_Register_RecoverPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PasswordChangeDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Users\Hashimov\Desktop\WebProject\MvcWEB\Views\Register\RecoverPassword.cshtml"
  
    ViewData["Title"] = "Recover Password";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<div class=\'forcolor\'></div>\r\n<main>\r\n    <section class=\"recovery-password-container\">\r\n        <span class=\"logo-container\">\r\n            <i class=\"zmdi zmdi-landscape\"></i>\r\n        </span>\r\n        <h1>RECOVERY</h1>\r\n");
#nullable restore
#line 19 "C:\Users\Hashimov\Desktop\WebProject\MvcWEB\Views\Register\RecoverPassword.cshtml"
         using (Html.BeginForm("RecoverPassword", "Register", FormMethod.Post))
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\Hashimov\Desktop\WebProject\MvcWEB\Views\Register\RecoverPassword.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\Hashimov\Desktop\WebProject\MvcWEB\Views\Register\RecoverPassword.cshtml"
       Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\Hashimov\Desktop\WebProject\MvcWEB\Views\Register\RecoverPassword.cshtml"
       Write(Html.HiddenFor(x => x.Id));

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\Hashimov\Desktop\WebProject\MvcWEB\Views\Register\RecoverPassword.cshtml"
       Write(Html.TextBoxFor(x => x.Password, new { @placeholder = "Password", @type = "password", @class = "register-input" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <i class=\"fas fa-lock\"></i>\r\n            <span class=\"text-danger\"></span>\r\n");
#nullable restore
#line 30 "C:\Users\Hashimov\Desktop\WebProject\MvcWEB\Views\Register\RecoverPassword.cshtml"
       Write(Html.TextBoxFor(x => x.PasswordRepeat, new { @placeholder = "Confirm Password", @type = "password", @class = "register-input" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("            <i class=\"fas fa-lock\"></i>\r\n            <span class=\"text-danger\"></span>\r\n            <div class=\"btn\">\r\n                <button type=\"submit\">Change Password</button>\r\n            </div>\r\n");
#nullable restore
#line 37 "C:\Users\Hashimov\Desktop\WebProject\MvcWEB\Views\Register\RecoverPassword.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </section>\r\n</main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PasswordChangeDto> Html { get; private set; }
    }
}
#pragma warning restore 1591