#pragma checksum "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Shop\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e38eab39d28140df992897373390f34fa49e8c56"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_Details), @"mvc.1.0.view", @"/Views/Shop/Details.cshtml")]
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
#line 1 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Shop\Details.cshtml"
using LastChance.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e38eab39d28140df992897373390f34fa49e8c56", @"/Views/Shop/Details.cshtml")]
    public class Views_Shop_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductDetailModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Shop\Details.cshtml"
      
        ViewData["Title"] = "Details";
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
   

    
            <div class=""row"">
                <div class=""col-md-3"">
                    <img class=""img-fluid"" src=""https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-xr-red-select-201809?wid=940&hei=1112&fmt=png-alpha&qlt=80&.v=1551226038669"" alt=""Alternate Text"" />
                </div>
                <div class=""col-md-9"">
                    <h5 class=""card-title"">");
#nullable restore
#line 15 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Shop\Details.cshtml"
                                      Write(Model.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n");
#nullable restore
#line 16 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Shop\Details.cshtml"
                     foreach (var item in Model.Categories)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 666, "\"", 692, 2);
            WriteAttributeValue("", 673, "/products/", 673, 10, true);
#nullable restore
#line 18 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Shop\Details.cshtml"
WriteAttributeValue("", 683, item.Url, 683, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-link p-0 mb-3\">");
#nullable restore
#line 18 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Shop\Details.cshtml"
                                                                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 19 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Shop\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <h6 class=\"card-text\">\r\n                        ");
#nullable restore
#line 22 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Shop\Details.cshtml"
                   Write(Model.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </h6>
                    <button type=""submit"" class=""btn btn-warning btn-lg"">Add To Cart</button>

                </div>
            </div>
            <div class=""row"">
                <div class=""col-md-9"">
                    <p>");
#nullable restore
#line 30 "C:\Users\Murad\Desktop\Web\Murad\LastChance\LastChance\Views\Shop\Details.cshtml"
                  Write(Model.Product.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p> \r\n                </div>\r\n                </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductDetailModel> Html { get; private set; }
    }
}
#pragma warning restore 1591