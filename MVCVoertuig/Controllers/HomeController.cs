using Microsoft.AspNetCore.Mvc;
using MVCVoertuig.Data;

namespace MVCVoertuig.Controllers
{
    public class HomeController : Controller
    {
        private readonly VoertuigDbContext _context;

        public HomeController(VoertuigDbContext context)
        {
            _context = context;
        }

        // Startpagina met de CarInfo TagHelper (stap 13)
        public IActionResult Index()
        {
            ViewBag.AantalVoertuigen = _context.Voertuigen.Count();
            ViewBag.AantalInShowroom = _context.Voertuigen.Count(v => v.AanwezigInShowroom);
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
