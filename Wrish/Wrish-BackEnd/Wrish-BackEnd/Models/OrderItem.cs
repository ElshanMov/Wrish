using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Models
{
    public class OrderItem:BaseEntity
    {
        //Reporting ucun Price saxliyiq
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPrice { get; set; } //Kari duzgun hesablamaq ucun
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountPrice { get; set; }

        public int Count { get; set; }

        public Order Oder { get; set; }
        public Product Product { get; set; }
    }
}
