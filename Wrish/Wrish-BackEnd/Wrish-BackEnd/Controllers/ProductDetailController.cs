using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Models;
using Wrish_BackEnd.ViewModels;

namespace Wrish_BackEnd.Controllers
{
    public class ProductDetailController : Controller
    {
        DataContext _context;
        UserManager<AppUser> _userManager;

        public ProductDetailController(DataContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            Product product = _context.Products
                .Include(x => x.BasketItems)                
                .Include(x => x.ProductImages)
                .Include(x => x.Gender)
                .Include(x => x.Brand)
                .Include(x => x.ProductComments)
                .Include(x => x.ProductTags)                
                .ThenInclude(x => x.Tag)
                .FirstOrDefault(x => x.Id == id);
            if (product == null) return RedirectToAction("errorpage", "pages");

            ProductDetailViewModel productDetailVM = new ProductDetailViewModel
            {
                Product=product,
                Comment=new ProductComment(),
                RelatedProduct=_context.Products
                .Include(x => x.ProductImages)
                .Include(x=>x.Brand)
                .Where(x => x.BrandId == product.BrandId)
                .OrderByDescending(x => x.Id).Take(5).ToList()
            };

            double rateCount = 0;
            double totalReview = 0;
            ViewBag.RateCount = 0;

            if (product.ProductComments.Count>0)
            {
                foreach (var comment in product.ProductComments.Where(x => x.Status == true))
                {
                    rateCount++;
                    totalReview += comment.Rate;
                }
                if (rateCount != 0)
                {
                    totalReview = Math.Round((totalReview / rateCount),MidpointRounding.AwayFromZero);
                    ViewBag.RateCount = totalReview;
                }
            }
            else
            {
                ViewBag.RateCount=5;
            }

            return View(productDetailVM);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Comment(ProductComment comment)
        {
            Product product = _context.Products
                .Include(x => x.BasketItems)
                .Include(x => x.ProductImages)
                .Include(x => x.Gender)
                .Include(x => x.Brand)
                .Include(x => x.ProductComments)
                .Include(x => x.ProductTags)
                .ThenInclude(x => x.Tag)
                .FirstOrDefault(x => x.Id == comment.ProductId && !x.IsDeleted);
            if (product == null) return RedirectToAction("errorpage", "pages");

            ProductDetailViewModel productDetailVM = new ProductDetailViewModel
            {
                Product = product,
                Comment = new ProductComment(),
                RelatedProduct = _context.Products
                .Include(x => x.ProductImages)
                .Include(x => x.Brand)
                .Where(x => x.BrandId == product.BrandId)
                .OrderByDescending(x => x.Id).Take(5).ToList()
            };
            if (!ModelState.IsValid) 
            {
                TempData["error"] = "The comment information is incorrect";
                return View("index", productDetailVM);

            }

            if (!_context.Products.Any(x => x.Id == comment.ProductId)) 
            {
                TempData["error"] = "This product is not available";
                return View("index", productDetailVM);

            }
            if (string.IsNullOrWhiteSpace(comment.Text))
            {
                TempData["error"] = "Comment is required";
                return View("index", productDetailVM);
            }

            if (!User.Identity.IsAuthenticated)
            {
                if (string.IsNullOrWhiteSpace(comment.FullName))
                {
                    {
                        TempData["error"] = "Full Name is required";
                        return View("index", productDetailVM);

                    }
                }

                if (string.IsNullOrWhiteSpace(comment.Email))
                {
                    TempData["error"] = "Email is required";
                    return View("index", productDetailVM);

                }                                
            }

            else
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                comment.AppUserId = user.Id;
                comment.FullName = user.FullName;
                comment.Email = user.Email;
            }           
            comment.Status = false;            
            _context.ProductComments.Add(comment);
            _context.SaveChanges();
            TempData["success"] = "The comment operation was successful";
            return RedirectToAction("index",new {Id=comment.ProductId });
        }
    }
}
