using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
    public class ShoppingCart
    {
        public string ID { get; set; }
        public string CommodityID { get; set; }
        public DateTime JoinTime { get; set; }
        //属性列表

        public virtual Buyers Buyers { get; set; }
        public virtual Commodities Commodities { get; set; }
        //与本模型类相关的一些模型类
    }
}
