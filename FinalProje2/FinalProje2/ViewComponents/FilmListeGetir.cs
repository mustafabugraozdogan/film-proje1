using FinalProje2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinalProje2.ViewComponents
{
    public class FilmListeGetir:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FilmRepository filmDeposu = new FilmRepository();
            var filmliste = filmDeposu.Tlist("Kategori");
            return View(filmliste);
        }
    }
}
