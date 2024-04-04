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
    public class JobsController : Controller
    {
        private readonly fypContext _context;

        public JobsController(fypContext context)
        {
            _context = context;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            var fypContext = _context.jobs.Include(j => j.Category).Include(j => j.Corporation);
            return View(await fypContext.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobsModel = await _context.jobs
                .Include(j => j.Category)
                .Include(j => j.Corporation)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (jobsModel == null)
            {
                return NotFound();
            }

            return View(jobsModel);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            ViewData["Categoryid"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["CorporationId"] = new SelectList(_context.corporations, "CorporationId", "CorporationName");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,JobName,Location,Description,Requirement,Salary,PostedDate,Deadline,Categoryid,CorporationId")] JobsModel jobsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categoryid"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", jobsModel.Categoryid);
            ViewData["CorporationId"] = new SelectList(_context.corporations, "CorporationId", "CorporationName", jobsModel.CorporationId);
            return View(jobsModel);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobsModel = await _context.jobs.FindAsync(id);
            if (jobsModel == null)
            {
                return NotFound();
            }
            ViewData["Categoryid"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", jobsModel.Categoryid);
            ViewData["CorporationId"] = new SelectList(_context.corporations, "CorporationId", "CorporationId", jobsModel.CorporationId);
            return View(jobsModel);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobId,JobName,Location,Description,Requirement,Salary,PostedDate,Deadline,Categoryid,CorporationId")] JobsModel jobsModel)
        {
            if (id != jobsModel.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobsModelExists(jobsModel.JobId))
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
            ViewData["Categoryid"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", jobsModel.Categoryid);
            ViewData["CorporationId"] = new SelectList(_context.corporations, "CorporationId", "CorporationId", jobsModel.CorporationId);
            return View(jobsModel);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobsModel = await _context.jobs
                .Include(j => j.Category)
                .Include(j => j.Corporation)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (jobsModel == null)
            {
                return NotFound();
            }

            return View(jobsModel);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobsModel = await _context.jobs.FindAsync(id);
            if (jobsModel != null)
            {
                _context.jobs.Remove(jobsModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobsModelExists(int id)
        {
            return _context.jobs.Any(e => e.JobId == id);
        }
    }
}
