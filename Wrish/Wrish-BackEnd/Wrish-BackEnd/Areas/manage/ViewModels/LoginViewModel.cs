using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Areas.manage.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(maximumLength:20,MinimumLength =5)]
        public string UserName { get; set; }
        [Required]
        [StringLength(maximumLength:25,MinimumLength =8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
