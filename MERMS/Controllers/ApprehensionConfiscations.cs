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
    public class ApprehensionConfiscations : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApprehensionConfiscations(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApprehensionConfiscations
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApprehensionConfiscations.ToListAsync());
        }

        // GET: ApprehensionConfiscations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apprehensionConfiscation = await _context.ApprehensionConfiscations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apprehensionConfiscation == null)
            {
                return NotFound();
            }

            return View(apprehensionConfiscation);
        }

        // GET: ApprehensionConfiscations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApprehensionConfiscations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Jurisdiction,PlaceOfApprehension,DateOfConfiscation,NumberOfPieces,Species,BoardFeet,CubicMeter,VehiclePlateNo,ParaphernaliaSerialNo,Offender,Address,Custodian,Status,EstimatedValue,Remarks")] ApprehensionConfiscation apprehensionConfiscation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apprehensionConfiscation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apprehensionConfiscation);
        }

        // GET: ApprehensionConfiscations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apprehensionConfiscation = await _context.ApprehensionConfiscations.FindAsync(id);
            if (apprehensionConfiscation == null)
            {
                return NotFound();
            }
            return View(apprehensionConfiscation);
        }

        // POST: ApprehensionConfiscations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Jurisdiction,PlaceOfApprehension,DateOfConfiscation,NumberOfPieces,Species,BoardFeet,CubicMeter,VehiclePlateNo,ParaphernaliaSerialNo,Offender,Address,Custodian,Status,EstimatedValue,Remarks")] ApprehensionConfiscation apprehensionConfiscation)
        {
            if (id != apprehensionConfiscation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apprehensionConfiscation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApprehensionConfiscationExists(apprehensionConfiscation.Id))
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
            return View(apprehensionConfiscation);
        }

        // GET: ApprehensionConfiscations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apprehensionConfiscation = await _context.ApprehensionConfiscations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apprehensionConfiscation == null)
            {
                return NotFound();
            }

            return View(apprehensionConfiscation);
        }

        // POST: ApprehensionConfiscations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apprehensionConfiscation = await _context.ApprehensionConfiscations.FindAsync(id);
            _context.ApprehensionConfiscations.Remove(apprehensionConfiscation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApprehensionConfiscationExists(int id)
        {
            return _context.ApprehensionConfiscations.Any(e => e.Id == id);
        }
    }
}
