using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Models
{
    public class Slider:BaseEntity
    {
        [Required]
        [StringLength(maximumLength:30)]
        public string Title1 { get; set; }
        [Required]
        [StringLength(maximumLength: 30)]
        public string Title2 { get; set; }
        [Required]
        [StringLength(maximumLength: 15)]
        public string BtnText { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string ReturnUrl { get; set; }
        [StringLength(maximumLength: 100)]
        public string Image { get; set; }
        [Required]
        [StringLength(maximumLength: 200)]
        public string Desc { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
