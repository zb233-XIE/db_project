using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
    public partial class Evaluation
    {
        public Evaluation()
        {
            Commodities = new Commodities();
            Users = new Users();
        }//构造函数

        public string CommodityID { get; set; }
        public string UserID { get; set; }
        public string Description { get; set; }
        public DateTime EvaluaionTime { get; set; }
        public string AdministratorID { get; set; }
        //属性列表

        public virtual Commodities Commodities { get; set; }
        public virtual Users Users { get; set; }

        public virtual Administrators Administrators { get; set; }
        //与本模型类相关的一些模型类
    }
}
