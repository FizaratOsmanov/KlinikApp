using Microsoft.AspNetCore.Mvc;

namespace PL.Controlers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
