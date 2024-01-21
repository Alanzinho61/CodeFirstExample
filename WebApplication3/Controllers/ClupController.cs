using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ClupController : Controller
    {
        private readonly ClupContext _db;

        public ClupController(ClupContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Clups.ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Clup c)
        {
            if (c != null)
            {
               _db.Clups.Add(c);
               _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int id) 
        {
            return View(_db.Clups.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Clup c)
        {
            if (c != null)
            {
                _db.Clups.Update(c);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Delete(int id) 
        {
           var sil=_db.Clups.Find(id);
           if (sil != null)
            {
                _db.Clups.Remove(sil);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
           return  View(null);
        }

    }
}
