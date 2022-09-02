using TJ_Games.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games
{
  public static class Global
  {
    public static string GSearchName = "";
    //初值设定为debug需求
    //搜索框内的文字

    public static List<string> GClassification = new List<string> { "类魂" };
    //初值设定为debug需求
    //在主页搜索框点击搜索后会跳转到搜索页面，搜索页面内提供一些选项来缩小范围
    //比如游戏类型（具体见steam）

    public static Cart GCart;
    //购物车中提交至订单确认页面的商品

    public static string GToWhom;
    // 1:为自己购买  2:为他人购买
  }
}
