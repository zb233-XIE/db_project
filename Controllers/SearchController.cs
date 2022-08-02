using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Search()
        {
            return View();
        }
        public class Myshop
        {
            public string name { get; set; }
            public string img { get; set; }
            public string id { get; set; }
            public string classification { get; set; }
            public string publisher { get; set; }

        }
        [HttpPost]
        public IActionResult SearchCommodity([FromBody] Object context)
        {
            string c = context.ToString();
            c = c.Replace("{", "");
            c = c.Replace("}", "");
            c = c.Replace(":", "");
            c = c.Replace("\"", "");
            c = c.Substring(14);
            List<Myshop> myshop = new List<Myshop>();
            myshop.Add(new Myshop { name = "第五人格", img = "http://dummyimage.com/200x200/50B347/fff&text=avator", id = "1", classification = "休闲", publisher = "网易" });
            myshop.Add(new Myshop { name = "王者荣耀", img = "http://dummyimage.com/200x200/50B347/fff&text=twice", id = "2", classification = "动作", publisher = "腾讯" });
            myshop.Add(new Myshop { name = "pubg", img = "http://dummyimage.com/200x200/50B347/fff&text=blackpink", id = "3", classification = "多人在线", publisher = "EA" });
            myshop.Add(new Myshop { name = "ITZY", img = "http://dummyimage.com/200x200/50B347/fff&text=ITZY", id = "4", classification = "冒险", publisher = "jype" });
            myshop.Add(new Myshop { name = "aespa", img = "http://dummyimage.com/200x200/50B347/fff&text=aespa", id = "5", classification = "角色扮演", publisher = "sm" });
            myshop.Add(new Myshop { name = "ive", img = "http://dummyimage.com/200x200/50B347/fff&text=ive", id = "6", classification = "模拟", publisher = "starship" });
            List<Myshop> newshop = new List<Myshop>();
            newshop = myshop.FindAll(s => s.name == c);
            var str = JsonConvert.SerializeObject(newshop);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }
        public IActionResult SearchPublishers([FromBody] Object context)
        {
            string c = context.ToString();
            c = c.Replace("{", "");
            c = c.Replace("}", "");
            c = c.Replace(":", "");
            c = c.Replace("\"", "");
            c = c.Substring(9);
            List<Myshop> myshop = new List<Myshop>();
            myshop.Add(new Myshop { name = "第五人格", img = "http://dummyimage.com/200x200/50B347/fff&text=avator", id = "1", classification = "休闲", publisher = "网易" });
            myshop.Add(new Myshop { name = "王者荣耀", img = "http://dummyimage.com/200x200/50B347/fff&text=twice", id = "2", classification = "动作", publisher = "腾讯" });
            myshop.Add(new Myshop { name = "pubg", img = "http://dummyimage.com/200x200/50B347/fff&text=blackpink", id = "3", classification = "多人在线",publisher="EA" });
            myshop.Add(new Myshop { name = "ITZY", img = "http://dummyimage.com/200x200/50B347/fff&text=ITZY", id = "4", classification = "冒险", publisher = "jype" });
            myshop.Add(new Myshop { name = "aespa", img = "http://dummyimage.com/200x200/50B347/fff&text=aespa", id = "5", classification = "角色扮演", publisher = "sm" });
            myshop.Add(new Myshop { name = "ive", img = "http://dummyimage.com/200x200/50B347/fff&text=ive", id = "6", classification = "模拟", publisher = "starship" });
            List<Myshop> newshop = new List<Myshop>();
            newshop = myshop.FindAll(s => s.publisher == c);
            var str = JsonConvert.SerializeObject(newshop);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }
    }

}
