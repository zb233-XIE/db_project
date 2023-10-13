using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TJ_Games.Models;
using TJ_Games.Models.BusinessEntity;
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

        /*public Goods SearchCommodity(string name, int type)
        {
            Goods goods = new Goods();

            Commodities commodities = _context.Commodities.Where(x => x.CommodityName == name).FirstOrDefault();
            goods.PictureURL = commodities.PictureURL;
            goods.description = commodities.Description;
            goods.CommodityName = commodities.CommodityName;
            goods.CommodityID=commodities.CommodityID;

            Commodity_Genre commodity_Genre = _context.Commodity_Genre.Where(x => x.CommodityID == goods.CommodityID).FirstOrDefault();
            Genre genre=_context.Genre.Where(x=>x.ID==commodity_Genre.GenreID).FirstOrDefault();
            goods.type = genre.Type;

          /*  if (type == 1)//直接模糊匹配游戏
            {
                if (name != String.Empty)
                {
                  //List<Commodities> CommodityList = new List<Commodities>();
                    Commodities commodities = _context.Commodities.Where(x => x.CommodityName == name).FirstOrDefault();

                    //foreach (var item in CommodityList)//对于每一个游戏
                    {
                        List<Commodity_Genre> commodity_genre = new List<Commodity_Genre>();

                        commodity_genre = _context.Commodity_Genre//搜索该游戏对应的所有类型的ID
                            .Where(x => x.CommodityID == item.CommodityID)
                            .ToList();

                        List<Genre> genrelist = new List<Genre>();
                        List<string> gametype = new List<string>();

                        foreach (var v in commodity_genre)//对于游戏的所有ID
                        {
                            Genre genre = new Genre();
                            genre = _context.Genre.Where(x => x.ID == v.GenreID).FirstOrDefault();//搜索游戏的类型（字符串）
                            gametype.Add(genre.Type);
                        }

                        Goods TBA = new Goods
                        {
                            CommodityID = item.CommodityID,
                            CommodityName = item.CommodityName,
                            type = gametype,
                            PictureURL = item.PictureURL,
                            description = item.Description
                        };
                        result.Add(TBA);
                    }
                }
            }
            else//模糊匹配发行商的名字，然后返回发行商对应的游戏
            {
                if (name != String.Empty)
                {
                    List<Publishers> publisherlist = new List<Publishers>();

                    publisherlist = _context.Publishers
                        .Where(c => EF.Functions.Like(c.PublisherName, "%name%"))
                        .ToList();
                    //模糊匹配发行商的名字

                    List<Commodities> Commoditylist = new List<Commodities>();

                    foreach (var v in publisherlist)//对于每一个发行商
                    {
                        string id = v.PublisherID;
                        List<Commodities> publisher_game = _context.Commodities.Where(x => x.PublisherID == id).ToList();
                        //查找该发行商发布的所有游戏

                        foreach (var item in publisher_game)//对于每一个游戏
                        {
                            List<Commodity_Genre> commodity_genre = new List<Commodity_Genre>();

                            commodity_genre = _context.Commodity_Genre//搜索该游戏对应的所有类型的ID
                                .Where(x => x.CommodityID == item.CommodityID)
                                .ToList();

                            List<Genre> genrelist = new List<Genre>();
                            List<string> gametype = new List<string>();
                            
                            foreach (var v1 in commodity_genre)//对于游戏的所有ID
                            {
                                Genre genre = new Genre();
                                genre = _context.Genre.Where(x => x.ID == v1.GenreID).FirstOrDefault();//搜索游戏的类型（字符串）
                                gametype.Add(genre.Type);
                            }

                            Goods TBA = new Goods
                            {
                                CommodityID = item.CommodityID,
                                CommodityName = item.CommodityName,
                                type = gametype,
                                PictureURL = item.PictureURL,
                                description = item.Description
                            };
                            result.Add(TBA);
                        }
                    }
                }
            }*/
        /*return goods;
    }*/
        public List<Goods> SearchCommodity(string name, int type)
        {
            List<Goods> result = new List<Goods>();
            name = name + "%"; name = "%" + name;
            if (type == 1)//直接模糊匹配游戏
            {
                if (name != String.Empty)
                {
                    List<Commodities> CommodityList = new List<Commodities>();

                    Console.WriteLine(name);
                    CommodityList = _context.Commodities
                        .Where(c => EF.Functions.Like(c.CommodityName, name))
                        .ToList();

                    foreach (var item in CommodityList)//对于每一个游戏
                    {
                        List<Commodity_Genre> commodity_genre = new List<Commodity_Genre>();

                        commodity_genre = _context.Commodity_Genre//搜索该游戏对应的所有类型的ID
                            .Where(x => x.CommodityID == item.CommodityID)
                            .ToList();

                        List<Genre> genrelist = new List<Genre>();
                        List<string> gametype = new List<string>();

                        foreach (var v in commodity_genre)//对于游戏的所有ID
                        {
                            Genre genre = new Genre();
                            genre = _context.Genre.Where(x => x.ID == v.GenreID).FirstOrDefault();//搜索游戏的类型（字符串）
                            gametype.Add(genre.Type);
                        }

                        Goods TBA = new Goods
                        {
                            CommodityID = item.CommodityID,
                            CommodityName = item.CommodityName,
                            type = gametype,
                            PictureURL = item.PictureURL,
                            description = item.Description
                        };
                        result.Add(TBA);
                    }
                }
            }
            else//模糊匹配发行商的名字，然后返回发行商对应的游戏
            {
                if (name != String.Empty)
                {
                    List<Publishers> publisherlist = new List<Publishers>();

                    publisherlist = _context.Publishers
                        .Where(c => EF.Functions.Like(c.PublisherName, name))
                        .ToList();
                    //模糊匹配发行商的名字

                    List<Commodities> Commoditylist = new List<Commodities>();

                    foreach (var v in publisherlist)//对于每一个发行商
                    {
                        string id = v.PublisherID;
                        List<Commodities> publisher_game = _context.Commodities.Where(x => x.PublisherID == id).ToList();
                        //查找该发行商发布的所有游戏

                        foreach (var item in publisher_game)//对于每一个游戏
                        {
                            List<Commodity_Genre> commodity_genre = new List<Commodity_Genre>();

                            commodity_genre = _context.Commodity_Genre//搜索该游戏对应的所有类型的ID
                                .Where(x => x.CommodityID == item.CommodityID)
                                .ToList();

                            List<Genre> genrelist = new List<Genre>();
                            List<string> gametype = new List<string>();

                            foreach (var v1 in commodity_genre)//对于游戏的所有ID
                            {
                                Genre genre = new Genre();
                                genre = _context.Genre.Where(x => x.ID == v1.GenreID).FirstOrDefault();//搜索游戏的类型（字符串）
                                gametype.Add(genre.Type);
                            }

                            Goods TBA = new Goods
                            {
                                CommodityID = item.CommodityID,
                                CommodityName = item.CommodityName,
                                type = gametype,
                                PictureURL = item.PictureURL,
                                description = item.Description
                            };
                            result.Add(TBA);
                        }
                    }
                }
            }
            return result;
        }
    }
}
