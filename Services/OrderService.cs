using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TJ_Games.Models;
using TJ_Games.Models.BusinessEntity;
using TJ_Games.DBContext;

namespace TJ_Games.Services
{
    public class OrderService
    {
        private ModelContext _context;
        const int LENGTH = 12;
        Random rand;

        public OrderService(ModelContext context)
        {
            _context = context;
            rand = new Random();
        }

        public bool CreateOrder(string buyerID, string receiverID, Cart order)
        {
            if (string.IsNullOrEmpty(buyerID) || string.IsNullOrEmpty(receiverID) || order.items.Count() == 0)
            {
                return false;
            }
            else
            {
                Orders TBA = new Orders();
                string orderID = "";
                for (int i = 0; i < LENGTH; i++)
                {
                    orderID += (char)(rand.Next(1, 9) + '0');
                    //check
                }
                TBA.OrderID = orderID;
                TBA.BuyerID = buyerID;
                TBA.ReceiverID = receiverID;
                TBA.OrderCost = order.tot_money;
                TBA.OrderTime = DateTime.Now;

                _context.Orders.Add(TBA);

                foreach (var v in order.items)
                {
                    Order_Commodity tba = new Order_Commodity
                    {
                        OrderID = orderID,
                        CommodityID = v.CommodityID
                    };
                    _context.Order_Commmodity.Add(tba);
                }

                if (_context.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
        }
        //创建订单


    }
}
