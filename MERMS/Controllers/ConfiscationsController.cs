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
using Wkhtmltopdf.NetCore;

namespace MERMS.Controllers
{
    [Authorize]
    public class ConfiscationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        readonly IGeneratePdf _generatePdf;
        public ConfiscationsController(ApplicationDbContext context,IWebHostEnvironment hostEnvironment, IGeneratePdf generatePdf)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
            _generatePdf = generatePdf;
        }

        // GET: Confiscations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Confiscation.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Report(string jurisdiction, int yr)
        {

            var options = new CustomOptions
            {
                PageOrientation = Wkhtmltopdf.NetCore.Options.Orientation.Landscape
            };
            _generatePdf.SetConvertOptions(options);



            var data = new ConfiscationReportModel
            {
                Confiscations = _context.Confiscation.Where(m => m.Jurisdiction == jurisdiction && m.DateFiled.Value.Year == yr).ToList(),
                Jurisdiction = jurisdiction,
                Year = yr
            };
            return await _generatePdf.GetPdf("Views/Confiscations/Print.cshtml", data);
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
                    TrackingNo = model.TrackingNo,
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

        public async Task<IActionResult> ViewFile(int? id)
        {
            var model = await _context.Confiscation.FindAsync(id);


            var path = Path.Combine(webHostEnvironment.WebRootPath, "uploads", model.FilePath);
            var filePath = System.IO.File.OpenRead(path);
            return File(filePath, "application/pdf");
        }

        // GET: Confiscations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.Confiscation.FindAsync(id);
            ConfiscationViewModel vm = new ConfiscationViewModel
            {
                TrackingNo = model.TrackingNo,
                Jurisdiction = model.Jurisdiction,
                DateFiled = model.DateFiled,
                DocketCaseNo = model.DocketCaseNo,
                CaseTitleRespondent = model.CaseTitleRespondent,
                NatureOfViolation = model.NatureOfViolation,
                CourtFiled = model.CourtFiled,
                VehiclePlateNo = model.VehiclePlateNo,
                KindSpecies = model.KindSpecies,
                EstimatedValue = model.EstimatedValue,
                ForestProductStockPiled = model.ForestProductStockPiled,
                BoardFeet = model.BoardFeet,
                CubicMeter = model.CubicMeter,
                Status = model.Status,
                Remarks = model.Remarks,
                
            };
            if (model == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        // POST: Confiscations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ConfiscationViewModel model)
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
                    Confiscation data = new Confiscation
                    {
                        Id = model.Id,
                        TrackingNo = model.TrackingNo,
                        Jurisdiction = model.Jurisdiction,
                        DateFiled = model.DateFiled,
                        DocketCaseNo = model.DocketCaseNo,
                        CaseTitleRespondent = model.CaseTitleRespondent,
                        NatureOfViolation = model.NatureOfViolation,
                        CourtFiled = model.CourtFiled,
                        VehiclePlateNo = model.VehiclePlateNo,
                        KindSpecies = model.KindSpecies,
                        EstimatedValue = model.EstimatedValue,
                        ForestProductStockPiled = model.ForestProductStockPiled,
                        BoardFeet = model.BoardFeet,
                        CubicMeter = model.CubicMeter,
                        Status = model.Status,
                        Remarks = model.Remarks,
                        FilePath = uniqueFileName,
                    };

                    _context.Update(data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfiscationExists(model.Id))
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

        // GET: Confiscations/Delete/5
       
        // POST: Confiscations/Delete/5
       
        public async Task<IActionResult> Delete(int id)
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
