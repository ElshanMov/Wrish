#pragma checksum "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Pages\FAQ.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "46f4804c53c13ed1d4ff55b8f171eb9a99bc5696"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pages_FAQ), @"mvc.1.0.view", @"/Views/Pages/FAQ.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46f4804c53c13ed1d4ff55b8f171eb9a99bc5696", @"/Views/Pages/FAQ.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a3bec1f82b24751fff3782631b57652ff6723cb", @"/Views/_ViewImports.cshtml")]
    public class Views_Pages_FAQ : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Faq>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Pages\FAQ.cshtml"
  
    ViewData["Title"] = "FAQ";
    int count = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main>
    <section id=""faqs"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12 col-md-12 col-sm-12"">
                    <div class=""faqs-page-title"">
                        <h1>Frequently Asked Questions<span>.</span></h1>
                    </div>
                </div>
");
#nullable restore
#line 16 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Pages\FAQ.cshtml"
                 foreach (var item in Model)
                {
                    count++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"col-lg-6 col-md-6 col-sm-12\">\r\n                        <div class=\"question-content\">\r\n\r\n                            <h3 class=\"question-title\">0");
#nullable restore
#line 22 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Pages\FAQ.cshtml"
                                                    Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral(". ");
#nullable restore
#line 22 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Pages\FAQ.cshtml"
                                                             Write(item.QuestionsTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            <div class=\"faq_editor\">");
#nullable restore
#line 23 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Pages\FAQ.cshtml"
                                               Write(Html.Raw(item.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 26 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Views\Pages\FAQ.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n    </section>\r\n</main>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Faq>> Html { get; private set; }
    }
}
#pragma warning restore 1591