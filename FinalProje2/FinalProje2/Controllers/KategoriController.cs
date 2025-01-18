using FinalProje2.Repositories;
using Microsoft.AspNetCore.Mvc;
using FinalProje2.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalProje2.Controllers
{
    [Authorize]
    public class KategoriController : Controller
    {
        KategoriRepository kategoriRepository = new KategoriRepository();
        public IActionResult Index()
        {
            
            return View(kategoriRepository.TList());
        }
        [HttpGet]
        public IActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KategoriEkle(Kategori kat)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriEkle");
            }
            kategoriRepository.TEkle(kat);
            return View();
        }
        public IActionResult KategoriGetir(int id)
        {
            var x = kategoriRepository.TGetir(id);
            Kategori ct = new Kategori()
            {
                KategoriAd = x.KategoriAd,
                KategoriId = x.KategoriId,
            };
            return View(ct);
        }
        [HttpPost]
        public IActionResult KategoriGuncelle(Kategori p)
        {
            var x = kategoriRepository.TGetir(p.KategoriId);
            x.KategoriAd = p.KategoriAd;
            x.Durum = true;
            kategoriRepository.TGuncelle(x);
            return RedirectToAction("Index");
        }
        public IActionResult KategoriSil(int id)
        {
            kategoriRepository.TSil(new Kategori { KategoriId = id });
            return RedirectToAction("Index");
        }
    }
}
