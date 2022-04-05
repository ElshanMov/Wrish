using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wrish_BackEnd.Models;

namespace Wrish_BackEnd.ViewModels
{
    public class ProfileViewModel
    {
        public MemberUpdateViewModel Member { get; set; }
        public List<Order> Orders { get; set; }
    }
}
