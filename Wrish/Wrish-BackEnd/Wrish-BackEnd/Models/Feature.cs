using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Models
{
    public class Feature:BaseEntity
    {
        [Required]
        [StringLength(maximumLength:100)]
        public string Icon { get; set; }
        [Required]
        [StringLength(maximumLength:30)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Desc { get; set; }
    }
}
