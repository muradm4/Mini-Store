#pragma checksum "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Account\ForgetPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a7901a5558714854e1cd194ed3f540024e63cbc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ForgetPassword), @"mvc.1.0.view", @"/Views/Account/ForgetPassword.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a7901a5558714854e1cd194ed3f540024e63cbc", @"/Views/Account/ForgetPassword.cshtml")]
    public class Views_Account_ForgetPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Account\ForgetPassword.cshtml"
  
    ViewData["Title"] = "ForgetPassword";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div class=""col-md-12"">
<h1>Forget Password</h1>
<hr />
<form action=""/Account/ForgetPassword"" method=""post"">
    
    
    <div class=""form-group"">
        <label for=""Email"">Email</label>
        <input  class=""form-control"" type=""email"" name=""Email"" />
     
    </div>
 
    <button type=""submit"" class=""btn btn-primary"">Submit</button>
</form>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
