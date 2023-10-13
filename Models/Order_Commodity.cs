using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
    public class Order_Commodity
    {
        public string OrderID { get; set; }
        public string CommodityID { get; set; }

        public virtual Commodities Commodities { get; set; }

        public virtual Orders Orders { get; set; }
    }
}
