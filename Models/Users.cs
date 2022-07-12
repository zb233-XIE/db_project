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
            Publishers = new Publishers();
            Administrators = new Administrators();
            Wishlist = new HashSet<Wishlist>();
            ShoppingCart = new HashSet<ShoppingCart>();
            GameLibrary = new HashSet<GameLibrary>();
            Message = new HashSet<Message>();
            Orders = new HashSet<Orders>();
            Evaluation = new HashSet<Evaluation>();
            Friends = new HashSet<Friends>();
        }//构造函数

        public string UserID { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        //属性列表

        public virtual Buyers Buyers { get; set; }
        public virtual Publishers Publishers { get; set; }
        public virtual Administrators Administrators { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
        public virtual ICollection<GameLibrary> GameLibrary { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Evaluation> Evaluation { get; set; }
        public virtual ICollection<Friends> Friends { get; set; }
        //与本模型类相关的一些模型类
    }
}
