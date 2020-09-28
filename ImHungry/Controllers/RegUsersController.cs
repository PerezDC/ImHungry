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
    public class RegUsersController : Controller
    {
        private readonly ImHungryDBContext _context;

        public RegUsersController(ImHungryDBContext context)
        {
            _context = context;
        }

        // GET: RegUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegUser.ToListAsync());
        }

        // GET: RegUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regUser = await _context.RegUser
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (regUser == null)
            {
                return NotFound();
            }

            return View(regUser);
        }

        // GET: RegUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserPassword,FirstName,LastName,SearchRadius")] RegUser regUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regUser);
        }

        // GET: RegUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regUser = await _context.RegUser.FindAsync(id);
            if (regUser == null)
            {
                return NotFound();
            }
            return View(regUser);
        }

        // POST: RegUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserPassword,FirstName,LastName,SearchRadius")] RegUser regUser)
        {
            if (id != regUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegUserExists(regUser.UserId))
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
            return View(regUser);
        }

        // GET: RegUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regUser = await _context.RegUser
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (regUser == null)
            {
                return NotFound();
            }

            return View(regUser);
        }

        // POST: RegUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regUser = await _context.RegUser.FindAsync(id);
            _context.RegUser.Remove(regUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegUserExists(int id)
        {
            return _context.RegUser.Any(e => e.UserId == id);
        }
    }
}
