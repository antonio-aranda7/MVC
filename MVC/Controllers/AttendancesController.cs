﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GigHub.Models;
using MVC.Data;

namespace MVC.Controllers
{
    public class AttendancesController : Controller
    {
        private readonly MVCContext _context;

        public AttendancesController(MVCContext context)
        {
            _context = context;
        }

        // GET: Attendances
        public async Task<IActionResult> Index()
        {
            var mVCContext = _context.Attendances.Include(a => a.Attendee).Include(a => a.Gig);
            return View(await mVCContext.ToListAsync());
        }

        // GET: Attendances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Attendances == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .Include(a => a.Attendee)
                .Include(a => a.Gig)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // GET: Attendances/Create
        public IActionResult Create()
        {
            ViewData["AttendeeId"] = new SelectList(_context.Set<User>(), "Id", "Name");
            ViewData["GigId"] = new SelectList(_context.Gig, "Id", "Venue");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GigId,AttendeeId")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AttendeeId"] = new SelectList(_context.Set<User>(), "Id", "Name", attendance.AttendeeId);
            ViewData["GigId"] = new SelectList(_context.Gig, "Id", "Venue", attendance.GigId);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public async Task<IActionResult> CEdit(int? id)
        {
            if (id == null || _context.Attendances == null)
            {
                return NotFound();
            }

            var attendance = await _context.Gig.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            ViewData["AttendeeId"] = new SelectList(_context.Set<User>(), "Id", "Name", attendance.ArtistId);
            ViewData["GigId"] = new SelectList(_context.Gig, "Id", "Venue", attendance.Id);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Attendances == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            ViewData["AttendeeId"] = new SelectList(_context.Set<User>(), "Id", "Name", attendance.AttendeeId);
            ViewData["GigId"] = new SelectList(_context.Gig, "Id", "Venue", attendance.GigId);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GigId,AttendeeId")] Attendance attendance)
        {
            if (id != attendance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceExists(attendance.Id))
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
            ViewData["AttendeeId"] = new SelectList(_context.Set<User>(), "Id", "Name", attendance.AttendeeId);
            ViewData["GigId"] = new SelectList(_context.Gig, "Id", "Venue", attendance.GigId);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Attendances == null)
            {
                return NotFound();
            }

            var attendance = await _context.Attendances
                .Include(a => a.Attendee)
                .Include(a => a.Gig)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Attendances == null)
            {
                return Problem("Entity set 'MVCContext.Attendances'  is null.");
            }
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendanceExists(int id)
        {
          return _context.Attendances.Any(e => e.Id == id);
        }
    }
}
