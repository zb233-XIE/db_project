using TJ_Games.Models.BusinessEntity;
using TJ_Games.DBContext;
using TJ_Games.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//此功能尚未被应用，可能其他控制器已经有使用，该部分需要完善
namespace TJ_Games.Services
{
    // 构造函数
    public class OrderService
    {
        // 构造函数
        private readonly ModelContext _context;

        public OrderService(ModelContext context)
        {
            _context = context;
        }

    }
}