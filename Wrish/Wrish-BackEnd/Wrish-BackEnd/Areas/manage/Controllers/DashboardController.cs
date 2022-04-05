using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Areas.manage.ViewModels;
using Wrish_BackEnd.Models;

namespace Wrish_BackEnd.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class DashboardController : Controller
    {
        DataContext _context;

        public DashboardController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            DashboardViewModel dashboardVM = new DashboardViewModel
            {
                Users = _context.Users.ToList(),
                Orders=_context.Orders.ToList(),
                Products=_context.Products.ToList()
            };
            
            return View(dashboardVM);
        }

        public JsonResult VisualizeProductResult()
        {
            return Json(ChartProducts());
        }

        public List<SalesStatisticsViewModel> ChartProducts()
        {
            List<SalesStatisticsViewModel> salesStatistics =new List<SalesStatisticsViewModel>();
            List<Product> products = _context.Products.OrderByDescending(x => x.SalesCount * (x.DiscountPrice > 0 ? x.SalePrice * (1 - x.DiscountPrice / 100) : x.SalePrice)).ToList();
            foreach (var item in products)
            {
                SalesStatisticsViewModel salesStatisticsItem = new SalesStatisticsViewModel
                {
                    Name = item.Name,
                    TotalAmount = (item.SalesCount * (item.DiscountPrice > 0 ? item.SalePrice * (1 - item.DiscountPrice / 100) : item.SalePrice))
                };
                salesStatistics.Add(salesStatisticsItem);
            }
            return salesStatistics;
        }

       


    }
}
