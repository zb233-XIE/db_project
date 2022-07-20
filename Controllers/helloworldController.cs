using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using LitJson;
using AutoMapper;


namespace test456465.Controllers
{
    public class helloworldController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Welcome(string name, int numTimes = 3)
        {
            ViewData["face"] = "https://gimg2.baidu.com/image_search/src=http%3A%2F%2Fc-ssl.duitang.com%2Fuploads%2Fitem%2F202005%2F30%2F20200530112650_4XXME.thumb.1000_0.jpeg&refer=http%3A%2F%2Fc-ssl.duitang.com&app=2002&size=f9999,10000&q=a80&n=0&g=0n&fmt=jpeg?sec=1628654333&t=ccef3bc418154fea7edd5c5a5902766f";
            ViewData["NumTimes"] = 7;
            List<string> NickName=new List<string>();
            NickName.Add("共享达人");
            NickName.Add("未来");
            NickName.Add("游戏达人");
            NickName.Add("挖行人少");
            NickName.Add("共享小白");
            NickName.Add("程序猿一枚");
            NickName.Add("努力向上");
            NickName.Add("123123");
            ViewData.Add("list", NickName);
            List<string> liuyan = new List<string>();
            liuyan.Add("共享一直都在");
            liuyan.Add("共享是一种游戏");
            liuyan.Add("共享是一种游戏");
            liuyan.Add("共享是一种游戏");
            liuyan.Add("小白的世界你不懂");
            liuyan.Add("小白的世界你不懂");
            liuyan.Add("请叫我大神");
            liuyan.Add("123就是我");
            ViewData.Add("list1", liuyan);
            ViewData["nickName2"] = null;
            ViewData["face2"] = null;
            ViewData["signature2"] = null;
            // 获取路由数据
            if (Request.QueryString != null)
            {
                string value = Request.QueryString.ToString();
                ViewData["msg"] = value;
                if(value=="?name=123123")
                {
                    ViewData["face"] = "https://gimg2.baidu.com/image_search/src=http%3A%2F%2Fc-ssl.duitang.com%2Fuploads%2Fitem%2F202005%2F30%2F20200530112650_4XXME.thumb.1000_0.jpeg&refer=http%3A%2F%2Fc-ssl.duitang.com&app=2002&size=f9999,10000&q=a80&n=0&g=0n&fmt=jpeg?sec=1628654333&t=ccef3bc418154fea7edd5c5a5902766f";
                    ViewData["nickName"] = "123123";
                    ViewData["signature"] = "来自就是123";
                }
            } 
            return View();
        }
        [HttpPost]
          public IActionResult shanchu([FromBody] Object ID)
          {
            string a = ID.ToString();
            a = a.Replace("{", "");
            a = a.Replace("}", "");
            a = a.Replace(":", "");
            int index = a.IndexOf("ID");
            a = a.Substring(index + 3, a.Length - index - 3);
            a = a.Replace('"', ' ');
            a.Trim();
            return Json(a);
           
          }
        [HttpPost]
        public IActionResult tianjia([FromBody] Object ID)
        {

            string a = ID.ToString();
            a = a.Replace("{", "");
            a = a.Replace("}", "");
            a = a.Replace(":", "");
            int index = a.IndexOf("ID");
            a = a.Substring(index + 3, a.Length - index - 3);
            a = a.Replace('"', ' ');
            a.Trim();
            return Json(a);

        }

        [HttpPost]
        public IActionResult sousuo([FromBody] Object ID)
        {
            string a = ID.ToString();
            a = a.Replace("{","");
            a = a.Replace("}", "");
            a = a.Replace(":", "");
            int index = a.IndexOf("ID");
            a = a.Substring(index+3, a.Length- index-3);
            a = a.Replace('"',' ');
            a.Trim();
            var data = new
            {
                nickName = a,
                face = "https://gimg2.baidu.com/image_search/src=http%3A%2F%2Fc-ssl.duitang.com%2Fuploads%2Fitem%2F202005%2F30%2F20200530112650_4XXME.thumb.1000_0.jpeg&refer=http%3A%2F%2Fc-ssl.duitang.com&app=2002&size=f9999,10000&q=a80&n=0&g=0n&fmt=jpeg?sec=1628654333&t=ccef3bc418154fea7edd5c5a5902766f",
                signature = "来自就是123"
            };
              var jsonstr = JsonConvert.SerializeObject(data);
            return Content(jsonstr);
        }

    }
}
