using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Models;
using Wrish_BackEnd.Services;
using Wrish_BackEnd.ViewModels;

namespace Wrish_BackEnd.Controllers
{
    public class OrderController : Controller
    {
        DataContext _context;
        UserManager<AppUser> _userManager;
        IEmailService _emailService;

        public OrderController(DataContext context, UserManager<AppUser> userManager,IEmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<IActionResult> ShoppingCart() 
        {
            return View(await GetCheckOutItems());
        }


        public async Task<IActionResult> Checkout()
        {

            CheckOutViewModel checkoutVM = new CheckOutViewModel
            {
                CheckOutItems = await GetCheckOutItems(),
                Order = new Order()
            };
            return View(checkoutVM);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Order(Order order)
        {
            AppUser user = null;
            List<CheckOutItemViewModel> checkoutItems = await GetCheckOutItems();
            if (User.Identity.IsAuthenticated)
            {
                user = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.isAdmin);
            }
            if (checkoutItems.Count==0) ModelState.AddModelError("", "There is not any selected product");

            if (user == null && string.IsNullOrWhiteSpace(order.Email))
                ModelState.AddModelError("Email", "Email is required");

            if (user == null && string.IsNullOrWhiteSpace(order.FullName))
                ModelState.AddModelError("FullName", "FullName is required");
         

            if (!ModelState.IsValid)
            {
                return View("checkout", new CheckOutViewModel { CheckOutItems = checkoutItems, Order = order });
            }


            if (user != null)
            {
                order.Email = user.Email;
                order.FullName = user.FullName;
                order.AppUserId = user.Id;
            }

            var lastOrder = _context.Orders.OrderByDescending(x => x.Id).FirstOrDefault();
            order.CodePrefix = order.FullName[0].ToString().ToUpper() + order.Email[0].ToString().ToUpper();
            order.CodeNumber = lastOrder == null ? 1001 : lastOrder.CodeNumber + 1;
            
            order.AppUserId = user?.Id;

            

            order.Status = Enums.OrderStatus.Pending;

            order.OrderItems = new List<OrderItem>();
            foreach (var item in checkoutItems)
            {
                OrderItem orderItem = new OrderItem
                {
                    ProductId = item.Product.Id,
                    Count = item.Count,
                    CostPrice = item.Product.CostPrice,
                    SalePrice = item.Product.SalePrice,
                    DiscountPrice = item.Product.DiscountPrice
                };
                _context.Products.FirstOrDefault(x => x.Id == orderItem.ProductId).SalesCount+=item.Count;
                order.TotalAmount += orderItem.DiscountPrice > 0 ? (orderItem.SalePrice * (1 - orderItem.DiscountPrice / 100)) * orderItem.Count
                    : orderItem.SalePrice * orderItem.Count;
                order.OrderItems.Add(orderItem);
            }            
            var url = Url.Action("trackorder", "order", new { email = order.Email}, Request.Scheme);

            _emailService.Send(order.Email, $"Thank you for choosing us. Order Code-{order.CodePrefix+order.CodeNumber}", url);
            _context.Orders.Add(order);
            _context.SaveChanges();

            if (user!=null)
            {
                _context.BasketItems.RemoveRange(_context.BasketItems.Where(x => x.AppUserId == user.Id));
                _context.SaveChanges();

            }
            else
            {
                HttpContext.Response.Cookies.Delete("basketItemList");
            }

            return RedirectToAction("profile", "account");
        }

        private async Task<List<CheckOutItemViewModel>> GetCheckOutItems()
        {
            List<CheckOutItemViewModel> checkoutItems = new List<CheckOutItemViewModel>();

            AppUser user = null;
            if (User.Identity.IsAuthenticated)
            {
                user =await _userManager.FindByNameAsync(User.Identity.Name);
            }
            if (user!=null && user.isAdmin==false)
            {
                List<BasketItem> basketItems = _context.BasketItems.Include(x => x.Product).ThenInclude(x=>x.ProductImages)
                    .Where(x => x.AppUserId == user.Id).ToList();

                foreach (var item in basketItems)
                {
                    CheckOutItemViewModel checkoutItem = new CheckOutItemViewModel
                    {
                        Product = item.Product,
                        Count = item.Count
                    };                    
                    checkoutItems.Add(checkoutItem);

                }
            }
            else
            {
                string basketItemStr = HttpContext.Request.Cookies["basketItemList"];
                if (basketItemStr != null)
                {
                    List<CookieBasketItemViewModel> basketItems = JsonConvert.DeserializeObject<List<CookieBasketItemViewModel>>(basketItemStr);

                    foreach (var item in basketItems)
                    {
                        CheckOutItemViewModel checkoutItem = new CheckOutItemViewModel
                        {
                            Product = _context.Products.Include(x=>x.ProductImages).FirstOrDefault(x => x.Id == item.ProductId),
                            Count = item.Count
                        };
                        checkoutItems.Add(checkoutItem);
                    }
                }
            }           
            return checkoutItems;
        }

        public IActionResult TrackOrder()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult TrackOrder(OrderTrackViewModel ordertrackVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            ordertrackVM.Order = _context.Orders.Include(x=>x.OrderItems).ThenInclude(x=>x.Product).FirstOrDefault(x => (x.CodePrefix + x.CodeNumber) == ordertrackVM.Code);
            if (ordertrackVM.Order==null)
            {
                ModelState.AddModelError("Code", "There is not any order with this code");
                return View();
            }
            return View(ordertrackVM);
        }
    }
}
