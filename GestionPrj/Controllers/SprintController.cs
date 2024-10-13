using GestionPrj.Context;
using GestionPrj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionPrj.Controllers
{
    public class SprintController : Controller
    {
        MyContext db;
        public SprintController(MyContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<Projet> Projets = db.Projets.ToList();
            ViewBag.projets = Projets;
            ViewBag.UserStories = db.UserStories.ToList();
            Sprint sprint = new Sprint();
            sprint.Date_debut = DateTime.Now; 

            return View(sprint);
           
        }
        [HttpPost]
        public IActionResult Add(Sprint S, List<int> selectedUserStoryIds)
        {

            if (ModelState.IsValid)
            {
                S.UserStories = db.UserStories
                                         .Where(us => selectedUserStoryIds.Contains(us.Id))
                                         .ToList();

                db.Sprints.Add(S);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserStories = db.UserStories.ToList();
            return View(S);
        }
        public IActionResult Index()
        {
            if(ModelState.IsValid)
            {
                List<Sprint> sprints = db.Sprints.Include(S =>S.Projet).Include(S => S.UserStories).Include(S=>S.RScrum).ToList();
                return View(sprints);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            List<Projet> Projets = db.Projets.ToList();
            ViewBag.projets = Projets;
            List<RScrum> RScrums = db.RScrums.ToList();
            ViewBag.rScrums = RScrums;

            Sprint S = db.Sprints.Where(S => S.Id == id).FirstOrDefault();
            return View(S);
        }
        [HttpPost]
        public IActionResult Update(Sprint S)
        {
            if (ModelState.IsValid)
            {
                db.Sprints.Update(S);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int id)
        {
            db.Sprints.Remove(db.Sprints.Where(P => P.Id == id).Include(S => S.Projet).Include(S => S.RScrum).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}
