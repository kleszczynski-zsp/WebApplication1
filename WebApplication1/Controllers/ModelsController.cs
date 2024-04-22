using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.DB;

namespace WebApplication1.Controllers
{
    public class ModelsController : Controller
    {
        private readonly DataContext _context;

        public ModelsController(DataContext context)
        {
            _context = context;
        }

        // GET: Models
        public async Task<IActionResult> Index()
        {
              return _context.Modele != null ? 
                          View(await _context.Modele.ToListAsync()) :
                          Problem("Entity set 'DataContext.Modele'  is null.");
        }

        // GET: Models/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Modele == null)
            {
                return NotFound();
            }

            var model = await _context.Modele
                .FirstOrDefaultAsync(m => m.ModelId == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: Models/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Models/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModelId,NazwaModelu")] Model model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Models/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Modele == null)
            {
                return NotFound();
            }

            var model = await _context.Modele.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Models/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModelId,NazwaModelu")] Model model)
        {
            if (id != model.ModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelExists(model.ModelId))
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
            return View(model);
        }

        // GET: Models/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Modele == null)
            {
                return NotFound();
            }

            var model = await _context.Modele
                .FirstOrDefaultAsync(m => m.ModelId == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Modele == null)
            {
                return Problem("Entity set 'DataContext.Modele'  is null.");
            }
            var model = await _context.Modele.FindAsync(id);
            if (model != null)
            {
                _context.Modele.Remove(model);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelExists(int id)
        {
          return (_context.Modele?.Any(e => e.ModelId == id)).GetValueOrDefault();
        }
    }
}
