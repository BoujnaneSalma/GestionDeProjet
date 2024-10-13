using GestionPrj.Context;
using GestionPrj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionPrj.Controllers
{
    public class ProjetController : Controller
    {
        MyContext db;
        public ProjetController(MyContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Add()
        {
            Projet nouveauProjet = new Projet();
            nouveauProjet.Date_debut = DateTime.Now; // Définir la date de début à la date d'aujourd'hui

            return View(nouveauProjet);
        }
        [HttpPost]
        public IActionResult Add(Projet P)
        {
            if(ModelState.IsValid)
            {
                db.Projets.Add(P);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Index()
        {
            List<Projet> projets = db.Projets.Include(P =>P.UProjets).Include(P =>P.UserStories).Include(P => P.Sprints).ToList();
            return View(projets);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {

            Projet P = db.Projets.Where(T => T.Id == id).FirstOrDefault();
            return View(P);
        }
        [HttpPost]
        public IActionResult Update(Projet P)
        {
            if (ModelState.IsValid)
            {
                db.Projets.Update(P);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int id)
        {
            db.Projets.Remove(db.Projets.Where(P => P.Id == id).Include(P => P.Sprints).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
