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
using Microsoft.AspNetCore.Http;

namespace TJ_Games.Controllers
{
    public class EntryController : Controller
    {
        private readonly ModelContext _context;   //数据库上下文
        private BuyerService service;             //后端service
        private PublishersService PublisherService;
        private AdministratorService AdministratorService;

        public EntryController(ModelContext context)
        {
            _context = context;
            service = new BuyerService(_context);
            PublisherService = new PublishersService(_context);
            AdministratorService = new AdministratorService(_context);
        }

        // 传输页面
        public IActionResult BuyerLogIn()
        {
            if (Request.Cookies["buyerNickName"] != null)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult BuyerSignUp()
        {
            if (Request.Cookies["buyerNickName"] != null)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult SellerSignUp()
        {
            if (Request.Cookies["sellerNickName"] != null)
            {
                return Redirect("/SellerBackground/Home");
            }
            else
            {
                return View();
            }
        }
        public IActionResult SellerLogIn()
        {
            if (Request.Cookies["sellerNickName"] != null)
            {
                return Redirect("/SellerBackground/Home");
            }
            else
            {
                return View();
            }
        }
        public IActionResult AdministratorLogIn()
        {
            if (Request.Cookies["adminNickName"] != null)
            {
                return Redirect("/Admin/AdminWork");
            }
            else
            {
                return View();
            }
        }

        public IActionResult BuyerLogOut()    //买家退出登录
        {
            if (Request.Cookies["buyerNickName"] != null)
            {
                //设置cookie
                HttpContext.Response.Cookies.Delete("buyerNickName");
                HttpContext.Response.Cookies.Delete("buyerID");
                return Redirect("/Home/Index");
            }
            else
            {
                return Redirect("/Home/Index");
            }
        }

        [HttpPost]
        public IActionResult BuyerLogInForm([FromBody] LoginModel loginModel)
        {
            int is_vaild = service.BuyerLogin(loginModel.Login_ID, loginModel.Login_Password);

            if (is_vaild == 1)//说明此时验证通过
            {
                //设置对应的登录Cookie
                HttpContext.Response.Cookies.Append("buyerID", loginModel.Login_ID, new CookieOptions { Expires = DateTime.Now.AddSeconds(3600) });
                //跳转到指定位置
                return Redirect("/Home/Index");
            }
            else if (is_vaild == -1)//说明此时没有该用户名
            {
                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 0;
                jsondata["REASON"] = "找不到对应的用户名";
                return Json(jsondata.ToJson());
            }
            else if (is_vaild == -2)//说明此时密码错误
            {
                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 0;
                jsondata["REASON"] = "用户名对应的密码错误";
                return Json(jsondata.ToJson());
            }
            else//此种情况理论上不会出现，如果出现此种情况，考虑数据传输被恶意攻击了
            {
                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 0;
                jsondata["REASON"] = "未知错误";
                return Json(jsondata.ToJson());
            }
        }
        [HttpPost]
        public IActionResult BuyerSignUpForm([FromBody] BuyerSignUpModel buyer)
        {
            int is_success = service.BuyerSignup(buyer);

            if ( is_success == 1)//说明添加成功
            {
                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 1;
                jsondata["SIGNUP"] = "SUCCESS";
                return Json(jsondata.ToJson());
            }
            else if(is_success==-1)//说明此时数据库当中已经有该用户
            {
                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 0;
                jsondata["SIGNUP"] = "FAILED";
                jsondata["REASON"] = "该用户ID已经被注册";
                return Json(jsondata.ToJson());
            }
            else if(is_success==-2)//说明此时数据库保存失败
            {
                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 0;
                jsondata["SIGNUP"] = "FAILED";
                jsondata["REASON"] = "数据库保存失败";
                return Json(jsondata.ToJson());
            }
            else//此种情况理论上不会出现，如果出现此种情况，考虑数据传输被恶意攻击了
            {
                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 0;
                jsondata["SIGNUP"] = "FAILED";
                jsondata["REASON"] = "未知错误";
                return Json(jsondata.ToJson());
            }
        }

        public IActionResult PublisherLogInForm([FromBody] LoginModel loginModel)
        {
            int is_vaild = PublisherService.PublisherLogin(loginModel.Login_ID, loginModel.Login_Password);

            if (is_vaild == 1)//说明此时验证通过
            {
                //设置对应的登录Cookie
                HttpContext.Response.Cookies.Append("PublisherID", loginModel.Login_ID, new CookieOptions { Expires = DateTime.Now.AddSeconds(3600) });
                //跳转到指定位置
                return Redirect("/Home/Index");
            }
            else if (is_vaild == -1)//说明此时没有该用户名
            {
                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 0;
                jsondata["REASON"] = "找不到对应的用户名";
                return Json(jsondata.ToJson());
            }
            else if (is_vaild == -2)//说明此时密码错误
            {
                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 0;
                jsondata["REASON"] = "用户名对应的密码错误";
                return Json(jsondata.ToJson());
            }
            else//此种情况理论上不会出现，如果出现此种情况，考虑数据传输被恶意攻击了
            {
                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 0;
                jsondata["REASON"] = "未知错误";
                return Json(jsondata.ToJson());
            }
        }

        public IActionResult PublisherSignUpForm([FromBody] PublisherSignUpModel publisher)
        {
            int is_success = PublisherService.PublisherSignup(publisher);

            if (is_success == 1)//说明添加成功
            {
                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 1;
                jsondata["SIGNUP"] = "SUCCESS";
                return Json(jsondata.ToJson());
            }
            else if (is_success == -1)//说明此时数据库当中已经有该用户
            {
                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 0;
                jsondata["SIGNUP"] = "FAILED";
                jsondata["REASON"] = "该用户ID已经被注册";
                return Json(jsondata.ToJson());
            }
            else if (is_success == -2)//说明此时数据库保存失败
            {
                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 0;
                jsondata["SIGNUP"] = "FAILED";
                jsondata["REASON"] = "数据库保存失败";
                return Json(jsondata.ToJson());
            }
            else//此种情况理论上不会出现，如果出现此种情况，考虑数据传输被恶意攻击了
            {
                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 0;
                jsondata["SIGNUP"] = "FAILED";
                jsondata["REASON"] = "未知错误";
                return Json(jsondata.ToJson());
            }
        }

        public IActionResult AdministratorLogInForm([FromBody] LoginModel loginModel)
        {
            int is_vaild = AdministratorService.AdministratorLogin(loginModel.Login_ID, loginModel.Login_Password);

            if (is_vaild == 1)//说明此时验证通过
            {
                //设置对应的登录Cookie
                HttpContext.Response.Cookies.Append("AdministratorID", loginModel.Login_ID, new CookieOptions { Expires = DateTime.Now.AddSeconds(3600) });
                //跳转到指定位置
                return Redirect("/Home/Index");
            }
            else if (is_vaild == -1)//说明此时没有该用户名
            {
                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 0;
                jsondata["REASON"] = "找不到对应的用户名";
                return Json(jsondata.ToJson());
            }
            else if (is_vaild == -2)//说明此时密码错误
            {
                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 0;
                jsondata["REASON"] = "用户名对应的密码错误";
                return Json(jsondata.ToJson());
            }
            else//此种情况理论上不会出现，如果出现此种情况，考虑数据传输被恶意攻击了
            {
                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 0;
                jsondata["REASON"] = "未知错误";
                return Json(jsondata.ToJson());
            }
        }
    }
}
