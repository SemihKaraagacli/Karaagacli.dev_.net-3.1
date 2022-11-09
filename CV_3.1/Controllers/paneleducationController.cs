using CV_3._1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CV_3._1.Controllers
{
    [Authorize]
    public class paneleducationController : Controller
    {
        Context db = new Context();
        public IActionResult education()
        {
            var deger = db.panelEducations.ToList();
            
            return View(deger);
        }
        [HttpGet]
        public IActionResult educationAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult educationAdd(PanelEducation education)
        {
            db.panelEducations.Add(education);
            db.SaveChanges();
            return RedirectToAction("education");
        }

        public IActionResult educationRemove(PanelEducation rm)
        {
            var deger = db.panelEducations.Find(rm.Id);
            db.panelEducations.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("education");
        }

        [HttpGet]
        public IActionResult educationGet(int Id)
        {
            var pe_get = db.panelEducations.SingleOrDefault(x => x.Id == Id);
            return View(pe_get);
        }
        [HttpPost]
        public IActionResult educationUpdate(PanelEducation education)
        {
            var pe_update = db.panelEducations.SingleOrDefault(x => x.Id == education.Id);
            pe_update.Id = education.Id;
            pe_update.OkulAd = education.OkulAd;
            pe_update.OkulYıl = education.OkulYıl;
            pe_update.OkulAlan = education.OkulAlan;
            pe_update.OkulIcerik = education.OkulIcerik;
            db.SaveChanges();
            return RedirectToAction("education");
        }
    }
}
