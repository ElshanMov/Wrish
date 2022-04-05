using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles ="SuperAdmin,Admin")]
    public class TagController : Controller
    {
        DataContext _context;

        public TagController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {
            var query = _context.Tags.AsQueryable();
            ViewBag.SelectedPage = page;
            return View(PagenatedList<Tag>.Create(query, page, 8));
        }

        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Tag tag)
        {
            if (!ModelState.IsValid) return View();
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Tag tag = _context.Tags.FirstOrDefault(x => x.Id == id);
            if (tag == null)
            {
                return RedirectToAction("notfound", "error");
            }
            return View(tag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tag tag)
        {
            Tag existTag = _context.Tags.FirstOrDefault(x => x.Id == tag.Id);
            if (existTag == null)
            {
                return RedirectToAction("notfound", "error");

            }            

            if (!ModelState.IsValid) return View();
            existTag.ModifiedAt = DateTime.UtcNow.AddHours(4);
            existTag.Name = tag.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Tag tag = _context.Tags.FirstOrDefault(x => x.Id == id);
            if (tag == null)
            {
                return RedirectToAction("notfound", "error");
            }

            tag.IsDeleted = true;
            _context.SaveChanges();
            return Ok();
        }
    }
}
