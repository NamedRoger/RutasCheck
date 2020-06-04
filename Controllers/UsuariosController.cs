using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RutasCheck.Data;
using RutasCheck.Helpers;
using RutasCheck.Models;
using RutasCheck.Models.ViewModels;

namespace RutasCheck.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UsuariosController : Controller
    {
        private readonly RutasCheckContext _context;
        private readonly IUserHelper _userHelper;

        public UsuariosController(RutasCheckContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var rutasCheckContext = _context.Usuarios.Where(u => u.IsDelete == false)
                .Include(u => u.IdRutaNavigation)
                .Include(u => u.UsuariosHasRoles);

            
            return View(await rutasCheckContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.IdRutaNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["IdRuta"] = new SelectList(_context.Rutas, "IdRuta", "IdRuta");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Nombre,UserName,Password,ConfirmPassword,IdRuta,Activo")] Usuario usuario)
        {
            // Se verifica si el usuairo existe o no
            var verifyUser = _userHelper.FindByUserName(usuario.UserName);
            if (verifyUser != null)
            {
                //si el usuario existe, añande un error al estado del modelo
                ModelState.AddModelError("UserName", "El Usuario ya existe");
            }

            // se verifica el estado del modelo 
            if (ModelState.IsValid)
            {
                usuario.transformUserNameLowered();
                usuario.Password = Hash.GetSha256(usuario.Password);
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            ViewData["IdRuta"] = new SelectList(_context.Rutas, "IdRuta", "IdRuta", usuario.IdRuta);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            ViewData["IdRuta"] = new SelectList(_context.Rutas, "IdRuta", "IdRuta", usuario.IdRuta);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdUsuario,Nombre,UserName,IdRuta,Activo")] ViewModelUser usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            var verifyUser = _userHelper.FindByUserName(usuario.UserName);
            if (verifyUser != null)
            {
                if (verifyUser.UserNameLowered != usuario.UserName.ToLower())
                {
                    //si el usuario existe, añande un error al e9stado del modelo
                    ModelState.AddModelError("UserName", "El Usuario ya existe");
                } 
            }


            if (ModelState.IsValid)
            {
                try
                {
                    await _userHelper.Update(usuario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
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
            ViewData["IdRuta"] = new SelectList(_context.Rutas, "IdRuta", "IdRuta", usuario.IdRuta);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.IdRutaNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            usuario.IsDelete = true;
            _context.Entry<Usuario>(usuario).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(long id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
