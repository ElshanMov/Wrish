#pragma checksum "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Shared\_FilterProductsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "923d066ab333eb124ce68f4c8cb4e1fa47e9714a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__FilterProductsPartial), @"mvc.1.0.view", @"/Views/Shared/_FilterProductsPartial.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"923d066ab333eb124ce68f4c8cb4e1fa47e9714a", @"/Views/Shared/_FilterProductsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a3bec1f82b24751fff3782631b57652ff6723cb", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__FilterProductsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FilterProductViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid poster-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("xorus_red"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid hover-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("xorus_hover"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Shared\_FilterProductsPartial.cshtml"
 foreach (var product in Model.Products)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-lg-4 col-md-4 col-sm-6 col-12 col-sep\">\r\n        <div class=\"product-body\">\r\n            <div class=\"img-body\">\r\n                <a href=\"product-detail.html\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "923d066ab333eb124ce68f4c8cb4e1fa47e9714a5452", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 296, "~/uploads/products/", 296, 19, true);
#nullable restore
#line 8 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Shared\_FilterProductsPartial.cshtml"
AddHtmlAttributeValue("", 315, product.ProductImages.FirstOrDefault(x=>x.PosterStatus==true).Image, 315, 68, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</a>\r\n                <a href=\"product-detail.html\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "923d066ab333eb124ce68f4c8cb4e1fa47e9714a7228", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 491, "~/uploads/products/", 491, 19, true);
#nullable restore
#line 9 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Shared\_FilterProductsPartial.cshtml"
AddHtmlAttributeValue("", 510, product.ProductImages.FirstOrDefault(x=>x.PosterStatus==false).Image, 510, 69, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</a>\r\n            </div>\r\n");
#nullable restore
#line 11 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Shared\_FilterProductsPartial.cshtml"
             if (product.DiscountPrice > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"discount-percent\">-");
#nullable restore
#line 13 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Shared\_FilterProductsPartial.cshtml"
                                            Write(product.DiscountPrice.ToString("#00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n");
#nullable restore
#line 14 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Shared\_FilterProductsPartial.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""product-button animate__animated"">
                <a href=""#""><i class=""fa-solid fa-heart product-wishlist""></i></a>
                <a href=""#"" class=""lupa single-lupa-btn"" data-bs-toggle=""modal"" data-bs-target=""#shopModal"" data-id=""6""><i class=""fa-solid fa-magnifying-glass""></i></a>
            </div>
            <div class=""product-content"">
                <a class=""cat-products"" href=""#"">");
#nullable restore
#line 20 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Shared\_FilterProductsPartial.cshtml"
                                            Write(product.Brand.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                <a class=\"product-title\" href=\"#\">");
#nullable restore
#line 21 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Shared\_FilterProductsPartial.cshtml"
                                             Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                <div class=\"price\">\r\n                    <span class=\"amount\">\r\n");
#nullable restore
#line 24 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Shared\_FilterProductsPartial.cshtml"
                         if (product.DiscountPrice > 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <bdi>$<span class=\"old-price\">");
#nullable restore
#line 26 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Shared\_FilterProductsPartial.cshtml"
                                                     Write(product.SalePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></bdi>\r\n                            <span class=\"dollar-symbol\">$</span>\r\n");
#nullable restore
#line 28 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Shared\_FilterProductsPartial.cshtml"
                        Write((product.SalePrice*(100-product.DiscountPrice)/100).ToString("#.00"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Shared\_FilterProductsPartial.cshtml"
                                                                                                   
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"dollar-symbol\">$</span>\r\n");
#nullable restore
#line 33 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Shared\_FilterProductsPartial.cshtml"
                       Write(product.SalePrice);

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Shared\_FilterProductsPartial.cshtml"
                                              
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </span>
                </div>
                <div class=""btn-shop"">
                    <a class=""add-to-card"" href=""#""><span>ADD TO CART</span><i class=""fa-solid fa-bag-shopping""></i></a>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 43 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Shared\_FilterProductsPartial.cshtml"

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FilterProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
