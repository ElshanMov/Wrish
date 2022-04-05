﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Models
{
    public class Gender:BaseEntity
    {
        [Required]
        [StringLength(maximumLength:20)]
        public string Name { get; set; }
        [StringLength(maximumLength:100)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public List<Product> Products { get; set; }
    }
}
