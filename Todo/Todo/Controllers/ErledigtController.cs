using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
    public class ErledigtController : Controller
    {
        private readonly TodoContext _context;

        public ErledigtController(TodoContext context)
        {
            _context = context;
        }

        // GET: Erledigt
        public async Task<IActionResult> Index()
        {
              return _context.Aufgabe != null ? 
                          View(await _context.Aufgabe.ToListAsync()) :
                          Problem("Entity set 'TodoContext.Aufgabe'  is null.");
        }

        // GET: Erledigt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aufgabe == null)
            {
                return NotFound();
            }

            var aufgabe = await _context.Aufgabe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aufgabe == null)
            {
                return NotFound();
            }

            return View(aufgabe);
        }


        // GET: Erledigt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aufgabe == null)
            {
                return NotFound();
            }

            var aufgabe = await _context.Aufgabe.FindAsync(id);
            if (aufgabe == null)
            {
                return NotFound();
            }
            return View(aufgabe);
        }

        // POST: Erledigt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BeschreibungText,AbgabeTime,Erledigt")] Aufgabe aufgabe)
        {
            if (id != aufgabe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aufgabe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AufgabeExists(aufgabe.Id))
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
            return View(aufgabe);
        }

        // GET: Erledigt/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aufgabe == null)
            {
                return NotFound();
            }

            var aufgabe = await _context.Aufgabe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aufgabe == null)
            {
                return NotFound();
            }

            return View(aufgabe);
        }

        // POST: Erledigt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aufgabe == null)
            {
                return Problem("Entity set 'TodoContext.Aufgabe'  is null.");
            }
            var aufgabe = await _context.Aufgabe.FindAsync(id);
            if (aufgabe != null)
            {
                _context.Aufgabe.Remove(aufgabe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AufgabeExists(int id)
        {
          return (_context.Aufgabe?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
