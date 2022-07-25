using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TJ_Games.Models;
using TJ_Games.DBContext;

namespace TJ_Games.Services
{
    public class BuyerService 
    {
        private ModelContext _context;

        public Buyers EditBuyer(Buyers before, Buyers now)//修改个人信息，主码不允许修改！
        {
            string id = before.BuyerID;

            var buyer = Edit(id, now);

            return buyer;
        }


        public BuyerService(ModelContext context)
        {
            _context = context;
        }
        public List<Buyers> Index()
        {
            return _context.Buyers.ToList();
        }
        public Buyers SearchByID(string ID)
        {
            if (ID == null)
            {
                return null;
            }

            var buyer = _context.Buyers
                .FirstOrDefault(m => m.BuyerID == ID);
            if (buyer == null)
            {
                return null;
            }

            return buyer;
        }
        public Buyers Edit(string id)
        {
            if (id == null)
            {
                return null;
            }

            var buyer = _context.Buyers.Find(id);
            if (buyer == null)
            {
                return null;
            }
            return buyer;
        }
        public Buyers Edit(string id, [Bind("BuyerId,Mail,Passwd,Nickname,DateBirth,IdNumber")] Buyers buyer)
        {
            if (id != buyer.BuyerID)
            {
                return null;
            }

            try
            {
                _context.Update(buyer);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyerExists(buyer.Mail))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return buyer;
        }
        public bool BuyerExists(string Mail)
        {
            return _context.Buyers.Any(e => e.Mail == Mail);
        }
    }
}
