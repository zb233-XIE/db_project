using Microsoft.AspNetCore.Mvc;
using TJ_Games.DBContext;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdParty.Json.LitJson;
using TJ_Games.Service;
using TJ_Games.Models;
using TJ_Games.Models.ControllerModels;

namespace TJ_Project.Controllers
{
    public class talkController : Controller
    {
        private readonly ModelContext _context;   //数据库上下文
        private DialogService dialogService;             //后端service
        public talkController(ModelContext context)
        {
            _context = context;
            dialogService = new DialogService(_context);
        }

        public IActionResult talk()
        {
            //if (Request.Cookies["buyerNickName"] != null)
            //{
                return View();
            //}
            /*else
            {
                return Redirect("/Entry/BuyerLogIn");
            }*/
        }
        [HttpPost]
        public IActionResult GetChatHistory([FromBody] Object h)
        {
            string a = h.ToString();
            a = a.Substring(13, 11);
            a.Trim();//a是friendid
            string b = h.ToString();
            b = b.Substring(36, 11);
            b.Trim();//b是userID
            string UserID = b;
            string FriendID = a;
            List<ChatView> DialogList = new List<ChatView>();
            DialogList = dialogService.GetChatHistory(UserID, FriendID);
            List<string> Sender_ID = new List<string>();
            List<string> Receiver_ID = new List<string>();
            List<DateTime> time = new List<DateTime>();
            List<string> content=new List<string>();
            for(int i = 0; i < DialogList.Count; i++)
            {
                Sender_ID.Add(DialogList[i].SenderID);
                Receiver_ID.Add(DialogList[i].ReceiverID);
                time.Add(DialogList[i].Time);
                content.Add(DialogList[i].content);
            }
            var data = new
            {
                SenderID=Sender_ID,
                ReceiverID=Receiver_ID,
                Time=time,
                text=content
            };
            var jsonstr = JsonConvert.SerializeObject(data);
            return Content(jsonstr);
        }
        [HttpPost]
        public IActionResult liaotian([FromBody] Object ID)
        {
            string a = ID.ToString();
         //   a = a.Replace("{", "");
          //  a = a.Replace("}", "");
          //  a = a.Replace(":", "");
          //  int index = a.IndexOf("ID");
         //   a = a.Substring(index + 3, a.Length - index - 3);
           // a = a.Replace('"', ' ');
            a.Trim();

            return Json(a);

        }
        [HttpPost]
        public IActionResult SaveChat([FromBody] Object h)
        {
            string a = h.ToString();
            a = a.Substring(13, 11);
            a.Trim();//a是friendid
            string b = h.ToString();
            b = b.Substring(36, 11);
            b.Trim();//b是userID
            string c=h.ToString();
            int index = c.IndexOf('C');
            c = c.Substring(index + 10, c.Length - index - 12);
            string FriendID = a;
            string UserID = b;
            string Content = c;
            if (dialogService.SaveChat(UserID, FriendID, Content))
            {
                JsonData jsondata = new JsonData();
                jsondata["SaveChat"] = "SUCESS";
                return Json(jsondata.ToJson());
            }
            else
            {
                JsonData jsondata = new JsonData();
                jsondata["SaveChat"] = "ERROR";
                return Json(jsondata.ToJson());
            }
        
        }      
    }
}
