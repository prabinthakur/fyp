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
    public class VaccanciesController : Controller
    {
        private readonly fypContext _context;

        public VaccanciesController(fypContext context)
        {
            _context = context;
        }

        // GET: Vaccancies
        public async Task<IActionResult> Index()
        {
            var fypContext = _context.Vaccancy.Include(v => v.Category);
            return View(await fypContext.ToListAsync());
        }

        // GET: Vaccancies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccancy = await _context.Vaccancy
                .Include(v => v.Category)
                .FirstOrDefaultAsync(m => m.VaccancyID == id);
            if (vaccancy == null)
            {
                return NotFound();
            }

            return View(vaccancy);
        }

        // GET: Vaccancies/Create
        public IActionResult Create()
        {
            ViewData["vaccancytype"] = new SelectList(_context.Category, "ID", "Name");
            return View();
        }

        // POST: Vaccancies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VaccancyID,vaccancytype,VaccancyName,PostedDate")] Vaccancy vaccancy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccancy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["vaccancytype"] = new SelectList(_context.Category, "ID", "name", vaccancy.vaccancytype);
            return View(vaccancy);
        }

        // GET: Vaccancies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccancy = await _context.Vaccancy.FindAsync(id);
            if (vaccancy == null)
            {
                return NotFound();
            }
            ViewData["vaccancytype"] = new SelectList(_context.Category, "ID", "ID", vaccancy.vaccancytype);
            return View(vaccancy);
        }

        // POST: Vaccancies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VaccancyID,vaccancytype,VaccancyName,PostedDate")] Vaccancy vaccancy)
        {
            if (id != vaccancy.VaccancyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccancy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccancyExists(vaccancy.VaccancyID))
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
            ViewData["vaccancytype"] = new SelectList(_context.Category, "ID", "ID", vaccancy.vaccancytype);
            return View(vaccancy);
        }

        // GET: Vaccancies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccancy = await _context.Vaccancy
                .Include(v => v.Category)
                .FirstOrDefaultAsync(m => m.VaccancyID == id);
            if (vaccancy == null)
            {
                return NotFound();
            }

            return View(vaccancy);
        }

        // POST: Vaccancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaccancy = await _context.Vaccancy.FindAsync(id);
            if (vaccancy != null)
            {
                _context.Vaccancy.Remove(vaccancy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaccancyExists(int id)
        {
            return _context.Vaccancy.Any(e => e.VaccancyID == id);
        }
    }
}
