using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
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
        }
    }
}
