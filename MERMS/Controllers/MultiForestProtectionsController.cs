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
using Microsoft.AspNetCore.Http;
using MERMS.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace MERMS.Controllers
{
    public class MultiForestProtectionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public MultiForestProtectionsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
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
        public async Task<IActionResult> Create(MultiForestProtectionViewModel model)
        {
            if (ModelState.IsValid)
            {
                string letterOfInvitation = UploadedFile(model.LetterOfInvitation);
                string attendanceSheet = UploadedFile(model.AttendanceSheet);
                string minutesOfMeeting = UploadedFile(model.MinutesOfMeeting);
                string photoDocumentation = UploadedFile(model.PhotoDocumentation);
                MultiForestProtection data = new MultiForestProtection
                {
                    TrackingNo=model.TrackingNo,
                    DateOfMeeting=model.DateOfMeeting,
                    VenueOfMeeting=model.VenueOfMeeting,
                    NumberOfAttendees=model.NumberOfAttendees,
                    LetterOfInvitation = letterOfInvitation,
                    AttendanceSheet = attendanceSheet,
                    MinutesOfMeeting = minutesOfMeeting,
                    PhotoDocumentation = photoDocumentation,
                };

                _context.Add(data);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> LetterOfInvitation(int? id)
        {
            var model = await _context.MultiForestProtections.FindAsync(id);


            var path = Path.Combine(webHostEnvironment.WebRootPath, "uploads", model.LetterOfInvitation);
            var filePath = System.IO.File.OpenRead(path);
            return File(filePath, "application/pdf");
        }
        public async Task<IActionResult> AttendanceSheet(int? id)
        {
            var model = await _context.MultiForestProtections.FindAsync(id);


            var path = Path.Combine(webHostEnvironment.WebRootPath, "uploads", model.AttendanceSheet);
            var filePath = System.IO.File.OpenRead(path);
            return File(filePath, "application/pdf");
        }
        public async Task<IActionResult> MinutesOfMeeting(int? id)
        {
            var model = await _context.MultiForestProtections.FindAsync(id);


            var path = Path.Combine(webHostEnvironment.WebRootPath, "uploads", model.MinutesOfMeeting);
            var filePath = System.IO.File.OpenRead(path);
            return File(filePath, "application/pdf");
        }

        public async Task<IActionResult> PhotoDocumentation(int? id)
        {
            var model = await _context.MultiForestProtections.FindAsync(id);


            var path = Path.Combine(webHostEnvironment.WebRootPath, "uploads", model.PhotoDocumentation);
            var filePath = System.IO.File.OpenRead(path);
            return File(filePath, "application/pdf");
        }

        // GET: MultiForestProtections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.MultiForestProtections.FindAsync(id);
            MultiForestProtectionViewModel vm = new MultiForestProtectionViewModel
            {
                TrackingNo = model.TrackingNo,
                DateOfMeeting = model.DateOfMeeting,
                VenueOfMeeting = model.VenueOfMeeting,
                NumberOfAttendees = model.NumberOfAttendees,
                

            };
            if (model == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        // POST: MultiForestProtections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  MultiForestProtectionViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string letterOfInvitation = UploadedFile(model.LetterOfInvitation);
                    string attendanceSheet = UploadedFile(model.AttendanceSheet);
                    string minutesOfMeeting = UploadedFile(model.MinutesOfMeeting);
                    string photoDocumentation = UploadedFile(model.PhotoDocumentation);
                    MultiForestProtection data = new MultiForestProtection
                    {
                        Id = model.Id,
                        TrackingNo = model.TrackingNo,
                        DateOfMeeting = model.DateOfMeeting,
                        VenueOfMeeting = model.VenueOfMeeting,
                        NumberOfAttendees = model.NumberOfAttendees,
                        LetterOfInvitation = letterOfInvitation,
                        AttendanceSheet = attendanceSheet,
                        MinutesOfMeeting = minutesOfMeeting,
                        PhotoDocumentation = photoDocumentation,
                    };
                    _context.Update(data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MultiForestProtectionExists(model.Id))
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
            var multiForestProtection = await _context.MultiForestProtections.FindAsync(id);
            _context.MultiForestProtections.Remove(multiForestProtection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MultiForestProtectionExists(int id)
        {
            return _context.MultiForestProtections.Any(e => e.Id == id);
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
