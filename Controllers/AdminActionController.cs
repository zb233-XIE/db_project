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
        /*************** 封禁功能 ********************/
        [HttpPost]
        public IActionResult DeleteBuyer([FromBody] DeleteBuyer deleteBuyer)  // 删除买家
        {
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
        /*************** 封禁功能 ********************/

        [HttpPost]
        public IActionResult DeleteCommodity([FromBody] DeleteCommodity deleteCommodity)  // 下架商品
        {
            if (adminActionService.DeleteCommodity(deleteCommodity.ID))
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
