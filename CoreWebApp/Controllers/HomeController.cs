using Microsoft.AspNetCore.Mvc;

namespace CoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error()
        {
            string message = "";
            return View(message);
        }
    }
}
