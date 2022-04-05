using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Models;

namespace Wrish_BackEnd.ViewModels
{
    public class ProductViewModel
    {
        public List<Brand> Brands { get; set; }
        public List<Gender> Genders { get; set; }
        public List<Color> Colors { get; set; }

        public List<Size> Sizes { get; set; }
        public PagenatedList<Product> Products { get; set; }
    }

    public class FilterProductViewModel
    {

        public PagenatedList<Product> Products { get; set; }
    }

}
