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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Wkhtmltopdf.NetCore;

namespace MERMS.Controllers
{
    public class PriceMonitoringsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        readonly IGeneratePdf _generatePdf;

        public PriceMonitoringsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IGeneratePdf generatePdf)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
            _generatePdf = generatePdf;
        }

        [HttpGet]
        public async Task<IActionResult> Report(int yr)
        {
            var data = new PriceMonitoringReportModel
            {
                PriceMonitorings = _context.PriceMonitorings.Where(m => m.ReleasedCenro.Value.Year == yr).ToList(),
                Year = yr
            };
            return await _generatePdf.GetPdf("Views/pricemonitorings/Print.cshtml", data);
        }
        // GET: PriceMonitorings
        public async Task<IActionResult> Index()
        {
            return View(await _context.PriceMonitorings.ToListAsync());
        }

        // GET: PriceMonitorings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceMonitoring = await _context.PriceMonitorings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priceMonitoring == null)
            {
                return NotFound();
            }

            return View(priceMonitoring);
        }

        // GET: PriceMonitorings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PriceMonitorings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PriceMonitoringViewModel model)
        {
            if (ModelState.IsValid)
            {
                string cenroReport = UploadedFile(model.CenroReport);

                PriceMonitoring data = new PriceMonitoring
                {
                    TrackingNo = model.TrackingNo,
                    CenroConcerned = model.CenroConcerned,
                    ReleasedCenro = model.ReleasedCenro,
                    ReceivedPenro = model.ReceivedPenro,
                    CenroReport = cenroReport
                    
                };
                _context.Add(data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PriceMonitorings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.PriceMonitorings.FindAsync(id);
            PriceMonitoringViewModel vm = new PriceMonitoringViewModel
            {
                TrackingNo = model.TrackingNo,
                CenroConcerned = model.CenroConcerned,
                ReleasedCenro = model.ReleasedCenro,
                ReceivedPenro = model.ReceivedPenro,
               
              
               

            };
            if (model == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        // POST: PriceMonitorings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,PriceMonitoringViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string cenroReport = UploadedFile(model.CenroReport);

                    PriceMonitoring data = new PriceMonitoring
                    {
                        Id=model.Id,
                        TrackingNo = model.TrackingNo,
                        CenroConcerned = model.CenroConcerned,
                        ReleasedCenro = model.ReleasedCenro,
                        ReceivedPenro = model.ReceivedPenro,
                        CenroReport = cenroReport
                        
                    };
                    _context.Update(data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriceMonitoringExists(model.Id))
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

      
        public async Task<IActionResult> CenroReport(int? id)
        {
            var model = await _context.PriceMonitorings.FindAsync(id);


            var path = Path.Combine(webHostEnvironment.WebRootPath, "uploads", model.CenroReport);
            var filePath = System.IO.File.OpenRead(path);
            return File(filePath, "application/pdf");
        }
       
        public async Task<IActionResult> Delete(int id)
        {
            var priceMonitoring = await _context.PriceMonitorings.FindAsync(id);
            _context.PriceMonitorings.Remove(priceMonitoring);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PriceMonitoringExists(int id)
        {
            return _context.PriceMonitorings.Any(e => e.Id == id);
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
