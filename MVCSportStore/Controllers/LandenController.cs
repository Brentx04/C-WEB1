using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCSportStore.Data;
using MVCSportStore.Models;

namespace MVCSportStore.Controllers
{
    public class LandenController : Controller
    {
        private readonly StoreDbContext _context;

        public LandenController(StoreDbContext context)
        {
            _context = context;
        }

        // GET: Landen
        public async Task<IActionResult> Index()
        {
            var tagHelperDbContext = _context.Landen;
            return View(await tagHelperDbContext.ToListAsync());
        }

        // GET: Landen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Landen
                .FirstOrDefaultAsync(m => m.LandId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Landen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Landen/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LandId,LandCode,LandNaam")] Land item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Landen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Landen.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Landen/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LandId,LandCode,LandNaam")] Land item)
        {
            if (id != item.LandId)
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
                    if (!_context.Landen.Any(e => e.LandId == item.LandId))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Landen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Landen
                .FirstOrDefaultAsync(m => m.LandId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Landen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Landen.FindAsync(id);
            if (item != null)
            {
                _context.Landen.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
