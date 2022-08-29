using Microsoft.AspNetCore.Mvc;
using TJ_Games.DBContext;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdParty.Json.LitJson;
using TJ_Games.Service;
using TJ_Games.Models;
#nullable disable

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
        public IActionResult Index(string Publisher_id)//返回SellerBackground的主视图（INDEX）
        {
            return View();
        }
        public IActionResult change(string Publisher_id)//转到change_更改个人信息的界面
        {
            /* -- 如何为参数Publisher_id赋值？
             * -- 解决方法是，在函数seller后面添加?Publisher_id = 发行商名字的字符串就可以了 */

            return View();
        }
        public IActionResult date(string Publisher_id)//转到date_发布更新的界面
        {
            return View();
        }
        public IActionResult publish(string Publisher_id)//转到publish_发布游戏的页面
        {
            return View();
        }
        public IActionResult seller(string Publisher_id)//转到seller_显示发行商信息的页面
        {
            /* 采取url传参的模式完成 */


            /* -- 如何为参数Publisher_id赋值？
             * -- 解决方法是，在函数seller后面添加?Publisher_id = 发行商名字的字符串就可以了 */
            
            //ViewData模式完成传值工作，在数据库中查找到相应内容并将其返回

            var publisher = publisherService.GetPublisherInfo(Publisher_id);

            ViewData["id"] = Publisher_id;
            ViewData["name"] = publisher.PublisherName;
            ViewData["time"] = publisher.StartTime;
            ViewData["mail"] = publisher.HomepageURL;
            ViewData["description"] = publisher.Description;
            return View();
        }
        public IActionResult old(string Publisher_id)//转到old_显示发行商信息的页面
        {
            //ViewData模式完成传值工作，在数据库中查找到相应内容并将其返回
            
            var commodity = publisherService.GetCommodityInfo(Publisher_id);

            /* 注意！由于相关V模块的功能还没有实现，所以这里的ViewData采取了引用第一个值的模式，
             * 但是这不符合逻辑，如果能修改尽量改掉*/
            ViewData["List"] = commodity;
            return View();
        }

       [HttpPost]
        public IActionResult Updatepublish([FromBody] object commodities)//URL：Updatepublish：发布新游戏，传参，将数据以OBJECT的形式传送过来，然后在数据库中实现。
        {
            JsonData jsondata = new JsonData();
            string content = commodities.ToString();
            Commodities commodity = JsonConvert.DeserializeObject<Commodities>(content);
            if (publisherService.PublishGame(commodity.CommodityID, commodity.CommodityName, commodity.PublisherID, commodity.Price, commodity.LowestPrice, commodity.PublishTime, commodity.Description, commodity.PictureURL, commodity.DownLoadURL))
            {
                jsondata["PublishGame"] = "发布游戏成功！";//对应V模块应该注意打印相应的内容，做出判断
                jsondata["Flag"] = 1;
            }
            else
            {
                jsondata["PublishGame"] = "发布游戏失败！";
                jsondata["Flag"] = 0;
            }
            return Json(jsondata.ToJson());
        }
        public IActionResult Updatedate([FromBody] object update)//URL：Updatedate：发布更新，传参，将数据以object的形式传送过来，然后在数据库中实现。
        {
            JsonData jsondata = new JsonData();
            string content = update.ToString();
            Updatelog updatelog = JsonConvert.DeserializeObject<Updatelog>(content);
            if (publisherService.AddUpdate(updatelog.CommodityID, updatelog.VersionNumber, updatelog.UpdateTime, updatelog.Description))
            {
                jsondata["UpdateDate"] = "发布更新成功！";
                jsondata["Flag"] = 1;
            }
            else
            {
                jsondata["UpdateDate"] = "发布更新失败！";
                jsondata["Flag"] = 0;
            }
            return Json(jsondata.ToJson());
        }
        public IActionResult Updatechange([FromBody] object _publisher)//URL：Updatechange：修改卖家信息，传参，将数据以OBJECT的形式传送过来，然后在数据库中实现。
        {
            JsonData jsondata = new JsonData();
            string content = _publisher.ToString();
            Publishers publisher = JsonConvert.DeserializeObject<Publishers>(content);
            if (publisherService.EditPublisher(publisher.PublisherID, publisher.PublisherName, publisher.StartTime, publisher.Description, publisher.HomepageURL))
            {
                jsondata["UpdateChange"] = "更改个人信息成功！";
                jsondata["Flag"] = 1;
            }
            else
            {
                jsondata["UpdateChange"] = "更改个人信息失败！";
                jsondata["Flag"] = 0;
            }
            return Json(jsondata.ToJson());
        }
    }
}

