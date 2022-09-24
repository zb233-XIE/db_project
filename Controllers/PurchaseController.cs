using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using TJ_Games.DBContext;
using TJ_Games.Services;
using TJ_Games.Models;
using TJ_Games.Models.BusinessEntity;
using TJ_Games.Models.AlipayModels;
using Alipay.AopSdk.Core;
using Alipay.AopSdk.Core.Domain;
using Alipay.AopSdk.Core.Request;
using Alipay.AopSdk.Core.Util;
using Newtonsoft.Json;
using ThirdParty.Json.LitJson;

namespace TJ_Games.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly ModelContext _context; //申明只读的数据库上下文
        private CartService cartService;
        private OrderService orderService;

        public PurchaseController(ModelContext context)
        {
            _context = context;
            cartService = new CartService(_context);
            orderService = new OrderService(_context);
        }

        /*
         * 一些支付宝业务相关的函数（可删）
        */
        [HttpPost]
        public void PayRequest([FromQuery]string tradeno, [FromQuery] string subject, [FromQuery] string totalAmout, [FromQuery] string itemBody)
        {
            DefaultAopClient client = new DefaultAopClient(AlipayConfig.Gatewayurl, AlipayConfig.AppId, AlipayConfig.PrivateKey, "json", "2.0",
                AlipayConfig.SignType, AlipayConfig.AlipayPublicKey, AlipayConfig.CharSet, false);

            // 组装业务参数model
            AlipayTradePagePayModel model = new AlipayTradePagePayModel();
            model.Body = itemBody;
            model.Subject = subject;
            model.TotalAmount = totalAmout;
            model.OutTradeNo = tradeno;
            model.ProductCode = "FAST_INSTANT_TRADE_PAY";

            AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
            // 设置同步回调地址
            request.SetReturnUrl("/GameLibrary/HaveGame");
            // 设置异步通知接收地址
            request.SetNotifyUrl("");
            // 将业务model载入到request
            request.SetBizModel(model);

            var response = client.SdkExecute(request);
            Console.WriteLine($"订单支付发起成功，订单号：{tradeno}");
            //跳转支付宝支付
            Response.Redirect(AlipayConfig.Gatewayurl + "?" + response.Body);
        }
        //前端回传和支付宝相关的参数，后端发起支付请求

        private Dictionary<string, string> GetRequestGet()
        {
            Dictionary<string, string> sArray = new Dictionary<string, string>();

            ICollection<string> requestItem = Request.Query.Keys;
            foreach (var item in requestItem)
            {
                sArray.Add(item, Request.Query[item]);

            }
            return sArray;

        }
        //解析前端回传表单的内容，转化为C#字典

        /*
         * 负责路由与重定向
        */
        public IActionResult ConfirmOrder()
        {
            if (Request.Cookies["UID"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/Entry/BuyerLogIn");
            }
        }
        //重定向到订单确认/登陆页面
        [HttpGet]
        public IActionResult SuccessPay()
        {
            if (Request.Cookies["UID"] != null)
            {
                return View();
            }
            else
            {
                Dictionary<string, string> sArray = GetRequestGet();
                if (sArray.Count != 0)
                {
                    bool flag = AlipaySignature.RSACheckV1(sArray, AlipayConfig.AlipayPublicKey, AlipayConfig.CharSet, AlipayConfig.SignType, false);
                    if (flag)
                    {
                        Console.WriteLine($"同步验证通过，订单号：{sArray["out_trade_no"]}");
                        ViewData["PayResult"] = "同步验证通过";
                    }
                    else
                    {
                        Console.WriteLine($"同步验证失败，订单号：{sArray["out_trade_no"]}");
                        ViewData["PayResult"] = "同步验证失败";
                    }
                }
                return Redirect("/Entry/BuyerLogIn");
            }
        }
        //重定向到购买成功/登陆页面

        /*
         * 将后端全局变量Global的值返回给前端
        */
        public IActionResult GetOrder()
        {
            string str = JsonConvert.SerializeObject(Global.GCart);

            return new ContentResult { Content = str, ContentType = "application/json" };
        }
        //向前端返回订单商品信息

        /*
          * 设置后端全局变量Global
        */
        [HttpPost]
        public IActionResult SetReceiver([FromBody] Towhom t)
        {
            //t.ID = t.ID.Substring(4, 11);
            Global.GToWhom = t.ID;

            JsonData jsondata = new JsonData();
            jsondata["status"] = 1;

            return Json(jsondata.ToJson());
        }

        /*
         * 调用service函数操作数据库
        */
        [HttpPost]
        public IActionResult CreateOrder()
        {
            JsonData jsonData = new JsonData();

            jsonData["status"] = orderService.CreateOrder(Request.Cookies["UID"], Global.GToWhom, Global.GCart);

            return Json(jsonData.ToJson());
        }
        //生成订单
        [HttpPost]
        public IActionResult TidyCart()
        {
            JsonData jsondata = new JsonData();
            if (string.IsNullOrEmpty(Global.GToWhom))
            {
                jsondata["status"] = 0;
                return Json(jsondata.ToJson());
            }
            jsondata["status"] = 1;
            foreach (CartView v in Global.GCart.items)
            {
                bool flag = cartService.RemoveFromCart(Global.GToWhom, v.CommodityID);
                if (!flag) jsondata["status"] = 0;
            }
            return Json(jsondata.ToJson());
        }
        //从receiver的购物车中删除已购买的商品
    }
}
