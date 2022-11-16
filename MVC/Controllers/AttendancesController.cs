using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;

namespace GigHub.Controllers
{
    //[Authorize]
    public class AttendancesController : Controller
    {
        private readonly MVCContext _context;

        public AttendancesController(MVCContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Attend(int? id)
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

        /*[HttpPost]
        public async Task<IActionResult> Attend(int id)
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
        public IActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.Name;

            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId))
                return BadRequest("The attendance already exists.");

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }*/
    }
}
