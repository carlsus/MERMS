using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MERMS.Data;
using MERMS.Models;
using Microsoft.AspNetCore.Authorization;
using MERMS.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MERMS.Controllers
{
    [Authorize]
    public class DonatedConfiscatedsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public DonatedConfiscatedsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: DonatedConfiscateds
        public async Task<IActionResult> Index()
        {
            return View(await _context.DonatedConfiscateds.ToListAsync());
        }

        // GET: DonatedConfiscateds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donatedConfiscated = await _context.DonatedConfiscateds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donatedConfiscated == null)
            {
                return NotFound();
            }

            return View(donatedConfiscated);
        }

        // GET: DonatedConfiscateds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DonatedConfiscateds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DonatedConfiscatedViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                DonatedConfiscated data = new DonatedConfiscated
                {
                    TrackingNo=model.TrackingNo,
                    DateOfDonation=model.DateOfDonation,
                    DoneeRecipient=model.DoneeRecipient,
                    SpeciesForm=model.SpeciesForm,
                    NumberOfPieces=model.NumberOfPieces,
                    VolumeBoardFeet=model.VolumeBoardFeet,
                    EstimatedMarketValue=model.EstimatedMarketValue,
                    Purpose=model.Purpose,
                    FilePath = uniqueFileName,
                };
                _context.Add(data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: DonatedConfiscateds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.DonatedConfiscateds.FindAsync(id);
            DonatedConfiscatedViewModel vm = new DonatedConfiscatedViewModel
            {
                TrackingNo = model.TrackingNo,
                DateOfDonation = model.DateOfDonation,
                DoneeRecipient = model.DoneeRecipient,
                SpeciesForm = model.SpeciesForm,
                NumberOfPieces = model.NumberOfPieces,
                VolumeBoardFeet = model.VolumeBoardFeet,
                EstimatedMarketValue = model.EstimatedMarketValue,
                Purpose = model.Purpose,

            };
            if (model == null)
            {
                return NotFound();
            }
            return View(vm);
        }
        public async Task<IActionResult> ViewFile(int? id)
        {
            var model = await _context.DonatedConfiscateds.FindAsync(id);


            var path = Path.Combine(webHostEnvironment.WebRootPath, "uploads", model.FilePath);
            var filePath = System.IO.File.OpenRead(path);
            return File(filePath, "application/pdf");
        }

        // POST: DonatedConfiscateds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DonatedConfiscatedViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string uniqueFileName = UploadedFile(model);
                    DonatedConfiscated data = new DonatedConfiscated
                    {
                        Id = model.Id,
                        TrackingNo = model.TrackingNo,
                        DateOfDonation = model.DateOfDonation,
                        DoneeRecipient = model.DoneeRecipient,
                        SpeciesForm = model.SpeciesForm,
                        NumberOfPieces = model.NumberOfPieces,
                        VolumeBoardFeet = model.VolumeBoardFeet,
                        EstimatedMarketValue = model.EstimatedMarketValue,
                        Purpose=model.Purpose,
                        FilePath = uniqueFileName,
                    };
                    _context.Update(data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonatedConfiscatedExists(model.Id))
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

        // GET: DonatedConfiscateds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donatedConfiscated = await _context.DonatedConfiscateds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donatedConfiscated == null)
            {
                return NotFound();
            }

            return View(donatedConfiscated);
        }

        // POST: DonatedConfiscateds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donatedConfiscated = await _context.DonatedConfiscateds.FindAsync(id);
            _context.DonatedConfiscateds.Remove(donatedConfiscated);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonatedConfiscatedExists(int id)
        {
            return _context.DonatedConfiscateds.Any(e => e.Id == id);
        }

        private string UploadedFile(DonatedConfiscatedViewModel model)
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
