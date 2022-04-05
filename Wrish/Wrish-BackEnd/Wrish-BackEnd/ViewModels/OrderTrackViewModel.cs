using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Models;

namespace Wrish_BackEnd.ViewModels
{
    public class OrderTrackViewModel
    {
        [Required]
        [StringLength(maximumLength:20)]
        public string Code { get; set; }

        public Order Order { get; set; }
    }
}
