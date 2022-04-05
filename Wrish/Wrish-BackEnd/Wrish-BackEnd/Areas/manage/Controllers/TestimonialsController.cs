using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Helper;
using Wrish_BackEnd.Models;

namespace Wrish_BackEnd.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles ="SuperAdmin,Admin")]
    public class TestimonialsController:Controller
    {
        DataContext _context;
        IWebHostEnvironment _env;
        bool? flag = null;

        public TestimonialsController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int page=1,bool? select=null)
        {
            var query = _context.Testimonials.AsQueryable();
            if (select != null)
            {
                query = query.Where(x => x.IsDeleted == select);
                flag = select;
            }
            if (flag == true)
            {
                query = query.Where(x => x.IsDeleted);
            }
            if (flag == false)
            {
                query = query.Where(x => !x.IsDeleted);
            }
            ViewBag.SelectedPage = page;
            return View(PagenatedList<Testimonial>.Create(query, page, 8));
        }

        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Testimonial testimonial)
        {
            if (testimonial.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile is required");
                return View();
            }
            else if (testimonial.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "ImageFile max size is 2MB");
                return View();
            }
            else if (testimonial.ImageFile.ContentType != "image/jpeg" && testimonial.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "The file type is incorrect");
                return View();
            }

            if (!ModelState.IsValid) return View();

            testimonial.Image = FileManager.Save(_env.WebRootPath, "uploads/testimonials", testimonial.ImageFile);
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Testimonial testimonial = _context.Testimonials.FirstOrDefault(x => x.Id == id);
            if (testimonial == null)
            {
                return RedirectToAction("notfound", "error");
            }
            FileManager.Delete(_env.WebRootPath, "uploads/testimonials", testimonial.Image);
            _context.Testimonials.Remove(testimonial);
            return Ok();
        }

        public IActionResult Edit(int id)
        {
            Testimonial testimonial = _context.Testimonials.FirstOrDefault(x => x.Id == id);
            if (testimonial == null)
            {
                return RedirectToAction("notfound", "error");
            }
            return View(testimonial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Testimonial testimonial)
        {
            Testimonial existTestimonial = _context.Testimonials.FirstOrDefault(x => x.Id == testimonial.Id);
            if (existTestimonial == null)
            {
                return RedirectToAction("notfound", "error");
            }
            if (testimonial.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile is required");
                return View();
            }
            else if (testimonial.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "ImageFile max size is 2MB");
            }
            else if (testimonial.ImageFile.ContentType != "image/jpeg" && testimonial.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "The file type is incorrect");
                return View();
            }

            if (!ModelState.IsValid) return View();
            FileManager.Delete(_env.WebRootPath, "uploads/testimonials", existTestimonial.Image);
            existTestimonial.Image = FileManager.Save(_env.WebRootPath, "uploads/testimonials", testimonial.ImageFile);
            existTestimonial.ModifiedAt = DateTime.UtcNow.AddHours(4);
            existTestimonial.FullName = testimonial.FullName;
            existTestimonial.Desc = testimonial.Desc;
            existTestimonial.ReviewCount = testimonial.ReviewCount;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
