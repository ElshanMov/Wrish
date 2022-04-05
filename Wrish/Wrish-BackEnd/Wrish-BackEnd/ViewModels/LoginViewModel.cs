using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 4)]
        public string Email { get; set; } 
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
