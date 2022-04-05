using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Models
{
    public class AppUser:IdentityUser
    {
        [Required]
        [StringLength(maximumLength:30,MinimumLength =5)]
        public string FullName { get; set; }

        public bool isAdmin { get; set; }
        public List<ProductComment> ProductComments { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public List<WishListItem> WishListItems { get; set; }
        public List<Order> Orders { get; set; }

    }
}
