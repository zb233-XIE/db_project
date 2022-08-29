using TJ_Games.DBContext;
using TJ_Games.Models;
using TJ_Games.Models.ControllerModels;
using TJ_Games.Models.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Services
{
    public class AdminActionService
    {
        private readonly ModelContext _context;

        public AdminActionService(ModelContext context)
        {
            _context = context;
        }


        /*public bool DeleteBuyer(string buyerID)
        {
            if (buyerID == "")
                return false;
            else
            {
                Buyers buyer = _context.Buyers.Where(x => x.BuyerID == buyerID).FirstOrDefault();
                _context.Buyers.Update(buyer);
                if (_context.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
        }*/

        /**************** 下架商品 ***************/
        public bool DeleteCommodity(string commodityId)
        {
            if (commodityId == "")
                return false;
            else
            {
                if (_context.Commodities.Any(c => c.CommodityID == commodityId))
                {
                    Commodities newCommodity = _context.Commodities.FirstOrDefault(c => c.CommodityID == commodityId);
                    _context.Commodities.Remove(newCommodity);
                    _context.SaveChanges();
                    return true;
                }
                else return false;
            }
        }
        /**************** 封禁用户 ***************/
        public bool DeleteBuyer(string buyerId)
        {
            if (buyerId == "")
                return false;
            else
            {
                if (_context.Buyers.Any(c => c.BuyerID == buyerId))
                {
                    Buyers newBuyer = _context.Buyers.FirstOrDefault(c => c.BuyerID == buyerId);
                    _context.Buyers.Remove(newBuyer);
                    _context.SaveChanges();
                    return true;
                }
                else return false;
            }
        }
    }
}
