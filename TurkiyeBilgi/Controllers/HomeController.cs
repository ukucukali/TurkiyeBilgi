using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TurkiyeBilgi.Models;

namespace TurkiyeBilgi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // loglama icin bir servis
        private readonly TurkiyeContext _db;

        public HomeController(ILogger<HomeController> logger, TurkiyeContext db)
        {
            _logger = logger;
            _db=db;
        }

        public IActionResult Index(int? bolgeId)
        {
            var vm = new HomeViewModel()
            {
                BolgeId = bolgeId,
                Sehirler=_db.Sehirler.Where(x=>!bolgeId.HasValue||x.BolgeId==bolgeId).ToList(),
                Bolgeler=_db.Bolgeler.Select(x =>
                new SelectListItem()
                {
                    Value = x.Id.ToString(),
                    Text = x.BolgeAd

                }).ToList()
            };
            return View(vm);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
