using FinalProje2.Models;
using FinalProje2.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProje2.Controllers
{
    public class YorumController : Controller
    {
        YorumRepository yorumRepository = new YorumRepository();
        FilmContext c = new FilmContext();

        [Authorize]
        public IActionResult Index()
        {
            return View(yorumRepository.Plist("Film"));
        }
        public IActionResult YorumSil(int id)
        {
            yorumRepository.TSil(new Yorum { YorumId = id });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult YorumYap(int id) // Formu göstermek için ayrı bir action
        {
            ViewBag.FilmId = id; // Daha açıklayıcı bir isim
            return View();
        }

        [HttpPost] // CSRF koruması ekleyin
        public IActionResult YorumKaydet(Yorum y) // Yorumu kaydetmek için ayrı bir action
        {
                c.Yorumlar.Add(y);
                c.SaveChanges();

                // Başarılı gönderim sonrası yönlendirme
                return RedirectToAction("FilmDetay", "Filmler", new { id = y.FilmId }); // FilmDetay action'ına yönlendir
            
        }
    }
}
