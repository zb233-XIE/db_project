using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using TJ_Games.DBContext;
using TJ_Games.Services;
using TJ_Games.Models;
using TJ_Games.Models.BusinessEntity;
using TJ_Games.Models.AlipayModels;
using Newtonsoft.Json;
using ThirdParty.Json.LitJson;

namespace TJ_Games.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ModelContext _context; //申明只读的数据库上下文
        private CartService cartService;

        public ShoppingCartController(ModelContext context)
        {
            _context = context;
            cartService = new CartService(context);
        }

        /*
         * 路由与重定向 
        */
        public IActionResult Index()
        {
            //测试用
            if (Request.Cookies["UID"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/Entry/BuyerLogIn");
            }
        }
        //重定向到购物车/登陆页面

        /*
         * 前后端交互
        */
        [HttpPost]
        public IActionResult GetCartDetail()
        {
            List<CartView> shopCarts = new List<CartView>();
            shopCarts = cartService.GetCartProduct(Request.Cookies["UID"]);

            string str = JsonConvert.SerializeObject(shopCarts);
            return new ContentResult { Content = str, ContentType = "application/json" };
        }
        //获取当前用户购物车内容

        [HttpPost]
        public IActionResult DeleteCommodity([FromBody] CommodityID commodity)
        {
            JsonData jsondata = new JsonData();
            jsondata["status"] = cartService.RemoveFromCart(Request.Cookies["UID"], commodity.ID);

            return Json(jsondata.ToJson());
        }
        //从购物车删除指定商品

        [HttpPost]
        public IActionResult ClearCart()
        {
            JsonData jsondata = new JsonData();
            jsondata["status"] = cartService.RemoveAll(Request.Cookies["UID"]);

            return Json(jsondata.ToJson());
        }
        //清空购物车

        [HttpPost]
        public IActionResult SetCartOrder([FromBody] Cart c)
        {
            JsonData jsonData = new JsonData();
            if (c.items.Count == 0)  //没有商品
            {
                jsonData["status"] = 0;
            }
            else
            {
                jsonData["status"] = 1;
                Global.GCart = c;
            }
            return Json(jsonData.ToJson());
        }
        //从购物车中选择要购买的游戏并在Global中设置
    }
}
