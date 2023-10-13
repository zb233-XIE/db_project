using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
    public class Dialog
    {
        public string SenderID { get; set; }
        public string ReceiverID { get; set; }
        public DateTime Time { get; set; }       
        public string content { get; set; }

        public virtual Users Users { get; set; }
    }
}