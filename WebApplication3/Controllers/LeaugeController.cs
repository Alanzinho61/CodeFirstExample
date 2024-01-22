using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class LeaugeController : Controller
    {
        private readonly ClupContext _db;
        public LeaugeController(ClupContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
            
            return View(_db.Lauges.ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Leauge l)
        {
            if (l != null)
            {
                _db.Lauges.Add(l);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
