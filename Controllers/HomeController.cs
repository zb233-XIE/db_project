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
using TJ_Games.Models.ControllerModels;
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
        public IActionResult Index()
        {
            return View();
        }
        /*public ActionResult Index()
        {
            if (Request.Cookies["buyerNickName"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/Entry/BuyerLogIn");
            }
        }*/
        [HttpPost]
        public IActionResult GetCommodityDetail([FromQuery]  string CommodityID)   //设置商品ID
        {
            JsonData jsondata = new JsonData();
            Good good=new Good();
            good = shopService.GetCommodityDetail(CommodityID);
            good.PictureURL = "../.." + good.PictureURL;
            string str = JsonConvert.SerializeObject(good);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }
        [HttpPost]
        public IActionResult SetClassification([FromQuery] string Type)   //设置分类
        {
            //string Type = JsonConvert.DeserializeObject<string>(content);
            JsonData jsondata = new JsonData();
            List<Good> CommodityClassification = new List<Good>();
            Genre genre = new Genre();
            genre = _context.Genre.Where(x => x.Type == Type).FirstOrDefault();
            string genreid = genre.ID;
            //jsondata["type"] = Type;
            CommodityClassification = shopService.ShowCommodityClassification(genreid);
            foreach (var Good in CommodityClassification)
            {
                Good.PictureURL = "../.." + Good.PictureURL;
            }
            string str = JsonConvert.SerializeObject(CommodityClassification);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }       
        public IActionResult ShowShopCommodity()      //展示商店的推荐商品
        {
            List<Good> commodityList = new List<Good>();
            commodityList = shopService.ShowShopCommodity();    //未登录情况下的商品推荐，但因为打开页面需要先验证登录，故也作为登陆情况下的商品推荐
            foreach (var commodity in commodityList)
            {
                commodity.PictureURL = "../.." + commodity.PictureURL;
            }
            string str = JsonConvert.SerializeObject(commodityList);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }

        public IActionResult ShowNewCommodity()      //展示商店的最新商品
        {
            List<Good> commodityList = new List<Good>();
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
            List<Good> commodityList = new List<Good>();
            commodityList = shopService.ShowHotCommodity();
            foreach (var commodity in commodityList)
            {
                commodity.PictureURL = "../.." + commodity.PictureURL;
            }
            string str = JsonConvert.SerializeObject(commodityList);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }
    }
}