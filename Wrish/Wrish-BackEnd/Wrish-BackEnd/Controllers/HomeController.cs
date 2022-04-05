using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.ViewModels;

namespace Wrish_BackEnd.Models
{
    public class HomeController : Controller
    {
        DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                Sliders=_context.Sliders.Where(x=>!x.IsDeleted).ToList(),
                Features=_context.Features.Where(x=>!x.IsDeleted).ToList(),
                Brands=_context.Brands.Where(x=>!x.IsDeleted&&x.Image!=null).ToList(),
                Genders=_context.Genders.Where(x=>!x.IsDeleted).ToList(),
                FeatureProducts=_context.FeatureProducts.ToList(),
                LatestProducts=_context.Products.Include(x=>x.Brand).Include(x=>x.ProductImages).Take(15).ToList(),
                SalesProducts=_context.Products.Include(x=>x.Brand).Include(x=>x.ProductImages).Where(x=>x.DiscountPrice>0&&!x.IsDeleted).Take(20).ToList(),
                InstaImages=_context.InstaImages.Where(x=>!x.IsDeleted).ToList(),
                Products=_context.Products.Include(x=>x.ProductImages).Include(x=>x.ProductComments).Where(x=>!x.IsDeleted).ToList()
            };
            return View(homeVM);
        }

        public IActionResult GetProduct(int id) 
        {
            Product product = _context.Products.Include(x => x.ProductImages).Include(x=>x.ProductComments).FirstOrDefault(x => x.Id == id);
            double rateCount = 0;
            double totalReview = 0;
            ViewBag.RateCount = 0;

            if (product.ProductComments.Count > 0)
            {
                foreach (var comment in product.ProductComments.Where(x => x.Status == true))
                {
                    rateCount++;
                    totalReview += comment.Rate;
                }
                if (rateCount != 0)
                {
                    totalReview = Math.Round((totalReview / rateCount), MidpointRounding.AwayFromZero);
                    ViewBag.RateCount = totalReview;
                }
            }
            else
            {
                ViewBag.RateCount = 5;
            }
            return PartialView("_ModalProductDetail", product);
        }
    }
}
