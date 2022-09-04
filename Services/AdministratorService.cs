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
    public class AdministratorService
    {
        private readonly ModelContext _context;
        public AdministratorService(ModelContext context)
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

            if(users.UserType!=3)
            {
                return -3;
            }

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
    }
}
