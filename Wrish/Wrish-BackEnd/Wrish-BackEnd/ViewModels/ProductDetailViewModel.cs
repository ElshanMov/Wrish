using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Models;

namespace Wrish_BackEnd.ViewModels
{
    public class ProductDetailViewModel
    {
        public ProductComment Comment { get; set; }
        public Product Product { get; set; }
        public List<Product> RelatedProduct { get; set; }
    }
}
