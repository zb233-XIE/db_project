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
            Orders = new HashSet<Orders>();
            Wishlist = new HashSet<Wishlist>();
            Evaluation = new HashSet<Evaluation>();
            ShoppingCart = new HashSet<ShoppingCart>();
            GameLibrary = new HashSet<GameLibrary>();
        }

        public string BuyerID { get; set; }
        public string BuyerName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Mail { get; set; }

        public virtual Users Users { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
        public virtual ICollection<Evaluation> Evaluation { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
        public virtual ICollection<GameLibrary> GameLibrary { get; set; }
        //与本模型类相关的一些模型类

    }
}
