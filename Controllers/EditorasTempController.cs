using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bookworm.Data;
using Bookworm.Models;

namespace Bookworm.Controllers
{
    public class EditorasTempController : Controller
    {
        private readonly ApplicationtDbContext _context;

        public EditorasTempController(ApplicationtDbContext context)
        {
            _context = context;
        }

        // GET: EditorasTemp
        public async Task<IActionResult> Index()
        {
              return View(await _context.Editora.ToListAsync());
        }

        // GET: EditorasTemp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Editora == null)
            {
                return NotFound();
            }

            var editora = await _context.Editora
                .FirstOrDefaultAsync(m => m.IdEditora == id);
            if (editora == null)
            {
                return NotFound();
            }

            return View(editora);
        }

        // GET: EditorasTemp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EditorasTemp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEditora,Nomefantasia,Endereco")] Editora editora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(editora);
        }

        // GET: EditorasTemp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Editora == null)
            {
                return NotFound();
            }

            var editora = await _context.Editora.FindAsync(id);
            if (editora == null)
            {
                return NotFound();
            }
            return View(editora);
        }

        // POST: EditorasTemp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEditora,Nomefantasia,Endereco")] Editora editora)
        {
            if (id != editora.IdEditora)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditoraExists(editora.IdEditora))
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
            return View(editora);
        }

        // GET: EditorasTemp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Editora == null)
            {
                return NotFound();
            }

            var editora = await _context.Editora
                .FirstOrDefaultAsync(m => m.IdEditora == id);
            if (editora == null)
            {
                return NotFound();
            }

            return View(editora);
        }

        // POST: EditorasTemp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Editora == null)
            {
                return Problem("Entity set 'ApplicationtDbContext.Editora'  is null.");
            }
            var editora = await _context.Editora.FindAsync(id);
            if (editora != null)
            {
                _context.Editora.Remove(editora);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditoraExists(int id)
        {
          return _context.Editora.Any(e => e.IdEditora == id);
        }
    }
}
