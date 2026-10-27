using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCSportStore.Data;
using MVCSportStore.Models;

namespace MVCSportStore.Controllers
{
    public class LocatiesController : Controller
    {
        private readonly StoreDbContext _context;

        public LocatiesController(StoreDbContext context)
        {
            _context = context;
        }

        // GET: Locaties
        public async Task<IActionResult> Index()
        {
            var tagHelperDbContext = _context.Locaties
                .Include(l => l.Land);
            return View(await tagHelperDbContext.ToListAsync());
        }

        // GET: Locaties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Locaties
                .Include(l => l.Land)
                .FirstOrDefaultAsync(m => m.LocatieId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Locaties/Create
        public IActionResult Create()
        {
            ViewData["LandId"] = new SelectList(_context.Landen, "LandId", "LandNaam", null);
            return View();
        }

        // POST: Locaties/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocatieId,Stad,LandId")] Locatie item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LandId"] = new SelectList(_context.Landen, "LandId", "LandNaam", item.LandId);
            return View(item);
        }

        // GET: Locaties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Locaties.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["LandId"] = new SelectList(_context.Landen, "LandId", "LandNaam", item.LandId);
            return View(item);
        }

        // POST: Locaties/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocatieId,Stad,LandId")] Locatie item)
        {
            if (id != item.LocatieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Locaties.Any(e => e.LocatieId == item.LocatieId))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LandId"] = new SelectList(_context.Landen, "LandId", "LandNaam", item.LandId);
            return View(item);
        }

        // GET: Locaties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Locaties
                .Include(l => l.Land)
                .FirstOrDefaultAsync(m => m.LocatieId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Locaties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Locaties.FindAsync(id);
            if (item != null)
            {
                _context.Locaties.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
