using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TJ_Games.DBContext;
using TJ_Games.Models;
using Newtonsoft.Json;
using ThirdParty.Json.LitJson;
using TJ_Games.Services;

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

        public IActionResult Index()
        {
            return View();
        }
        //返回默认视图（对应情景1）

        /*
         * 设置后端全局变量Global
        */
        [HttpPost]
        public IActionResult SetSearchName([FromBody] string name)
        {
            Global.GSearchName = name;
            JsonData jsondata = new JsonData();
            jsondata["searchResult"] = name;
            return Json(jsondata.ToJson());
        }
        //函数接受的参数有待与前端沟通
        //前端回传 设置搜索框内容（对应情景2）
        [HttpPost]
        public IActionResult SetSearchClassification([FromBody] List<string> classification)
        {
            Global.GClassification = classification;
            JsonData Classification = new JsonData();
            foreach(string s in classification)
            {
                Classification.Add(s);
            }
            JsonData jsondata = new JsonData();
            jsondata["classification"] = Classification;
            return Json(jsondata.ToJson());
        }
        //前端回传 设置搜索的游戏分类（对应情景1 2）
        //return <"classification",List<string>>

        /*
         * 将后端全局变量Global的值返回给前端
        */
        public IActionResult GetSearchName()
        {
            JsonData jsondata = new JsonData();
            jsondata["searchResult"] = Global.GSearchName;
            return Json(jsondata.ToJson());
        }
        public IActionResult GetCommodityType()
        {
            JsonData Classification = new JsonData();
            foreach(string s in Global.GClassification)
            {
                Classification.Add(s);
            }
            JsonData jsondata = new JsonData();
            jsondata["classification"] = Classification;
            return Json(jsondata.ToJson());
        }
        /* 返回参数
         * classification : List<string>
         */

        /*
         * 解析前端回传的查询字段并调用service函数
        */
        [HttpPost]
        public IActionResult GetCommodities([FromBody] string name, [FromBody] List<string> classification)   //根据名称和类别来渲染页面
        {
            List<Commodities> commodityList = new List<Commodities>();
            commodityList = searchService.SearchCommodity(name, classification);
            foreach (var good in commodityList)
            {
                good.PictureURL = "../.." + good.PictureURL;
            }
            //图片放在根目录的一个文件夹下
            string str = JsonConvert.SerializeObject(commodityList);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }
        /* 接收参数
         * name : string
         * classification : List<string>
         */
    }
}
