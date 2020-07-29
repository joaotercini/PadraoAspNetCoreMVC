using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PadraoAspNetCoreMVC.Data;
using PadraoAspNetCoreMVC.Models;

namespace PadraoAspNetCoreMVC.Controllers
{
    [Authorize]
    public class RainfallsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RainfallsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rainfalls
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rainfalls.Include(r => r.Station);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rainfalls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rainfall = await _context.Rainfalls
                .Include(r => r.Station)
                .FirstOrDefaultAsync(m => m.StationId == id);
            if (rainfall == null)
            {
                return NotFound();
            }

            return View(rainfall);
        }

        // GET: Rainfalls/Create
        public IActionResult Create()
        {
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "Name");
            return View();
        }

        // POST: Rainfalls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StationId,Date,Value")] Rainfall rainfall)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rainfall);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "Name", rainfall.StationId);
            return View(rainfall);
        }

        // GET: Rainfalls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rainfall = await _context.Rainfalls.FindAsync(id);
            if (rainfall == null)
            {
                return NotFound();
            }
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "Name", rainfall.StationId);
            return View(rainfall);
        }

        // POST: Rainfalls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StationId,Date,Value")] Rainfall rainfall)
        {
            if (id != rainfall.StationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rainfall);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RainfallExists(rainfall.StationId))
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
            ViewData["StationId"] = new SelectList(_context.Stations, "StationId", "Name", rainfall.StationId);
            return View(rainfall);
        }

        // GET: Rainfalls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rainfall = await _context.Rainfalls
                .Include(r => r.Station)
                .FirstOrDefaultAsync(m => m.StationId == id);
            if (rainfall == null)
            {
                return NotFound();
            }

            return View(rainfall);
        }

        // POST: Rainfalls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rainfall = await _context.Rainfalls.FindAsync(id);
            _context.Rainfalls.Remove(rainfall);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RainfallExists(int id)
        {
            return _context.Rainfalls.Any(e => e.StationId == id);
        }
    }
}
