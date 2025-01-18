using FinalProje2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinalProje2.ViewComponents
{
    public class KategoriListeGetir: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            KategoriRepository kategoriDeposu = new KategoriRepository();
            var KategoriListe = kategoriDeposu.TList();
            return View(KategoriListe);
        }
    }
}
