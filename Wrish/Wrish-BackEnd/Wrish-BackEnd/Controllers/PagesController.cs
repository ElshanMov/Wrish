using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Models;
using Wrish_BackEnd.ViewModels;

namespace Wrish_BackEnd.Controllers
{
    public class PagesController : Controller
    {
        DataContext _context;

        public PagesController(DataContext context)
        {
            _context = context;
        }

        public IActionResult FAQ()
        {
            return View(_context.Faqs.Where(x => !x.IsDeleted).ToList());
        }

        public IActionResult AboutUs()
        {
            AboutUsViewModel aboutusVM = new AboutUsViewModel
            {
                InstaImages=_context.InstaImages.Where(x=>!x.IsDeleted).ToList(),
                Settings=_context.Settings.ToList(),
                Testimonials=_context.Testimonials.ToList()
            };
            return View(aboutusVM);
        }

        public IActionResult ErrorPage()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Contact(ContactUs contactUs)
        {
            if (!ModelState.IsValid) return View();
            contactUs.Status = false;
            _context.ContactUs.Add(contactUs);
            _context.SaveChanges();
            TempData["Success"] = "Thank you for your message. You will be contacted as soon as possible";
            return RedirectToAction("contact");
        }
    }
}
