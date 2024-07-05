using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School_Management.Data;
using School_Management.Models;

namespace School_Management.Controllers
{
    public class ExamModelsController : Controller
    {
        private readonly School_ManagementContext _context;

        public ExamModelsController(School_ManagementContext context)
        {
            _context = context;
        }

        // GET: ExamModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExamModel.ToListAsync());
        }

        // GET: ExamModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examModel = await _context.ExamModel
                .FirstOrDefaultAsync(m => m.subjectID == id);
            if (examModel == null)
            {
                return NotFound();
            }

            return View(examModel);
        }

        // GET: ExamModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExamModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("subjectID,subjectName,examDate,standard")] ExamModel examModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(examModel);
        }

        // GET: ExamModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examModel = await _context.ExamModel.FindAsync(id);
            if (examModel == null)
            {
                return NotFound();
            }
            return View(examModel);
        }

        // POST: ExamModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("subjectID,subjectName,examDate,standard")] ExamModel examModel)
        {
            if (id != examModel.subjectID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamModelExists(examModel.subjectID))
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
            return View(examModel);
        }

        // GET: ExamModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var examModel = await _context.ExamModel
                .FirstOrDefaultAsync(m => m.subjectID == id);
            if (examModel == null)
            {
                return NotFound();
            }

            return View(examModel);
        }

        // POST: ExamModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var examModel = await _context.ExamModel.FindAsync(id);
            if (examModel != null)
            {
                _context.ExamModel.Remove(examModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExamModelExists(int id)
        {
            return _context.ExamModel.Any(e => e.subjectID == id);
        }
    }
}
