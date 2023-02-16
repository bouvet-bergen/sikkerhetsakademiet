using Microsoft.AspNetCore.Mvc;

namespace Sikkerhetsakademiet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Pages/Home/Index.cshtml");
        }
    }
}
