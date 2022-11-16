using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;

namespace GigHub.Controllers
{
    //[Authorize]
    public class FollowingsController : Controller
    {
        private readonly MVCContext _context;

        public FollowingsController(MVCContext context)
        {
            _context = context;
        }

        // GET: Gigs/Edit/5
        public async Task<IActionResult> Follow(String? id)
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
            ViewData["ArtistId"] = new SelectList(_context.Set<User>(), "Id", "Id", gig.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "Name", gig.GenreId);
            return View(gig);
        }

        // POST: Gigs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Follow(int id, [Bind("Id,ArtistId,DateTime,Venue,GenreId")] Gig gig)
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
            ViewData["ArtistId"] = new SelectList(_context.Set<User>(), "Id", "Id", gig.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "Id", "Name", gig.GenreId);
            return View(gig);
        }*/

        /*[HttpPost]
        public async Task<IActionResult> Follow(int? id)
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
        }*/

        /*[HttpPost]
        public IActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.Name;
            //var userId = _context.Followings.ToList(); //User.Identity.GetUserId();


            if (_context.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == dto.FolloweeId))
                return BadRequest("Following already exists.");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }*/
    }
}
