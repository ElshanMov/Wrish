using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Models;

namespace Wrish_BackEnd.ViewModels
{
    public class CheckOutItemViewModel
    {
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
