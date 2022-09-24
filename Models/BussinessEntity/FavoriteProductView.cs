using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models.BusinessEntity
{
    /// <summary>
    /// 查看收藏夹显示信息类
    /// </summary>
    public class FavoriteProductView
    {
        public string BuyerId { get; set; }
        public string CommodityId { get; set; }
        public string CommodityImg { get; set; }         // 商品图片
        public DateTime? DateCreated { get; set; }       // 收藏时间
        public string ShopName { get; set; }             // 发行商名称
        public string CommodityName { get; set; }       // 商品名称
        public double Price { get; set; }             // 商品价格    
    }
}
