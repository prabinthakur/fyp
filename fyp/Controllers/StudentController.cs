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
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

       

        public StudentController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentModel.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentModel
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentModel == null)
            {
                return NotFound();
            }

            return View(studentModel);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentModel studentModel,IFormFile file, IFormFile file2)
        {


        


            string FileUpload = Path.Combine(_webHostEnvironment.WebRootPath, "FileFolder");
            if (!Directory.Exists(FileUpload))
            {


                Directory.CreateDirectory(FileUpload);

            }
            string filepath=Path.Combine(FileUpload, file.FileName);
            using(var filestream= new FileStream(filepath,FileMode.Create))
            {
                file.CopyTo(filestream);

                studentModel.Resume = "/FileUpload/" + file.FileName;


            }


            string ImageUpload = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

            string ImagePath = Path.Combine(ImageUpload, file2.FileName);

            using(var Filestream=new FileStream(ImagePath,FileMode.Create))
            {
                file2.CopyTo(Filestream);
                studentModel.ImageUrl = "/uploads/" + file2.FileName;
            }


            


            if (ModelState.IsValid)
            {
                studentModel.Resume="/FileUpload/" + file.FileName;
                studentModel.ImageUrl="/uploads/" + file2.FileName;
                _context.Add(studentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View(studentModel);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentModel.FindAsync(id);
            if (studentModel == null)
            {
                return NotFound();
            }
            return View(studentModel);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,FullName,Email,PhoneNo,Address,Resume")] StudentModel studentModel)
        {
            if (id != studentModel.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentModelExists(studentModel.StudentId))
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
            return View(studentModel);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentModel
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentModel == null)
            {
                return NotFound();
            }

            return View(studentModel);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentModel = await _context.StudentModel.FindAsync(id);
            if (studentModel != null)
            {
                _context.StudentModel.Remove(studentModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentModelExists(int id)
        {
            return _context.StudentModel.Any(e => e.StudentId == id);
        }
    }
}
