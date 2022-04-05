using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Models;

namespace Wrish_BackEnd.ViewModels
{
    public class CheckOutViewModel
    {
        public List<CheckOutItemViewModel> CheckOutItems { get; set; }
        public Order Order { get; set; }
    }
}
