using CV_3._1.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

namespace CV_3._1.Controllers
{
    public class loginController : Controller
    {
        Context db = new Context();
        public IActionResult loginpage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Admin p)
        {
            var bilgiler = db.admins.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Parola == p.Parola);
            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.KullaniciAdi)
                };
                //var useridentity = new ClaimsIdentity(claims, "Login");
                //ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                //await HttpContext.SignInAsync(principal);
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var autProperties = new AuthenticationProperties();
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
                    autProperties);

                return RedirectToAction("profil", "panelprofil");
            }
            return RedirectToAction("loginPage", "login");
        }
        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("loginPage", "login");
        }
    }
}
