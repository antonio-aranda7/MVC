using GigHub.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;

namespace MVC.Controllers
{
    public class GigsController : Controller
    {
        private readonly MVCContext _context;

        public GigsController(MVCContext context)
        {
            _context = context;
        }

        // GET: Gigs
        public async Task<IActionResult> Index()
        {
            var mVCContext = _context.Gig.Include(g => g.Artist).Include(g => g.Genre);
            return View(await mVCContext.ToListAsync());
        }

        // GET: Gigs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gig == null)
            {
                return NotFound();
            }

            var gig = await _context.Gig
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gig == null)
            {
                return NotFound();
            }

            return View(gig);
        }

        // GET: Gigs/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Set<User>(), "Id", "Name");
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "Name");
            return View();
        }

        // POST: Gigs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArtistId,DateTime,Venue,GenreId")] Gig gig)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Set<User>(), "Id", "Name", gig.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "Name", gig.GenreId);
            return View(gig);
        }

        // GET: Gigs/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gig == null)
            {
                return NotFound();
            }

            var gig = await _context.Gig.FindAsync(id);
            if (gig == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Set<User>(), "Id", "Name", gig.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "Name", gig.GenreId);
            return View(gig);
        }

        // POST: Gigs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArtistId,DateTime,Venue,GenreId")] Gig gig)
        {
            if (id != gig.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gig);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GigExists(gig.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Set<User>(), "Id", "Name", gig.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "Name", gig.GenreId);
            return View(gig);
        }

        // GET: Gigs/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gig == null)
            {
                return NotFound();
            }

            var gig = await _context.Gig
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gig == null)
            {
                return NotFound();
            }

            return View(gig);
        }

        // POST: Gigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gig == null)
            {
                return Problem("Entity set 'MVCContext.Gig'  is null.");
            }
            var gig = await _context.Gig.FindAsync(id);
            if (gig != null)
            {
                _context.Gig.Remove(gig);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GigExists(int id)
        {
          return _context.Gig.Any(e => e.Id == id);
        }
    }
}
