using Microsoft.AspNetCore.Mvc;
using TJ_Games.DBContext;
using TJ_Games.Service;
using TJ_Games.Models;
using Newtonsoft.Json;
using ThirdParty.Json.LitJson;

namespace WEBTEST.Controllers
{
    
    public class FriendsController : Controller
    {
        private readonly ModelContext _context;   //数据库上下文
        private FriendsService friendservice;
        public FriendsController(ModelContext context)
        {
            _context = context;
            friendservice = new FriendsService(_context);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Friends()
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
        public IActionResult FriendInfo()
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
    }
    
}
