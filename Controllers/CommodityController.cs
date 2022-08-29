using Microsoft.AspNetCore.Mvc;
using TJ_Games.DBContext;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdParty.Json.LitJson;
using TJ_Games.Services;
using TJ_Games.Models;
#nullable disable

namespace TJ_Games.Controllers
{
    public class CommodityController : Controller
    {
        private readonly ModelContext _context;   //数据库上下文
        private CartService cartService;
        public CommodityController(ModelContext context)
        {
            _context = context;
            cartService = new CartService(_context);
        }
        public IActionResult Details(string? CommodityID)
        {
            Commodities commodities = _context.Commodities.Where(x => x.CommodityID == CommodityID).FirstOrDefault();//查询给定ID的商品的有效信息

            
            if (commodities == null)//此时说明此时没有该ID对应的商品
            {
                ViewData["CommodityID"] = -1;
            }
            else
            {
                //找到两个和这个商品有关的评价
                List<Evaluation> evaluationList;
                 evaluationList = _context.Evaluation.Where(x=>x.CommodityID==CommodityID).ToList();
                
                //根据商品的有效信息查询对应的PublisherName
                string target_publisher = commodities.PublisherID;
                Publishers publishers = _context.Publishers.Where(d => d.PublisherID == target_publisher).FirstOrDefault();

                ViewData["CommodityID"] = commodities.CommodityID;
                ViewData["CommodityName"] = commodities.CommodityName;
                ViewData["PublisherName"] =publishers.PublisherName;
                ViewData["Price"] = commodities.Price;
                ViewData["LowestPrice"] = commodities.LowestPrice;
                ViewData["PublishTime"] = commodities.PublishTime.ToString();
                ViewData["Description"] = commodities.Description;
                ViewData["PictureURL"] = commodities.PictureURL;
                ViewData["DownLoadURL"] = commodities.DownLoadURL;
                ViewData["SalesVolume"] = commodities.SalesVolume;
                ViewData["Evaluation1_ID"] = evaluationList[0].BuyerID;
                ViewData["Evaluation2_ID"] = evaluationList[1].BuyerID;
                ViewData["Evaluation1_Description"] = evaluationList[0].Description;
                ViewData["Evaluation2_Description"] = evaluationList[1].Description;
            }

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddToCart([FromQuery]string UserID, [FromQuery]string CommodityID )
        {
            JsonData jsondata = new JsonData();
            if (cartService.addToCart(UserID,CommodityID))
            {
                jsondata["STATUS"] = 1;
                jsondata["REASON"] = "添加成功";
            }
            else
            {
                jsondata["STATUS"] = 0;
                jsondata["REASON"] = "添加失败";
            }

            return Json(jsondata.ToJson());
        }

        public IActionResult CommodityDetails([FromQuery]string CommodityID)
        {
            JsonData jsondata = new JsonData();
            jsondata = cartService.CommodityDetails(CommodityID);

            if (jsondata == null)
            {
                jsondata = new JsonData();
                jsondata["STATUS"] = "FAILED";
            }
           else
            {
                jsondata["STATUS"] = "SUCCESS";
            }
            return Json(jsondata.ToJson());
        }
        public IActionResult AddToWishList([FromQuery] string UserID, [FromQuery] string CommodityID)
        {
            JsonData jsondata = new JsonData();
            if (cartService.addToWishList(UserID, CommodityID))
            {
                jsondata["STATUS"] = 1;
                jsondata["REASON"] = "添加成功";
            }
            else
            {
                jsondata["STATUS"] = 0;
                jsondata["REASON"] = "添加失败";
            }

            return Json(jsondata.ToJson());
        }

        public IActionResult DeleteWishList([FromQuery] string UserID, [FromQuery] string CommodityID)
        {
            JsonData jsondata = new JsonData();
            if (cartService.deleteWishList(UserID, CommodityID))
            {
                jsondata["STATUS"] = 1;
                jsondata["REASON"] = "添加成功";
            }
            else
            {
                jsondata["STATUS"] = 0;
                jsondata["REASON"] = "添加失败";
            }

            return Json(jsondata.ToJson());
        }

        public IActionResult AddEvaluation([FromBody] object evaluation)
        {
            JsonData jsondata = new JsonData();

            string content =evaluation.ToString();
            Evaluation EValuation = JsonConvert.DeserializeObject<Evaluation>(content);

            if (cartService.addevaluations(EValuation))
            {
                jsondata["STATUS"] = 1;
                jsondata["REASON"] = "添加成功";
            }
            else
            {
                jsondata["STATUS"] = 0;
                jsondata["REASON"] = "添加失败";
            }

            return Json(jsondata.ToJson());
        }

    }
}
