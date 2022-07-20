using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class shopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public class Myshop
        {
            public string name { get; set; }
            public string img { get; set; }
            public string id { get; set; }
            public string classification { get; set; }

        }
        [Obsolete]
        public IActionResult ShowNewCommodity()
        {
            List<Myshop> myshop = new List<Myshop>();
            myshop.Add(new Myshop { name = "第五人格", img = "http://dummyimage.com/200x200/50B347/fff&text=avator", id = "1", classification = "休闲" });
            myshop.Add(new Myshop { name = "王者荣耀", img = "http://dummyimage.com/200x200/50B347/fff&text=twice", id = "2", classification = "动作" });
            myshop.Add(new Myshop { name = "pubg", img = "http://dummyimage.com/200x200/50B347/fff&text=blackpink", id = "3", classification = "多人在线" });
            var str = JsonConvert.SerializeObject(myshop);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }
        public IActionResult ShowHotCommodity()
        {
            List<Myshop> myshop = new List<Myshop>();
            myshop.Add(new Myshop { name = "ITZY", img = "http://dummyimage.com/200x200/50B347/fff&text=ITZY", id = "4", classification = "冒险" });
            myshop.Add(new Myshop { name = "aespa", img = "http://dummyimage.com/200x200/50B347/fff&text=aespa", id = "5", classification = "角色扮演" });
            myshop.Add(new Myshop { name = "ive", img = "http://dummyimage.com/200x200/50B347/fff&text=ive", id = "6", classification = "模拟" });
            var str = JsonConvert.SerializeObject(myshop);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }
        public IActionResult ShowShopCommodity()
        {
            List<Myshop> myshop = new List<Myshop>();
            myshop.Add(new Myshop { name = "ITZY", img = "http://dummyimage.com/200x200/50B347/fff&text=ITZY" });
            myshop.Add(new Myshop { name = "aespa", img = "http://dummyimage.com/200x200/50B347/fff&text=aespa" });
            myshop.Add(new Myshop { name = "ive", img = "http://dummyimage.com/200x200/50B347/fff&text=ive" });
            myshop.Add(new Myshop { name = "TWICE", img = "http://dummyimage.com/200x200/50B347/fff&text=twice" });
            myshop.Add(new Myshop { name = "BLACKPINK", img = "http://dummyimage.com/200x200/50B347/fff&text=blackpink" });
            var str = JsonConvert.SerializeObject(myshop);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }
        public IActionResult ShowCurrentActivity()
        {
            List<Myshop> myshop = new List<Myshop>();
            myshop.Add(new Myshop { name = "STAYC", img = "http://dummyimage.com/200x200/50B347/fff&text=STAYC" });
            myshop.Add(new Myshop { name = "Red Velvet", img = "http://dummyimage.com/200x200/50B347/fff&text=RedVelvet" });
            myshop.Add(new Myshop { name = "(G)-IDLE", img = "http://dummyimage.com/200x200/50B347/fff&text=GIDLE" });
            var str = JsonConvert.SerializeObject(myshop);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }
        [HttpPost]
        public IActionResult ShowComodityClassification([FromBody] Object classes)
        {
            string c = classes.ToString();
            c = c.Replace("{", "");
            c = c.Replace("}", "");
            c = c.Replace(":", "");
            c = c.Replace("\"","");
            c = c.Substring(14);
            List<Myshop> myshop = new List<Myshop>();
            myshop.Add(new Myshop { name = "第五人格", img = "http://dummyimage.com/200x200/50B347/fff&text=avator", id = "1", classification = "休闲" });
            myshop.Add(new Myshop { name = "王者荣耀", img = "http://dummyimage.com/200x200/50B347/fff&text=twice", id = "2", classification = "动作" });
            myshop.Add(new Myshop { name = "pubg", img = "http://dummyimage.com/200x200/50B347/fff&text=blackpink", id = "3", classification = "多人在线" });
            myshop.Add(new Myshop { name = "ITZY", img = "http://dummyimage.com/200x200/50B347/fff&text=ITZY", id = "4", classification = "冒险" });
            myshop.Add(new Myshop { name = "aespa", img = "http://dummyimage.com/200x200/50B347/fff&text=aespa", id = "5", classification = "角色扮演" });
            myshop.Add(new Myshop { name = "ive", img = "http://dummyimage.com/200x200/50B347/fff&text=ive", id = "6", classification = "模拟" });
            List<Myshop> newshop = new List<Myshop>();
            newshop = myshop.FindAll(s => s.classification==c);
            var str = JsonConvert.SerializeObject(newshop);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }
    }
}

