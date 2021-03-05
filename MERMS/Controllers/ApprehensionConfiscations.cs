using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MERMS.Data;
using MERMS.Models;
using MERMS.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace MERMS.Controllers
{
    [Authorize]
    public class ApprehensionConfiscations : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ApprehensionConfiscations(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment; 
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
        public async Task<IActionResult> Create(ApprehensionConfiscationViewModel model)
        {
            if (ModelState.IsValid)
            {                
                string uniqueFileName = UploadedFile(model);
                ApprehensionConfiscation data = new ApprehensionConfiscation { 
                    Jurisdiction=model.Jurisdiction,
                    PlaceOfApprehension = model.PlaceOfApprehension,
                    DateOfConfiscation = model.DateOfConfiscation,
                    NumberOfPieces = model.NumberOfPieces,
                    Species = model.Species,
                    BoardFeet = model.BoardFeet,
                    CubicMeter = model.CubicMeter,
                    VehiclePlateNo = model.VehiclePlateNo,
                    ParaphernaliaSerialNo = model.ParaphernaliaSerialNo,
                    Offender = model.Offender,
                    Address = model.Address,
                    Custodian = model.Custodian,
                    Status = model.Status,
                    EstimatedValue = model.EstimatedValue,
                    Remarks = model.Remarks,
                    FilePath = uniqueFileName,
                };
                
                _context.Add(data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
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
            ApprehensionConfiscationViewModel data=apprehensionConfiscation;
            return View(apprehensionConfiscation);
        }

        // POST: ApprehensionConfiscations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ApprehensionConfiscationViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApprehensionConfiscationExists(model.Id))
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
            return View(model);
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

        private string UploadedFile(ApprehensionConfiscationViewModel model)
        {
            string uniqueFileName = null;

            if (model.FilePath != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FilePath.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.FilePath.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
