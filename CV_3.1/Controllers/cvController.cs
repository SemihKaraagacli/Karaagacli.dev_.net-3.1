using CV_3._1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CV_3._1.Controllers
{
    public class cvController : Controller
    {
        Context db = new Context();
        public IActionResult About()
        {
            var about = db.panelAbouts.ToList();
            var profil = db.panelProfils.ToList();
            about.Reverse();
            return View(Tuple.Create(about, profil));

        }
        public IActionResult Resume()
        {
            var profil = db.panelProfils.ToList();
            var education = db.panelEducations.ToList();
            var experiance = db.panelExperiances.ToList();
            education.Reverse();
            experiance.Reverse();
            return View(Tuple.Create(profil, education, experiance));
        }
        public IActionResult Project()
        {
            var profil = db.panelProfils.ToList();
            var project = db.panelProjects.ToList();
            project.Reverse();
            return View(Tuple.Create(profil, project));
        }
        public IActionResult Contact()
        {
            var contact = db.panelProfils.ToList();
            return View(contact);
        }
    }
}
