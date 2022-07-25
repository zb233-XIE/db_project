using TJ_Games.DBContext;
using TJ_Games.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Services
{
    public class SecurityService 
    {
        private ModelContext _ctx;
        public SecurityService(ModelContext ctx)
        {
            _ctx = ctx;
        }
        public string displayPhone(string buyerid)
        {
            // 检测用户是否存在，但应该没有必要，因为已经登录
            /*if(_ctx.Buyers.Any(e => e.BuyerId == id))
            */
            Buyers buyer = _ctx.Buyers.FirstOrDefault(x => x.BuyerID == buyerid);
            // 电子邮件需要检测是否存在
            if (buyer.Mail != null)
                return buyer.Mail;
            else
                return null;
        }

        // 显示用户密码
        public string displayPasswd(string buyerid)
        {
            Users buyer = _ctx.Users.FirstOrDefault(x => x.UserID == buyerid);
            return buyer.Password;
        }

        // 修改用户绑定的电子邮件
        public bool updateMail(string buyerid, string oldMail, string newMail)
        {
            Buyers buyer = _ctx.Buyers.FirstOrDefault(x => x.BuyerID == buyerid);

            if (buyer == null)
            {
                return false;
                throw new DllNotFoundException();
            }
            else
            {
                if (buyer.Mail == null || buyer.Mail == oldMail)  // 比对电子邮件
                {
                    buyer.Mail = newMail;
                    _ctx.Buyers.Update(buyer);
                    _ctx.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }

        // 修改用户密码
        public bool updatePasswd(string buyerid, string oldPasswd, string newPasswd)
        {
            Users buyer = _ctx.Users.FirstOrDefault(x => x.UserID == buyerid);

            if (buyer == null)
            {
                return false;
                throw new DllNotFoundException();
            }
            else
            {
                if (buyer.Password == oldPasswd)  // 比对密码
                {
                    buyer.Password = newPasswd;
                    _ctx.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }
    }
}
