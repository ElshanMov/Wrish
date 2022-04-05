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
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class FaqController : Controller
    {
        DataContext _context;
        bool? flag = null;
        public FaqController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page=1,bool? select=null)
        {
            var query = _context.Faqs.AsQueryable();
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
            return View(PagenatedList<Faq>.Create(query, page, 2));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Faq faq)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Faqs.Add(faq);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Faq faq = _context.Faqs.FirstOrDefault(x => x.Id == id);
            if (faq == null)
            {
                return RedirectToAction("notfound", "error");
            }
            faq.IsDeleted = true;
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult Edit(int id) 
        {
            Faq faq = _context.Faqs.FirstOrDefault(x => x.Id == id);
            if (faq==null)
            {
                return RedirectToAction("notfound", "error");
            }
            return View(faq);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Faq faq)
        {
            Faq existFaq = _context.Faqs.FirstOrDefault(x => x.Id == faq.Id);
            if (existFaq == null)
            {
                return RedirectToAction("notfound", "error");
            }
            existFaq.ModifiedAt = DateTime.UtcNow.AddHours(4);
            existFaq.QuestionsTitle = faq.QuestionsTitle;
            existFaq.Content = faq.Content;
            existFaq.ModifiedAt = DateTime.UtcNow.AddHours(4);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
