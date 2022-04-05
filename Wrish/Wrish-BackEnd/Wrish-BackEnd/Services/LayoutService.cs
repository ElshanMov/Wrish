using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Models;
using Wrish_BackEnd.ViewModels;

namespace Wrish_BackEnd.Services
{
    public class LayoutService
    {
        DataContext _context;
        UserManager<AppUser> _userManager;
        IHttpContextAccessor _contextAccessor;

        public LayoutService(DataContext context, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }

        public async Task<List<Setting>> GetSettings()
        {
            return await _context.Settings.ToListAsync();
        }

        public async Task<List<ContactUs>> GetContactUs()
        {
            return await _context.ContactUs.ToListAsync();
        }

        public async Task<List<AppUser>> GetUsers() 
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.Include(x=>x.ProductImages).ToListAsync();
        }

        public async Task<BasketViewModel> GetBasketItems()
        {
            BasketViewModel basket = null;
            AppUser user = null;
            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(_contextAccessor.HttpContext.User.Identity.Name);
            }
            if (user != null && user.isAdmin==false)
            {
                basket = _getBasketItems(_context.BasketItems.Include(x=>x.Product).ThenInclude(x=>x.ProductImages).Where(x => x.AppUserId == user.Id).ToList());
            }
            else
            {
                var basketItemStr = _contextAccessor.HttpContext.Request.Cookies["basketItemList"];
                if (basketItemStr != null)
                {
                    List<CookieBasketItemViewModel> cookieItems = JsonConvert.DeserializeObject<List<CookieBasketItemViewModel>>(basketItemStr);
                    basket = _getBasketItems(cookieItems);

                }
            }

            return basket;

        }

        private BasketViewModel _getBasketItems(List<CookieBasketItemViewModel> cookieBasketItems)
        {
            BasketViewModel basket = new BasketViewModel
            {
                BasketItems = new List<BasketItemViewModel>(),
            };

            foreach (var item in cookieBasketItems)
            {
                Product product = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == item.ProductId);
                BasketItemViewModel basketItem = new BasketItemViewModel
                {
                    Name = product.Name,
                    Price = product.DiscountPrice > 0 ? (product.SalePrice * (1 - product.DiscountPrice / 100)) : product.SalePrice,
                    ProductId = product.Id,
                    Count = item.Count,
                    PosterImage = product.ProductImages.FirstOrDefault(x => x.PosterStatus == true)?.Image
                };

                basketItem.TotalPrice = basketItem.Count * basketItem.Price;
                basket.TotalAmount += basketItem.TotalPrice;
                basket.BasketItems.Add(basketItem);
            }

            return basket;
        }
        private BasketViewModel _getBasketItems(List<BasketItem> basketItems)
        {
            BasketViewModel basket = new BasketViewModel
            {
                BasketItems = new List<BasketItemViewModel>(),
            };


            foreach (var item in basketItems)
            {


                BasketItemViewModel basketItem = new BasketItemViewModel
                {
                    Name = item.Product.Name,
                    Price = item.Product.DiscountPrice > 0 ? (item.Product.SalePrice * (1 - item.Product.DiscountPrice / 100)) : item.Product.SalePrice,
                    ProductId = item.Product.Id,
                    Count = item.Count,
                    PosterImage = item.Product.ProductImages.FirstOrDefault(x => x.PosterStatus == true)?.Image,
                    
                };

                basketItem.TotalPrice = basketItem.Count * basketItem.Price;
                basket.TotalAmount += basketItem.TotalPrice;
                basket.BasketItems.Add(basketItem);
            }

            return basket;
        }

    }
}
