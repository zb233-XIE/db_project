using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
  public class Giftcode
  {
        public Giftcode()
        {
            Commodities = new Commodities();
        }//构造函数

        public string ActivateCode { get; set; }
        public string CommodityID { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsUsed { get; set; }
        //属性列表

        public virtual Commodities Commodities { get; set; }
        //与本模型类相关的一些模型类
    }
}
