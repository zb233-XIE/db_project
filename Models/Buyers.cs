using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TJ_Games.Models
{
    public partial class Buyers
    {
        public Buyers()
        {
            Users = new Users();
        }//构造函数

        public string BuyerID { get; set;}
        public string BuyerName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Mail { get; set; }

        public virtual Users Users { get; set; }

        //与本模型类相关的一些模型类

    }
}
