using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TJ_Games.Models
{
  public class Message
  {
        public string MessageID { get; set; }
        public string MessagTitle { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageTime { get; set; }
        public string ReceiverID { get; set; }
        public bool IsRead { get; set; }
        //属性列表

        public virtual Users Users { get; set; }
        //与本模型类相关的一些模型类
    }
}
