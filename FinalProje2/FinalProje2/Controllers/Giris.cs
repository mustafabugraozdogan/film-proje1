using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using FinalProje2.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FinalProje2.Controllers
{
    public class Giris : Controller
    {
        FilmContext c = new FilmContext();


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Admin p)
        {
            var veri = c.Admins.FirstOrDefault(x=>x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);
            if(veri != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.KullaniciAdi)
                };
                var useridenty = new ClaimsIdentity(claims,"Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridenty);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Kategori");

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Giris");
        }
    }
}
