using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Models
{
    public class BasketItem:BaseEntity
    {
        public int ProductId { get; set; }
        public string AppUserId { get; set; }
        public int Count { get; set; }

        public Product Product { get; set; }
        public AppUser AppUser { get; set; }
    }
}
