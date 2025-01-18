using FinalProje2.Models;
using FinalProje2.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalProje2.Controllers
{
    
    public class FilmController : Controller
    {
        FilmRepository filmDepo = new FilmRepository();

        FilmContext c = new FilmContext();

        [Authorize]
        public IActionResult Index()
        {
            
            return View(filmDepo.Tlist("Kategori"));
        }
        [Authorize]
        [HttpGet]
        public IActionResult FilmEkle()
        {
            List<SelectListItem> values = (from x in c.Kategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult FilmEkle(resimekle p)
        {
            Film f = new Film();
            if (p.Afis != null)
            {
                var extension = Path.GetExtension(p.Afis.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/img/",newimagename);
                var stream = new FileStream(location,FileMode.Create);
                p.Afis.CopyTo(stream);
                f.Afis = newimagename;
            }
            f.FilmAd = p.FilmAd;
            f.FilmPuan = p.FilmPuan;
            f.Detay = p.Detay;
            f.KategoriId = p.KategoriId;
            f.Yil = p.Yil;
            filmDepo.TEkle(f);
            return RedirectToAction("Index");
        }
        public IActionResult FilmSil(int id)
        {
            filmDepo.TSil(new Film { FilmId = id});
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult FilmGetir(int id)
        {
            var x = filmDepo.TGetir(id);
            List<SelectListItem> values = (from y in c.Kategoriler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.KategoriAd,
                                               Value = y.KategoriId.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            Film f = new Film()
            {
                FilmId = x.FilmId,
                KategoriId = x.KategoriId,
                FilmAd = x.FilmAd,
                FilmPuan = x.FilmPuan,
                Detay = x.Detay,
                Afis = x.Afis,
                Yil = x.Yil,
            };
            return View(f);
        }
        [Authorize]
        [HttpPost]
        public IActionResult FilmGuncelle(Film p)
        {
            var x = filmDepo.TGetir(p.FilmId);
            x.FilmAd = p.FilmAd;
            x.FilmPuan = p.FilmPuan;
            x.KategoriId = p.KategoriId;
            x.Detay = p.Detay;
            x.Afis = p.Afis;
            x.Yil = p.Yil;
            filmDepo.TGuncelle(x);
            return RedirectToAction("Index");
        }
        FilmYorum fy = new FilmYorum();

        [HttpGet]
        public IActionResult FilmDetay(int id)
        {
            var film = c.Filmler.Include(f => f.Kategori).FirstOrDefault(f => f.FilmId == id);
            //var filmbul = c.Filmler.Where(x => x.FilmId == id).ToList();
            fy.Deger1 = c.Filmler.Where(x => x.FilmId == id).ToList();
            fy.Deger2 = c.Yorumlar.Where(x=>x.FilmId == id).ToList();
            ViewBag.FilmKategoriAdi = film.Kategori.KategoriAd;
            return View(fy);
        }
        
        [HttpPost]
        public IActionResult FilmDetay(Yorum y)
        {

            c.Yorumlar.Add(y);
            c.SaveChanges();
            return RedirectToAction("FilmDetay");
        }
    }
}
