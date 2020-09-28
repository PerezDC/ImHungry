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
    public class VisitedRestaurantsController : Controller
    {
        private readonly ImHungryDBContext _context;

        public VisitedRestaurantsController(ImHungryDBContext context)
        {
            _context = context;
        }

        // GET: VisitedRestaurants
        public async Task<IActionResult> Index()
        {
            var imHungryDBContext = _context.VisitedRestaurant.Include(v => v.Rest).Include(v => v.User);
            return View(await imHungryDBContext.ToListAsync());
        }

        // GET: VisitedRestaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitedRestaurant = await _context.VisitedRestaurant
                .Include(v => v.Rest)
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (visitedRestaurant == null)
            {
                return NotFound();
            }

            return View(visitedRestaurant);
        }

        // GET: VisitedRestaurants/Create
        public IActionResult Create()
        {
            ViewData["RestId"] = new SelectList(_context.Restaurants, "RestId", "RestId");
            ViewData["UserId"] = new SelectList(_context.RegUser, "UserId", "EmailAddress");
            return View();
        }

        // POST: VisitedRestaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,RestId,UserLiked")] VisitedRestaurant visitedRestaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitedRestaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestId"] = new SelectList(_context.Restaurants, "RestId", "RestId", visitedRestaurant.RestId);
            ViewData["UserId"] = new SelectList(_context.RegUser, "UserId", "EmailAddress", visitedRestaurant.UserId);
            return View(visitedRestaurant);
        }

        // GET: VisitedRestaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitedRestaurant = await _context.VisitedRestaurant.FindAsync(id);
            if (visitedRestaurant == null)
            {
                return NotFound();
            }
            ViewData["RestId"] = new SelectList(_context.Restaurants, "RestId", "RestId", visitedRestaurant.RestId);
            ViewData["UserId"] = new SelectList(_context.RegUser, "UserId", "EmailAddress", visitedRestaurant.UserId);
            return View(visitedRestaurant);
        }

        // POST: VisitedRestaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,RestId,UserLiked")] VisitedRestaurant visitedRestaurant)
        {
            if (id != visitedRestaurant.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitedRestaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitedRestaurantExists(visitedRestaurant.UserId))
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
            ViewData["RestId"] = new SelectList(_context.Restaurants, "RestId", "RestId", visitedRestaurant.RestId);
            ViewData["UserId"] = new SelectList(_context.RegUser, "UserId", "EmailAddress", visitedRestaurant.UserId);
            return View(visitedRestaurant);
        }

        // GET: VisitedRestaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitedRestaurant = await _context.VisitedRestaurant
                .Include(v => v.Rest)
                .Include(v => v.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (visitedRestaurant == null)
            {
                return NotFound();
            }

            return View(visitedRestaurant);
        }

        // POST: VisitedRestaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitedRestaurant = await _context.VisitedRestaurant.FindAsync(id);
            _context.VisitedRestaurant.Remove(visitedRestaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitedRestaurantExists(int id)
        {
            return _context.VisitedRestaurant.Any(e => e.UserId == id);
        }
    }
}
