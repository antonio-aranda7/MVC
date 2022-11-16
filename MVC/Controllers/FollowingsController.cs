using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
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
        }

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
