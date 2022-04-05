using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Models
{
    public class DataContext:IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public new DbSet<AppUser> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Faq> Faqs { get; set; }

        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<WishListItem> WishListItems { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<FeatureProduct> FeatureProducts { get; set; }
        public DbSet<InstaImage> InstaImages { get; set; }

        public DbSet<Testimonial> Testimonials { get; set; }


    }
}
