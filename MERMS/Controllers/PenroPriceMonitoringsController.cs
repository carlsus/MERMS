using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MERMS.Data;
using MERMS.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using MERMS.ViewModels;
using Microsoft.AspNetCore.Http;

namespace MERMS.Controllers
{
    public class PenroPriceMonitoringsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public PenroPriceMonitoringsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: PenroPriceMonitorings
        public async Task<IActionResult> Index()
        {
            return View(await _context.PenroPriceMonitorings.ToListAsync());
        }

        public async Task<IActionResult> PenroREport(int? id)
        {
            var model = await _context.PenroPriceMonitorings.FindAsync(id);


            var path = Path.Combine(webHostEnvironment.WebRootPath, "uploads", model.PenroReport);
            var filePath = System.IO.File.OpenRead(path);
            return File(filePath, "application/pdf");
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
        public async Task<IActionResult> Create(PenroPriceMonitoringViewModel model)
        {
            if (ModelState.IsValid)
            {
                string penroReport = UploadedFile(model.PenroReport);
                PenroPriceMonitoring data = new PenroPriceMonitoring
                {
                    TrackingNo = model.TrackingNo,
                    ReleasedPenro=model.ReleasedPenro,
                    PenroReport=penroReport
                };
                _context.Add(data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PenroPriceMonitorings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var m = await _context.PenroPriceMonitorings.FindAsync(id);
            PenroPriceMonitoringViewModel vm = new PenroPriceMonitoringViewModel
            {
                
               TrackingNo=m.TrackingNo,
               ReleasedPenro=m.ReleasedPenro


            };
            if (m == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        // POST: PenroPriceMonitorings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PenroPriceMonitoringViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string penroReport = UploadedFile(model.PenroReport);
                    PenroPriceMonitoring data = new PenroPriceMonitoring
                    {
                        Id = model.Id,
                        TrackingNo = model.TrackingNo,
                        ReleasedPenro = model.ReleasedPenro,
                        PenroReport = penroReport
                    };
                    _context.Update(data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PenroPriceMonitoringExists(model.Id))
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

        private string UploadedFile(IFormFile model)
        {
            string uniqueFileName = null;

            if (model != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
