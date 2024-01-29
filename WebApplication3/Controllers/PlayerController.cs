using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ClupContext _db;
        public PlayerController(ClupContext db)
        {
            _db = db;          
        }
        public IActionResult Index()
        {
            return View(_db.Players.ToList());
        }
        
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Player p)
        {
            if (p != null)
            {
                _db.Players.Add(p);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int id)
        {
            return View(_db.Players.Find(id));
        }
        [HttpPost]
        public IActionResult Update(Player p)
        {
            if (p != null)
            {
                _db.Players.Update(p);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id) 
        {
            var sil = _db.Players.Find(id);
            if(sil != null)
            {
                _db.Players.Remove(sil);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
