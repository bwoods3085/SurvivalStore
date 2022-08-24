using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuvivalStore.DATA.EF.Models;
using System.Drawing;
using X.PagedList;

namespace SurvivalStore.UI.MVC.Controllers
{
    public class GearsController : Controller
    {
        private readonly SurvivalStoreContext _context;

        public GearsController(SurvivalStoreContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET: Gears
        public async Task<IActionResult> Index()
        {
            var gear = _context.Gears
                
           .Include(g => g.Category).Include(g => g.Status).Include(g => g.OrderGears);
            return View(await gear.ToListAsync());
        }
        
        public async Task<IActionResult> TiledGears(string searchTerm, int categoryId = 0, int page = 1)
        {
            int pageSize = 5;

            var gear = _context.Gears
                .Include(g => g.Category)
                .Include(g => g.Status)
                .Include(g => g.OrderGears).ToList();

            #region Category Filter

            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");

            ViewBag.Category = 0;

            if (categoryId != 0)
            {
                gear = gear.Where(g => g.CategoryId == categoryId).ToList();

                ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
                ViewBag.Category = categoryId;
            }
            #endregion

            #region Search Filter

            if (!String.IsNullOrEmpty(searchTerm))
            {
                gear = gear.Where(g =>
                g.GearName.ToLower().Contains(searchTerm.ToLower()) ||
                g.Status.StatusName.ToLower().Contains(searchTerm.ToLower()) ||
                g.Category.CategoryName.ToLower().Contains(searchTerm.ToLower()) ||
                g.GearDescription.ToLower().Contains(searchTerm.ToLower())).ToList();

                ViewBag.NumResults = gear.Count;

                ViewBag.SearchTerm = searchTerm;
            }
            else
            {
                ViewBag.NumResults = null;
                ViewBag.SearchTerm = null;
            }
            #endregion


            return View(gear.ToPagedList(page, pageSize));
        }

        //GET: Gears/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gears == null)
            {
                return NotFound();
            }

            var gear = await _context.Gears
                .Include(g => g.Category)
                .Include(g => g.Status)
                .FirstOrDefaultAsync(m => m.GearId == id);
            if (gear == null)
            {
                return NotFound();
            }

            return View(gear);
        }

        // GET: Gears/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["StatusId"] = new SelectList(_context.GearStatuses, "StatusId", "StatusName");
            return View();
        }

        // POST: Gears/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("GearId,GearName,GearDescription,GearPrice,UnitsInStock,UnitsOnOrder,IsDiscontinued,CategoryId,StatusId,GearImage")] Gear gear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", gear.CategoryId);
            ViewData["StatusId"] = new SelectList(_context.GearStatuses, "StatusId", "StatusName", gear.StatusId);
            return View(gear);
        }

        // GET: Gears/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gears == null)
            {
                return NotFound();
            }

            var gear = await _context.Gears.FindAsync(id);
            if (gear == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", gear.CategoryId);
            ViewData["StatusId"] = new SelectList(_context.GearStatuses, "StatusId", "StatusName", gear.StatusId);
            return View(gear);
        }

        // POST: Gears/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("GearId,GearName,GearDescription,GearPrice,UnitsInStock,UnitsOnOrder,IsDiscontinued,CategoryId,StatusId,GearImage")] Gear gear)
        {
            if (id != gear.GearId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GearExists(gear.GearId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", gear.CategoryId);
            ViewData["StatusId"] = new SelectList(_context.GearStatuses, "StatusId", "StatusName", gear.StatusId);
            return View(gear);
        }

        // GET: Gears/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gears == null)
            {
                return NotFound();
            }

            var gear = await _context.Gears
                .Include(g => g.Category)
                .Include(g => g.Status)
                .FirstOrDefaultAsync(m => m.GearId == id);
            if (gear == null)
            {
                return NotFound();
            }

            return View(gear);
        }

        // POST: Gears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gears == null)
            {
                return Problem("Entity set 'SurvivalStoreContext.Gears'  is null.");
            }
            var gear = await _context.Gears.FindAsync(id);
            if (gear != null)
            {
                _context.Gears.Remove(gear);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GearExists(int id)
        {
          return (_context.Gears?.Any(e => e.GearId == id)).GetValueOrDefault();
        }
    }
}
