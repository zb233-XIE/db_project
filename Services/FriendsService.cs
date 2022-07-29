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
namespace TJ_Games.Service
{
    public class FriendsService
    {
        private readonly ModelContext _context;

        /*------------------------------------------------------
         * PublishersService()
         * 构造函数
         * ---------------------------------------------------*/
        public FriendsService(ModelContext context)
        {
            _context = context;//数据库上下文初始化
        }
        
        /*------------------------------------------------------
         * 函数名：GetFriends()
         * 拉取好友列表
         * 传回Friends列表
         * ---------------------------------------------------*/
        public List<Friends> GetFriends(string u_id)
        {
            List<Friends> friendlist = _context.Friends
                    .Where(c => c.UserID == u_id).ToList();
            return friendlist;
        }

        /*------------------------------------------------------
         * 函数名：GetPubisherInfo()
         * 在User表中查到指定好友的信息
         * 传回该好友的信息
         * ---------------------------------------------------*/
        public Users GetUsersInfo(string friend_id)
        {
            Users friendInfo = _context.Users
                    .Where(c => c.UserID == friend_id).FirstOrDefault();
            return friendInfo;
        }
        /*------------------------------------------------------
        * 函数名：AddFriends()
        * 添加好友功能的实现
        * 返回true或false
        * ---------------------------------------------------*/
        public bool AddFriends(string u_id, string f_id)
        {
            Friends friend = new Friends();
            bool have_friend = _context.Friends.Any(c => c.UserID == u_id && c.FriendID == f_id);
            if (have_friend == false)
            {
                friend.UserID = u_id;
                friend.FriendID = f_id;

                _context.Friends.Add(friend);

                /*
                 * 加好友应该是双向的，但现在不知道添加好友操作有着怎样的底层逻辑，所以这里先注释处理
                friend.UserID = f_id;
                friend.FriendID = u_id;
                _context.Friends.Add(friend);
                */

                _context.SaveChanges();
                return true;
            }
            return false;
        }
        /*------------------------------------------------------
        * 函数名：DeleteFriends()
        * 删除好友功能的实现
        * 返回true或false
        * ---------------------------------------------------*/
        public bool DeleteFriends(string u_id, string f_id)
        {
            Friends friend = _context.Friends.Where(c => c.UserID == u_id && c.FriendID == f_id).FirstOrDefault();
            if (friend != null)
            {
                _context.Friends.Remove(friend);
                if (_context.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }
    }
}
