using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TJ_Games.DBContext;
using TJ_Games.Models;
namespace TJ_Games.Service
{
    public class ShopService
    {
        private readonly ModelContext _context;
        public ShopService(ModelContext context)
        {
            _context = context;
        }
        public  Commodities? GetCommodityDetail(string commodityId)
        {
            if (commodityId == "")
                return null;
            else
            {
                Commodities newCommodity = _context.Commodities.FirstOrDefault(c => c.CommodityID == commodityId);
                Commodities newCommodityDetails = new Commodities();
                newCommodityDetails.CommodityID = commodityId;
                newCommodityDetails.CommodityName = newCommodity.CommodityName;
                newCommodityDetails.PublisherID = newCommodity.PublisherID;
                newCommodityDetails.Price = newCommodity.Price;
                newCommodityDetails.LowestPrice = newCommodity.LowestPrice;
                newCommodityDetails.PublishTime = newCommodity.PublishTime;
                newCommodityDetails.Description = newCommodity.Description;
                newCommodityDetails.PictureURL = newCommodity.PictureURL;
                newCommodityDetails.DownLoadURL = newCommodity.DownLoadURL;
                newCommodityDetails.SalesVolume = newCommodity.SalesVolume;
                return newCommodityDetails;
            }
        }

        public List<Commodities> ShowShopCommodity(bool flag=false, string buyerId = null)
        {
            List<Commodities> returnList = new List<Commodities>();
            DateTime current=DateTime.Now;
            if (flag == true)
            {
                List<Commodities> newList = _context.Commodities.Where(c => (c.PublishTime - current).Days <= 7).ToList();
                int newlist_count = newList.Count;
                int max = 0;
                Commodities tmp = new Commodities();
                for (int i = 0; i < newlist_count - 1; i++)
                {
                    max = i;
                    for (int j = i + 1; j < newlist_count; j++)
                    {
                        if (newList[max].SalesVolume < newList[j].SalesVolume)
                        {
                            max = j;
                        }
                    }
                    if (max != i)
                    {
                        tmp = newList[max];
                        newList[max] = newList[i];
                        newList[i] = tmp;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    Commodities newCommodityDetails = new Commodities();
                    newCommodityDetails = newList[i];
                    returnList.Add(newCommodityDetails);
                }
                return returnList;
            }
            else
            {
                return returnList;
            }
        }
        public List<Commodities> ShowNewCommodity()
        {
            List<Commodities> returnList = new List<Commodities>();
            DateTime current = DateTime.Now;
            List<Commodities> newList = _context.Commodities.Where(c => (c.PublishTime - current).Days <= 7).ToList();
            int newlist_count = newList.Count;
            int max = 0;
            Commodities tmp = new Commodities();
            for (int i = 0; i < newlist_count - 1; i++)
            {
                max = i;
                for (int j = i + 1; j < newlist_count; j++)
                {
                    if (newList[max].PublishTime< newList[j].PublishTime)
                    {
                        max = j;
                    }
                }
                if (max != i)
                {
                    tmp = newList[max];
                    newList[max] = newList[i];
                    newList[i] = tmp;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                Commodities newCommodityDetails = new Commodities();
                newCommodityDetails = newList[i];
                returnList.Add(newCommodityDetails);
            }
            return returnList;
        }

        public List<Commodities> ShowHotCommodity()
        {
            List<Commodities> returnList = new List<Commodities>();
            DateTime current = DateTime.Now;
            List<Commodities> newList = _context.Commodities.Where(c => (c.PublishTime - current).Days <= 30).ToList();
            int newlist_count = newList.Count;
            int max = 0;
            Commodities tmp = new Commodities();
            for (int i = 0; i < newlist_count - 1; i++)
            {
                max = i;
                for (int j = i + 1; j < newlist_count; j++)
                {
                    if (newList[max].SalesVolume < newList[j].SalesVolume)
                    {
                        max = j;
                    }
                }
                if (max != i)
                {
                    tmp = newList[max];
                    newList[max] = newList[i];
                    newList[i] = tmp;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                Commodities newCommodityDetails = new Commodities();
                newCommodityDetails = newList[i];
                returnList.Add(newCommodityDetails);
            }
            return returnList;
        }
        public string GetType(string Genre_ID)            //游戏分类
        {
            Genre genre = new Genre();
            if (Genre_ID == null)
                return null;
            else
            {
                genre = _context.Genre.Where(x => x.ID == Genre_ID).FirstOrDefault();
                return genre.Type;
            }
        }
        public List<Commodities>? ShowCommodityClassification(string Genre_ID)            //游戏分类
        {
            List<Commodity_Genre> commodities = new List<Commodity_Genre>();
            List<Commodities> returnList = new List<Commodities>();
            if (Genre_ID == null)
                return null;
            else
            {
                commodities= _context.Commodity_Genre.Where(x => x.GenreID == Genre_ID).ToList();
                foreach(Commodity_Genre element in commodities)
                {
                    Commodities commodity = new Commodities();
                    commodity = _context.Commodities.Where(x => x.CommodityID == element.CommodityID).FirstOrDefault();
                    returnList.Add(commodity);
                }
                return returnList;
            }
        }
    }

}
