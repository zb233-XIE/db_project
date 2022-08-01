using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using LitJson;
using AutoMapper;
using System.Text.Encodings.Web;

namespace test456465.Controllers
{
    public class talkController : Controller
    {
        public IActionResult talk()
        {
            string value = Request.QueryString.ToString();
            value = value.Replace("?", "");
            ViewData["name"] = value;
            return View();
        }
        [HttpPost]
        public IActionResult liaotian([FromBody] Object ID)
        {
            string a = ID.ToString();
            a = a.Replace("{", "");
            a = a.Replace("}", "");
            a = a.Replace(":", "");
            int index = a.IndexOf("ID");
            a = a.Substring(index + 3, a.Length - index - 3);
            a = a.Replace('"', ' ');
            a.Trim();
            
            return Json(a);

        }
        [HttpPost]
        public IActionResult fasong([FromBody] Object ID)
        {
            string a = ID.ToString();
            a = a.Replace("{", "");
            a = a.Replace("}", "");
            a = a.Replace(":", "");
            int index = a.IndexOf("words");
            a = a.Substring(index + 3, a.Length - index - 3);
            a = a.Replace('"', ' ');
            a.Trim();
            return Json(a);

        }
    }
}
