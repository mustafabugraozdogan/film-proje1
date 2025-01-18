using FinalProje2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProje2.Controllers
{
    public class RastgeleFilm : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        FilmContext c => new FilmContext();
        public IActionResult RandomFilm(int id)
        {
            var filmler = c.Filmler.ToList();
            if (filmler.Count == 0)
            {
                return NotFound("film yok");
            }
            Random rnd = new Random();
            int index = rnd.Next(0,filmler.Count);
            var rastgelefilm = filmler[index];
            
            return View(rastgelefilm);
        }
    }
}
