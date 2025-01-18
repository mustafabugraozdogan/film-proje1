using FinalProje2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProje2.Controllers
{
    [Authorize]
    public class İstatistikler : Controller
    {
        FilmContext c = new FilmContext();
        
        public IActionResult Index()
        {
            var toplamfilm = c.Filmler.Count();
            var toplamkategori = c.Kategoriler.Count();
            var toplamyorum = c.Yorumlar.Count();
            var enYuksekPuanliFilm = c.Filmler.OrderByDescending(f => f.FilmPuan).FirstOrDefault();
            ViewBag.FilmAdi = enYuksekPuanliFilm.FilmAd;
            ViewBag.ImdbPuani = enYuksekPuanliFilm?.FilmPuan;

            var enCokYorumAlanFilm = c.Yorumlar.GroupBy(y => y.Film).OrderByDescending(g => g.Count()).Select(g => new { Film = g.Key, YorumSayisi = g.Count() }).FirstOrDefault();
            var enCokFilmOlanKategori = c.Filmler.GroupBy(f => f.Kategori).OrderByDescending(g => g.Count()).Select(g => new { Kategori = g.Key, FilmSayisi = g.Count() }).FirstOrDefault();


            ViewBag.EnCokYorumAlanFilm = enCokYorumAlanFilm.Film.FilmAd; 
            ViewBag.YorumSayisi = enCokYorumAlanFilm.YorumSayisi;
            ViewBag.EnCokFilmOlanKategori = enCokFilmOlanKategori.Kategori.KategoriAd;
            ViewBag.FilmSayisi = enCokFilmOlanKategori.FilmSayisi;
            ViewBag.Toplamfilm = toplamfilm;
            ViewBag.Toplamkategori = toplamkategori;
            ViewBag.toplamyorum = toplamyorum;
            return View();
        }
    }
}
