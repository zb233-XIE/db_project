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
                Commodities newCommodity = _context.Commodity.FirstOrDefault(c => c.CommodityID == commodityId);
                Commodities newCommodityDetails = new Commodities();
                newCommodityDetails.CommodityID = commodityId;
                newCommodityDetails.CommodityName = newCommodity.CommodityName;
                newCommodityDetails.PublisherID = newCommodity.PublisherID;
                newCommodityDetails.Price = newCommodity.Price;
                newCommodityDetails.LowestPrice = newCommodity.LowestPrice;
                newCommodityDetails.PublishTime = newCommodity.PublishTime;
                newCommodityDetails.Classification = newCommodity.Classification;
                newCommodityDetails.Description = newCommodity.Description;
                newCommodityDetails.PictureURL = newCommodity.PictureURL;
                newCommodityDetails.DownLoadURL = newCommodity.DownLoadURL;
                newCommodityDetails.SalesVolume = newCommodity.SalesVolume;
                return newCommodityDetails;
            }
        }

        public List<Commodities> ShowShopCommodity()
        {
            List<Commodities> returnList = new List<Commodities>();
            DateTime current=DateTime.Now;
            List<Commodities> newList = _context.Commodity.Where(c => (c.PublishTime - current).Days<=7 ).ToList();
            int newlist_count = newList.Count;
            int max = 0;
            Commodities tmp=new Commodities();
            for(int i=0;i<newlist_count-1;i++)
            {
                max = i;
                for(int j=i+1;j<newlist_count;j++)
                {
                    if (newList[max].SalesVolume < newList[j].SalesVolume)
                    {
                        max = j;
                    }
                }
                if(max!=i)
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
        public List<Commodities> ShowNewCommodity()
        {
            List<Commodities> returnList = new List<Commodities>();
            DateTime current = DateTime.Now;
            List<Commodities> newList = _context.Commodity.Where(c => (c.PublishTime - current).Days <= 7).ToList();
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
            List<Commodities> newList = _context.Commodity.Where(c => (c.PublishTime - current).Days <= 30).ToList();
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
        public List<Commodities>? ShowCommodityClassification(string Classification)            //游戏分类
        {
            List<Commodities> returnList = new List<Commodities>();
            if (Classification == null)
                return null;
            else
            {
                returnList = _context.Commodity.Where(x => x.Classification==Classification).ToList();
                return returnList;
            }
        }

        /*public bool ShowCurrentActivity()                   //展示当前活动
        {
            return true;
        }*/
    }

}
