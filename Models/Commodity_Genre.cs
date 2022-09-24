using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
    public class Commodity_Genre
    {
        public string CommodityID { get; set; }
        public string GenreID { get; set; }

        public virtual Commodities Commodities { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
