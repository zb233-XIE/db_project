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


        public IActionResult Register()
        {
            return View();
        }

        // 传输页面
        public IActionResult Login()
        {
            if (Request.Cookies["UID"] != null)//说明此时已经登录成功了，无需再次登录
            { 
                 return Redirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Logout()    //退出登录
        {
            if (Request.Cookies["UID"] != null)
            {
                //删除cookie
                HttpContext.Response.Cookies.Delete("UID");
                return Redirect("/Entry/Login");
            }
            else
            {
                return Redirect("/Home/Index");
            }
        }

        [HttpPost]
        public IActionResult BuyerLogInForm([FromBody] object LoginModel)
        {
            //由于未知原因，上面的参数传过来只能用object方式，下面对其进行转换，转换为我们想要的格式
            string content = LoginModel.ToString();
            LoginModel loginModel = JsonConvert.DeserializeObject<LoginModel>(content);

            int is_vaild = service.BuyerLogin(loginModel.Login_ID, loginModel.Login_Password);

            if (is_vaild == 1)//说明此时验证通过
            {
                //设置对应的登录Cookie
                HttpContext.Response.Cookies.Append("UID", loginModel.Login_ID, new CookieOptions { Expires = DateTime.Now.AddSeconds(3600) });

                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 1;
                jsondata["REASON"] = "登录成功";
                return Json(jsondata.ToJson());
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
        public IActionResult BuyerSignUpForm([FromBody] object buyer)
        {
            //由于未知原因，上面的参数传过来只能用object方式，下面对其进行转换，转换为我们想要的格式
            string content = buyer.ToString();
            BuyerSignUpModel Buyer = JsonConvert.DeserializeObject<BuyerSignUpModel>(content);

            int is_success = service.BuyerSignup(Buyer);

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

        public IActionResult PublisherLogInForm([FromBody] object LoginModel)
        {
            //由于未知原因，上面的参数传过来只能用object方式，下面对其进行转换，转换为我们想要的格式
            string content = LoginModel.ToString();
            LoginModel loginModel = JsonConvert.DeserializeObject<LoginModel>(content);


            int is_vaild = PublisherService.PublisherLogin(loginModel.Login_ID, loginModel.Login_Password);

            if (is_vaild == 1)//说明此时验证通过
            {
                //设置对应的登录Cookie
                HttpContext.Response.Cookies.Append("UID", loginModel.Login_ID, new CookieOptions { Expires = DateTime.Now.AddSeconds(3600) });

                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 1;
                jsondata["REASON"] = "登录成功";
                return Json(jsondata.ToJson());
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

        public IActionResult PublisherSignUpForm([FromBody] object Publisher)
        {
            //由于未知原因，上面的参数传过来只能用object方式，下面对其进行转换，转换为我们想要的格式
            string content = Publisher.ToString();
            PublisherSignUpModel publisher = JsonConvert.DeserializeObject<PublisherSignUpModel>(content);


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

        public IActionResult AdministratorLogInForm([FromBody] object LoginModel)
        {
            //由于未知原因，上面的参数传过来只能用object方式，下面对其进行转换，转换为我们想要的格式
            string content = LoginModel.ToString();
            LoginModel loginModel = JsonConvert.DeserializeObject<LoginModel>(content);


            int is_vaild = AdministratorService.AdministratorLogin(loginModel.Login_ID, loginModel.Login_Password);

            if (is_vaild == 1)//说明此时验证通过
            {
                //设置对应的登录Cookie
                HttpContext.Response.Cookies.Append("UID", loginModel.Login_ID, new CookieOptions { Expires = DateTime.Now.AddSeconds(3600) });

                JsonData jsondata = new JsonData();
                jsondata["STATUS"] = 1;
                jsondata["REASON"] = "登录成功";
                return Json(jsondata.ToJson());
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
