#pragma checksum "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Admin\RoleList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71b1b831914ca779112c51b43bb7d62601751895"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_RoleList), @"mvc.1.0.view", @"/Views/Admin/RoleList.cshtml")]
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
#line 1 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Admin\RoleList.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71b1b831914ca779112c51b43bb7d62601751895", @"/Views/Admin/RoleList.cshtml")]
    public class Views_Admin_RoleList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<IdentityRole>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Admin\RoleList.cshtml"
  
    ViewData["Title"] = "RoleList";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Role List</h1>
<hr />
<a href=""/Admin/Roles/Add"" class=""btn btn-primary"">Add Role</a>
<table class=""table table-bordered mt-3"">
    <thead>
        <tr>
            <td>Id</td>
            <td>Name</td>
            <td style=""width:220px""></td>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 19 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Admin\RoleList.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 22 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Admin\RoleList.cshtml"
               Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Admin\RoleList.cshtml"
               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                <td>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 604, "\"", 635, 2);
            WriteAttributeValue("", 611, "/admin/EditRole/", 611, 16, true);
#nullable restore
#line 26 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Admin\RoleList.cshtml"
WriteAttributeValue("", 627, item.Id, 627, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm mr-2\">Edit</a>\r\n                    <form action=\"/admin/RoleDelete\" method=\"post\" style=\"display:inline;\">\r\n                        <input type=\"hidden\" name=\"Id\"");
            BeginWriteAttribute("value", " value=\"", 830, "\"", 846, 1);
#nullable restore
#line 28 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Admin\RoleList.cshtml"
WriteAttributeValue("", 838, item.Id, 838, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        <button type=\"submit\" class=\"btn btn-danger btn-sm\">Delete</button>\r\n                    </form>\r\n\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 34 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Admin\RoleList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<IdentityRole>> Html { get; private set; }
    }
}
#pragma warning restore 1591