using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Models;

namespace Wrish_BackEnd.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles =("SuperAdmin,Admin"))]
    public class SizeController : Controller
    {
        DataContext _context;

        public SizeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1)
        {
            var query = _context.Sizes.AsQueryable();
            ViewBag.SelectedPage = page;
            return View(PagenatedList<Size>.Create(query, page, 8));
        }

        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Size size)
        {
            if (!ModelState.IsValid) return View();
            _context.Sizes.Add(size);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Size size = _context.Sizes.FirstOrDefault(x => x.Id == id);
            if (size == null)
            {
                return RedirectToAction("notfound", "error");
            }
            return View(size);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Size size)
        {
            Size existSize = _context.Sizes.FirstOrDefault(x => x.Id == size.Id);
            if (existSize == null)
            {
                return RedirectToAction("notfound", "error");

            }

            if (!ModelState.IsValid) return View();
            existSize.ModifiedAt = DateTime.UtcNow.AddHours(4);
            existSize.Name = size.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Size size = _context.Sizes.FirstOrDefault(x => x.Id == id);
            if (size == null)
            {
                return RedirectToAction("notfound", "error");
            }

            size.IsDeleted = true;
            _context.SaveChanges();
            return Ok();
        }
    }
}
