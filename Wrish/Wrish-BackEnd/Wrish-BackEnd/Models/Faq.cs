using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Models
{
    public class Faq:BaseEntity
    {
        [Required]
        [StringLength(maximumLength:50)]
        public string QuestionsTitle { get; set; }
        [Required]
        [StringLength(maximumLength:3000)]
        public string Content { get; set; }
        
    }
}
