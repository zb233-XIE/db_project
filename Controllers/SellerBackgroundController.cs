using Microsoft.AspNetCore.Mvc;
using TJ_Games.DBContext;
using TJ_Games.Service;
using TJ_Games.Models;
using Newtonsoft.Json;
using ThirdParty.Json.LitJson;
namespace TJ_Games.Controllers
{
    public class SellerBackgroundController : Controller
    {
        private readonly ModelContext _context;   //数据库上下文
        private PublishersService publisherService;
        public SellerBackgroundController(ModelContext context)
        {
            _context = context;
            publisherService = new PublishersService(_context);
        }
        public IActionResult Index()//返回SellerBackground主视图
        {
            return View();
        }

        public IActionResult change()
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
        public IActionResult date()
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
        public IActionResult publish()
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
        public IActionResult seller(string Publisher_id)
        {
            if (Request.Cookies["buyerNickName"] != null)
            {
                Publisher_id = Request.Cookies["buyerNickName"];
                var publisher = publisherService.GetPublisherInfo(Publisher_id);
                ViewData["id"] = Publisher_id;
                ViewData["name"] = publisher.PublisherName;
                ViewData["time"] = publisher.StartTime;
                ViewData["mail"] = publisher.HomepageURL;
                ViewData["description"] = publisher.Description;
                return View();
            }
            else
            {
                return Redirect("/Entry/BuyerLogIn");
            }
        }
        public IActionResult old(string Publisher_id)
        {
            if (Request.Cookies["buyerNickName"] != null)
            {
                Publisher_id = Request.Cookies["buyerNickName"];
                var commodity = publisherService.GetCommodityInfo(Publisher_id);
                ViewData["publisher"] = Publisher_id;
                ViewData["id"] = commodity.FirstOrDefault().CommodityID;
                ViewData["name"] = commodity.FirstOrDefault().CommodityName;
                ViewData["price"] = commodity.FirstOrDefault().Price;
                ViewData["time"] = commodity.FirstOrDefault().PublishTime;
                ViewData["classification"] = commodity.FirstOrDefault().Classification;
                ViewData["downloadurl"] = commodity.FirstOrDefault().DownLoadURL;
                ViewData["volume"] = commodity.FirstOrDefault().SalesVolume;
                ViewData["description"] = commodity.FirstOrDefault().Description;

                return View();
            }
            {
                return Redirect("/Entry/BuyerLogIn");
            }
        }

        [HttpPost]
        public IActionResult ChangePublisherInfo([FromBody] Publishers publisher)
        {
            JsonData jsondata = new JsonData();
            jsondata["id"] = publisher.PublisherID;//我感觉ID是不能改的，但是V模块将其修改了??
            jsondata["name"] = publisher.PublisherName;
            jsondata["time"] = Convert.ToString(publisher.StartTime);//????
            jsondata["mail"] = publisher.HomepageURL;
            jsondata["description"] = publisher.Description;
            return Json(jsondata.ToJson());
        }

        public IActionResult PublishNewGames([FromBody] Commodities commodity)
        {
            JsonData jsondata = new JsonData();
            jsondata["id"] = commodity.CommodityID;
            jsondata["name"]=commodity.CommodityName;
            jsondata["price"] = commodity.Price;
            jsondata["time"] = Convert.ToString(commodity.PublishTime);
            jsondata["classification"] = commodity.Classification;
            jsondata["downloadurl"] = commodity.DownLoadURL;
            jsondata["volume"] = commodity.SalesVolume;
            jsondata["description"] = commodity.Description;
            return Json(jsondata.ToJson());
        }

        public IActionResult PublishUpdates([FromBody] Updatelog update)
        {
            JsonData jsondata = new JsonData();
            jsondata["id"] = update.CommodityID;
            jsondata["version"] = update.VersionNumber;
            jsondata["time"] = Convert.ToString(update.UpdateTime);
            jsondata["content"] = update.Description;
            return Json(jsondata.ToJson());
        }
    } 
}
