using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
  public class Wishlist
  {
        public Wishlist()
        {
            Users = new Users();
            Commodities = new Commodities();
        }//构造函数

        public string ID { get; set; }
        public string CommoditityID { get; set; }
        public string PromoteMessage { get; set; }
        //属性列表

        public virtual Users Users { get; set; }
        public virtual Commodities Commodities { get; set; }
        //与本模型类相关的一些模型类
    }
}
