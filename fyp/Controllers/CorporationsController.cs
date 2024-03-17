using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using fyp.Data;
using fyp.Models;

namespace fyp.Controllers
{
    public class CorporationsController : Controller
    {
        private readonly fypContext _context;

        public CorporationsController(fypContext context)
        {
            _context = context;
        }

        // GET: Corporations
        public async Task<IActionResult> Index()
        {
            return View(await _context.corporations.ToListAsync());
        }

        // GET: Corporations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corporation = await _context.corporations
                .FirstOrDefaultAsync(m => m.CorporationId == id);
            if (corporation == null)
            {
                return NotFound();
            }

            return View(corporation);
        }

        // GET: Corporations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Corporations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CorporationId,CorporationName,Location")] Corporation corporation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(corporation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(corporation);
        }

        // GET: Corporations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corporation = await _context.corporations.FindAsync(id);
            if (corporation == null)
            {
                return NotFound();
            }
            return View(corporation);
        }

        // POST: Corporations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CorporationId,CorporationName,Location")] Corporation corporation)
        {
            if (id != corporation.CorporationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(corporation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorporationExists(corporation.CorporationId))
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
            return View(corporation);
        }

        // GET: Corporations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corporation = await _context.corporations
                .FirstOrDefaultAsync(m => m.CorporationId == id);
            if (corporation == null)
            {
                return NotFound();
            }

            return View(corporation);
        }

        // POST: Corporations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var corporation = await _context.corporations.FindAsync(id);
            if (corporation != null)
            {
                _context.corporations.Remove(corporation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorporationExists(int id)
        {
            return _context.corporations.Any(e => e.CorporationId == id);
        }
    }
}
