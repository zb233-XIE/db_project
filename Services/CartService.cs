using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TJ_Games.DBContext;
using TJ_Games.Models;
using ThirdParty.Json.LitJson;
namespace TJ_Games.Services
{
    public class CartService
    {
        private readonly ModelContext _context;
        public CartService(ModelContext context)
        {
            _context = context;
        }
        public bool addToCart(string buyerid, string commodityid)
        {
            //筛选该用户的购物车，看里面是否还有该商品
            Users user = _context.Users.FirstOrDefault();
            ShoppingCart cart = _context.ShoppingCart.Where(x => x.ID == buyerid && x.CommodityID == commodityid).FirstOrDefault();
            
            if (cart == null)//说明此时没有对应的游戏在购物车当中
            {
                cart = new ShoppingCart { ID = buyerid, CommodityID = commodityid, JoinTime = DateTime.Now };
                _context.ShoppingCart.Add(cart);
            }
            else
            {
                //为一个空语句，因为一个人不可能在自己游戏库中有两个相同游戏
                ;
            }

            if(_context.SaveChanges()>0)//说明保存成功
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public JsonData CommodityDetails(string CommodityID)
        {
            JsonData jsondata = new JsonData();
            Commodities commodities =_context.Commodities.Where(x=>x.CommodityID==CommodityID).FirstOrDefault();

            if (commodities == null)//此时说明此时没有该ID对应的商品
                return null;
            else
            {
                jsondata["CommodityID"] = commodities.CommodityID;
                jsondata["CommodityName"] = commodities.CommodityName;
                jsondata[" PublisherID"] = commodities.PublisherID;
                jsondata["Price"] = commodities.Price;
                jsondata["LowestPrice"] = commodities.LowestPrice;
                jsondata["PublishTime"] = commodities.PublishTime.ToString();
                jsondata["Description"] = commodities.Description;
                jsondata["PictureURL"] = commodities.PictureURL;
                jsondata["DownLoadURL"] = commodities.DownLoadURL;
                jsondata["SalesVolume"] = commodities.SalesVolume;

                return jsondata;
            }
        }

        public bool addToWishList(string buyerid, string commodityid)
        {

            //筛选该用户的愿望单，看里面是否还有该商品
            Wishlist wishlist = _context.Wishlist.Where(x => x.ID == buyerid && x.CommodityID == commodityid).FirstOrDefault();

            if (wishlist == null)//说明此时没有对应的游戏在愿望单当中
            {
                wishlist = new Wishlist { ID = buyerid, CommodityID = commodityid, PromoteMessage="test" };
                _context.Wishlist.Add(wishlist);
            }
            else
            {
                //为一个空语句，因为一个人不可能在自己愿望单中有两个相同游戏
                ;
            }

            if (_context.SaveChanges() > 0)//说明保存成功
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deleteWishList(string buyerid, string commodityid)
        {
            Wishlist wishlist = _context.Wishlist.Where(x => x.ID == buyerid && x.CommodityID == commodityid).FirstOrDefault();

            //该种情况一般不会出现，因为前端只能在点击按钮之后，才能删除愿望单，那么该愿望单数据是一定会存在的
            if(wishlist == null)//说明此时愿望单当中没有该元素
            {
                return true;
            }
            else//此时说明有愿望单的元素，则对其进行删除
            {
                _context.Wishlist.Remove(wishlist);
            }
            if (_context.SaveChanges() > 0)//说明保存成功
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool addevaluations(Evaluation evaluation)
        {
            if (evaluation == null)
                return false;
            else
            {
                Evaluation evaluation1 = _context.Evaluation.Where(x => x.CommodityID == evaluation.CommodityID && x.BuyerID == evaluation.BuyerID).FirstOrDefault();

                if (evaluation1 != null)
                    return false;

                //添加对应的评论到数据库
                _context.Evaluation.Add(evaluation);

                if (_context.SaveChanges() > 0)//说明保存成功
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
