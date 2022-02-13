using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using TurkiyeBilgi.Models;

namespace TurkiyeBilgi.Controllers
{
    public class SehirController : Controller
    {
        private readonly TurkiyeContext _db;

        public 
            SehirController( TurkiyeContext db)
        {
            _db=db;
        }

        [Route("Sehir/{id:int}")]
        
        public IActionResult Index(int id)
        {
            Sehir sehir = _db.Sehirler.Include(x=>x.Bolge).FirstOrDefault(x=>x.Id==id);
            if (sehir == null)return NotFound();
            return View(sehir);
            
        }
        [Route("Sehir/{ad}")]
        public IActionResult Index(string ad)
        {
            Sehir sehir = _db.Sehirler.Include(x => x.Bolge).FirstOrDefault(x => x.SehirAd==ad);
            if (sehir == null) return NotFound();
            return View(sehir);

        }
    }
}
