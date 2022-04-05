using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    public class ProductController : Controller
    {
        DataContext _context;
        IWebHostEnvironment _env;
        bool? flag = null;

        public ProductController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(int page=1,bool? select=null,string word=null)
        {
            var query = _context.Products.Include(x => x.ProductImages).Include(x=>x.ProductComments).Include(x=>x.Brand).AsQueryable();
            if (select!=null)
            {
                query = query.Where(x => x.IsDeleted == select);
                flag = select;
            }
            if (flag == true)
            {
                query = query.Where(x => x.IsDeleted);
            }
            if (flag==false)
            {
                query = query.Where(x => !x.IsDeleted);
            }
            if (word!=null)
            {
                query = query.Where(x => x.Name.Contains(word) || x.Brand.Name.Contains(word));
            }
            ViewBag.SelectedPage = page;
            return View(PagenatedList<Product>.Create(query, page, 8));
        }

        public IActionResult Create()
        {
            ViewBag.Brand = _context.Brands.ToList();
            ViewBag.Gender = _context.Genders.ToList();
            ViewBag.Size = _context.Sizes.ToList();
            ViewBag.Color = _context.Colors.ToList();
            ViewBag.Tag = _context.Tags.ToList();
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Product product)
        {
            ViewBag.Brand = _context.Brands.ToList();
            ViewBag.Gender = _context.Genders.ToList();
            ViewBag.Size = _context.Sizes.ToList();
            ViewBag.Color = _context.Colors.ToList();
            ViewBag.Tag = _context.Tags.ToList();

            if (!ModelState.IsValid) return View();

            if (!_context.Brands.Any(x => x.Id == product.BrandId)) 
            {
                ModelState.AddModelError("BrandId", "Brand not found");
                return View(); 
            } 

            if (!_context.Genders.Any(x => x.Id == product.GenderId))
            {
                ModelState.AddModelError("GenreId", "Gender not found");
                return View();
            }

            product.ProductImages = new List<ProductImage>();
            if (product.PosterFile!=null)
            {
                if (product.PosterFile.Length > 2097152)
                {
                    ModelState.AddModelError("PosterFile", "PosterFile max size is 2MB");
                    return View();
                }
                if (product.PosterFile.ContentType != "image/jpeg" && product.PosterFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("PosterFile", "PosterFile must be image/jpeg or image/png");
                    return View();
                }

                ProductImage posterProductImage = new ProductImage
                {
                    PosterStatus = true,
                    Image = FileManager.Save(_env.WebRootPath, "uploads/products", product.PosterFile),
                    Product = product
                };
                product.ProductImages.Add(posterProductImage);
            }
            else
            {
                ModelState.AddModelError("PosterFile", "Poster file is required");
                return View();
            }
            if (product.HoverPosterFile != null)
            {
                if (product.HoverPosterFile.Length > 2097152)
                {
                    ModelState.AddModelError("HoverPosterFile", "HoverPosterFile max size is 2MB");
                    return View();
                }
                if (product.HoverPosterFile.ContentType != "image/jpeg" && product.HoverPosterFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("HoverPosterFile", "HoverPosterFile must be png or jpeg");
                    return View();
                }

                ProductImage hoverImage = new ProductImage()
                {
                    PosterStatus = false,
                    Product = product,
                    Image = FileManager.Save(_env.WebRootPath, "uploads/products", product.HoverPosterFile)
                };

                product.ProductImages.Add(hoverImage);
            }
            else
            {
                ModelState.AddModelError("HoverPosterFile", "HoverPosterFile is reiqured");
                return View();
            }
            if (product.ImageFiles != null)
            {
                foreach (var item in product.ImageFiles)
                {
                    if (item.Length > 2097152)
                    {
                        ModelState.AddModelError("ImageFiles", "ImageFile max size is 2MB");
                        return View();
                    }
                    if (item.ContentType != "image/jpeg" && item.ContentType != "image/png")
                    {
                        ModelState.AddModelError("ImageFiles", "ImageFile must be png or jpeg");
                        return View();
                    }

                    ProductImage productImage = new ProductImage()
                    {
                        PosterStatus = null,
                        Product = product,
                        Image = FileManager.Save(_env.WebRootPath, "uploads/products", item)
                    };

                    product.ProductImages.Add(productImage);
                }
            }

            if (product.ProductSizesIds != null)
            {

                foreach (var item in product.ProductSizesIds)
                {

                    ProductSize productSize = new ProductSize()
                    {
                        SizeId = item,
                        Product = product
                    };

                    _context.ProductSizes.Add(productSize);
                }
            }

            if (product.ProductTagIds != null)
            {

                foreach (var item in product.ProductTagIds)
                {

                    ProductTag productTag = new ProductTag()
                    {
                        TagId = item,
                        Product = product
                    };

                    _context.ProductTags.Add(productTag);
                }
            }

            if (product.ProductColorsIds != null)
            {

                foreach (var item in product.ProductColorsIds)
                {

                    ProductColor productColor = new ProductColor()
                    {
                        ColorId = item,
                        Product = product
                    };

                    _context.ProductColors.Add(productColor);
                }
            }
            

            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id) 
        {
            Product product = _context.Products
                .Include(x => x.ProductImages)
                .Include(x=>x.Brand)
                .Include(x => x.ProductColors)
                .Include(x => x.ProductSizes)
                .Include(x => x.ProductTags)
                .FirstOrDefault(x => x.Id == id);

            if (product==null) return RedirectToAction("notfound", "error");

            ViewBag.Brand = _context.Brands.ToList();
            ViewBag.Gender = _context.Genders.ToList();
            ViewBag.Size = _context.Sizes.ToList();
            ViewBag.Color = _context.Colors.ToList();
            ViewBag.Tag = _context.Tags.ToList();

            product.ProductSizesIds = product.ProductSizes.Select(x => x.SizeId).ToList();
            product.ProductColorsIds = product.ProductColors.Select(x => x.ColorId).ToList();
            product.ProductTagIds = product.ProductTags.Select(x => x.TagId).ToList();

            return View(product);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            Product existProduct = _context.Products
                .Include(x => x.ProductImages)
                .Include(x => x.ProductColors)
                .Include(x => x.ProductSizes)
                .Include(x => x.ProductTags)
                .FirstOrDefault(x => x.Id == product.Id);

            if (existProduct==null) return RedirectToAction("notfound", "error");


            if (product.HoverPosterFile != null)
            {
                var hover = product.HoverPosterFile;
                if (hover.Length > 2097152)
                {
                    ModelState.AddModelError("HoverPosterFile", "HoverPosterFile max size is 2MB");
                    return View();
                }

                if (hover.ContentType != "image/jpeg" && hover.ContentType != "image/png")
                {
                    ModelState.AddModelError("HoverPosterFile", "HoverImage must be png or jpeg");
                    return View();
                }
            }

            if (product.PosterFile != null)
            {
                var poster = product.PosterFile;
                if (poster.Length > 2097152)
                {
                    ModelState.AddModelError("PosterFile", "PosterImage max size is 2MB");
                    return View();
                }

                if (poster.ContentType != "image/jpeg" && poster.ContentType != "image/png")
                {
                    ModelState.AddModelError("PosterFile", "PosterImage must be png or jpeg");
                    return View();
                }
            }

            if (product.ImageFiles != null)
            {
                foreach (var item in product.ImageFiles)
                {
                    if (item.Length > 2097152)
                    {
                        ModelState.AddModelError("ImageFiles", "ImageFile max size is 2MB");
                        break;
                    }
                    if (item.ContentType != "image/jpeg" && item.ContentType != "image/png")
                    {
                        ModelState.AddModelError("ImageFiles", "ImageFile must be png or jpg");
                        break;
                    }
                }
            }

            if (!ModelState.IsValid) return View();

            if (product.PosterFile != null)
            {
                ProductImage posterImage = existProduct.ProductImages.FirstOrDefault(x => x.PosterStatus == true);

                if (posterImage == null) return RedirectToAction("notfound", "error");

                _setProductImages(posterImage, product.PosterFile);
            }

            if (product.HoverPosterFile != null)
            {
                ProductImage hoverImage = existProduct.ProductImages.FirstOrDefault(x => x.PosterStatus == false);
                if (hoverImage == null) return RedirectToAction("notfound", "error");

                _setProductImages(hoverImage, product.HoverPosterFile);
            }
            if (product.ImageFiles != null)
            {
                foreach (var imageItem in existProduct.ProductImages.Where(x => x.PosterStatus == null))
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/products", imageItem.Image);
                    _context.ProductImages.Remove(imageItem);
                }

                foreach (var imageFile in product.ImageFiles)
                {
                    ProductImage productImage = new ProductImage()
                    {
                        ProductId = product.Id,
                        PosterStatus = null,
                        Image = FileManager.Save(_env.WebRootPath, "uploads/products", imageFile)
                    };
                    _context.ProductImages.Add(productImage);
                }
            }

            _setData(product, existProduct);

            existProduct.ProductSizes.RemoveAll(x => !product.ProductSizesIds.Contains(x.SizeId));
            existProduct.ProductColors.RemoveAll(x => !product.ProductColorsIds.Contains(x.ColorId));
            existProduct.ProductTags.RemoveAll(x => !product.ProductTagIds.Contains(x.TagId));

            foreach (var item in product.ProductSizesIds.Where(x => !existProduct.ProductSizes.Any(ps => ps.SizeId == x)))
            {
                ProductSize productSize = new ProductSize()
                {
                    SizeId = item,
                    Product = product
                };
                existProduct.ProductSizes.Add(productSize);
            }



            foreach (var item in product.ProductColorsIds.Where(x => !existProduct.ProductColors.Any(pd => pd.ColorId == x)))
            {
                ProductColor productColor = new ProductColor()
                {
                    ColorId = item,
                    Product = product
                };
                existProduct.ProductColors.Add(productColor);
            }

            foreach (var item in product.ProductTagIds.Where(x => !existProduct.ProductTags.Any(pd => pd.TagId == x)))
            {
                ProductTag productTag = new ProductTag()
                {
                    TagId = item,
                    Product = product
                };
                existProduct.ProductTags.Add(productTag);
            }


            _context.SaveChanges();

            return RedirectToAction("index");

        }
        public IActionResult Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);

            if (product == null) return NotFound();

            product.IsDeleted = true;
            _context.SaveChanges();

            return Ok();
        }
        private void _setData(Product product, Product existProduct)
        {
            existProduct.BrandId = product.BrandId;
            existProduct.GenderId = product.GenderId;
            existProduct.SKU = product.SKU;
            existProduct.CostPrice = product.CostPrice;
            existProduct.ModifiedAt = DateTime.UtcNow.AddHours(4);
            existProduct.Desc = product.Desc;
            existProduct.DiscountPrice = product.DiscountPrice;
            existProduct.Name = product.Name;
            existProduct.SalePrice = product.SalePrice;
        }
        private void _setProductImages(ProductImage productImage, IFormFile productImageFile)
        {
            string filename = FileManager.Save(_env.WebRootPath, "uploads/products", productImageFile);

            FileManager.Delete(_env.WebRootPath, "uploads/products", productImage.Image);
            productImage.Image = filename;
        }

        public IActionResult Comments(int productId,int page=1)
        {
            var query = _context.ProductComments.Include(x=>x.Product).Where(x => x.ProductId == productId);
            ViewBag.SelectedPage = page;
            return View(PagenatedList<ProductComment>.Create(query,page,8));
        }

        public IActionResult DeleteComment(int id)
        {
            ProductComment comment = _context.ProductComments.FirstOrDefault(x => x.Id == id);

            if (comment == null) return RedirectToAction("notfound", "errorpage");

            _context.ProductComments.Remove(comment);
            _context.SaveChanges();
            return Ok();
            
        }

        public IActionResult InfoComment(int id)
        {
            ProductComment comment = _context.ProductComments.Include(x=>x.Product).FirstOrDefault(x => x.Id == id);

            if (comment == null) return RedirectToAction("notfound", "errorpage");

            return View(comment);

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult AcceptComment(int id)
        {
            ProductComment comment = _context.ProductComments.FirstOrDefault(x => x.Id == id);

            if (comment == null) return RedirectToAction("notfound", "errorpage");

            comment.Status = true;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }

}
