﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TJ_Games.Models;
using TJ_Games.DBContext;
using System.Text;
using System.Security.Cryptography;

namespace TJ_Games.Service
{
    public class PublishersService
    {
        private readonly ModelContext _context;

        /*------------------------------------------------------
         * PublishersService()
         * 构造函数
         * ---------------------------------------------------*/
        public PublishersService(ModelContext context)
        {
            _context = context;//数据库上下文初始化
        }
        /*------------------------------------------------------
         * 函数名：GetPubisherInfo()
         * 在Publisher表中查到Publisher的信息
         * 并以传回publisher类，以供下一部分运行
         * ---------------------------------------------------*/
        public Publishers GetPublisherInfo(string u_id)
        {
            Publishers publisher;
            publisher = _context.Publishers
                    .Where(c => c.PublisherID == u_id).FirstOrDefault();
            return publisher;
        }

        /*------------------------------------------------------
         * 函数名：GetCommodityInfo()
         * 在Commodity表中查到某一位发行商旗下游戏商品的信息
         * 并传回Commodity对象
         * ---------------------------------------------------*/
        public List<Commodities> GetCommodityInfo(string p_id)
        {
            List<Commodities> gameList;    //用来存放查找结果

            gameList = _context.Commodities
                    .Where(c => c.PublisherID == p_id).ToList();

            return gameList;
        }



        /*------------------------------------------------------
         * 函数名：PublishGame()
         * 发布游戏，在Commodities表中做添加处理
         * 返回值为true或者false，表示添加游戏成功或失败
         * ---------------------------------------------------*/
        public bool PublishGame(string c_id, string c_name, string p_id, double price, double l_price, DateTime p_time, string description, string p_URL, string D_URL)
        {
            Commodities commodity = new Commodities();
            Commodities result = _context.Commodities
                .Where(c => c.CommodityID == c_id).FirstOrDefault();
            if (result == null)
            {
                commodity.CommodityID = c_id;
                commodity.CommodityName = c_name;
                commodity.PublisherID = p_id;
                commodity.Price = price;
                commodity.LowestPrice = l_price;
                commodity.PublishTime = p_time;
                commodity.Description = description;
                commodity.PictureURL = p_URL;
                commodity.DownLoadURL = D_URL;
                commodity.SalesVolume = 0;

                _context.Commodities.Add(commodity);
                _context.SaveChanges();//保存更新
                return true;
            }
            return false;//本项目中不考虑存在两份一样的游戏
        }
        /*------------------------------------------------------
         * 函数名：AddUpdateInfo()
         * 添加游戏日志，在Updatelog表中做添加处理
         * 返回值为true或者false，表示添加更新日志成功或失败
         * ---------------------------------------------------*/
        public bool AddUpdate(string c_id, string v_number, DateTime u_time, string u_content)
        {
            Updatelog updatelog = new Updatelog();
            Updatelog result = _context.Updatelog
                .Where(c => c.CommodityID == c_id && c.VersionNumber == v_number).FirstOrDefault();//
            if (result == null)
            {
                updatelog.CommodityID = c_id;
                updatelog.VersionNumber = v_number;
                updatelog.UpdateTime = u_time;
                updatelog.Description = u_content;

                _context.Updatelog.Add(updatelog);
                _context.SaveChanges();//保存更新
                return true;
            }
            return false;//本项目中不考虑存在两份一样的游戏更新
        }
        /*------------------------------------------------------
        * 函数名：EditPublisher()
        * 根据输入的发行商信息，对在Publisher表做修改处理
        * 并传回Publisher对象
        * ---------------------------------------------------*/
        public bool EditPublisher(string p_id, string p_name, DateTime s_time, string dsc, string hmpurl)
        {
            Publishers publishers = new Publishers();
            Publishers result = _context.Publishers.Where(c => c.PublisherID == p_id).FirstOrDefault();
            if (result != null)
            {
                _context.Publishers.Remove(result);//首先删除

                publishers.PublisherID = p_id;//再重新添加
                publishers.PublisherName = p_name;
                publishers.StartTime = s_time;
                publishers.Description = dsc;
                publishers.HomepageURL = hmpurl;
                _context.Publishers.Add(publishers);
                _context.SaveChanges();//保存更新
                return true;
            }
            else
                return false;//没找到就无法修改
        }
    }
}
