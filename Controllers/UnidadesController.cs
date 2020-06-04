using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RutasCheck.Data;
using RutasCheck.Models;

namespace RutasCheck.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UnidadesController : Controller
    {
        private readonly RutasCheckContext _context;

        public UnidadesController(RutasCheckContext context)
        {
            _context = context;

        }

        // GET: Unidades
        public async Task<IActionResult> Index()
        {
            return View(await this.Unidades());
        }

        // GET: Unidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidades
                .Include(u => u.IdConcecionarioNavigation)
                .Include(u => u.IdPropietarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUnidad == id);
            if (unidad == null)
            {
                return NotFound();
            }

            return View(unidad);
        }

        // GET: Unidades/Create
        public async Task<IActionResult> Create()
        {
            ViewData["IdConcecionario"] = new SelectList(await this.Concecionarios(), "IdConcecionario", "Nombre");
            ViewData["IdPropiedatrio"] = new SelectList(await this.Concecionarios(), "IdConcecionario", "Nombre");
            return View();
        }

        // POST: Unidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUnidad,IdConcecionario,NumeroEconomico,IdPropiedatrio,Placa")] Unidad unidad)
        {
            if (ModelState.IsValid)
            {
                unidad.Placa = unidad.Placa.ToUpper();
                _context.Add(unidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdConcecionario"] = new SelectList(await this.Concecionarios(), "IdConcecionario", "Nombre", unidad.IdConcecionario);
            ViewData["IdPropiedatrio"] = new SelectList(await this.Concecionarios(), "IdConcecionario", "Nombre", unidad.IdPropiedatrio);
            return View(unidad);
        }

        // GET: Unidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidades.FindAsync(id);
            if (unidad == null)
            {
                return NotFound();
            }
            ViewData["IdConcecionario"] = new SelectList(await this.Concecionarios(), "IdConcecionario", "Nombre", unidad.IdConcecionario);
            ViewData["IdPropiedatrio"] = new SelectList(await this.Concecionarios(), "IdConcecionario", "Nombre", unidad.IdPropiedatrio);
            return View(unidad);
        }

        // POST: Unidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUnidad,IdConcecionario,NumeroEconomico,IdPropiedatrio,Placa")] Unidad unidad)
        {
            if (id != unidad.IdUnidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    unidad.Placa = unidad.Placa.ToUpper();

                    _context.Update(unidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadExists(unidad.IdUnidad))
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
            ViewData["IdConcecionario"] = new SelectList(await this.Concecionarios(), "IdConcecionario", "Nombre", unidad.IdConcecionario);
            ViewData["IdPropiedatrio"] = new SelectList(await this.Concecionarios(), "IdConcecionario", "Nombre", unidad.IdPropiedatrio);
            return View(unidad);
        }

        // GET: Unidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad = await _context.Unidades
                .Include(u => u.IdConcecionarioNavigation)
                .Include(u => u.IdPropietarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUnidad == id);
            if (unidad == null)
            {
                return NotFound();
            }

            return View(unidad);
        }

        // POST: Unidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidad = await _context.Unidades.FindAsync(id);
            unidad.IsDelete = true;
            _context.Entry<Unidad>(unidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadExists(int id)
        {
            return _context.Unidades.Any(e => e.IdUnidad == id);
        }

        public async Task<ICollection<Unidad>> Unidades()
        {
            var unidades = _context.Unidades.Where(u => u.IsDelete == false)
                .Include(u => u.IdConcecionarioNavigation)
                .Include(u => u.IdPropietarioNavigation);
            return await unidades.ToListAsync();
        }

        private async Task<IEnumerable<Concecionario>> Concecionarios()
        {
            var concecionarios = await _context.Concecionarios.Where(c => c.IsDelete == false).ToListAsync();
            return concecionarios;
        }
    }
}
