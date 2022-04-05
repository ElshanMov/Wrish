using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Models;

namespace Wrish_BackEnd.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Feature> Features { get; set; }

        public List<Brand> Brands { get; set; }
        public List<Gender> Genders { get; set; }

        public List<FeatureProduct> FeatureProducts { get; set; }

        public List<Product> LatestProducts { get; set; }
        public List<Product> SalesProducts { get; set; }

        public List<InstaImage> InstaImages { get; set; }
        public List<Product> Products { get; set; }
    }
}
