using TJ_Games.DBContext;
using TJ_Games.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models.ControllerModels
{
    public class Commodity2       // 下架商品
    {
        public string CommodityID { get; set; }
        public string CommodityName { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public string Commodity_Genre { get; set; }
    }


}
