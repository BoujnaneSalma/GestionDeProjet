using GestionPrj.Context;
using GestionPrj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionPrj.Controllers
{
    public class TacheController : Controller
    {
        MyContext db;
        public TacheController(MyContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<UserStory> stories = db.UserStories.ToList();
            ViewBag.Stories = stories;
            return View();
        }
        [HttpPost]
        public IActionResult Add(Tache T) 
        {
            List<UserStory> stories = db.UserStories.ToList();
            ViewBag.Stories = stories;
            if (!T.Estimation_Temps.HasValue)
            {
                T.Estimation_Temps = 0; // ou toute autre valeur par défaut souhaitée
            }
            db.Taches.Add(T);
                db.SaveChanges();
                return RedirectToAction("Index","UserStory");
            

        }
        public IActionResult Index()
        {
            if (ModelState.IsValid)
            {
                List<Tache> taches = db.Taches.Include(T =>T.UserStory).ToList();
                return View(taches);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            List<UserStory> stories = db.UserStories.ToList();
            ViewBag.Stories = stories;

            Tache T = db.Taches.Where(T => T.Id == id).FirstOrDefault();
            return View(T);
        }
        [HttpPost]
        public IActionResult Update(Tache T)
        {
            if (ModelState.IsValid)
            {
                db.Taches.Update(T);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        /*
        [HttpPost]
        public IActionResult UpdateState(int id, string state)
        {
            var tache = db.Taches.Find(id);
            if (tache == null)
            {
                return NotFound();
            }

            tache.//Etat = state;
            db.Taches.Update(tache);
            db.SaveChanges();

            return Ok();
        }
        */
        public IActionResult Delete(int id)
        {
            db.Taches.Remove(db.Taches.Where(T => T.Id == id).Include(T => T.UserStory).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detail()
        {
            Tache T = db.Taches.Include(c => c.UserStory).FirstOrDefault();


            return View(T);
        }
    }
}
