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
    public class InstaImageController : Controller
    {
        DataContext _context;
        IWebHostEnvironment _env;
        bool? flag = null;

        public InstaImageController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int page = 1, bool? select = null)
        {
            var query = _context.InstaImages.AsQueryable();
            if (select != null)
            {
                query = query.Where(x => x.IsDeleted == select);
                flag = select;
            }

            if (flag == true)
            {
                query = query.Where(x => x.IsDeleted);

            }
            else if (flag == false)
            {
                query = query.Where(x => !x.IsDeleted);
            }

            ViewBag.SelectedPage = page;
            return View(PagenatedList<InstaImage>.Create(query, page, 8));

        }

        public IActionResult Create() 
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(InstaImage image)
        {
            if (image.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile is required");
            }
            else if (image.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "ImageFile max size is 2MB");
            }
            else if (image.ImageFile.ContentType != "image/jpeg" && image.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "The file type is incorrect");
            }

            if (!ModelState.IsValid) return View();
            image.Image = FileManager.Save(_env.WebRootPath, "uploads/instaimages", image.ImageFile);
            _context.InstaImages.Add(image);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            InstaImage image = _context.InstaImages.FirstOrDefault(x => x.Id == id);

            if (image == null) RedirectToAction("notfound", "error");

            return View(image);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InstaImage image)
        {
            InstaImage existImage = _context.InstaImages.FirstOrDefault(x => x.Id == image.Id);

            if (image == null) RedirectToAction("notfound", "error");

            if (image.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile is required");
            }
            else if (image.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "ImageFile max size is 2MB");
            }
            else if (image.ImageFile.ContentType != "image/jpeg" && image.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "The file type is incorrect");
            }

            if (!ModelState.IsValid) return View();
            FileManager.Delete(_env.WebRootPath, "uploads/instaimages", existImage.Image);
            existImage.Image = FileManager.Save(_env.WebRootPath, "uploads/instaimages", image.ImageFile);
            _context.SaveChanges();
            return RedirectToAction("index");

        }

        public IActionResult Delete(int id)
        {
            InstaImage image = _context.InstaImages.FirstOrDefault(x => x.Id == id);
            if (image == null)
            {
                return RedirectToAction("notfound", "error");
            }
            image.IsDeleted = true;
            _context.SaveChanges();
            return Ok();
        }
    }
}
