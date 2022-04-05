using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Models
{
    public class Color:BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<ProductColor> ProductColors { get; set; }
    }
}
