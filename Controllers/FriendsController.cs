using Microsoft.AspNetCore.Mvc;
using TJ_Games.DBContext;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdParty.Json.LitJson;
using TJ_Games.Service;
using TJ_Games.Models;
#nullable disable

namespace WEBTEST.Controllers
{
    public class FriendsController : Controller
    {
        private readonly ModelContext _context;   //数据库上下文
        private FriendsService friendservice;
        public FriendsController(ModelContext context)
        {
            _context = context;
            friendservice = new FriendsService(_context);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcome(string UserID)//Welcome主页面 完成拉取好友列表功能
        {
            string name;
            int numTimes = friendservice.GetCount(UserID);
            ViewData["face"] = "https://gimg2.baidu.com/image_search/src=http%3A%2F%2Fc-ssl.duitang.com%2Fuploads%2Fitem%2F202005%2F30%2F20200530112650_4XXME.thumb.1000_0.jpeg&refer=http%3A%2F%2Fc-ssl.duitang.com&app=2002&size=f9999,10000&q=a80&n=0&g=0n&fmt=jpeg?sec=1628654333&t=ccef3bc418154fea7edd5c5a5902766f";
            //面部信息图片 使用网络图片

            ViewData["NumTimes"] = numTimes;
            List<string> NickName = new List<string>();
            List<string> liuyan = new List<string>();
            string id;
            ViewData.Add("list", NickName);
            ViewData.Add("list1", liuyan);
            for (int i = 0; i < numTimes; i++)
            {
                id = friendservice.GetFriends(UserID)[i].FriendID;
                name = friendservice.GetBuyerInfo(id).BuyerName;
                liuyan.Add(id);//liuyan对应ID功能
                NickName.Add(name);
            }

            // 获取路由数据
            if (Request.QueryString != null)
            {
                string value = Request.QueryString.ToString();
                ViewData["msg"] = value;
                if (value == "?name=123123")
                {
                    ViewData["face"] = "https://gimg2.baidu.com/image_search/src=http%3A%2F%2Fc-ssl.duitang.com%2Fuploads%2Fitem%2F202005%2F30%2F20200530112650_4XXME.thumb.1000_0.jpeg&refer=http%3A%2F%2Fc-ssl.duitang.com&app=2002&size=f9999,10000&q=a80&n=0&g=0n&fmt=jpeg?sec=1628654333&t=ccef3bc418154fea7edd5c5a5902766f";
                    ViewData["nickName"] = "123123";
                    ViewData["signature"] = "来自就是123";
                }
            }
            return View();
        }
        public IActionResult search()//SERACH页面 完成搜索--添加好友的功能
        {
            return View();
        }
        //GET
        public IActionResult sousuo([FromQuery] string UserID, [FromBody] object u_id)//搜索功能
        {
            JsonData jsondata = new JsonData();
            string content = u_id.ToString();
            string to_search = JsonConvert.DeserializeObject<string>(content);

            Buyers buyer = friendservice.GetBuyerInfo(to_search);
            var data = new
            {
                //nickname就是name
                nickName = buyer.BuyerName,
                //face使用默认图片
                face = "https://gimg2.baidu.com/image_search/src=http%3A%2F%2Fc-ssl.duitang.com%2Fuploads%2Fitem%2F202005%2F30%2F20200530112650_4XXME.thumb.1000_0.jpeg&refer=http%3A%2F%2Fc-ssl.duitang.com&app=2002&size=f9999,10000&q=a80&n=0&g=0n&fmt=jpeg?sec=1628654333&t=ccef3bc418154fea7edd5c5a5902766f",
                //signature代指UID
                signature = to_search
            };

            var jsonstr = JsonConvert.SerializeObject(data);

            //不能添加自己为好友的功能还在完善中

            return Content(jsonstr);
        }
        [HttpPost]
        public int blank()
        {
            return 0;
        }
        
        public IActionResult shanchu([FromQuery] string UserID,[FromBody] object u_id)
        {
            JsonData jsondata = new JsonData();
            string content = u_id.ToString();
            string friend_id = JsonConvert.DeserializeObject<string>(content);
            if (friendservice.DeleteFriends(UserID, friend_id))//这里采取单方向的添加和删除
            {
                return Json("删除好友成功");
            }
            else
            {
                return Json("删除好友失败");
            }
            return Json(jsondata.ToJson());
        }

        public IActionResult tianjia(string UserID,[FromBody] object u_id)
        {
            JsonData jsondata = new JsonData();
            string content = u_id.ToString();
            string friend_id = JsonConvert.DeserializeObject<string>(content);
            if (friendservice.AddFriends(UserID, friend_id))//这里先采取单方向的添加和删除，稍后再修改
            {
                return Json("添加好友成功");
            }
            else
            {
                return Json("删除好友失败");
            }
            return Json(jsondata.ToJson());
        }
    }
}