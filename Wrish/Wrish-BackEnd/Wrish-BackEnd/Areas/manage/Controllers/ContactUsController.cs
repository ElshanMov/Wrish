using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Models;
using Wrish_BackEnd.Services;

namespace Wrish_BackEnd.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class ContactUsController : Controller
    {
        DataContext _context;
        IEmailService _emailService;

        public ContactUsController(DataContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public IActionResult Index(int page=1)
        {
            var query = _context.ContactUs.AsQueryable();
            ViewBag.SelectedPage = page;
            return View(PagenatedList<ContactUs>.Create(query,page,4));
        }

        public IActionResult Message(int id)
        {
            var message = _context.ContactUs.FirstOrDefault(x => x.Id == id);

            if (message == null) return RedirectToAction("notfound", "error");

            return View(message);
        }

        public IActionResult AcceptMessage(ContactUs contactUs)
        {
            ContactUs contactExist = _context.ContactUs.FirstOrDefault(x => x.Id == contactUs.Id);

            if (contactExist == null) return RedirectToAction("notfound", "Error");


            _emailService.Send(contactExist.Email, $"Wrish Customer Service Apartment.", $"Hello {contactExist.FullName}.\n {contactUs.Text}");
            contactExist.Status = true;
            _context.SaveChanges();
            return RedirectToAction("index", "contactus");
        }

        public IActionResult Delete(int id)
        {
            ContactUs contact = _context.ContactUs.FirstOrDefault(x => x.Id == id);
            if (contact == null)
            {
                return RedirectToAction("notfound", "error");
            }
            _context.ContactUs.Remove(contact);
            _context.SaveChanges();
            return Ok();
        }
    }
}
