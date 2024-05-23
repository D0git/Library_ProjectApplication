using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryClient.Data;
using LibraryClient.Models;

namespace LibraryClient.Controllers
{
    public class PaniersController : Controller
    {
        private readonly LibraryClientContext _context;

        public PaniersController(LibraryClientContext context)
        {
            _context = context;
        }

        // GET: Paniers
        public async Task<IActionResult> Index()
        {
            var libraryClientContext = _context.Paniers.Include(p => p.Adherent).Include(p => p.Livre);
            return View(await libraryClientContext.ToListAsync());
        }

        // GET: Paniers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panier = await _context.Paniers
                .Include(p => p.Adherent)
                .Include(p => p.Livre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panier == null)
            {
                return NotFound();
            }

            return View(panier);
        }

        // GET: Paniers/Create
        public IActionResult Create()
        {
            ViewData["AdherentId"] = new SelectList(_context.Set<Adherent>(), "Id", "Id");
            ViewData["LivreId"] = new SelectList(_context.Livres, "Id", "Id");
            return View();
        }

        // POST: Paniers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LivreId,AdherentId")] Panier panier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(panier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdherentId"] = new SelectList(_context.Set<Adherent>(), "Id", "Id", panier.AdherentId);
            ViewData["LivreId"] = new SelectList(_context.Livres, "Id", "Id", panier.LivreId);
            return View(panier);
        }

        // GET: Paniers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panier = await _context.Paniers.FindAsync(id);
            if (panier == null)
            {
                return NotFound();
            }
            ViewData["AdherentId"] = new SelectList(_context.Set<Adherent>(), "Id", "Id", panier.AdherentId);
            ViewData["LivreId"] = new SelectList(_context.Livres, "Id", "Id", panier.LivreId);
            return View(panier);
        }

        // POST: Paniers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LivreId,AdherentId")] Panier panier)
        {
            if (id != panier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(panier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PanierExists(panier.Id))
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
            ViewData["AdherentId"] = new SelectList(_context.Set<Adherent>(), "Id", "Id", panier.AdherentId);
            ViewData["LivreId"] = new SelectList(_context.Livres, "Id", "Id", panier.LivreId);
            return View(panier);
        }

        // GET: Paniers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panier = await _context.Paniers
                .Include(p => p.Adherent)
                .Include(p => p.Livre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panier == null)
            {
                return NotFound();
            }

            return View(panier);
        }

        // POST: Paniers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var panier = await _context.Paniers.FindAsync(id);
            if (panier != null)
            {
                _context.Paniers.Remove(panier);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PanierExists(int id)
        {
            return _context.Paniers.Any(e => e.Id == id);
        }
    }
}
