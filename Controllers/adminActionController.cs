using admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace admin.Controllers
{
    public class adminActionController : Controller
    {
        List<data> dataList = new List<data> { };
        public adminActionController()
        {
            data model1 = new data()
            {
                ID = 10,
                Name = "111",
                Publisher = "ea",
                Price = 1,
                Time = 20110101,
                Classification = "qihuan",
                Downloadurl = "www.111",
                Volume = 101,
                Description = "hao111",
            };
            data model2 = new data()
            {
                ID = 20,
                Name = "222",
                Publisher = "rstar",
                Price = 2,
                Time = 20220202,
                Classification = "maoxian",
                Downloadurl = "www.222",
                Volume = 202,
                Description = "hao222",
            };
            dataList.Add(model1);
            dataList.Add(model2);
        }

        public IActionResult Index()
        {
            return View();
        }

   
        public IActionResult Find()
        {
            ViewData["List"]= dataList;

            /*
            ViewData.Add("list1", liuyan);
            ViewData["nickName2"] = null;
            ViewData["face2"] = null;
            ViewData["signature2"] = null;
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
            */
            return View();
        }

        public IActionResult SEARCH(int id)
        {
            List<data> list = dataList.Where(t => t.ID == id).ToList();

            string jsondata = JsonConvert.SerializeObject(list);

            return Content(jsondata);
        }

        public IActionResult Updatedelete(int id)
        {
            List<data> list = dataList.Where(t => t.ID == id).ToList();

            bool OK = dataList.Remove(list[0]);


            return Content(OK.ToString());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Updatecreate(string ID)
        {
            return Content(ID);
        }
        public IActionResult Updatetempdelete(string ID)
        {
            return Content(ID);
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            ViewData["List"] = dataList;
            return View();
        }

        public IActionResult Updateedit(string ID)
        {
            return Content(ID);
        }
    }

}
