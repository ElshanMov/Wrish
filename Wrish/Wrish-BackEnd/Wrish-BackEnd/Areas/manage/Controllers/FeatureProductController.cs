using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Helper;
using Wrish_BackEnd.Models;

namespace Wrish_BackEnd.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class FeatureProductController : Controller
    {
        DataContext _context;
        IWebHostEnvironment _env;
        bool? flag=null;

        public FeatureProductController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int page=1)
        {
            var query = _context.FeatureProducts.AsQueryable();                       
            ViewBag.SelectedPage = page;
            return View(PagenatedList<FeatureProduct>.Create(query,page,6));
        }

        public IActionResult Edit(int id)
        {
            FeatureProduct product = _context.FeatureProducts.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(product);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(FeatureProduct product)
        {
            FeatureProduct existProduct = _context.FeatureProducts.FirstOrDefault(x => x.Id == product.Id);

            if (existProduct == null)
            {
                return RedirectToAction("notfound", "error");
            }

            if (product.ImageFile != null)
            {
                if (product.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("Value", "ImageFile max size is 2MB");
                }
                else if (product.ImageFile.ContentType != "image/jpeg" && product.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("Value", "The file type is incorrect");
                }

                FileManager.Delete(_env.WebRootPath, "uploads/featureproducts", existProduct.Value);
                existProduct.Value = FileManager.Save(_env.WebRootPath, "uploads/featureproducts", product.ImageFile);

            }
            else
            {
                existProduct.Value = product.Value;
            }
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
