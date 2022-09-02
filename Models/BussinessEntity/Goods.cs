using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models.BusinessEntity
{
    public class Goods
    {
        public string CommodityID { get; set; }
        public string CommodityName { get; set; }
        public string PictureURL { get; set; }
        public List<string> type { get; set; }
        public string description { get; set; }
    }
}
