using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Web.Models;
using DB.Web.Services;
using DB.Web.controllers;
using Newtonsoft.Json;

namespace DB.Controllers
{



    public class ShoppingChartController : Controller
    {
        public class ChosenCommodity
        {
            public ChosenCommodity(int id,string name,int price,string img)
            {
                this.id = id;
                this.name = name;
                this.price = price;
                this.img = img;
            }
            private int id { get; set; }
            private string name { get; set; }
            private int price { get; set; }
            private string img { get; set; }
        }
        public IActionResult Index()
        {
                return View();
        }

        public IActionResult DeleteFromShoppingCart([FromBody] object ID)
        {
            string s= ID.ToString();
            s = s.Replace("{\"ID\":", "");
            s = s.Replace("}", "");
            var data = s;
            var jsonstr = JsonConvert.SerializeObject(data);
            return Content(jsonstr);
        }

        public IActionResult CreateOrder()
        {
            return View();
        }


        public IActionResult GetCommodityDetail([FromBody] object ID)
        {
            string s = ID.ToString();
            s = s.Replace("{\"ID\":", "");
            s = s.Replace("}", "");
            var data = s;
            var jsonstr = JsonConvert.SerializeObject(data);
            return Content(jsonstr);
        }

        public IActionResult InitialData()
        {
            var data = new
            {
                id = new int[3] { 29333, 182777, 6444 },
                pic = new string[3] {"https://cdn.pixabay.com/photo/2022/04/29/17/48/lofoten-7164179_1280.jpg",
                       "https://cdn.pixabay.com/photo/2022/07/10/06/51/flowers-7312298_1280.jpg",
                       "https://cdn.pixabay.com/photo/2022/07/13/18/34/grassland-7319829_1280.jpg" },
                name = new string[3] { "王者荣耀__", "英雄联盟__", "哈利波特__" },
                price = new string[3] { "1000", "2000", "3000" }
            };
            var jsonstr = JsonConvert.SerializeObject(data);
            return Content(jsonstr);
        }
    }
}
