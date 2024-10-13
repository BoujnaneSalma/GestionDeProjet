using GestionPrj.Context;
using GestionPrj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionPrj.Controllers
{
    public class UserStoryController : Controller
    {
        MyContext db;
        public UserStoryController(MyContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Add()
        {
           
            List<Projet> Projets = db.Projets.ToList();
            ViewBag.projets = Projets;
            List<Sprint> sprint = db.Sprints.ToList();
            ViewBag.Sprint = sprint;

            return View();
        }
        [HttpPost]
        public IActionResult Add(UserStory US)
        {
            List<Projet> Projets = db.Projets.ToList();
            ViewBag.projets = Projets;
            List<Sprint> sprint = db.Sprints.ToList();
            ViewBag.Sprint = sprint;
            if (ModelState.IsValid)
            {
               // US.UserId = US.UserId ?? 0;
                db.UserStories.Add(US);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
        public IActionResult Index()
        {

            List<UserStory> userStories = db.UserStories.Include(US => US.Sprint).Include(US => US.Projet).Include(US => US.Taches).Include(US => US.User).ToList();
            return View(userStories);
        }
        [HttpPost]

        [HttpPost]
        public IActionResult UpdateStatus(int id, string status)
        {
            var userStory = db.UserStories.Find(id); // Suppose que '_context' est votre DbContext
            if (userStory == null)
            {
                return NotFound();
            }

            userStory.Etat = status;
            db.SaveChanges();

            return Ok();
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            List<Projet> Projets = db.Projets.ToList();
            ViewBag.projets = Projets;
            List<Sprint> Sprint = db.Sprints.ToList();
            ViewBag.sprint = Sprint;
            List<User> users = db.Users.ToList();
            ViewBag.Users = users;

            UserStory US = db.UserStories.Where(US => US.Id == id).FirstOrDefault();
            return View(US);
        }
        [HttpPost]
        public IActionResult Update(UserStory US)
        {
            List<Projet> Projets = db.Projets.ToList();
            ViewBag.projets = Projets;
            List<Sprint> Sprint = db.Sprints.ToList();
            ViewBag.sprint = Sprint;
            if (ModelState.IsValid)
            {
                db.UserStories.Update(US);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int id)
        {
            db.UserStories.Remove(db.UserStories.Where(P => P.Id == id).Include(S => S.Projet).Include(S => S.Sprint).Include(S => S.User).Include(S => S.Taches).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
