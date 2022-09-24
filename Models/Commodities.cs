using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
    public class Commodities
    {
        public Commodities()
        {
            Wishlist = new HashSet<Wishlist>();
            ShoppingCart = new HashSet<ShoppingCart>();
            GameLibrary = new HashSet<GameLibrary>();
            Updatelog = new HashSet<Updatelog>();
            Orders = new HashSet<Orders>();
            Evaluation = new HashSet<Evaluation>();
            Giftcode = new HashSet<Giftcode>();
            Commodity_Genre = new HashSet<Commodity_Genre>();
            Order_Commodity = new HashSet<Order_Commodity>();
        }//构造函数

        public string CommodityID { get; set; }
        public string CommodityName { get; set; }
        public string PublisherID { get; set; }
        public double Price { get; set; }
        public double LowestPrice { get; set; }
        public DateTime PublishTime { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public string DownLoadURL { get; set; }
        public UInt64 SalesVolume { get; set; }
        //属性列表

        public virtual Publishers Publishers { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
        public virtual ICollection<GameLibrary> GameLibrary { get; set; }
        public virtual ICollection<Updatelog> Updatelog { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Evaluation> Evaluation { get; set; }
        public virtual ICollection<Giftcode> Giftcode { get; set; }
        public virtual ICollection<Commodity_Genre> Commodity_Genre { get; set; }
        public virtual ICollection<Order_Commodity> Order_Commodity { get; set; }
        //与本模型类相关的一些模型类
    }
}
