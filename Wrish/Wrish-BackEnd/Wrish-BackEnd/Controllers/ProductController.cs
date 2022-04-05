using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Models;
using Wrish_BackEnd.ViewModels;

namespace Wrish_BackEnd.Controllers
{
    public class ProductController : Controller
    {
        DataContext _context;
        UserManager<AppUser> _userManager;
        List<Product> searchProducts;

        public ProductController(DataContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            searchProducts = _context.Products.Include(x => x.ProductImages).Where(x=>!x.IsDeleted).ToList();
        }
        
        public IActionResult Shop(int? brandId = null, int? genderId = null, int? maxPrice = null
            , int? minPrice = null, int? colorId = null, int? sizeId = null, int page = 1,string select=null)
        {
            var products = _context.Products.Include(x => x.Brand).Include(x => x.Gender).Include(x => x.ProductImages)
                .Include(x => x.ProductColors).ThenInclude(x => x.Color).Include(x => x.ProductSizes).ThenInclude(x => x.Size)
                .Where(x => !x.IsDeleted).AsQueryable();

            ViewBag.MinPrice = (int)products.Min(x => x.SalePrice);
            ViewBag.MaxPrice = (int)products.Max(x => x.SalePrice);


            if (minPrice != null && maxPrice != null)
                products = products.Where(x => x.SalePrice >= minPrice && x.SalePrice <= maxPrice);

            ViewBag.SelectedMinPrice = minPrice ?? ViewBag.MinPrice;
            ViewBag.SelectedMaxPrice = maxPrice ?? ViewBag.MaxPrice;


            ViewBag.GenderId = genderId;
            ViewBag.BrandId = brandId;
            ViewBag.ColorId = colorId;
            ViewBag.SizeId = sizeId;
            ViewBag.SelectedPage = page;
            ViewBag.Select = select;

            switch (select)
            {
                case "null":
                    products = products.AsQueryable();
                    break;
                case "A-Z":products=products.OrderBy(x => x.Name);
                        break;
                case "PLtH":
                    products = products.OrderBy(x => x.DiscountPrice>0?x.SalePrice*(1-x.DiscountPrice/100):x.SalePrice);
                    break;
                case "PHtL":
                    products = products.OrderByDescending(x => x.DiscountPrice > 0 ? x.SalePrice * (1 - x.DiscountPrice / 100) : x.SalePrice);
                    break;
                case "LaP":
                    products = products.OrderByDescending(x=>x.Id);
                    break;
            }
            if (sizeId!=null)
            {
                products = products.Where(x => x.ProductSizes.Any(x => x.SizeId==sizeId));
            }

            if (colorId != null)
            {
                products = products.Where(x => x.ProductColors.Any(x => x.ColorId == colorId));
            }

            if (genderId != null)
            {
                products = products.Where(x => x.GenderId == genderId);
            }
            if (brandId != null)
            {
                products = products.Where(x => x.BrandId == brandId);
            }

            ProductViewModel productVM = new ProductViewModel
            {
                Brands = _context.Brands.Include(x => x.Products).Where(x => !x.IsDeleted).ToList(),
                Genders = _context.Genders.Include(x => x.Products).Where(x => !x.IsDeleted).ToList(),
                Colors = _context.Colors.Include(x => x.ProductColors).ThenInclude(x => x.Color).Where(x => !x.IsDeleted).ToList(),
                Sizes = _context.Sizes.Where(x => !x.IsDeleted).ToList(),
                Products = PagenatedList<Product>.Create(products, page, 6)
            };

            return View(productVM);
        }

        

        public async Task<IActionResult> AddBasket(int productId, int count = 1)
        {
            if (!_context.Products.Any(x => x.Id == productId))
            {
                return RedirectToAction("errorpage", "pages");
            }

            BasketViewModel data = null;

            AppUser user = null;
            if (User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(User.Identity.Name);
            }

            if (user != null && !user.isAdmin)
            {

                BasketItem basketItem = _context.BasketItems.FirstOrDefault(x => x.AppUserId == user.Id && x.ProductId == productId);
                if (basketItem == null)
                {
                    basketItem = new BasketItem
                    {
                        AppUserId = user.Id,
                        ProductId = productId,

                        Count = count > 1 ? count : 1
                    };
                    _context.BasketItems.Add(basketItem);
                }
                else
                {
                    basketItem.Count += count;
                }
                _context.SaveChanges();

                data = _getBasketItems(_context.BasketItems.Include(x => x.Product).ThenInclude(x => x.ProductImages).Where(x => x.AppUserId == user.Id).ToList());

            }
            else
            {
                List<CookieBasketItemViewModel> basketItems = new List<CookieBasketItemViewModel>();

                string existBasketItems = HttpContext.Request.Cookies["basketItemList"];

                if (existBasketItems != null)
                {
                    basketItems = JsonConvert.DeserializeObject<List<CookieBasketItemViewModel>>(existBasketItems);

                }
                CookieBasketItemViewModel item = basketItems.FirstOrDefault(x => x.ProductId == productId);
                if (item == null)
                {
                    item = new CookieBasketItemViewModel
                    {
                        ProductId = productId,
                        Count = count > 1 ? count : 1
                    };
                    basketItems.Add(item);
                }
                else
                {
                    item.Count += count;
                }

                var productIdStr = JsonConvert.SerializeObject(basketItems);

                HttpContext.Response.Cookies.Append("basketItemList", productIdStr);

                data = _getBasketItems(basketItems);
            }
            return PartialView("_BasketItemPartial", data);
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
                    PosterImage = item.Product.ProductImages.FirstOrDefault(x => x.PosterStatus == true)?.Image
                };

                basketItem.TotalPrice = basketItem.Count * basketItem.Price;
                basket.TotalAmount += basketItem.TotalPrice;
                basket.BasketItems.Add(basketItem);
            }

            return basket;
        }

        public async Task<IActionResult> DeleteFromBasket(int id)
        {
            List<CookieBasketItemViewModel> cookieBaskets = new List<CookieBasketItemViewModel>();
            AppUser user = null;
            BasketViewModel data = null;
            if (User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(User.Identity.Name);
            }
            if (user!=null && !user.isAdmin)
            {
                BasketItem basketItem = _context.BasketItems.FirstOrDefault(x => x.ProductId == id);
                if (basketItem.Count == 1)
                {
                    _context.BasketItems.Remove(basketItem);
                }
                else
                {
                    basketItem.Count--;
                }
                _context.SaveChanges();
                data = _getBasketItems(_context.BasketItems.Include(x => x.Product).ThenInclude(x => x.ProductImages).Where(x => x.AppUserId == user.Id).ToList());
            }
            else
            {
                string basketStr = HttpContext.Request.Cookies["basketItemList"];
                cookieBaskets = JsonConvert.DeserializeObject<List<CookieBasketItemViewModel>>(basketStr);
                CookieBasketItemViewModel cookieBasket = cookieBaskets.FirstOrDefault(x => x.ProductId == id);
                if (cookieBasket == null) return NotFound();

                if (cookieBasket.Count < 2)
                {
                    cookieBaskets.Remove(cookieBasket);
                }
                else
                {
                    cookieBasket.Count--;
                }
                data = _getBasketItems(cookieBaskets);
                HttpContext.Response.Cookies.Append("basketItemList", JsonConvert.SerializeObject(cookieBaskets));
                
            }
            return PartialView("_BasketItemPartial", data);
        }





        public IActionResult WishList()
        {
            AppUser user = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.isAdmin);
            if (user == null) return RedirectToAction("login", "account");
            WishListViewModel wishListsVM = new WishListViewModel();
            wishListsVM.WishlistItems = _context.WishListItems.Select(x => new WishListItemViewModel
            {
                Name = x.Product.Name,
                ProductId = x.ProductId,
                DiscountPercent = x.Product.DiscountPrice,
                SalePrice = x.Product.SalePrice,
                CostPrice = x.Product.CostPrice,
                inStock = true,
                PosterImage = x.Product.ProductImages.FirstOrDefault(x => x.PosterStatus == true).Image
            }).ToList();

            return View(wishListsVM);
        }

        public IActionResult AddWishList(int id)
        {
            AppUser member = null;

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("login", "account");
            }
            else
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.isAdmin);
            }
            Product product = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);                      

            WishListViewModel wishListsVM = new WishListViewModel();

            if (member != null)
            {

                WishListItem memberWistListItem = _context.WishListItems.FirstOrDefault(x => x.AppUserId == member.Id && x.ProductId == id);

                if (memberWistListItem == null)
                {
                    memberWistListItem = new WishListItem()
                    {
                        AppUserId = member.Id,
                        ProductId = product.Id
                    };
                    _context.WishListItems.Add(memberWistListItem);
                }

                _context.SaveChanges();

                wishListsVM.WishlistItems = _context.WishListItems.Select(x => new WishListItemViewModel()
                {
                    DiscountPercent = x.Product.DiscountPrice,
                    Name = x.Product.Name,
                    SalePrice = x.Product.SalePrice,
                    ProductId = x.ProductId,
                    PosterImage = x.Product.ProductImages.FirstOrDefault(x => x.PosterStatus == true).Image,
                    inStock = false,
                    CreatedAt = memberWistListItem.CreatedAt,
                    CostPrice = x.Product.CostPrice
                }).ToList();

            }            
            return NoContent();
        }

        public IActionResult RemoveWishList(int id)
        {
            Product product = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);

            if (product == null) return RedirectToAction("errorpage", "pages");




            AppUser member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.isAdmin);


            WishListViewModel wishListsItem = new WishListViewModel();

            if (member != null)
            {

                WishListItem wishListItem = _context.WishListItems.
                    Include(x => x.Product).ThenInclude(x => x.ProductImages).
                    FirstOrDefault(x => x.ProductId == id);

                _context.WishListItems.Remove(wishListItem);

                _context.SaveChanges();

                wishListsItem.WishlistItems = _context.WishListItems.Include(x => x.Product).ThenInclude(x => x.ProductSizes).ThenInclude(x => x.Size)
                    .Include(x => x.Product).ThenInclude(x => x.ProductImages).Where(x => x.AppUserId == member.Id).Select(x => new WishListItemViewModel()
                    {
                        ProductId = x.ProductId,
                        Name = x.Product.Name,
                        DiscountPercent = x.Product.DiscountPrice,
                        SalePrice = x.Product.SalePrice,
                        PosterImage = x.Product.ProductImages.FirstOrDefault(x => x.PosterStatus == true).Image
                    }).ToList();
            }

            return PartialView("_WishlistItemPartial", wishListsItem);
        }

        public IActionResult Search(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) text = string.Empty;
            List<Product> products = searchProducts.Where(x=>x.Name.ToUpper().Contains(text.ToUpper())).ToList();
            return PartialView("_SearchPartial", products);
        }


        
    }
}
