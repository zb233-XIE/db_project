using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using TJ_Games.DBContext;
using TJ_Games.Services;
using TJ_Games.Models;
using TJ_Games.Models.BusinessEntity;
using Newtonsoft.Json;
using ThirdParty.Json.LitJson;


namespace TJ_Games.Controllers
{
    public class SearchController : Controller
    {
        private readonly ModelContext _context; //申明只读的数据库上下文
        private SearchService searchService;

        public SearchController(ModelContext context)
        {
            _context = context;
            searchService = new SearchService(_context);
        }//构造函数

        /*
         * 搜索功能的两大使用情景：
         * 1、用户在商店里浏览游戏
         * 2、用户通过在搜索框搜索特定游戏
        */

        public IActionResult Search()
        {
            return View();
        }
        //返回默认视图（对应情景1）

        /*
         * 设置后端全局变量Global
        */
        [HttpPost]
        public IActionResult SetSearchName([FromBody] SearchName sn)
        {
            Global.GSearchName = sn.name;

            JsonData jsondata = new JsonData();
            jsondata["status"] = "success";

            if (string.IsNullOrEmpty(Global.GSearchName))
            {
                jsondata["status"] = "empty!";
            }
            else
            {
                jsondata["name"] = Global.GSearchName;
            }

            return Json(jsondata.ToJson());
        }
        //前端回传 设置搜索框内容（对应情景2）
        [HttpPost]
        public IActionResult SetSearchClassification([FromBody] SearchClassification sc)
        {
            Global.GClassification = sc.classification;

            JsonData jsondata = new JsonData();
            jsondata["status"] = "success";

            //JsonData lst = new JsonData();
            //foreach(var v in Global.GClassification)
            //{
            //    lst.Add(v);
            //}
            //if (!Global.GClassification.Any())
            //{
            //    jsondata["status"] = "empty!";
            //}
            //else {
            //    jsondata["list"] = lst;
            //}
            // for debugging

            return Json(jsondata.ToJson());
        }
        //前端回传 设置搜索的游戏分类（对应情景1 2）

        /*
         * 将后端全局变量Global的值返回给前端
        */
        public IActionResult GetSearchName()
        {
            JsonData jsondata = new JsonData();
            jsondata["status"] = "success";
            jsondata["SearchName"] = Global.GSearchName;

            return Json(jsondata.ToJson());
        }
        public IActionResult GetCommodityType()
        {
            JsonData jsondata = new JsonData();
            jsondata["status"] = "success";

            JsonData Classification = new JsonData();
            foreach (string s in Global.GClassification)
            {
                Classification.Add(s);
            }
            jsondata["Classification"] = Classification;

            return Json(jsondata.ToJson());
        }

        /*
         * 解析前端回传的查询字段并调用service函数
        */
        public IActionResult SearchCommodity([FromQuery]string CommodityName)   //根据名称和类别来渲染页面
        {
           List<Goods> commodityList = new List<Goods>();
           //Goods goods = new Goods();
          commodityList = searchService.SearchCommodity(CommodityName, 1);
            //foreach (var good in commodityList)
            //{
            //    good.PictureURL = "../.." + good.PictureURL;
            //}
            if (!commodityList.Any())
            {
                JsonData jsondata = new JsonData();
                jsondata["status"] = "empty!";
                return Json(jsondata.ToJson());
            }
            //commodityList.Add(goods);
            string str = JsonConvert.SerializeObject(commodityList);

            return new ContentResult { Content = str, ContentType = "application/json" };
            //注意可能为空！
        }
        public IActionResult SearchPublishers([FromQuery] string PublisherName)   //根据名称和类别来渲染页面
        {
            List<Goods> commodityList = new List<Goods>();
            commodityList = searchService.SearchCommodity(PublisherName, 2);
            //foreach (var good in commodityList)
            //{
            //    good.PictureURL = "../.." + good.PictureURL;
            //}
            if (!commodityList.Any())
            {
                JsonData jsondata = new JsonData();
                jsondata["status"] = "empty!";
                return Json(jsondata.ToJson());
            }
            string str = JsonConvert.SerializeObject(commodityList);

            return new ContentResult { Content = str, ContentType = "application/json" };
            //注意可能为空！
        }
    }
}
