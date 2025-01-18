using Microsoft.AspNetCore.Mvc;

namespace FinalProje2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult KategoriDetay(int id)
        {
            ViewBag.x = id;
            return View();
        }
        public IActionResult Hakkinda()
        {
            return View();
        }
    }
}
