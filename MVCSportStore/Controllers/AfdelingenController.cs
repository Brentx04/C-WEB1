using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCSportStore.Data;
using MVCSportStore.Models;

namespace MVCSportStore.Controllers
{
    public class AfdelingenController : Controller
    {
        private readonly StoreDbContext _context;

        public AfdelingenController(StoreDbContext context)
        {
            _context = context;
        }

        // GET: Afdelingen
        public async Task<IActionResult> Index()
        {
            var tagHelperDbContext = _context.Afdelingen
                .Include(a => a.Locatie)
                .ThenInclude(b => b!.Land);
            return View(await tagHelperDbContext.ToListAsync());
        }

        // GET: Afdelingen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Afdelingen
                .Include(a => a.Locatie)
                .ThenInclude(b => b!.Land)
                .FirstOrDefaultAsync(m => m.AfdelingId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Afdelingen/Create
        public IActionResult Create()
        {
            ViewData["LocatieId"] = new SelectList(_context.Locaties, "LocatieId", "Stad", null);
            return View();
        }

        // POST: Afdelingen/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AfdelingId,AfdelingNaam,LocatieId")] Afdeling item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocatieId"] = new SelectList(_context.Locaties, "LocatieId", "Stad", item.LocatieId);
            return View(item);
        }

        // GET: Afdelingen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Afdelingen.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["LocatieId"] = new SelectList(_context.Locaties, "LocatieId", "Stad", item.LocatieId);
            return View(item);
        }

        // POST: Afdelingen/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AfdelingId,AfdelingNaam,LocatieId")] Afdeling item)
        {
            if (id != item.AfdelingId)
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
                    if (!_context.Afdelingen.Any(e => e.AfdelingId == item.AfdelingId))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocatieId"] = new SelectList(_context.Locaties, "LocatieId", "Stad", item.LocatieId);
            return View(item);
        }

        // GET: Afdelingen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Afdelingen
                .Include(a => a.Locatie)
                .ThenInclude(b => b!.Land)
                .FirstOrDefaultAsync(m => m.AfdelingId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Afdelingen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Afdelingen.FindAsync(id);
            if (item != null)
            {
                _context.Afdelingen.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
