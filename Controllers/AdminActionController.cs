using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using TJ_Games.DBContext;

using ThirdParty.Json.LitJson;
using TJ_Games.Models;
using TJ_Games.Models.BusinessEntity;
using WebApplication1.Services;

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

        public IActionResult DeleteBuyer()
        {
            return View();
        }
        /*************** 封禁功能 ********************/
        [HttpPost]
        public IActionResult DeleteBuyer([FromQuery] string deleteBuyerID)  // 删除买家
        {

            if (adminActionService.DeleteBuyer(deleteBuyerID))
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
        public IActionResult BuyerDetails([FromQuery] string BuyerID)
        {
            //string CommodityID = commodityID.ToString();
            JsonData jsondata = new JsonData();
            jsondata = adminActionService.BuyerDetails(BuyerID);

            if (jsondata == null)
            {
                jsondata = new JsonData();
                jsondata["STATUS"] = "FAILED";
            }
            else
            {
                jsondata["STATUS"] = "SUCCESS";
            }

            return Json(jsondata.ToJson());
        }
    }
}
