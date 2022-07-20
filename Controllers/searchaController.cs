using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace test456465.Controllers
{
    public class searchaController : Controller
    {
       
        public IActionResult search()
        { 
            return View();
        }
    }
}
