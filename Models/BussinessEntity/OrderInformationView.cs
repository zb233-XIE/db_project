using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TJ_Games.Models;

namespace TJ_Games.Models.BusinessEntity
{
    public class OrderInformationView
    {
        public string orderId { get; set; }
        public DateTime? date { get; set; }
        public string receiverName { get; set; }
        public string receiverPhone { get; set; }
        public string detailAddr { get; set; }
        public string status { get; set; }
        public List<CommodityView> commodityList { get; set; }
    }
}
