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
    public class QualificationController : Controller
    {
        private readonly fypContext _context;

        public QualificationController(fypContext context)
        {
            _context = context;
        }

        // GET: Qualification
        public async Task<IActionResult> Index()
        {
            var fypContext = _context.QualificationModel.Include(q => q.Student);
            return View(await fypContext.ToListAsync());
        }

        // GET: Qualification/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualificationModel = await _context.QualificationModel
                .Include(q => q.Student)
                .FirstOrDefaultAsync(m => m.QualificationId == id);
            if (qualificationModel == null)
            {
                return NotFound();
            }

            return View(qualificationModel);
        }

        // GET: Qualification/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.StudentModel, "StudentId", "StudentId");
            return View();
        }

        // POST: Qualification/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QualificationId,CurrentEducation,InstituteName,MajorSubject,CompletionYear,StudentId")] QualificationModel qualificationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qualificationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.StudentModel, "StudentId", "StudentId", qualificationModel.StudentId);
            return View(qualificationModel);
        }

        // GET: Qualification/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualificationModel = await _context.QualificationModel.FindAsync(id);
            if (qualificationModel == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.StudentModel, "StudentId", "StudentId", qualificationModel.StudentId);
            return View(qualificationModel);
        }

        // POST: Qualification/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QualificationId,CurrentEducation,InstituteName,MajorSubject,CompletionYear,StudentId")] QualificationModel qualificationModel)
        {
            if (id != qualificationModel.QualificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qualificationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QualificationModelExists(qualificationModel.QualificationId))
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
            ViewData["StudentId"] = new SelectList(_context.StudentModel, "StudentId", "StudentId", qualificationModel.StudentId);
            return View(qualificationModel);
        }

        // GET: Qualification/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualificationModel = await _context.QualificationModel
                .Include(q => q.Student)
                .FirstOrDefaultAsync(m => m.QualificationId == id);
            if (qualificationModel == null)
            {
                return NotFound();
            }

            return View(qualificationModel);
        }

        // POST: Qualification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qualificationModel = await _context.QualificationModel.FindAsync(id);
            if (qualificationModel != null)
            {
                _context.QualificationModel.Remove(qualificationModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QualificationModelExists(int id)
        {
            return _context.QualificationModel.Any(e => e.QualificationId == id);
        }
    }
}
