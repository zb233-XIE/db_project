using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
    public class Genre
    {
        public Genre()
        {
            Commodity_Genre = new HashSet<Commodity_Genre>();
        }//构造函数

        public string ID { get;set; }
        public string Type { get; set; }

        public virtual ICollection<Commodity_Genre> Commodity_Genre { get; set; }
        //相关模型类
    }
}
