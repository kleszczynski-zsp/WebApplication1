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
    public class MarkiController : Controller
    {
        private readonly DataContext _context;

        public MarkiController(DataContext context)
        {
            _context = context;
        }

        // GET: Marki
        public async Task<IActionResult> Index()
        {
              return View(await _context.Marki.Where(x=>!x.IsDisabled).ToListAsync());
        }

        // GET: Marki/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Marki == null)
            {
                return NotFound();
            }

            var marka = await _context.Marki
                .FirstOrDefaultAsync(m => m.MarkaId == id);
            if (marka == null)
            {
                return NotFound();
            }

            return View(marka);
        }

        // GET: Marki/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marki/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Marka marka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marka);
        }

        // GET: Marki/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Marki == null)
            {
                return NotFound();
            }

            var marka = await _context.Marki.FindAsync(id);
            if (marka == null)
            {
                return NotFound();
            }
            return View(marka);
        }

        // POST: Marki/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Marka marka)
        {
            if (id != marka.MarkaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkaExists(marka.MarkaId))
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
            return View(marka);
        }

        // GET: Marki/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Marki == null)
            {
                return NotFound();
            }

            var marka = await _context.Marki
                .FirstOrDefaultAsync(m => m.MarkaId == id);
            if (marka == null)
            {
                return NotFound();
            }

            return View(marka);
        }

        // POST: Marki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Marki == null)
            {
                return Problem("Entity set 'DataContext.Marki'  is null.");
            }
            var marka = await _context.Marki.FindAsync(id);
            if (marka != null)
            {
                _context.Marki.Remove(marka);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkaExists(int id)
        {
          return (_context.Marki?.Any(e => e.MarkaId == id)).GetValueOrDefault();
        }
    }
}
