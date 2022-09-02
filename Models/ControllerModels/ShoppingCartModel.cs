using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TJ_Games.Models.BusinessEntity;

namespace TJ_Games.Models
{
    public class Cart
    {
        public List<CartView> items { get; set; }
        public double tot_money { get; set; }
    }
}
