using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TJ_Games.DBContext;
using TJ_Games.Models;
using TJ_Games.Models.ControllerModels;
namespace TJ_Games.Service
{
    public class ShopService
    {
        private readonly ModelContext _context;
        public ShopService(ModelContext context)
        {
            _context = context;
        }
        public  Good GetCommodityDetail(string commodityId)
        {
            if (commodityId == "")
                return null;
            else
            {
                Commodities commodity = _context.Commodities.FirstOrDefault(c => c.CommodityID == commodityId);
                Good newgood = new Good();
                newgood.ID = commodity.CommodityID;
                newgood.Name = commodity.CommodityName;
                newgood.PublisherID = commodity.PublisherID;
                newgood.Price = commodity.Price;
                newgood.LowestPrice = commodity.LowestPrice;
                newgood.PublishTime = commodity.PublishTime;
                newgood.Description = commodity.Description;
                newgood.PictureURL = commodity.PictureURL;
                newgood.DownLoadURL = commodity.DownLoadURL;
                newgood.SalesVolume = commodity.SalesVolume;
                return newgood;
            }
        }

        public List<Good> ShowShopCommodity()
        {
            List<Commodities> tempList = new List<Commodities>();
            List<Good> returnList = new List<Good>();
            DateTime current = DateTime.Now;
            List<Commodities> newList1 = _context.Commodities.ToList();
            List<Commodities> newList=new List<Commodities>();
            foreach (Commodities commodity in newList1)
            {
                TimeSpan span = current - commodity.PublishTime;
                string str1=span.TotalDays.ToString();
                decimal decnumber=Convert.ToDecimal(str1);
                if (decnumber <= 30)
                   newList.Add(commodity);
            }
            int newlist_count = newList.Count;
            Commodities tmp = new Commodities();
            for (int i = 0; i < newlist_count - 1; i++)     //双层循环
                for (int j = 0; j < newlist_count - 1 - i; j++)
                {
                    if (newList[j].SalesVolume < newList[j + 1].SalesVolume)
                    {
                        tmp = newList[j];
                        newList[j] = newList[j+1];
                        newList[j+1]=tmp;
                    }
                }
            for (int i = 0; i < 5; i++)
            {
                Commodities newCommodityDetails = new Commodities();
                newCommodityDetails = newList[i];
                tempList.Add(newCommodityDetails);
            }
            foreach (Commodities commodity in tempList)
            {
                Good newgood = new Good();
                newgood.ID = commodity.CommodityID;
                newgood.Name = commodity.CommodityName;
                newgood.PublisherID = commodity.PublisherID;
                newgood.Price = commodity.Price;
                newgood.LowestPrice = commodity.LowestPrice;
                newgood.PublishTime = commodity.PublishTime;
                newgood.Description = commodity.Description;
                newgood.PictureURL = commodity.PictureURL;
                newgood.DownLoadURL = commodity.DownLoadURL;
                newgood.SalesVolume = commodity.SalesVolume;
                returnList.Add(newgood);
            }
            return returnList;
        }
        public List<Good> ShowNewCommodity()
        {
            const int LENGTH = 10;


            List<Commodities> tempList = new List<Commodities>();
            List<Good> returnList = new List<Good>();
            DateTime current = DateTime.Now;
            List<Commodities> newList1 = _context.Commodities.ToList();
            List<Commodities> newList = new List<Commodities>();
            foreach (Commodities commodity in newList1)
            {
                TimeSpan span = current - commodity.PublishTime;
                string str1 = span.TotalDays.ToString();
                decimal decnumber = Convert.ToDecimal(str1);
                if (decnumber <= 14)
                    newList.Add(commodity);
            }
            int newlist_count = newList.Count;
            Commodities tmp = new Commodities();
            for (int i = 0; i < newlist_count - 1; i++)     //双层循环
                for (int j = 0; j < newlist_count - 1 - i; j++)
                {
                    if (newList[j].SalesVolume < newList[j + 1].SalesVolume)
                    {
                        tmp = newList[j];
                        newList[j] = newList[j + 1];
                        newList[j + 1] = tmp;
                    }
                }
            for (int i = 0; i < LENGTH; i++)
            {
                Commodities newCommodityDetails = new Commodities();
                newCommodityDetails = newList[i];
                tempList.Add(newCommodityDetails);
            }
            foreach (Commodities commodity in tempList)
            {
                Good newgood = new Good();
                newgood.ID = commodity.CommodityID;
                newgood.Name = commodity.CommodityName;
                newgood.PublisherID = commodity.PublisherID;
                newgood.Price = commodity.Price;
                newgood.LowestPrice = commodity.LowestPrice;
                newgood.PublishTime = commodity.PublishTime;
                newgood.Description = commodity.Description;
                newgood.PictureURL = commodity.PictureURL;
                newgood.DownLoadURL = commodity.DownLoadURL;
                newgood.SalesVolume = commodity.SalesVolume;
                returnList.Add(newgood);
            }
            return returnList;
        }

        public List<Good> ShowHotCommodity()
        {
            const int LENGTH = 10;

            List<Commodities> tempList = new List<Commodities>();
            List<Good> returnList = new List<Good>();
            DateTime current = DateTime.Now;
            List<Commodities> newList1 = _context.Commodities.ToList();
            List<Commodities> newList = new List<Commodities>();
            foreach (Commodities commodity in newList1)
            {
                TimeSpan span = current - commodity.PublishTime;
                string str1 = span.TotalDays.ToString();
                decimal decnumber = Convert.ToDecimal(str1);
                if (decnumber <= 90)
                    newList.Add(commodity);
            }
            int newlist_count = newList.Count;
            Commodities tmp = new Commodities();
            for (int i = 0; i < newlist_count - 1; i++)     //双层循环
                for (int j = 0; j < newlist_count - 1 - i; j++)
                {
                    if (newList[j].SalesVolume < newList[j + 1].SalesVolume)
                    {
                        tmp = newList[j];
                        newList[j] = newList[j + 1];
                        newList[j + 1] = tmp;
                    }
                }
            for (int i = 0; i < LENGTH; i++)
            {
                Commodities newCommodityDetails = new Commodities();
                newCommodityDetails = newList[i];
                tempList.Add(newCommodityDetails);
            }
            foreach (Commodities commodity in tempList)
            {
                Good newgood = new Good();
                newgood.ID = commodity.CommodityID;
                newgood.Name = commodity.CommodityName;
                newgood.PublisherID = commodity.PublisherID;
                newgood.Price = commodity.Price;
                newgood.LowestPrice = commodity.LowestPrice;
                newgood.PublishTime = commodity.PublishTime;
                newgood.Description = commodity.Description;
                newgood.PictureURL = commodity.PictureURL;
                newgood.DownLoadURL = commodity.DownLoadURL;
                newgood.SalesVolume = commodity.SalesVolume;
                returnList.Add(newgood);
            }
            return returnList;
        }
        public List<Good>? ShowCommodityClassification(string genreid)            //游戏分类
        {
            List<Commodity_Genre> commodities = new List<Commodity_Genre>();
            List<Commodities> tempList = new List<Commodities>();
            List<Good> returnList = new List<Good>();
            if (genreid == null)
                return null;
            else
            {
                commodities = _context.Commodity_Genre.Where(x => x.GenreID == genreid).ToList();
                foreach(Commodity_Genre element in commodities)
                {
                    Commodities commodity = new Commodities();
                    commodity = _context.Commodities.Where(x => x.CommodityID == element.CommodityID).FirstOrDefault();
                    tempList.Add(commodity);
                }
                foreach(Commodities commodity in tempList)
                {
                    Good newgood=new Good();
                    newgood.ID = commodity.CommodityID;
                    newgood.Name = commodity.CommodityName;
                    newgood.PublisherID=commodity.PublisherID;
                    newgood.Price=commodity.Price;
                    newgood.LowestPrice = commodity.LowestPrice;
                    newgood.PublishTime = commodity.PublishTime;
                    newgood.Description = commodity.Description;
                    newgood.PictureURL=commodity.PictureURL;
                    newgood.DownLoadURL = commodity.DownLoadURL;
                    newgood.SalesVolume = commodity.SalesVolume;
                    returnList.Add(newgood);
                }
                return returnList;
            }
        }
    }

}
