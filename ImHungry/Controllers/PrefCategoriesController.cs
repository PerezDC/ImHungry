using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImHungry.Models;

namespace ImHungry.Controllers
{
    public class PrefCategoriesController : Controller
    {
        private readonly ImHungryDBContext _context;

        public PrefCategoriesController(ImHungryDBContext context)
        {
            _context = context;
        }

        // GET: PrefCategories
        public async Task<IActionResult> Index()
        {
            var imHungryDBContext = _context.PrefCategories.Include(p => p.Category).Include(p => p.User);
            return View(await imHungryDBContext.ToListAsync());
        }

        // GET: PrefCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prefCategories = await _context.PrefCategories
                .Include(p => p.Category)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (prefCategories == null)
            {
                return NotFound();
            }

            return View(prefCategories);
        }

        // GET: PrefCategories/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.RestaurantCategories, "CategoryId", "CategoryName");
            ViewData["UserId"] = new SelectList(_context.RegUser, "UserId", "EmailAddress");
            return View();
        }

        // POST: PrefCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,CategoryId")] PrefCategories prefCategories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prefCategories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.RestaurantCategories, "CategoryId", "CategoryName", prefCategories.CategoryId);
            ViewData["UserId"] = new SelectList(_context.RegUser, "UserId", "EmailAddress", prefCategories.UserId);
            return View(prefCategories);
        }

        // GET: PrefCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prefCategories = await _context.PrefCategories.FindAsync(id);
            if (prefCategories == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.RestaurantCategories, "CategoryId", "CategoryName", prefCategories.CategoryId);
            ViewData["UserId"] = new SelectList(_context.RegUser, "UserId", "EmailAddress", prefCategories.UserId);
            return View(prefCategories);
        }

        // POST: PrefCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,CategoryId")] PrefCategories prefCategories)
        {
            if (id != prefCategories.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prefCategories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrefCategoriesExists(prefCategories.UserId))
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
            ViewData["CategoryId"] = new SelectList(_context.RestaurantCategories, "CategoryId", "CategoryName", prefCategories.CategoryId);
            ViewData["UserId"] = new SelectList(_context.RegUser, "UserId", "EmailAddress", prefCategories.UserId);
            return View(prefCategories);
        }

        // GET: PrefCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prefCategories = await _context.PrefCategories
                .Include(p => p.Category)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (prefCategories == null)
            {
                return NotFound();
            }

            return View(prefCategories);
        }

        // POST: PrefCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prefCategories = await _context.PrefCategories.FindAsync(id);
            _context.PrefCategories.Remove(prefCategories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrefCategoriesExists(int id)
        {
            return _context.PrefCategories.Any(e => e.UserId == id);
        }
    }
}
