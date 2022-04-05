using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Models
{
    public class ProductSize
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }

        public Product Product { get; set; }
        public Size Size { get; set; }

        
    }
}
