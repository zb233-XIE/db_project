using TJ_Games.DBContext;
using TJ_Games.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models.ControllerModels
{
    public class DeleteCommodity       // 下架商品
    {
        public string ID { get; set; }
    }
    public class DeleteBuyer            // 删除买家
    {
        public string ID { get; set; }
    }

}
