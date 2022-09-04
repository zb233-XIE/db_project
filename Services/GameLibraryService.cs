using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TJ_Games.DBContext;
using TJ_Games.Models;
using TJ_Games.Models.ControllerModels;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System;
using System.Linq;

namespace TJ_Games.Services
{
    public class GameLibraryService 
    {

        // 构造函数
        private readonly ModelContext _context;

        public GameLibraryService(ModelContext context)
        {
            _context = context;
        }
        public List<Commodity2> GetCommodityInfo(string p_id)
        {
            List<GameLibrary> gameList;    //用来存放查找结果

            gameList = _context.GameLibrary.Where(x => x.ID == p_id).ToList();

            List<Commodity2> mygameList=new List<Commodity2>();
            //mygameList.Add()
            for (int i = 0; i < gameList.Count; i++)
            {
                Commodities tmp_commdities;
                 tmp_commdities= _context.Commodities
                   .Where(c => c.CommodityID == gameList[i].CommodityID).FirstOrDefault();
                Commodity_Genre commodity_Genre = _context.Commodity_Genre.Where(x => x.CommodityID == gameList[i].CommodityID).FirstOrDefault();
                Genre genre = _context.Genre.Where(x => x.ID == commodity_Genre.GenreID).FirstOrDefault();
                Commodity2 commodity2 = new Commodity2();
                commodity2.CommodityID=tmp_commdities.CommodityID;
                commodity2.CommodityName = tmp_commdities.CommodityName;
                commodity2.PictureURL = tmp_commdities.PictureURL;
                commodity2.Description = tmp_commdities.Description;
                commodity2.Commodity_Genre = genre.Type;
                mygameList.Add(commodity2);
            }
            //     gameList[0].CommodityID;
            int a = 1;
            return mygameList;
        }
        public bool InLibrary(string ID, List<string> GameID)
        {
            List<GameLibrary> GL = _context.GameLibrary.Where(x => x.ID == ID).ToList();
            List<string> GLST = new List<string>();
            foreach (var v in GL)
            {
                GLST.Add(v.CommodityID);
            }
            bool flag = GLST.Intersect(GameID).Any();
            if (flag) return true;
            return false;
        }
        public int AddGame(string id,string GameID)
        {
            GameLibrary gameLibrary = _context.GameLibrary.Where(x => x.CommodityID == GameID && x.ID == id).FirstOrDefault();

            if(gameLibrary != null)//说明此时该人已有该游戏
            {
                return -1;
            }
            GameLibrary GL = new GameLibrary
            {
                ID = id,
                CommodityID = GameID,
                PurchaseTime = DateTime.Now,
                GameTime = "0"
            };
            _context.GameLibrary.Add(GL);

            if (_context.SaveChanges() > 0)
                return 1;
            else
                return 0;
        }


    }
}
