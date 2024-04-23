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
    public class JobsModelsController : Controller
    {
        private readonly AppDbContext _context;

        public JobsModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: JobsModels
        //public async Task<IActionResult> Index()
        //{
        //    var appDbContext = _context.jobs.Include(j => j.Category).Include(j => j.Corporation);
        //    return View(await appDbContext.ToListAsync());
        //}

        // GET: JobsModels/Details/5
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

        // GET: JobsModels/Create
        public IActionResult Create()
        {
            ViewData["Categoryid"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            ViewData["CorporationId"] = new SelectList(_context.corporations, "CorporationId", "CorporationId");
            return View();
        }

        // POST: JobsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobsModel jobsModel)
        {
            if (ModelState.IsValid)
            {
               

                _context.Add(jobsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categoryid"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", jobsModel.Categoryid);
            ViewData["CorporationId"] = new SelectList(_context.corporations, "CorporationId", "CorporationId", jobsModel.CorporationId);
            return View(jobsModel);
        }

        // GET: JobsModels/Edit/5
        public async Task<IActionResult> Edit(string? id)
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

        // POST: JobsModels/Edit/5
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

        // GET: JobsModels/Delete/5
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

        // POST: JobsModels/Delete/5
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
