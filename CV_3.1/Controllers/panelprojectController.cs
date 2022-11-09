using CV_3._1.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace CV_3._1.Controllers
{
    [Authorize]
    public class panelprojectController : Controller
    {
        Context db = new Context();
        public IActionResult project()
        {
            var values = db.panelProjects.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult projectAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult projectAdd(PanelProject project)
        {
            if (project.ProjectDosya != null)
            {
                var extension = Path.GetExtension(project.ProjectDosya.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/images/Project_images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                project.ProjectDosya.CopyTo(stream);
                project.ProjectResim = newimagename;
            }
            else
            {
                project.ProjectResim = "Auto.jpg";
            }
            db.panelProjects.Add(project);
            db.SaveChanges();
            return RedirectToAction("project");
        }

        public IActionResult projectRemove(PanelProject rm)
        {
            var deger = db.panelProjects.Find(rm.Id);
            db.panelProjects.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("project");
        }

        [HttpGet]
        public IActionResult projectGet(int id)
        {
            var ppro_get = db.panelProjects.SingleOrDefault(x => x.Id == id);
            return View(ppro_get);
        }
        [HttpPost]
        public IActionResult projectUpdate(PanelProject b)
        {
            var ppro_update = db.panelProjects.SingleOrDefault(x => x.Id == b.Id);
            if (b.ProjectDosya != null)
            {
                var extension = Path.GetExtension(b.ProjectDosya.FileName);
                var newimagesname = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets/images/Project_images/", newimagesname);
                var stream = new FileStream(location, FileMode.Create);
                b.ProjectDosya.CopyTo(stream);
                b.ProjectResim = newimagesname;
                ppro_update.ProjectResim = b.ProjectResim;
            }
            ppro_update.Id = b.Id;
            ppro_update.ProjectAd = b.ProjectAd;
            ppro_update.ProjectAdres = b.ProjectAdres;
            ppro_update.ProjectIcerik = b.ProjectIcerik;
            db.SaveChanges();
            return RedirectToAction("project");
        }
    }
}
