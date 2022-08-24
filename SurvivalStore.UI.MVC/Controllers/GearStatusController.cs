using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuvivalStore.DATA.EF.Models;

namespace SurvivalStore.UI.MVC.Controllers
{
    public class GearStatusController : Controller
    {
        private readonly SurvivalStoreContext _context;

        public GearStatusController(SurvivalStoreContext context)
        {
            _context = context;
        }

        // GET: GearStatus
        public async Task<IActionResult> Index()
        {
              return _context.GearStatuses != null ? 
                          View(await _context.GearStatuses.ToListAsync()) :
                          Problem("Entity set 'SurvivalStoreContext.GearStatuses'  is null.");
        }

        // GET: GearStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GearStatuses == null)
            {
                return NotFound();
            }

            var gearStatus = await _context.GearStatuses
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (gearStatus == null)
            {
                return NotFound();
            }

            return View(gearStatus);
        }

        // GET: GearStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GearStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusId,StatusName")] GearStatus gearStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gearStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gearStatus);
        }

        // GET: GearStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GearStatuses == null)
            {
                return NotFound();
            }

            var gearStatus = await _context.GearStatuses.FindAsync(id);
            if (gearStatus == null)
            {
                return NotFound();
            }
            return View(gearStatus);
        }

        // POST: GearStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusId,StatusName")] GearStatus gearStatus)
        {
            if (id != gearStatus.StatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gearStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GearStatusExists(gearStatus.StatusId))
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
            return View(gearStatus);
        }

        // GET: GearStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GearStatuses == null)
            {
                return NotFound();
            }

            var gearStatus = await _context.GearStatuses
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (gearStatus == null)
            {
                return NotFound();
            }

            return View(gearStatus);
        }

        // POST: GearStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GearStatuses == null)
            {
                return Problem("Entity set 'SurvivalStoreContext.GearStatuses'  is null.");
            }
            var gearStatus = await _context.GearStatuses.FindAsync(id);
            if (gearStatus != null)
            {
                _context.GearStatuses.Remove(gearStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GearStatusExists(int id)
        {
          return (_context.GearStatuses?.Any(e => e.StatusId == id)).GetValueOrDefault();
        }
    }
}
