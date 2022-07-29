using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TJ_Games.Models;
using TJ_Games.DBContext;
using System.Text.RegularExpressions;

namespace TJ_Games.Services
{
    public class SearchService
    {
        private ModelContext _context;
        public SearchService(ModelContext context)
        {
            _context = context;
        }

        public List<Commodities> SearchCommodity(string name, List<string> classification)
        {
            List<Commodities> CommodityList = new List<Commodities>();
            if (classification.Any())//若指定了游戏类型
            {
                List<Commodities> tmplist = _context.Commodities
                    .Include(c => c.Commodity_Genre)
                        .ThenInclude(d => d.Genre)
                    .ToList();
                //先做表的连接
                if (name != String.Empty)
                {
                    tmplist.Select(c => EF.Functions.Like(c.CommodityName, "%name%"));
                }
                foreach (var item in tmplist)
                {
                    foreach (var type in item.Commodity_Genre)
                    {
                        if (classification.Contains(type.Genre.Type))
                        {
                            Commodities TBA = new Commodities
                            {
                                CommodityID = item.CommodityID,
                                CommodityName = item.CommodityName,
                                PublisherID = item.PublisherID,
                                Price = item.Price,
                                LowestPrice = item.LowestPrice,
                                PublishTime = item.PublishTime,
                                Description = item.Description,
                                PictureURL = item.PictureURL,
                                DownLoadURL = item.DownLoadURL,
                                SalesVolume = item.SalesVolume
                            };
                            CommodityList.Add(TBA);
                        }
                    }
                }
            }
            else
            {
                if (name != String.Empty)
                {
                    CommodityList = _context.Commodities
                        .Where(c => EF.Functions.Like(c.CommodityName, "%name%"))
                        .ToList();
                }

                //“既没有给定类型又没有给定名称的情况”处理待讨论（也许是展示最新发布的？更高级：推荐游戏库的类型的别的游戏？）
            }
            return CommodityList;
        }
    }
}
