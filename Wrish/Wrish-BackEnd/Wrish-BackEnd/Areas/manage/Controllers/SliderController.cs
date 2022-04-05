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

    public class SliderController : Controller
    {
        DataContext _context;
        IWebHostEnvironment _env;
        static bool? flag = null;

        public SliderController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int page = 1, bool? select = null)
        {
            var query = _context.Sliders.AsQueryable();
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
            return View(PagenatedList<Slider>.Create(query, page, 2));

        }

        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (slider.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile is required");
                return View();
            }
            else if (slider.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "ImageFile max size is 2MB");
                return View();
            }
            else if (slider.ImageFile.ContentType != "image/jpeg" && slider.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "The file type is incorrect");
                return View();
            }

            if (!ModelState.IsValid) return View();

            slider.Image = FileManager.Save(_env.WebRootPath, "uploads/sliders", slider.ImageFile);
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);
            if (slider == null)
            {
                return RedirectToAction("notfound", "error");
            }
            slider.IsDeleted = true;
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult Edit(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);
            if (slider==null)
            {
                return RedirectToAction("notfound", "error");
            }
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Slider slider) 
        {
            Slider existSlider = _context.Sliders.FirstOrDefault(x => x.Id == slider.Id);
            if (existSlider == null)
            {
                return RedirectToAction("notfound", "error");
            }
            if (slider.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile is required");
            }
            else if (slider.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "ImageFile max size is 2MB");
            }
            else if (slider.ImageFile.ContentType != "image/jpeg" && slider.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "The file type is incorrect");
            }

            if (!ModelState.IsValid) return View();
            FileManager.Delete(_env.WebRootPath, "uploads/sliders", existSlider.Image);            
            existSlider.Image = FileManager.Save(_env.WebRootPath, "uploads/sliders", slider.ImageFile);
            existSlider.ModifiedAt = DateTime.UtcNow.AddHours(4);
            existSlider.ReturnUrl = slider.ReturnUrl;
            existSlider.Title1 = slider.Title1;
            existSlider.Title2 = slider.Title2;
            existSlider.BtnText = slider.BtnText;
            existSlider.Desc = slider.Desc;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
