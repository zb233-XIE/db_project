using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace DB.Web.controllers
{
    public class CommodityController : Controller
    {
        public IActionResult Details(int ID = 20, string name = "王者荣耀", int price = 16, string publisher = "Tencent")
        {
            ViewData["id"] = ID;
            ViewData["name"] = name;
            ViewData["price"] = price;
            ViewData["publisher"] = publisher;
            JsonConvert.SerializeObject(ID);
            return View();
        }


        public string Welcome()
        {
            return "This is the Welcome action method...";
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody] Object ID)    //添加商品到购物车
        {
            string s = ID.ToString();
            s=s.Replace("{\"ID\":\"商品ID:", "");
            s=s.Replace("\"}", "");
            var data = new
            {
                ID = s,
                name="游戏1"
            };
            var jsonstr = JsonConvert.SerializeObject(data);
            return Content(jsonstr);
        }
        public IActionResult AddToWishList([FromBody] Object ID)     //添加商品到愿望单 
        {
            string s = ID.ToString();
            s = s.Replace("{\"ID\":\"商品ID:", "");
            s = s.Replace("\"}", "");
            var data = new
            {
                ID = s,
                name = "游戏1"
            };
            var jsonstr = JsonConvert.SerializeObject(data);
            return Content(jsonstr);
        }
    }
}
