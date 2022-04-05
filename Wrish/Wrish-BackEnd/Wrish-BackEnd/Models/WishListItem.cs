using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Models
{
    public class WishListItem:BaseEntity
    {
        public int ProductId { get; set; }
        public string AppUserId { get; set; }

        public Product Product { get; set; }
        public AppUser AppUser { get; set; }
    }
}
