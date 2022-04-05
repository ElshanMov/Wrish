using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [StringLength(maximumLength: 100)]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }
        [StringLength(maximumLength: 25, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
