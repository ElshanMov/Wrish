using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Models
{
    public class Testimonial:BaseEntity
    {
        [Required]
        [StringLength(maximumLength:30)]
        public string FullName { get; set; }
        [Required]
        [StringLength(maximumLength:300)]
        public string Desc { get; set; }
        [Required]
        [Range(1,5)]
        public int ReviewCount { get; set; }
        [StringLength(maximumLength:100)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
