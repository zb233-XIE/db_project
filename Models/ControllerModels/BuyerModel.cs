using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
    public class BuyerModel
    {
        public string BuyerID { get; set; }
    }
    public class BuyerMail
    {
        public string BuyerID { get; set; }
        public string OldMail { get; set; }
        public string NewMail { get; set; }
    }
    public class BuyerPasswd
    {
        public string BuyerID { get; set; }
        public string OldPasswd { get; set; }
        public string NewPasswd { get; set; }
    }
    public class AddOrDeleteFavorites                          // 添加或删除某件商品的关注
    {
        public string buyerid { get; set; }
        public string commodityid { get; set; }
    }
    public class DeleteAllFavorites                          // 删除所有关注
    {
        public string buyerid { get; set; }
    }
    public class BuyerOrder                                   //买家订单
    {
        public string BuyerId { get; set; }
    }
}