﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
    public class Orders
    {
        public string OrderID { get; set; }
        public string CommodityID { get; set; }
        public string BuyerID { get; set; }
        public DateTime OrderTime { get; set; }
        public UInt64 OrderCost { get; set; }
        // public bool Type { get; set; }
        public int Type { get; set; }
        //属性列表

        public virtual Commodities Commodities { get; set; }
        public virtual Buyers Buyers { get; set; }
    }
}
