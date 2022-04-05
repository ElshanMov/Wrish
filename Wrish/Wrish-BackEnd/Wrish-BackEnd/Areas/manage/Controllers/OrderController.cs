using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Enums;
using Wrish_BackEnd.Models;
using Wrish_BackEnd.Services;

namespace Wrish_BackEnd.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin,Admin")]

    public class OrderController : Controller
    {
        DataContext _context;
        IEmailService _emailService;
        bool? flag = null;

        public OrderController(DataContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public IActionResult Index(int page = 1, OrderStatus? orderStatus = null)
        {
            var query = _context.Orders.Include(x => x.OrderItems).AsQueryable();
            if (orderStatus == OrderStatus.Pending)
            {
                query = query.Where(x => x.Status == OrderStatus.Pending);
            }
            if (orderStatus == OrderStatus.Accepted)
            {
                query = query.Where(x => x.Status == OrderStatus.Accepted);
            }
            if (orderStatus == OrderStatus.Canceled)
            {
                query = query.Where(x => x.Status == OrderStatus.Canceled);
            }
            if (orderStatus == OrderStatus.Rejected)
            {
                query = query.Where(x => x.Status == OrderStatus.Rejected);
            }
            ViewBag.SelectedPage = page;
            return View(PagenatedList<Order>.Create(query, page, 8));
        }

        public IActionResult Edit(int id)
        {
            Order order = _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Product)
             .ThenInclude(x => x.ProductImages).Include(x => x.AppUser)
             .FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return RedirectToAction("notfound", "error");
            }

            return View(order);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Pending(int id)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null) return RedirectToAction("notfound", "error");

            order.Status = (OrderStatus)1;
            _context.SaveChanges();


            return RedirectToAction("index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnProcessing(int id)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null) return RedirectToAction("notfound", "error");
                                    
            order.DeliveryStatus = (OrderDeliveryStatus)1;
            order.Status = (OrderStatus)2;
            _context.SaveChanges();
            return RedirectToAction("index");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnDepot(int id)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null) return RedirectToAction("notfound", "error");

            order.DeliveryStatus = (OrderDeliveryStatus)2;
            _context.SaveChanges();


            return RedirectToAction("index");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnCouirer(int id)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null) return RedirectToAction("notfound", "error");

            order.DeliveryStatus = (OrderDeliveryStatus)3;
            _context.SaveChanges();


            return RedirectToAction("index");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delivered(int id)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null) return RedirectToAction("notfound", "error");

            order.DeliveryStatus = (OrderDeliveryStatus)4;
            _context.SaveChanges();


            return RedirectToAction("index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Canceled(int id)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == id);

            if (order == null) return RedirectToAction("notfound", "error");

            order.Status = (OrderStatus)4;
            _context.SaveChanges();


            return RedirectToAction("index");

        }
        public IActionResult Rejected(int id)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return RedirectToAction("notfound", "error");
            }
            return View(order);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Rejected(Order rejectedText)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == rejectedText.Id);

            if (order == null) return RedirectToAction("notfound", "error");

            if (string.IsNullOrWhiteSpace(rejectedText.RejectText))
            {
                ModelState.AddModelError("RejectText", "Reject text is required");
                return View();
            }


            order.Status = (OrderStatus)3;
            order.RejectText = rejectedText.RejectText;
            _emailService.Send(order.Email, $"Wrish Customer Service Apartment.", $"Hello {order.FullName}.\n {rejectedText.RejectText}");
            _context.SaveChanges();


            return RedirectToAction("index");

        }




    }
}
