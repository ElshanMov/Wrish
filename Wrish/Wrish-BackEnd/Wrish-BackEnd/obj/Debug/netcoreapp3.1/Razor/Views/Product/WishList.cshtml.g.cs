#pragma checksum "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Product\WishList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8d2cddcd9eb47348210798fe8b67a5679131211"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_WishList), @"mvc.1.0.view", @"/Views/Product/WishList.cshtml")]
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
#line 1 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\_ViewImports.cshtml"
using Wrish_BackEnd.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\_ViewImports.cshtml"
using Wrish_BackEnd.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\_ViewImports.cshtml"
using Wrish_BackEnd.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8d2cddcd9eb47348210798fe8b67a5679131211", @"/Views/Product/WishList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a3bec1f82b24751fff3782631b57652ff6723cb", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_WishList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WishListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Product\WishList.cshtml"
  
    ViewData["Title"] = "WishList";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<main>
    <section id=""back-image""></section>
    <section id=""wishlist"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12 col-md-12"">
                    <div class=""main-content"">
                        <table class=""content-items"">
                            <tbody>
                                ");
#nullable restore
#line 16 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Product\WishList.cshtml"
                           Write(await Html.PartialAsync("_WishlistItemPartial",Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n</main>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WishListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591