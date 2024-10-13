using GestionPrj.Context;
using GestionPrj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionPrj.Controllers
{
    public class RScrumController : Controller
    {
        MyContext db;
        public RScrumController(MyContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Add()
        {
            RScrum rs = new RScrum();
            rs.Date = DateTime.Now;
            return View(rs);
        }
        [HttpPost]
        public IActionResult Add(RScrum RS)
        {
            if(ModelState.IsValid)
            {
                db.RScrums.Add(RS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Index()
        {
            List<RScrum> rs = db.RScrums.Include(RS => RS.Sprints).ToList();
            return View(rs);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {

            RScrum RS = db.RScrums.Where(rs => rs.Id == id).FirstOrDefault();
            return View(RS);
        }
        [HttpPost]
        public IActionResult Update(RScrum R)
        {
            if (ModelState.IsValid)
            {
                db.RScrums.Update(R);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int id)
        {
            db.RScrums.Remove(db.RScrums.Where(P => P.Id == id).Include(P => P.Sprints).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
