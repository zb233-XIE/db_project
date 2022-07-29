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

namespace TJ_Games.Controllers
{
    public class HomeController : Controller
    {
        private readonly ModelContext _context;   //数据库上下文
        private ShopService shopService;             //后端service

        public HomeController(ModelContext context)
        {
            _context = context;
            shopService = new ShopService(_context);
        }
        public IActionResult Shop()
        {
            if (Request.Cookies["buyerNickName"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/Entry/BuyerLogIn");
            }
        }
        [HttpPost]
        public IActionResult SetCommodityID([FromBody]  Commodities commodity)   //设置商品ID
        {
            Global.GCommodityID = commodity.CommodityID;
            JsonData jsondata = new JsonData();
            jsondata["commodityID"] = commodity.CommodityID;
            return Json(jsondata.ToJson());
        }
        [HttpPost]
        public IActionResult SetClassification([FromBody] Commodities commodity)   //设置商品ID
        {
            Global.GClassification = commodity.Classification;
            JsonData jsondata = new JsonData();
            jsondata["Classification"] = commodity.Classification;
            return Json(jsondata.ToJson());
        }
        public IActionResult GetCommodityDetail()   //获得商品详情
        {
            Commodities commodity = new Commodities();
            commodity = shopService.GetCommodityDetail(Global.GCommodityID);
            string str = JsonConvert.SerializeObject(commodity);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }
        
        public IActionResult ShowShopCommodity()      //展示商店的推荐商品
        {
            List<Commodities> commodityList = new List<Commodities>();
            commodityList =shopService.ShowShopCommodity();
            string str = JsonConvert.SerializeObject(commodityList);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }

        public IActionResult ShowNewCommodity()      //展示商店的最新商品
        {
            List<Commodities> commodityList = new List<Commodities>();
            commodityList = shopService.ShowNewCommodity();
            string str = JsonConvert.SerializeObject(commodityList);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }

        public IActionResult ShowHotCommodity()      //展示商店的最热商品
        {
            List<Commodities> commodityList = new List<Commodities>();
            commodityList = shopService.ShowHotCommodity();
            string str = JsonConvert.SerializeObject(commodityList);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }

        public IActionResult ShowCommodityClassification() //展示选择的分类的游戏
        {
            List<Commodities> CommodityClassification = new List<Commodities>();
            CommodityClassification = shopService.ShowCommodityClassification(Global.GClassification);
            string str = JsonConvert.SerializeObject(CommodityClassification);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }

        /*public IActionResult ShowCurrentActivity()
        {

        }*/
    }
}