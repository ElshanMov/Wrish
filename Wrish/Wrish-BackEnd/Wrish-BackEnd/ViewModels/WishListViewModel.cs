using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Models;

namespace Wrish_BackEnd.ViewModels
{
    public class WishListViewModel
    {
        public List<WishListItemViewModel> WishlistItems { get; set; }
    }

    public class WishListItemViewModel 
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public string PosterImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool inStock { get; set; }
    }
}
