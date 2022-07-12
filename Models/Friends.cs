using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
  public class Friends
  {
        public Friends()
        {
            Users = new Users();
        }//构造函数

        public string UserID { get; set; }
        public string FriendID { get; set; }
        //属性列表

        public virtual Users Users { get; set; }
        //与本模型类相关的一些模型类
    }
}
