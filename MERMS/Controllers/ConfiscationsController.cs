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
    public class ConfiscationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ConfiscationsController(ApplicationDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Confiscations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Confiscation.ToListAsync());
        }

        // GET: Confiscations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confiscation = await _context.Confiscation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (confiscation == null)
            {
                return NotFound();
            }

            return View(confiscation);
        }

        // GET: Confiscations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Confiscations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConfiscationViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                Confiscation data = new Confiscation
                {
                    Jurisdiction = model.Jurisdiction,
                    DateFiled=model.DateFiled,
                    DocketCaseNo=model.DocketCaseNo,
                    CaseTitleRespondent=model.CaseTitleRespondent,
                    NatureOfViolation=model.NatureOfViolation,
                    CourtFiled=model.CourtFiled,
                    VehiclePlateNo=model.VehiclePlateNo,
                    KindSpecies=model.KindSpecies,
                    EstimatedValue=model.EstimatedValue,
                    ForestProductStockPiled=model.ForestProductStockPiled,
                    BoardFeet=model.BoardFeet,
                    CubicMeter=model.CubicMeter,
                    Status=model.Status,
                    Remarks=model.Remarks,
                    FilePath = uniqueFileName,
                };
                _context.Add(data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Confiscations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confiscation = await _context.Confiscation.FindAsync(id);
            if (confiscation == null)
            {
                return NotFound();
            }
            return View(confiscation);
        }

        // POST: Confiscations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Jurisdiction,DateFiled,DocketCaseNo,CaseTitleRespondent,NatureOfViolation,CourtFiled,VehiclePlateNo,KindSpecies,EstimatedValue,ForestProductStockPiled,BoardFeet,CubicMeter,Status,Remarks,FilePath")] Confiscation confiscation)
        {
            if (id != confiscation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(confiscation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfiscationExists(confiscation.Id))
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
            return View(confiscation);
        }

        // GET: Confiscations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var confiscation = await _context.Confiscation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (confiscation == null)
            {
                return NotFound();
            }

            return View(confiscation);
        }

        // POST: Confiscations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var confiscation = await _context.Confiscation.FindAsync(id);
            _context.Confiscation.Remove(confiscation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConfiscationExists(int id)
        {
            return _context.Confiscation.Any(e => e.Id == id);
        }

        private string UploadedFile(ConfiscationViewModel model)
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
