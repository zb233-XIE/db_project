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
using System.Text;
using System.Security.Cryptography;

namespace TJ_Games.Controllers
{
    public class GameLibraryController : Controller
    {
        private readonly ModelContext _context;   //数据库上下文
        private GameLibraryService gamelibraryService;
        [Obsolete]
        private readonly IWebHostEnvironment _hostingEnvironment;
        public GameLibraryController(ModelContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            gamelibraryService = new GameLibraryService(_context);
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult HaveGame(string Buyer_id)
        {
            //ViewData模式完成传值工作，在数据库中查找到相应内容并将其返回

            return View();
        }

        public IActionResult HaveGame2()
        {
            //var test = Request.Cookies["UID"];
            //ViewData模式完成传值工作，在数据库中查找到相应内容并将其返回
            var commodity = gamelibraryService.GetCommodityInfo(Request.Cookies["UID"]);
            var str = JsonConvert.SerializeObject(commodity);

            
            return new ContentResult { Content = str, ContentType = "application/json" };

        }
        [HttpPost]
        public IActionResult InGameLibrary()
        {
            JsonData jsondata = new JsonData();

            List<string> GIDlist = new List<string>();
            foreach(var v in Global.GCart.items)
            {
                GIDlist.Add(v.CommodityID);
            }

            jsondata["status"] = gamelibraryService.InLibrary(Global.GToWhom,GIDlist);

            return Json(jsondata.ToJson());
        }


        [HttpPost]
        public IActionResult ModifyGameLibrary()
        {
            JsonData jsondata = new JsonData();
            bool flag = true;

            foreach (var v in Global.GCart.items)
            {
                if(gamelibraryService.AddGame(Global.GToWhom, v.CommodityID)==-1)//说明此时该人已有该游戏
                {
                    jsondata["status"] = -1;
                    jsondata["reason"] = "您游戏库当中已经拥有您购物车当中游戏";
                    return Json(jsondata.ToJson());
                }
            }

            jsondata["status"] = flag;
            jsondata["reason"] = "购买成功";
            return Json(jsondata.ToJson());
        }
        //在gamelibrary控制器下

    }
}
