using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
    public partial class Administrators
    {
        public Administrators()
        {

        }//构造函数

        public string AdminID { get; set; }
        public string AdminName { get; set; }
        public string Department { get; set; }
        //属性列表

        public virtual ICollection<Evaluation> Evaluation { get; set; }
        //与本模型类相关的一些模型类
    }
}
