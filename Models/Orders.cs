using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
    public class Orders
    {
        public Orders()
        {
            Order_Commodity = new HashSet<Order_Commodity>();
        }

        public string OrderID { get; set; }
        public string BuyerID { get; set; }
        public string ReceiverID { get; set; }
        public DateTime OrderTime { get; set; }
        public double OrderCost { get; set; }
        // public bool Type { get; set; }

        //属性列表

        public virtual Commodities Commodities { get; set; }
        public virtual Buyers Buyers { get; set; }
        public virtual ICollection<Order_Commodity> Order_Commodity { get; set; }
    }
}
