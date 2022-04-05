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
    public class GenderController : Controller
    {
        DataContext _context;
        IWebHostEnvironment _env;

        public GenderController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int page=1)
        {
            var query = _context.Genders.AsQueryable();
            ViewBag.SelectedPage = page;
            return View(PagenatedList<Gender>.Create(query,1,8));
        }

        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Gender gender)
        {
            if (gender.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile is required");
            }
            else if (gender.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "ImageFile max size is 2MB");
            }
            else if (gender.ImageFile.ContentType != "image/jpeg" && gender.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "The file type is incorrect");
            }

            if (!ModelState.IsValid) return View();

            gender.Image = FileManager.Save(_env.WebRootPath, "uploads/genders", gender.ImageFile);            
            _context.Genders.Add(gender);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id) 
        {
            Gender gender = _context.Genders.FirstOrDefault(x => x.Id == id);
            if (gender==null)
            {
                return RedirectToAction("notfound", "error");
            }
            return View(gender);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Gender gender)
        {
            Gender existGender = _context.Genders.FirstOrDefault(x => x.Id == gender.Id);
            if (existGender == null)
            {
                return RedirectToAction("notfound", "error");

            }
            if (gender.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "ImageFile is required");
                return View();
            }
            else if (gender.ImageFile.Length > 2097152)
            {
                ModelState.AddModelError("ImageFile", "ImageFile max size is 2MB");
                return View();
            }
            else if (gender.ImageFile.ContentType != "image/jpeg" && gender.ImageFile.ContentType != "image/png")
            {
                ModelState.AddModelError("ImageFile", "The file type is incorrect");
                return View();
            }

            if (!ModelState.IsValid) return View();
            FileManager.Delete(_env.WebRootPath, "uploads/genders", existGender.Image);
            existGender.Image = FileManager.Save(_env.WebRootPath, "uploads/genders", gender.ImageFile);
            existGender.ModifiedAt = DateTime.UtcNow.AddHours(4);
            existGender.Name=gender.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Gender gender = _context.Genders.FirstOrDefault(x => x.Id == id);
            if (gender == null)
            {
                return RedirectToAction("notfound", "error");
            }

            gender.IsDeleted = true;
            _context.SaveChanges();
            return Ok();
        }
    }
}
