using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
    public partial class Users
    {
        public Users()
        {
            Buyers = new Buyers();
            Administrators = new Administrators();
            Publishers = new Publishers();
            Message = new HashSet<Message>();
        }//构造函数

        public string UserID { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        //属性列表

        public virtual Buyers Buyers { get; set; }
        public virtual Administrators Administrators { get; set; }
        public virtual Publishers Publishers { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        //与本模型类相关的一些模型类
    }
}
