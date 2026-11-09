using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCVoertuig.Data;
using MVCVoertuig.Models;

namespace MVCVoertuig.Controllers
{
    // Stap 7 + 8 - VoertuigController met Index en Create
    public class VoertuigController : Controller
    {
        private readonly VoertuigDbContext _context;

        // Dependency Injection: de DbContext die we in Program.cs registreerden komt hier binnen
        public VoertuigController(VoertuigDbContext context)
        {
            _context = context;
        }

        // GET: /Voertuig  of  /Voertuig?merk=AUDI  (links uit de HeaderMenu ViewComponent)
        public async Task<IActionResult> Index(string? merk)
        {
            var voertuigen = _context.Voertuigen.AsQueryable();

            if (!string.IsNullOrEmpty(merk))
            {
                voertuigen = voertuigen.Where(v => v.Merk == merk);
            }

            ViewBag.Merk = merk;
            return View(await voertuigen.OrderBy(v => v.Merk).ThenBy(v => v.MerkType).ToListAsync());
        }

        // GET: /Voertuig/Create -> leeg formulier tonen
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Voertuig/Create -> formulier verwerken
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Voertuig voertuig)
        {
            // ModelState.IsValid controleert alle DataAnnotations, ook [Bouwjaar]
            if (ModelState.IsValid)
            {
                _context.Voertuigen.Add(voertuig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Fouten -> zelfde view opnieuw tonen met de ingevulde waarden + foutmeldingen
            return View(voertuig);
        }
    }
}
