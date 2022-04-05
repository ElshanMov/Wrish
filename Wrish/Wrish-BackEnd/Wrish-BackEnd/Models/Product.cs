using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Models
{
    public class Product:BaseEntity
    {

        [Required]
        public int BrandId { get; set; }
        [Required]
        public int GenderId { get; set; }

        [Required]
        [StringLength(maximumLength:50)]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength:500)]
        public string Desc { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountPrice { get; set; }
        [StringLength(maximumLength:10)]
        public string SKU { get; set; }

        public int SalesCount { get; set; }

        [Required]
        public bool StockStatus { get; set; }

        public Brand Brand { get; set; }
        public Gender Gender { get; set; }

        public List<BasketItem> BasketItems { get; set; }
        public List<WishListItem> WishListItems { get; set; }

        public List<ProductComment> ProductComments { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public List<ProductImage> ProductImages { get; set; }
        public List<ProductTag> ProductTags { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
        public List<ProductColor> ProductColors { get; set; }

        [NotMapped]
        public IFormFile PosterFile { get; set; }
        [NotMapped]
        public IFormFile HoverPosterFile { get; set; }
        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; }
        [NotMapped]
        public List<int> ProductColorsIds { get; set; }
        [NotMapped]
        public List<int> ProductSizesIds { get; set; }

        [NotMapped]
        public List<int> ProductImageIds { get; set; }

        [NotMapped]
        public List<int> ProductTagIds { get; set; }

        


    }
}
