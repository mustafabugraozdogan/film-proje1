using FinalProje2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinalProje2.ViewComponents
{
    public class KategoriyeGoreFilm:ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            FilmRepository filmDeposu = new FilmRepository();
            var filmliste = filmDeposu.List(x => x.KategoriId == id);
            return View(filmliste);
        }
    }
}
