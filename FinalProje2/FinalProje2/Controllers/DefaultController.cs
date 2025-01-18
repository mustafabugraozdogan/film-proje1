using FinalProje2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProje2.Controllers
{
    public class DefaultController : Controller
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
    }
}
