using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _27112023.Data;
using _27112023.Models;

namespace _27112023.Controllers
{
    public class TesteViewModelsController : Controller
    {
        private readonly _27112023Context _context;

        public TesteViewModelsController(_27112023Context context)
        {
            _context = context;
        }

        // GET: TesteViewModels
        public async Task<IActionResult> Index()
        {
              return _context.TesteViewModel != null ? 
                          View(await _context.TesteViewModel.ToListAsync()) :
                          Problem("Entity set '_27112023Context.TesteViewModel'  is null.");
        }

        // GET: TesteViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TesteViewModel == null)
            {
                return NotFound();
            }

            var testeViewModel = await _context.TesteViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testeViewModel == null)
            {
                return NotFound();
            }

            return View(testeViewModel);
        }

        // GET: TesteViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TesteViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PosicaoMenu,Quantidade")] TesteViewModel testeViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testeViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testeViewModel);
        }

        // GET: TesteViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TesteViewModel == null)
            {
                return NotFound();
            }

            var testeViewModel = await _context.TesteViewModel.FindAsync(id);
            if (testeViewModel == null)
            {
                return NotFound();
            }
            return View(testeViewModel);
        }

        // POST: TesteViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PosicaoMenu,Quantidade")] TesteViewModel testeViewModel)
        {
            if (id != testeViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testeViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TesteViewModelExists(testeViewModel.Id))
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
            return View(testeViewModel);
        }

        // GET: TesteViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TesteViewModel == null)
            {
                return NotFound();
            }

            var testeViewModel = await _context.TesteViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testeViewModel == null)
            {
                return NotFound();
            }

            return View(testeViewModel);
        }

        // POST: TesteViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TesteViewModel == null)
            {
                return Problem("Entity set '_27112023Context.TesteViewModel'  is null.");
            }
            var testeViewModel = await _context.TesteViewModel.FindAsync(id);
            if (testeViewModel != null)
            {
                _context.TesteViewModel.Remove(testeViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TesteViewModelExists(int id)
        {
          return (_context.TesteViewModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
