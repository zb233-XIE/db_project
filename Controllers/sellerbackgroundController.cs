using Microsoft.AspNetCore.Mvc;
namespace seller.Controllers
{
    public class sellerbackgroundController : Controller
    {
        //初始界面
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult change()
        {
            ViewData["id"] = 10;
            ViewData["name"] = "111";
            ViewData["time"] = 20202020;
            ViewData["mail"] = "1581111111";
            ViewData["description"] = "dasdasdas";
            return View();
        }
        //卖家信息
        public IActionResult Seller(int ID = 10, string name = "111", int time = 20202020, string mail = "1581111111@",string description="dasdasdas")
        {
            ViewData["id"] = ID;
            ViewData["name"] = name;
            ViewData["time"] =time;
            ViewData["mail"] = mail;
            ViewData["description"] = description;
            return View();
        }
        //查看已经发布的游戏
        public IActionResult Old(int ID=10, string name = "111",string publisher="publisher",int price=4567, int time=19380908,string classification="wushi",string downloadurl="xwszxx",int volume=99, string description = "dasdasdas")
        {

            ViewData["id"] = ID;
            ViewData["name"] = name;
            ViewData["publisher"] = publisher;
            ViewData["price"] = price;
            ViewData["time"] = time;
            ViewData["classification"] = classification;
            ViewData["downloadurl"] = downloadurl;
            ViewData["volume"] = volume;
            ViewData["description"] = description;
            return View();
        }
        //发布更新日志
        public IActionResult Date(int ID = 10, int number = 11111, int time = 20202020, string content = "d11asdasdas")
        {

            //ViewData["id"] = ID;
            //ViewData["number"] = number;
            //ViewData["time"] = time;
            //ViewData["content"] = content;
            return View();
        }
        //发布新游戏
        public IActionResult Publish()
        {
            return View();
        }

        public IActionResult Updatechange(string ID)
        {
            return Content(ID);
        }
        public IActionResult Updatepublish(string ID)
        {
            return Content(ID);
        }
        public IActionResult Updatedate(string ID)
        {
            return Content(ID);
        }
        //修改卖家信息
        /*
        [HttpPost]
        public IActionResult Change([FromBody] Object ID)
        {
            if (ID is null)
            {
                throw new ArgumentNullException(nameof(ID));
            }
            //string a = ID.ToString();

            //return Json(a);
            return View();
        }
        */

    }
}
