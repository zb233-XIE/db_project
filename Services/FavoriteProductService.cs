using TJ_Games.DBContext;
using TJ_Games.Models;
using TJ_Games.Models.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Services
{
    /// <summary>
    /// 收藏夹管理中心
    /// </summary>
    public class FavoriteProductService 
    {
        // 构造函数
        private readonly ModelContext _context;

        public FavoriteProductService(ModelContext context)
        {
            _context = context;
        }

        //添加购物车
        public bool addToFavorite(string id, string commodityid)
        {
            ShoppingCart favorite = _context.ShoppingCart.Where(x => x.ID == id && x.CommodityID == commodityid).FirstOrDefault();
            if (favorite == null)
            {
                favorite = new ShoppingCart { ID = id, CommodityID = commodityid, JoinTime = DateTime.Now };
                _context.ShoppingCart.Add(favorite);

                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        // 从购物车中删除
        public bool removeFromFavorite(string buyerid, string commodityid)
        {
            ShoppingCart favorite = _context.ShoppingCart.Where(x => x.ID == buyerid && x.CommodityID == commodityid).FirstOrDefault();
            if (favorite != null)
            {
                _context.ShoppingCart.Remove(favorite);

                if (_context.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        // 清空购物车
        public bool removeAllFavorite(string buyerid)
        {
            List<ShoppingCart> favorites = _context.ShoppingCart.Where(x => x.ID == buyerid).ToList();
            _context.ShoppingCart.RemoveRange(favorites);

            if (_context.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        // 查看收藏夹所有商品信息
        public List<FavoriteProductView> getFavoriteProduct(string buyerid)
        {
            List<FavoriteProductView> favoriteProductViews = new List<FavoriteProductView>();    // 收藏商品信息List     

            List<ShoppingCart> favoriteProducts = _context.ShoppingCart.Where(x => x.ID == buyerid).ToList();

            foreach (ShoppingCart favorite in favoriteProducts)
            {
                Commodities commodity = _context.Commodities.Where(x => x.CommodityID == favorite.CommodityID).FirstOrDefault();

                Publishers shop = _context.Publishers.Where(x => x.PublisherID == commodity.PublisherID).FirstOrDefault();

                FavoriteProductView favoriteview = new FavoriteProductView
                {
                    BuyerId = favorite.ID,
                    CommodityId = favorite.CommodityID,
                    CommodityImg = commodity.PictureURL,
                    CommodityName = commodity.CommodityName,
                    ShopName = shop.PublisherName,
                    DateCreated = favorite.JoinTime,
                    Price = commodity.Price
                };

                favoriteProductViews.Add(favoriteview);
            }
            return favoriteProductViews;
        }
    }
}
