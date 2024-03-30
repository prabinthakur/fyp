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
    public class SkillsController : Controller
    {
        private readonly fypContext _context;

        public SkillsController(fypContext context)
        {
            _context = context;
        }

        // GET: Skills
        public async Task<IActionResult> Index()
        {
            var fypContext = _context.SkillsModel.Include(s => s.Jobs);
            return View(await fypContext.ToListAsync());
        }

        // GET: Skills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillsModel = await _context.SkillsModel
                .Include(s => s.Jobs)
                .FirstOrDefaultAsync(m => m.SkillId == id);
            if (skillsModel == null)
            {
                return NotFound();
            }

            return View(skillsModel);
        }

        // GET: Skills/Create
        public IActionResult Create()
        {
            ViewData["JobsId"] = new SelectList(_context.jobs, "JobId", "JobId");
            return View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkillId,SkillsTitle,JobsId")] SkillsModel skillsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skillsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobsId"] = new SelectList(_context.jobs, "JobId", "JobId", skillsModel.JobsId);
            return View(skillsModel);
        }

        // GET: Skills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillsModel = await _context.SkillsModel.FindAsync(id);
            if (skillsModel == null)
            {
                return NotFound();
            }
            ViewData["JobsId"] = new SelectList(_context.jobs, "JobId", "JobId", skillsModel.JobsId);
            return View(skillsModel);
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkillId,SkillsTitle,JobsId")] SkillsModel skillsModel)
        {
            if (id != skillsModel.SkillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skillsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillsModelExists(skillsModel.SkillId))
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
            ViewData["JobsId"] = new SelectList(_context.jobs, "JobId", "JobId", skillsModel.JobsId);
            return View(skillsModel);
        }

        // GET: Skills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skillsModel = await _context.SkillsModel
                .Include(s => s.Jobs)
                .FirstOrDefaultAsync(m => m.SkillId == id);
            if (skillsModel == null)
            {
                return NotFound();
            }

            return View(skillsModel);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skillsModel = await _context.SkillsModel.FindAsync(id);
            if (skillsModel != null)
            {
                _context.SkillsModel.Remove(skillsModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillsModelExists(int id)
        {
            return _context.SkillsModel.Any(e => e.SkillId == id);
        }
    }
}
