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
    public class SchoolRegisterModelsController : Controller
    {
        private readonly School_ManagementContext _context;

        public SchoolRegisterModelsController(School_ManagementContext context)
        {
            _context = context;
        }

        // GET: SchoolRegisterModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.SchoolRegisterModel.ToListAsync());
        }

        // GET: SchoolRegisterModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolRegisterModel = await _context.SchoolRegisterModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (schoolRegisterModel == null)
            {
                return NotFound();
            }

            return View(schoolRegisterModel);
        }

        // GET: SchoolRegisterModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SchoolRegisterModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,emailID,password,phoneNumber")] SchoolRegisterModel schoolRegisterModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schoolRegisterModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schoolRegisterModel);
        }

        // GET: SchoolRegisterModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolRegisterModel = await _context.SchoolRegisterModel.FindAsync(id);
            if (schoolRegisterModel == null)
            {
                return NotFound();
            }
            return View(schoolRegisterModel);
        }

        // POST: SchoolRegisterModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,emailID,password,phoneNumber")] SchoolRegisterModel schoolRegisterModel)
        {
            if (id != schoolRegisterModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolRegisterModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolRegisterModelExists(schoolRegisterModel.id))
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
            return View(schoolRegisterModel);
        }

        // GET: SchoolRegisterModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schoolRegisterModel = await _context.SchoolRegisterModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (schoolRegisterModel == null)
            {
                return NotFound();
            }

            return View(schoolRegisterModel);
        }

        // POST: SchoolRegisterModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schoolRegisterModel = await _context.SchoolRegisterModel.FindAsync(id);
            if (schoolRegisterModel != null)
            {
                _context.SchoolRegisterModel.Remove(schoolRegisterModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolRegisterModelExists(int id)
        {
            return _context.SchoolRegisterModel.Any(e => e.id == id);
        }
    }
}
