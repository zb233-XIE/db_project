using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TJ_Games.Models;
using TJ_Games.Services;
using TJ_Games.DBContext;
using ThirdParty.Json.LitJson;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using TJ_Games.Models.BusinessEntity;

namespace TJ_Games.Controllers
{
    public class AccountController : Controller
    {
        private readonly ModelContext _context;   //数据库上下文
        private SecurityService service1;             //后端service
        private FavoriteProductService favoriteProductService;
        private BuyerService service2;
        private OrderService orderService;
        [Obsolete]
        private readonly IWebHostEnvironment _hostingEnvironment;

        [Obsolete]
        public AccountController(ModelContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            service1 = new SecurityService(_context);
            _hostingEnvironment = hostingEnvironment;
        }
            public IActionResult PersonalInformation()
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
        public IActionResult Security()
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
        public IActionResult Address()
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
        public IActionResult orders()
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
        public IActionResult coupon()
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
        public JsonResult GetMailPasswdByID([FromBody] BuyerModel buyerModel)
        {
            string buyerPasswd = service1.displayPasswd(buyerModel.BuyerID);
            string buyerMail = service1.displayPhone(buyerModel.BuyerID);
            JsonData jsondata = new JsonData();
            if (buyerPasswd != null && buyerMail != null)
            {
                jsondata["buyerPasswd"] = buyerPasswd;
                jsondata["buyerMail"] = buyerMail;
            }

            return Json(jsondata.ToJson());

        }
        public JsonResult UpdateMailByID([FromBody] BuyerMail buyerMail)
        {
            bool flag = service1.updateMail(buyerMail.BuyerID, buyerMail.OldMail, buyerMail.NewMail);
            JsonData jsondata = new JsonData();
            if (flag)
            {
                jsondata["buyerMail"] = buyerMail.NewMail;
            }

            return Json(jsondata.ToJson());
        }
        //测试用数据
       /* public JsonResult UpdatePasswdByID()
        {
            bool flag = service1.updatePasswd("2054090", "123456", "654321");
            JsonData jsondata = new JsonData();
            if (flag)
            {
                jsondata["buyerPasswd"] = "654321";
            }

            return Json(jsondata.ToJson());
        }
       */
        public JsonResult UpdatePasswdByID([FromBody] BuyerPasswd buyerPasswd)
        {
            bool flag = service1.updatePasswd(buyerPasswd.BuyerID, buyerPasswd.OldPasswd, buyerPasswd.NewPasswd);
            JsonData jsondata = new JsonData();
            if (flag)
            {
                jsondata["buyerPasswd"] = buyerPasswd.NewPasswd;
            }

            return Json(jsondata.ToJson());
        }
        /**************************** 买家购物车服务 ***********************************/
        [HttpPost]
        public IActionResult DisplayFavorites([FromBody] BuyerModel buyerModel)   // 查看收藏商品
        {
            List<FavoriteProductView> favorites = new List<FavoriteProductView>();
            favorites = favoriteProductService.getFavoriteProduct(buyerModel.BuyerID);

            foreach (var favorite in favorites)
            {
                favorite.CommodityImg = "../.." + favorite.CommodityImg;
            }

            string str = JsonConvert.SerializeObject(favorites);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }

        [HttpPost]
        public IActionResult AddFavoriteProduct([FromBody] AddOrDeleteFavorites addFavorite)  // 添加商品进购物车
        {
            if (favoriteProductService.addToFavorite(addFavorite.buyerid, addFavorite.commodityid))
            {
                JsonData jsondata = new JsonData();
                jsondata["addFavorite"] = "SUCCESS";
                return Json(jsondata.ToJson());
            }
            else
            {
                JsonData jsondata = new JsonData();
                jsondata["addFavorite"] = "ERROR";
                return Json(jsondata.ToJson());
            }
        }

        [HttpPost]
        public IActionResult CancelFavoriteProduct([FromBody] AddOrDeleteFavorites addFavorite)  // 删除购物车里的商品
        {
            if (favoriteProductService.removeFromFavorite(addFavorite.buyerid, addFavorite.commodityid))
            {
                JsonData jsondata = new JsonData();
                jsondata["deleteFavorite"] = "SUCCESS";
                return Json(jsondata.ToJson());
            }
            else
            {
                JsonData jsondata = new JsonData();
                jsondata["deleteFavorite"] = "ERROR";
                return Json(jsondata.ToJson());
            }
        }

        [HttpPost]
        public IActionResult CancelAllFavoriteProduct([FromBody] DeleteAllFavorites deleteAllFavorite)  // 清空购物车
        {
            if (favoriteProductService.removeAllFavorite(deleteAllFavorite.buyerid))
            {
                JsonData jsondata = new JsonData();
                jsondata["deleteAllFavorite"] = "SUCCESS";
                return Json(jsondata.ToJson());
            }
            else
            {
                JsonData jsondata = new JsonData();
                jsondata["deleteAllFavorite"] = "ERROR";
                return Json(jsondata.ToJson());
            }
        }
        /**************************** 买家个人信息服务 ***********************************/
        public JsonResult DisplayBuyerInfo([FromBody] BuyerModel buyerModel)
        {
            Buyers buyer = service2.SearchByID(buyerModel.BuyerID);
            JsonData jsondata = new JsonData();
            if (buyer != null)
            {
                jsondata["buyerNickname"] = buyer.BuyerName;
                jsondata["buyerMail"] = buyer.Mail;
                jsondata["buyerBirth"] = buyer.Birthday.ToString();
            }
            return Json(jsondata.ToJson());
        }
        [HttpPost]
        [Obsolete]
        public Buyers UpdateInfoById()
        {
            var date = Request;
            var data = Request.Form;     //上传的信息
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            //通过id找到要更新的买家，准备更改后保存数据库
            Buyers beforeBuyer = service2.SearchByID(data["BuyerId"]);
            Buyers nowBuyer = beforeBuyer;
            //对其部分信息进行更新
            if (data["UpdatedBirth"] == "")
            {
                nowBuyer.Birthday = null;
            }
            else
            {
                nowBuyer.Birthday = DateTime.Parse(data["UpdatedBirth"]);
            }
            nowBuyer.BuyerName = data["UpdatedNickname"];
            service2.EditBuyer(beforeBuyer, nowBuyer);

            return nowBuyer;
        }
        //此功能暂时无法完成，需要等其他模块进行完善
        /***************** 买家订单服务 ***************************/
      /*  [HttpPost]
        public IActionResult DisplayOrders([FromBody] BuyerOrder buyerOrder)   // 查看买家订单
        {
            List<OrderInformationView> orders = new List<OrderInformationView>();
            orders = orderService.getOrderByBuyerId(buyerOrder.BuyerId);
            foreach (var order in orders)
            {
                foreach (var commodity in order.commodityList)
                {
                    commodity.Url = "../.." + commodity.Url;
                }
            }
            string str = JsonConvert.SerializeObject(orders);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }*/
    }
}

