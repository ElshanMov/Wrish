using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Models;

namespace Wrish_BackEnd.Areas.manage.ViewModels
{
    public class DashboardViewModel
    {
        public List<AppUser> Users { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
    }
}
