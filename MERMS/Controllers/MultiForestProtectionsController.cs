using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MERMS.Data;
using MERMS.Models;

namespace MERMS.Controllers
{
    public class MultiForestProtectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MultiForestProtectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MultiForestProtections
        public async Task<IActionResult> Index()
        {
            return View(await _context.MultiForestProtections.ToListAsync());
        }

        // GET: MultiForestProtections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multiForestProtection = await _context.MultiForestProtections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (multiForestProtection == null)
            {
                return NotFound();
            }

            return View(multiForestProtection);
        }

        // GET: MultiForestProtections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MultiForestProtections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateOfMeeting,VenueOfMeeting,NumberOfAttendees,LetterOfInvitation,AttendanceSheet,MinutesOfMeeting,PhotoDocumentation")] MultiForestProtection multiForestProtection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(multiForestProtection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(multiForestProtection);
        }

        // GET: MultiForestProtections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multiForestProtection = await _context.MultiForestProtections.FindAsync(id);
            if (multiForestProtection == null)
            {
                return NotFound();
            }
            return View(multiForestProtection);
        }

        // POST: MultiForestProtections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateOfMeeting,VenueOfMeeting,NumberOfAttendees,LetterOfInvitation,AttendanceSheet,MinutesOfMeeting,PhotoDocumentation")] MultiForestProtection multiForestProtection)
        {
            if (id != multiForestProtection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(multiForestProtection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MultiForestProtectionExists(multiForestProtection.Id))
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
            return View(multiForestProtection);
        }

        // GET: MultiForestProtections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var multiForestProtection = await _context.MultiForestProtections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (multiForestProtection == null)
            {
                return NotFound();
            }

            return View(multiForestProtection);
        }

        // POST: MultiForestProtections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var multiForestProtection = await _context.MultiForestProtections.FindAsync(id);
            _context.MultiForestProtections.Remove(multiForestProtection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MultiForestProtectionExists(int id)
        {
            return _context.MultiForestProtections.Any(e => e.Id == id);
        }
    }
}
