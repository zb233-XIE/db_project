using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models.BusinessEntity
{
    public class CartView
    {
        public string CommodityID { get; set; }
        public string CommodityName { get; set; }
        public double Price { get; set; }
        public string PictureURL { get; set; }
        public DateTime JoinTime { get; set; }
    }
}
