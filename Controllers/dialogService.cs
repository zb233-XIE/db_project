using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TJ_Games.DBContext;
using TJ_Games.Models;
using TJ_Games.Models.ControllerModels;
namespace TJ_Games.Service
{
    public class DialogService
    {
        private readonly ModelContext _context;  //连接数据库
        public DialogService(ModelContext context)
        {
            _context = context;
        }
        public  List<ChatView> GetChatHistory(string UserID,string FriendID)
        {
            List<Dialog> tempList = new List<Dialog>();
            List<ChatView> chatHistory = new List<ChatView>();
            tempList =_context.Dialog.Where(c=>((c.SenderID==UserID&&c.ReceiverID==FriendID)||(c.SenderID==FriendID&&c.ReceiverID==UserID))).ToList();
            foreach(Dialog dialog in tempList)
            {
                ChatView newChat = new ChatView();
                newChat.SenderID=dialog.SenderID;
                newChat.ReceiverID=dialog.ReceiverID;
                newChat.Time = dialog.Time;
                newChat.content = dialog.content;
                chatHistory.Add(newChat);
            }
            return chatHistory;
        }
        public bool SaveChat(string UserID, string FriendID,string content)
        {
            DateTime dateTime = DateTime.Now;
            Dialog dialog = new Dialog();
            dialog.SenderID = UserID;
            dialog.ReceiverID = FriendID;
            dialog.Time = dateTime;
            dialog.content = content;
            _context.Dialog.Add(dialog);
            if (_context.SaveChanges() > 0)
                return true;
            else
                return false;
        }
    }
    
}
