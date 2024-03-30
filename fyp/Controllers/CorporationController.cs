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
    public class CorporationController : Controller
    {
        private readonly fypContext _context;

        public CorporationController(fypContext context)
        {
            _context = context;
        }

        // GET: Corporation
        public async Task<IActionResult> Index()
        {
            return View(await _context.corporations.ToListAsync());
        }

        // GET: Corporation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corporationModel = await _context.corporations
                .FirstOrDefaultAsync(m => m.CorporationId == id);
            if (corporationModel == null)
            {
                return NotFound();
            }

            return View(corporationModel);
        }

        // GET: Corporation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Corporation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CorporationId,CorporationName,CorporationDescription,CorporationLocation,CorporationUrl")] CorporationModel corporationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(corporationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(corporationModel);
        }

        // GET: Corporation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corporationModel = await _context.corporations.FindAsync(id);
            if (corporationModel == null)
            {
                return NotFound();
            }
            return View(corporationModel);
        }

        // POST: Corporation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CorporationId,CorporationName,CorporationDescription,CorporationLocation,CorporationUrl")] CorporationModel corporationModel)
        {
            if (id != corporationModel.CorporationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(corporationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CorporationModelExists(corporationModel.CorporationId))
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
            return View(corporationModel);
        }

        // GET: Corporation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corporationModel = await _context.corporations
                .FirstOrDefaultAsync(m => m.CorporationId == id);
            if (corporationModel == null)
            {
                return NotFound();
            }

            return View(corporationModel);
        }

        // POST: Corporation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var corporationModel = await _context.corporations.FindAsync(id);
            if (corporationModel != null)
            {
                _context.corporations.Remove(corporationModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorporationModelExists(int id)
        {
            return _context.corporations.Any(e => e.CorporationId == id);
        }
    }
}
