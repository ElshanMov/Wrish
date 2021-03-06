#pragma checksum "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Areas\manage\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea55c0991e76bfeb3b033e37e51faa1748029290"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_manage_Views_Dashboard_Index), @"mvc.1.0.view", @"/Areas/manage/Views/Dashboard/Index.cshtml")]
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
#line 1 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Areas\manage\Views\_ViewImports.cshtml"
using Wrish_BackEnd.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Areas\manage\Views\_ViewImports.cshtml"
using Wrish_BackEnd.Areas.manage.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Areas\manage\Views\_ViewImports.cshtml"
using Wrish_BackEnd.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Areas\manage\Views\_ViewImports.cshtml"
using Wrish_BackEnd.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea55c0991e76bfeb3b033e37e51faa1748029290", @"/Areas/manage/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6fdbf4661cd4673db9e7dc035823b8fd99779b90", @"/Areas/manage/Views/_ViewImports.cshtml")]
    public class Areas_manage_Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""container-fluid"">
    <!-- Content Row -->
    <div class=""row"">

        <!-- Earnings (Monthly) Card Example -->
        <div class=""col-xl-3 col-md-6 mb-4"">
            <div class=""card border-left-primary shadow h-100 py-2"">
                <div class=""card-body"">
                    <div class=""row no-gutters align-items-center"">
                        <div class=""col mr-2"">
                            <div class=""text-xs font-weight-bold text-primary text-uppercase mb-1"">
                                Earnings (Monthly)
                            </div>
                            <div class=""h5 mb-0 font-weight-bold text-gray-800"">$40,000</div>
                        </div>
                        <div class=""col-auto"">
                            <i class=""fas fa-calendar fa-2x text-gray-300""></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Earnings (Monthly) Card Example -->
        <div class=""col-x");
            WriteLiteral(@"l-3 col-md-6 mb-4"">
            <div class=""card border-left-success shadow h-100 py-2"">
                <div class=""card-body"">
                    <div class=""row no-gutters align-items-center"">
                        <div class=""col mr-2"">
                            <div class=""text-xs font-weight-bold text-success text-uppercase mb-1"">
                                Earnings (Annual)
                            </div>
                            <div class=""h5 mb-0 font-weight-bold text-gray-800"">$215,000</div>
                        </div>
                        <div class=""col-auto"">
                            <i class=""fas fa-dollar-sign fa-2x text-gray-300""></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Earnings (Monthly) Card Example -->
        <div class=""col-xl-3 col-md-6 mb-4"">
            <div class=""card border-left-info shadow h-100 py-2"">
                <div class=""card-body"">
                    <di");
            WriteLiteral(@"v class=""row no-gutters align-items-center"">
                        <div class=""col mr-2"">
                            <div class=""text-xs font-weight-bold text-info text-uppercase mb-1"">
                                Tasks
                            </div>
                            <div class=""row no-gutters align-items-center"">
                                <div class=""col-auto"">
                                    <div class=""h5 mb-0 mr-3 font-weight-bold text-gray-800"">50%</div>
                                </div>
                                <div class=""col"">
                                    <div class=""progress progress-sm mr-2"">
                                        <div class=""progress-bar bg-info"" role=""progressbar""
                                             style=""width: 50%"" aria-valuenow=""50"" aria-valuemin=""0""
                                             aria-valuemax=""100""></div>
                                    </div>
                                </div>
               ");
            WriteLiteral(@"             </div>
                        </div>
                        <div class=""col-auto"">
                            <i class=""fas fa-clipboard-list fa-2x text-gray-300""></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Pending Requests Card Example -->
        <div class=""col-xl-3 col-md-6 mb-4"">
            <div class=""card border-left-warning shadow h-100 py-2"">
                <div class=""card-body"">
                    <div class=""row no-gutters align-items-center"">
                        <div class=""col mr-2"">
                            <div class=""text-xs font-weight-bold text-warning text-uppercase mb-1"">
                                Pending Requests
                            </div>
                            <div class=""h5 mb-0 font-weight-bold text-gray-800"">18</div>
                        </div>
                        <div class=""col-auto"">
                            <i class=""fas fa-comments fa-");
            WriteLiteral(@"2x text-gray-300""></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Content Row -->

    <div class=""row"">

        <!-- Area Chart -->
        <div class=""col-xl-12 col-lg-12"">
            <div id=""Piechart_div""></div>
        </div>

        <!-- Pie Chart -->
        
    </div>



</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script type=""text/javascript"" src=""https://www.google.com/jsapi""></script>
    <script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>
    <script src=""http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js""></script>
    <script>
        $(document).ready(function () {
            $.ajax({
                type: ""POST"",
                dataType: ""json"",
                contentType: ""application/json"",
                url: '");
#nullable restore
#line 121 "C:\Masaüstü\Final\Wrish\Wrish-BackEnd\Wrish-BackEnd\Areas\manage\Views\Dashboard\Index.cshtml"
                 Write(Url.Action("VisualizeProductResult", "Dashboard"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                success: function (result) {
                    google.charts.load('current', {
                        'packages': ['corechart']
                    });
                    google.charts.setOnLoadCallback(function () {
                        drawChart(result);
                    });
                }
            });
        });

        function drawChart(result) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Name');
            data.addColumn('number', 'Stoklar');
            var dataArray = [];

            $.each(result, function (i, obj) {
                dataArray.push([obj.name, obj.totalAmount]);
            });
            data.addRows(dataArray);

            var columnChartOptions = {
                title: ""Revenue Sources"",
                width: 850,
                height: 400,
                bar: { groupWidth: ""20%"" },
            };

            var columnChart = new google.visualization.PieChart(document
           ");
                WriteLiteral("     .getElementById(\'Piechart_div\'));\n\n            columnChart.draw(data, columnChartOptions);\n        }\n    </script>\n\n");
            }
            );
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
