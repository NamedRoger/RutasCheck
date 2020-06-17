using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RutasCheck.Data;
using RutasCheck.Models;

namespace RutasCheck.Controllers
{
    public class ParadasController : Controller
    {
        private readonly RutasCheckContext _context;

        public ParadasController(RutasCheckContext context)
        {
            _context = context;
        }

        // GET: Paradas
        public async Task<IActionResult> Index()
        {
            var paradas = await _context.Paradas.Where(p => p.Borrado == false)
            .ToListAsync();
            
            return View(paradas);
        }

        public async Task<List<Parada>> GetParadas() 
        {
            var paradas = await _context.Paradas.Where(p => p.Borrado == false)
            .ToListAsync();

            return paradas;
        }

        // GET: Paradas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parada = await _context.Paradas
                .FirstOrDefaultAsync(m => m.IdParada == id);
            if (parada == null)
            {
                return NotFound();
            }

            return View(parada);
        }

        // GET: Paradas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paradas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdParada,NombreParada,Borrado")] Parada parada)
        {
            if (ModelState.IsValid)
            {
                parada.NombreNormalizado = parada.NombreParada.ToUpper();
                _context.Add(parada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parada);
        }

        // GET: Paradas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parada = await _context.Paradas.FindAsync(id);
            if (parada == null)
            {
                return NotFound();
            }
            return View(parada);
        }

        // POST: Paradas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdParada,NombreParada,Borrado")] Parada parada)
        {
            if (id != parada.IdParada)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    parada.NombreNormalizado = parada.NombreParada.ToUpper();
                    _context.Update(parada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParadaExists(parada.IdParada))
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
            return View(parada);
        }

        // GET: Paradas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parada = await _context.Paradas
                .FirstOrDefaultAsync(m => m.IdParada == id);
            if (parada == null)
            {
                return NotFound();
            }

            return View(parada);
        }

        // POST: Paradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parada = await _context.Paradas.FindAsync(id);
            parada.Borrado = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParadaExists(int id)
        {
            return _context.Paradas.Any(e => e.IdParada == id);
        }
    }
}
