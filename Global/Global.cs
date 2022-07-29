using Microsoft.AspNetCore.Mvc;

namespace TJ_Project.Global
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
