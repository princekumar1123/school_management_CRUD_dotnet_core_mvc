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
    public class SchoolLoginModelsController : Controller
    {
        private readonly School_ManagementContext _context;

        public SchoolLoginModelsController(School_ManagementContext context)
        {
            _context = context;
        }

        // GET: SchoolLoginModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.SchoolLoginModel.ToListAsync());
        }

        // GET: SchoolLoginModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolLoginModel = await _context.SchoolLoginModel
                .FirstOrDefaultAsync(m => m.MyProperty == id);
            if (schoolLoginModel == null)
            {
                return NotFound();
            }

            return View(schoolLoginModel);
        }

        // GET: SchoolLoginModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SchoolLoginModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MyProperty,emailID,password")] SchoolLoginModel schoolLoginModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schoolLoginModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schoolLoginModel);
        }

        // GET: SchoolLoginModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolLoginModel = await _context.SchoolLoginModel.FindAsync(id);
            if (schoolLoginModel == null)
            {
                return NotFound();
            }
            return View(schoolLoginModel);
        }

        // POST: SchoolLoginModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MyProperty,emailID,password")] SchoolLoginModel schoolLoginModel)
        {
            if (id != schoolLoginModel.MyProperty)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolLoginModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolLoginModelExists(schoolLoginModel.MyProperty))
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
            return View(schoolLoginModel);
        }

        // GET: SchoolLoginModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolLoginModel = await _context.SchoolLoginModel
                .FirstOrDefaultAsync(m => m.MyProperty == id);
            if (schoolLoginModel == null)
            {
                return NotFound();
            }

            return View(schoolLoginModel);
        }

        // POST: SchoolLoginModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schoolLoginModel = await _context.SchoolLoginModel.FindAsync(id);
            if (schoolLoginModel != null)
            {
                _context.SchoolLoginModel.Remove(schoolLoginModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolLoginModelExists(int id)
        {
            return _context.SchoolLoginModel.Any(e => e.MyProperty == id);
        }
    }
}
