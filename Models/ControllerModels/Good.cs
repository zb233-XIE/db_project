using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models.ControllerModels
{
    public class Good
    {
        public string CommodityID { get; set; }
        public string CommodityName { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string PublisherID { get; set; }
        public double Price { get; set; }
        public double LowestPrice { get; set; }
        public DateTime PublishTime { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public string DownLoadURL { get; set; }
        public UInt64 SalesVolume { get; set; }
    }
}
