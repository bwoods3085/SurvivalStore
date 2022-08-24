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
    public class OrderGearsController : Controller
    {
        private readonly SurvivalStoreContext _context;

        public OrderGearsController(SurvivalStoreContext context)
        {
            _context = context;
        }

        // GET: OrderGears
        public async Task<IActionResult> Index()
        {
            var survivalStoreContext = _context.OrderGears.Include(o => o.Gear).Include(o => o.Order);
            return View(await survivalStoreContext.ToListAsync());
        }

        // GET: OrderGears/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderGears == null)
            {
                return NotFound();
            }

            var orderGear = await _context.OrderGears
                .Include(o => o.Gear)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderGearId == id);
            if (orderGear == null)
            {
                return NotFound();
            }

            return View(orderGear);
        }

        // GET: OrderGears/Create
        public IActionResult Create()
        {
            ViewData["GearId"] = new SelectList(_context.Gears, "GearId", "GearName");
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "UserId");
            return View();
        }

        // POST: OrderGears/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderGearId,GearId,OrderId,Quantity,GearPrice")] OrderGear orderGear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderGear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GearId"] = new SelectList(_context.Gears, "GearId", "GearName", orderGear.GearId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "UserId", orderGear.OrderId);
            return View(orderGear);
        }

        // GET: OrderGears/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderGears == null)
            {
                return NotFound();
            }

            var orderGear = await _context.OrderGears.FindAsync(id);
            if (orderGear == null)
            {
                return NotFound();
            }
            ViewData["GearId"] = new SelectList(_context.Gears, "GearId", "GearName", orderGear.GearId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "UserId", orderGear.OrderId);
            return View(orderGear);
        }

        // POST: OrderGears/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderGearId,GearId,OrderId,Quantity,GearPrice")] OrderGear orderGear)
        {
            if (id != orderGear.OrderGearId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderGear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderGearExists(orderGear.OrderGearId))
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
            ViewData["GearId"] = new SelectList(_context.Gears, "GearId", "GearName", orderGear.GearId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "UserId", orderGear.OrderId);
            return View(orderGear);
        }

        // GET: OrderGears/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderGears == null)
            {
                return NotFound();
            }

            var orderGear = await _context.OrderGears
                .Include(o => o.Gear)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderGearId == id);
            if (orderGear == null)
            {
                return NotFound();
            }

            return View(orderGear);
        }

        // POST: OrderGears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderGears == null)
            {
                return Problem("Entity set 'SurvivalStoreContext.OrderGears'  is null.");
            }
            var orderGear = await _context.OrderGears.FindAsync(id);
            if (orderGear != null)
            {
                _context.OrderGears.Remove(orderGear);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderGearExists(int id)
        {
          return (_context.OrderGears?.Any(e => e.OrderGearId == id)).GetValueOrDefault();
        }
    }
}
