using CV_3._1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CV_3._1.Controllers
{
    [Authorize]
    public class panelaboutController : Controller
    {
        Context db = new Context();
        public IActionResult about()
        {
            var values = db.panelAbouts.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult aboutAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult aboutAdd(PanelAbout p)
        {
            db.panelAbouts.Add(p);
            db.SaveChanges();
            return RedirectToAction("about");
        }

        public IActionResult aboutRemove(PanelAbout rm)
        {
            var deger = db.panelAbouts.Find(rm.Id);
            db.panelAbouts.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("about");
        }

        [HttpGet]
        public IActionResult aboutGet(int Id)
        {
            var pa_get = db.panelAbouts.Find(Id);
            return View("aboutGet", pa_get);
        }
        [HttpPost]
        public IActionResult aboutUpdate(PanelAbout h)
        {
            var pa_update = db.panelAbouts.Find(h.Id);
            pa_update.Tanıtım = h.Tanıtım;
            pa_update.NelerYapıyorumAd = h.NelerYapıyorumAd;
            pa_update.NelerYapıyorumIcerik = h.NelerYapıyorumIcerik;
            db.SaveChanges();
            return RedirectToAction("about");
        }
    }
}
