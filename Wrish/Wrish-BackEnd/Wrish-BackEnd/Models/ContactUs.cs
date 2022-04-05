using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Models
{
    public class ContactUs:BaseEntity
    {
        [Required]
        [StringLength(maximumLength:50)]
        public string FullName { get; set; }
        [Required]
        [StringLength(maximumLength:60)]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength:800)]
        public string Text { get; set; }
        [Required]        
        public bool Status { get; set; }
    }
}
