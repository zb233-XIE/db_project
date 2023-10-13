using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
    public  class Publishers
    {
        public Publishers()
        {
            Commodities = new HashSet<Commodities>();

        }//构造函数

        public string PublisherID { get; set; }
        public string PublisherName { get; set; }
        public DateTime? StartTime { get; set; }
        public string? Description { get; set; }
        public string? HomepageURL { get; set; }
        //属性列表

        public virtual ICollection<Commodities> Commodities { get; set; }
        public virtual Users Users { get; set; }
        //与本模型类相关的一些模型类

    }
}
