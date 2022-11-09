using CV_3._1.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace CV_3._1.Controllers
{
    [Authorize]
    public class panelprofilController : Controller
    {
        Context db = new Context();
        public IActionResult profil()
        {
            var values = db.panelProfils.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult profilAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult profilAdd(PanelProfil profil)
        {
            if (profil.ProfilDosya != null)
            {
                var extension = Path.GetExtension(profil.ProfilDosya.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/images/Profil_images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                profil.ProfilDosya.CopyTo(stream);
                profil.ProfilResmi = newimagename;
            }
            db.panelProfils.Add(profil);
            db.SaveChanges();
            return RedirectToAction("profil");
        }
        [HttpGet]
        public IActionResult profilGet(int Id)
        {
            var pp_get = db.panelProfils.SingleOrDefault(x => x.Id == Id);
            return View(pp_get);
        }
        [HttpPost]
        public IActionResult profilUpdate(PanelProfil p)
        {
            var pp_update = db.panelProfils.SingleOrDefault(x => x.Id == p.Id);
            if (p.ProfilDosya != null)
            {
                var extension = Path.GetExtension(p.ProfilDosya.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/images/Profil_images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ProfilDosya.CopyTo(stream);
                p.ProfilResmi = newimagename;
                pp_update.ProfilResmi = p.ProfilResmi;
            }
            pp_update.Id = p.Id;
            pp_update.MeslekAlanı = p.MeslekAlanı;
            pp_update.Twitter = p.Twitter;
            pp_update.Mail = p.Mail;
            pp_update.Konum = p.Konum;
            pp_update.KonumAdresi = p.KonumAdresi;
            pp_update.Github = p.Github;
            pp_update.Linkedin = p.Linkedin;
            pp_update.Instagram = p.Instagram;
            db.SaveChanges();
            return RedirectToAction("profil");
        }
    }
}
