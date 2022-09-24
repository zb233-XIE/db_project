using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
    public class Updatelog
    {
        public string CommodityID { get; set; }
        public string VersionNumber { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Description { get; set; }
        //属性列表

        public virtual Commodities Commodities { get; set; }
        //与本模型类相关的一些模型类
    }
}
