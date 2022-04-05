using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wrish_BackEnd.Enums
{
    public enum OrderStatus
    {
        Pending=1,
        Accepted=2,
        Rejected=3,
        Canceled=4 //Istifadeci sifarisi pending etdikden sonra legv ede biler biz bilekki kim legv edib admin yoxsa customer
    }
}
