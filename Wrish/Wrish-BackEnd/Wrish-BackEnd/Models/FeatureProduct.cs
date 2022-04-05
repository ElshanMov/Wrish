using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Models
{
    public class FeatureProduct:BaseEntity
    {
        
        [Required]
        [StringLength(maximumLength: 25)]
        public string Key { get; set; }
        [Required]
        [StringLength(maximumLength: 500)]
        public string Value { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
