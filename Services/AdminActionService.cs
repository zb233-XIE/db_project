using TJ_Games.DBContext;
using TJ_Games.Models;
using TJ_Games.Models.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdParty.Json.LitJson;
using System.Text;
using System.Security.Cryptography;

namespace WebApplication1.Services
{
    public class AdminActionService
    {
        private readonly ModelContext _context;

        public AdminActionService(ModelContext context)
        {
            _context = context;
        }

        public int AdministratorLogin(string Administrator_ID, string Administrator_Password)
        {
            //如果前端传明文密码,则计算有关HASH256的值
            SHA256 sha256 = SHA256.Create();


            byte[] Check_Password = Encoding.UTF8.GetBytes(Administrator_Password);
            byte[] Check_Hash = sha256.ComputeHash(Check_Password);

            string check_Hash = BitConverter.ToString(Check_Hash);


            //查询有关用户
            Users users = _context.Users.Where(x => x.UserID == Administrator_ID).FirstOrDefault();

            if (users == null)//说明此用户不存在
            {
                return -1;//代表用户不存在
            }
            else//说明此时用户存在
            {

                if (check_Hash == users.Password)//说明密码正确
                {
                    return 1;
                }
                else//说明密码错误
                {
                    return -2;
                }
            }
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
        public JsonData BuyerDetails(string BuyerID)
        {
            JsonData jsondata = new JsonData();
            Buyers buyers = _context.Buyers.Where(x => x.BuyerID == BuyerID).FirstOrDefault();

            if (buyers == null)//此时说明此时没有该ID对应的商品
                return null;
            else
            {
                jsondata["BuyerID"] = buyers.BuyerID;
                jsondata["BuyerName"] = buyers.BuyerName;
                //jsondata["Birthday"] = buyers.Birthday;
                jsondata["Mail"] = buyers.Mail;



                return jsondata;
            }
        }
    }
}
