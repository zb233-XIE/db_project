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
        string GCommodityID;

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
            GCommodityID = commodity.CommodityID;
            JsonData jsondata = new JsonData();
            jsondata["commodityID"] = commodity.CommodityID;
            return Json(jsondata.ToJson());
        }
        [HttpPost]
        public IActionResult SetClassification([FromBody] Commodity_Genre commodities_Genre)   //设置分类
        {
            string Genre_ID = commodities_Genre.GenreID;
            JsonData jsondata = new JsonData();
            if (Genre_ID != null)
            {
                string type = shopService.GetType(Genre_ID);
                jsondata["Type"] = type;
                List<Commodities> CommodityClassification = new List<Commodities>();
                CommodityClassification = shopService.ShowCommodityClassification(Genre_ID);
                foreach (var commodity in CommodityClassification)
                {
                    commodity.PictureURL = "../.." + commodity.PictureURL;
                }
                string str = JsonConvert.SerializeObject(CommodityClassification);
                return new ContentResult { Content = str, ContentType = "application/json" };
            }
            else
                return Json(jsondata.ToJson());
        }
        public IActionResult GetCommodityDetail()   //获得商品详情
        {
            Commodities commodity = new Commodities();
            commodity = shopService.GetCommodityDetail(GCommodityID);
            if (commodity != null)
            {
                commodity.PictureURL = "../.." + commodity.PictureURL;
                string str = JsonConvert.SerializeObject(commodity);
                return new ContentResult { Content = str, ContentType = "application/json" };
            }
            else
                return null;
        }
        
        public IActionResult ShowShopCommodity()      //展示商店的推荐商品
        {
            List<Commodities> commodityList = new List<Commodities>();
            /*if (Request.Cookies["buyerNickName"] != null)   //已经登录
            {
                commodityList = shopService.ShowShopCommodity(true, Request.Cookies["buyerID"]); //根据用户过往订单确定推荐的商品
            }
            else
            {*/
                commodityList = shopService.ShowShopCommodity(false);    //未登录情况下的商品推荐，但因为打开页面需要先验证登录，故也作为登陆情况下的商品推荐
            /*}*/
            foreach (var commodity in commodityList)
            {
                commodity.PictureURL = "../.." + commodity.PictureURL;
            }
            string str = JsonConvert.SerializeObject(commodityList);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }

        public IActionResult ShowNewCommodity()      //展示商店的最新商品
        {
            List<Commodities> commodityList = new List<Commodities>();
            commodityList = shopService.ShowNewCommodity();
            foreach (var commodity in commodityList)
            {
                commodity.PictureURL = "../.." + commodity.PictureURL;
            }
            string str = JsonConvert.SerializeObject(commodityList);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }

        public IActionResult ShowHotCommodity()      //展示商店的最热商品
        {
            List<Commodities> commodityList = new List<Commodities>();
            commodityList = shopService.ShowHotCommodity();
            foreach (var commodity in commodityList)
            {
                commodity.PictureURL = "../.." + commodity.PictureURL;
            }
            string str = JsonConvert.SerializeObject(commodityList);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }

        /*public IActionResult ShowCurrentActivity()
        {

        }*/
    }
}