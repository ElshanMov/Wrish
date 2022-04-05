using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Models;

namespace Wrish_BackEnd.ViewModels
{
    public class AboutUsViewModel
    {
        public List<InstaImage> InstaImages { get; set; }
        public List<Setting> Settings { get; set; }
        public List<Testimonial> Testimonials { get; set; }
    }
}
