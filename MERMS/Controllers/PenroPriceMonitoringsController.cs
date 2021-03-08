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
    public class PenroPriceMonitoringsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PenroPriceMonitoringsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PenroPriceMonitorings
        public async Task<IActionResult> Index()
        {
            return View(await _context.PenroPriceMonitorings.ToListAsync());
        }

        // GET: PenroPriceMonitorings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penroPriceMonitoring = await _context.PenroPriceMonitorings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (penroPriceMonitoring == null)
            {
                return NotFound();
            }

            return View(penroPriceMonitoring);
        }

        // GET: PenroPriceMonitorings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PenroPriceMonitorings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TrackingNo,ReleasedPenro,PenroReport")] PenroPriceMonitoring penroPriceMonitoring)
        {
            if (ModelState.IsValid)
            {
                _context.Add(penroPriceMonitoring);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(penroPriceMonitoring);
        }

        // GET: PenroPriceMonitorings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penroPriceMonitoring = await _context.PenroPriceMonitorings.FindAsync(id);
            if (penroPriceMonitoring == null)
            {
                return NotFound();
            }
            return View(penroPriceMonitoring);
        }

        // POST: PenroPriceMonitorings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TrackingNo,ReleasedPenro,PenroReport")] PenroPriceMonitoring penroPriceMonitoring)
        {
            if (id != penroPriceMonitoring.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(penroPriceMonitoring);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PenroPriceMonitoringExists(penroPriceMonitoring.Id))
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
            return View(penroPriceMonitoring);
        }

      
        public async Task<IActionResult> Delete(int id)
        {
            var penroPriceMonitoring = await _context.PenroPriceMonitorings.FindAsync(id);
            _context.PenroPriceMonitorings.Remove(penroPriceMonitoring);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PenroPriceMonitoringExists(int id)
        {
            return _context.PenroPriceMonitorings.Any(e => e.Id == id);
        }
    }
}
