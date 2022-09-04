using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TJ_Games.Models;
using TJ_Games.DBContext;
using System.Text;
using System.Security.Cryptography;


namespace TJ_Games.Services
{
    public class BuyerService 
    {
        private ModelContext _context;

        public Buyers EditBuyer(Buyers before, Buyers now)//修改个人信息，主码不允许修改！
        {
            string id = before.BuyerID;

            var buyer = Edit(id, now);

            return buyer;
        }


        public BuyerService(ModelContext context)
        {
            _context = context;
        }
        public List<Buyers> Index()
        {
            return _context.Buyers.ToList();
        }
        public Buyers SearchByID(string ID)
        {
            if (ID == null)
            {
                return null;
            }

            var buyer = _context.Buyers
                .FirstOrDefault(m => m.BuyerID == ID);
            if (buyer == null)
            {
                return null;
            }

            return buyer;
        }
        public Buyers Edit(string id)
        {
            if (id == null)
            {
                return null;
            }

            var buyer = _context.Buyers.Find(id);
            if (buyer == null)
            {
                return null;
            }
            return buyer;
        }
        public Buyers Edit(string id, [Bind("BuyerId,Mail,Passwd,Nickname,DateBirth,IdNumber")] Buyers buyer)
        {
            if (id != buyer.BuyerID)
            {
                return null;
            }

            try
            {
                _context.Update(buyer);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyerExists(buyer.Mail))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return buyer;
        }
        public bool BuyerExists(string Mail)
        {
            return _context.Buyers.Any(e => e.Mail == Mail);
        }

        public int BuyerLogin(string Buyer_ID,string Buyer_Password)
        {
            //如果前端传明文密码,则计算有关HASH256的值
            SHA256 sha256 = SHA256.Create();


            byte[] Check_Password = Encoding.UTF8.GetBytes(Buyer_Password);
            byte[] Check_Hash = sha256.ComputeHash(Check_Password);

            string check_Hash = BitConverter.ToString(Check_Hash);


            //查询有关用户
            Users users = _context.Users.Where(x=>x.UserID==Buyer_ID).FirstOrDefault();
            if(users.UserType!=1)
            {
                return -3;
            }


            if (users == null)//说明此用户不存在
            {
                return -1;//代表用户不存在
            }
            else//说明此时用户存在
            {

                if (check_Hash==users.Password)//说明密码正确
                {
                    return 1;
                }
                else//说明密码错误
                {
                    return -2;
                }
            }
        }

       public  int BuyerSignup(BuyerSignUpModel buyer)
        {
            if(_context.Users.Where(x=>x.UserID==buyer.BuyerID).FirstOrDefault()!=null)
            {
                return -1;//说明此时数据库当中已经有该用户
            }
            else
            {
                //如果前端传明文密码,则计算有关HASH256的值
                SHA256 sha256 = SHA256.Create();


                byte[] Check_Password = Encoding.UTF8.GetBytes(buyer.Password);
                byte[] Check_Hash = sha256.ComputeHash(Check_Password);

                string Password_Hash = BitConverter.ToString(Check_Hash);



                //往数据库当中进行添加操作
                Users users = new Users { UserID = buyer.BuyerID, UserType = buyer.UserType, Password = Password_Hash };
                _context.Entry(users).State = EntityState.Added;
                _context.Users.Add(users);
                if (_context.SaveChanges() < 0)//说明保存成功
                {
                    return -2;//说明数据库保存失败
                }

                Buyers new_buyers=new Buyers { BuyerID=buyer.BuyerID,BuyerName=buyer.BuyerName,Birthday=buyer.Birthday,Mail=buyer.Mail };
                _context.Entry(new_buyers).State = EntityState.Added;
                _context.Buyers.Add(new_buyers);
                if (_context.SaveChanges() < 0)//说明保存成功
                {
                    return -2;//说明数据库保存失败
                }

                return 1;
            }
        }
        public Buyers GetBuyerInfo(string u_id)
        {
            Buyers bbuyer;
            bbuyer = _context.Buyers
                    .Where(c => c.BuyerID == u_id).FirstOrDefault();
            return bbuyer;
        }


    }
}
