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
        public IActionResult Details()
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
                jsondata["AddToCart"] = "SUCCESS";
            }
            else
            {
                jsondata["AddToCart"] = "FAILED";
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
                jsondata["AddToWishList"] = "SUCCESS";
            }
            else
            {
                jsondata["AddToWishList"] = "FAILED";
            }

            return Json(jsondata.ToJson());
        }

        public IActionResult DeleteWishList([FromQuery] string UserID, [FromQuery] string CommodityID)
        {
            JsonData jsondata = new JsonData();
            if (cartService.deleteWishList(UserID, CommodityID))
            {
                jsondata["DeleteToWishList"] = "SUCCESS";
            }
            else
            {
                jsondata["DeleteToWishList"] = "FAILED";
            }

            return Json(jsondata.ToJson());
        }
    }
}
