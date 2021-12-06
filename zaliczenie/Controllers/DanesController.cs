using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using zaliczenie.Data;
using zaliczenie.Models;

namespace zaliczenie.Controllers
{
    public class DanesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DanesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Danes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dane.ToListAsync());
        }

        // GET: Danes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dane = await _context.Dane
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dane == null)
            {
                return NotFound();
            }

            return View(dane);
        }

        // GET: Danes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Danes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,plec,pas,masa,data")] Dane dane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dane);
        }

        // GET: Danes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dane = await _context.Dane.FindAsync(id);
            if (dane == null)
            {
                return NotFound();
            }
            return View(dane);
        }

        // POST: Danes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,plec,pas,masa,data")] Dane dane)
        {
            if (id != dane.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DaneExists(dane.Id))
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
            return View(dane);
        }

        // GET: Danes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dane = await _context.Dane
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dane == null)
            {
                return NotFound();
            }

            return View(dane);
        }

        // POST: Danes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dane = await _context.Dane.FindAsync(id);
            _context.Dane.Remove(dane);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DaneExists(int id)
        {
            return _context.Dane.Any(e => e.Id == id);
        }
    }
}
