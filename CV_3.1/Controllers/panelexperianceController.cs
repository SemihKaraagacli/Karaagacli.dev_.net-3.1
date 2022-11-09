using CV_3._1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CV_3._1.Controllers
{
    [Authorize]
    public class panelexperianceController : Controller
    {
        Context db = new Context();
        public IActionResult experiance()
        {
            var values = db.panelExperiances.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult experianceAdd()
        {
            return View();

        }
        [HttpPost]
        public IActionResult experianceAdd(PanelExperiance p)
        {
            db.panelExperiances.Add(p);
            db.SaveChanges();
            return RedirectToAction("experiance");
        }

        public IActionResult experianceRemove(PanelExperiance rm)
        {
            var deger = db.panelExperiances.Find(rm.Id);
            db.panelExperiances.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("experiance");
        }

        [HttpGet]
        public IActionResult experianceGet(int Id)
        {
            var get = db.panelExperiances.SingleOrDefault(x => x.Id == Id);
            return View(get);
        }
        [HttpPost]
        public IActionResult experianceUpdate(PanelExperiance e)
        {
            var update = db.panelExperiances.SingleOrDefault(x => x.Id == e.Id);
            update.Id = e.Id;
            update.DeneyimAd = e.DeneyimAd;
            update.DeneyimAlan = e.DeneyimAlan;
            update.DeneyimYıl = e.DeneyimYıl;
            update.DeneyimIcerik = e.DeneyimIcerik;
            db.SaveChanges();
            return RedirectToAction("experiance");
        }
    }
}
