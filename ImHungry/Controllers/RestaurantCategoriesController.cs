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
    public class RestaurantCategoriesController : Controller
    {
        private readonly ImHungryDBContext _context;

        public RestaurantCategoriesController(ImHungryDBContext context)
        {
            _context = context;
        }

        // GET: RestaurantCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.RestaurantCategories.ToListAsync());
        }

        // GET: RestaurantCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantCategories = await _context.RestaurantCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (restaurantCategories == null)
            {
                return NotFound();
            }

            return View(restaurantCategories);
        }

        // GET: RestaurantCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RestaurantCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName")] RestaurantCategories restaurantCategories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurantCategories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurantCategories);
        }

        // GET: RestaurantCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantCategories = await _context.RestaurantCategories.FindAsync(id);
            if (restaurantCategories == null)
            {
                return NotFound();
            }
            return View(restaurantCategories);
        }

        // POST: RestaurantCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName")] RestaurantCategories restaurantCategories)
        {
            if (id != restaurantCategories.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurantCategories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantCategoriesExists(restaurantCategories.CategoryId))
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
            return View(restaurantCategories);
        }

        // GET: RestaurantCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurantCategories = await _context.RestaurantCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (restaurantCategories == null)
            {
                return NotFound();
            }

            return View(restaurantCategories);
        }

        // POST: RestaurantCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurantCategories = await _context.RestaurantCategories.FindAsync(id);
            _context.RestaurantCategories.Remove(restaurantCategories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantCategoriesExists(int id)
        {
            return _context.RestaurantCategories.Any(e => e.CategoryId == id);
        }
    }
}
