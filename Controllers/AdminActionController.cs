using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using TJ_Games.DBContext;
using TJ_Games.Models.ControllerModels;
using TJ_Games.Services;
using ThirdParty.Json.LitJson;
using TJ_Games.Models;
using TJ_Games.Models.BusinessEntity;

namespace TJ_Games.Controllers
{
    public class AdminActionController : Controller
    {
        private readonly ModelContext _context;
        private AdminActionService adminActionService;

        public AdminActionController(ModelContext context)
        {
            _context = context;
            adminActionService = new AdminActionService(_context);
        }
        public IActionResult Delete()
        {
           return View();
        }
        /*************** 封禁功能 ********************/
        [HttpPost]
        public IActionResult DeleteBuyer([FromBody] object DeleteBuyer)  // 删除买家
        {
            string content = DeleteBuyer.ToString();
            DeleteBuyer deleteBuyer = JsonConvert.DeserializeObject<DeleteBuyer>(content);
            if (adminActionService.DeleteBuyer(deleteBuyer.ID))
            {
                JsonData jsondata = new JsonData();
                jsondata["deleteBuyer"] = "SUCESS";
                return Json(jsondata.ToJson());
            }
            else
            {
                JsonData jsondata = new JsonData();
                jsondata["deleteBuyer"] = "ERROR";
                return Json(jsondata.ToJson());
            }
        }

        [HttpPost]
        public IActionResult DeleteCommodity([FromQuery] string CommodityID)  // 下架商品
        {
            //string content = DeleteCommodity.ToString();
            //DeleteBuyer deleteCommodity = JsonConvert.DeserializeObject<DeleteBuyer>(content);


            if (adminActionService.DeleteCommodity(CommodityID))
            {
                JsonData jsondata = new JsonData();
                jsondata["deleteCommodity"] = "SUCESS";
                return Json(jsondata.ToJson());
            }
            else
            {
                JsonData jsondata = new JsonData();
                jsondata["deleteCommodity"] = "ERROR";
                return Json(jsondata.ToJson());
            }
        }
    }
}
