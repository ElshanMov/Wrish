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
    [Authorize(Roles ="Admin,SuperAdmin")]
    public class BrandController : Controller
    {
        DataContext _context;
        IWebHostEnvironment _env;

        public BrandController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int page = 1)
        {
            var query = _context.Brands.AsQueryable();
            ViewBag.SelectedPage = page;
            return View(PagenatedList<Brand>.Create(query, 1, 8));
        }

        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            if (brand.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile is required");
                return View();
            }
            else if (brand.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "ImageFile max size is 2MB");
                return View();
            }
            else if (brand.ImageFile.ContentType != "image/jpeg" && brand.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "The file type is incorrect");
                return View();
            }

            if (!ModelState.IsValid) return View();

            brand.Image = FileManager.Save(_env.WebRootPath, "uploads/brands", brand.ImageFile);
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Brand brand = _context.Brands.FirstOrDefault(x => x.Id == id);
            if (brand == null)
            {
                return RedirectToAction("notfound", "error");
            }
            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Brand brand)
        {
            Brand existBrand = _context.Brands.FirstOrDefault(x => x.Id == brand.Id);
            if (existBrand == null)
            {
                return RedirectToAction("notfound", "error");

            }
            if (brand.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile is required");
                return View();
            }
            else if (brand.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "ImageFile max size is 2MB");
                return View();
            }
            else if (brand.ImageFile.ContentType != "image/jpeg" && brand.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "The file type is incorrect");
                return View();
            }

            if (!ModelState.IsValid) return View();
            FileManager.Delete(_env.WebRootPath, "uploads/brands", existBrand.Image);
            existBrand.Image = FileManager.Save(_env.WebRootPath, "uploads/brands", brand.ImageFile);
            existBrand.ModifiedAt = DateTime.UtcNow.AddHours(4);
            existBrand.Name = brand.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Brand brand = _context.Brands.FirstOrDefault(x => x.Id == id);
            if (brand == null)
            {
                return RedirectToAction("notfound", "error");
            }

            brand.IsDeleted = true;
            _context.SaveChanges();
            return Ok();
        }
    }
}
