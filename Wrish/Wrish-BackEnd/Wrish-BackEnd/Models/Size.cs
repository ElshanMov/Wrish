using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Models
{
    public class Size:BaseEntity
    {
        [Required]
        [StringLength(maximumLength:10)]
        public string Name { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
    }
}
