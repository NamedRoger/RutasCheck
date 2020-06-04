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
    public class ConcecionariosController : Controller
    {
        
        private readonly RutasCheckContext _context;
        [TempData]
        private string Mensaje { get; set; }

        public ConcecionariosController(RutasCheckContext context)
        {
            _context = context;
        }

        // GET: Concecionarios
        public async Task<IActionResult> Index()
        {
            var concecionarios = await _context.Concecionarios.Where(c => c.IsDelete == false).ToListAsync();
            return View(concecionarios);
        }

        // GET: Concecionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concecionario = await _context.Concecionarios
                .FirstOrDefaultAsync(m => m.IdConcecionario == id);
            if (concecionario == null)
            {
                return NotFound();
            }

            return View(concecionario);
        }

        // GET: Concecionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Concecionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConcecionario,Nombre")] Concecionario concecionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(concecionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concecionario);
        }

        // GET: Concecionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concecionario = await _context.Concecionarios.FindAsync(id);
            if (concecionario == null)
            {
                return NotFound();
            }
            return View(concecionario);
        }

        // POST: Concecionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConcecionario,Nombre")] Concecionario concecionario)
        {
            if (id != concecionario.IdConcecionario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concecionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcecionarioExists(concecionario.IdConcecionario))
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
            return View(concecionario);
        }

        // GET: Concecionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concecionario = await _context.Concecionarios
                .FirstOrDefaultAsync(m => m.IdConcecionario == id);
            if (concecionario == null)
            {
                return NotFound();
            }

            return View(concecionario);
        }

        // POST: Concecionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concecionario = await _context.Concecionarios.FindAsync(id);
            concecionario.IsDelete = true;
            _context.Entry<Concecionario>(concecionario).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            //return Ok(concecionario);
            return RedirectToAction("Index");
        }

        private bool ConcecionarioExists(int id)
        {
            return _context.Concecionarios.Any(e => e.IdConcecionario == id);
        }
    }
}
