using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using RutasCheck.Data;
using RutasCheck.Models;
using RutasCheck.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RutasCheck.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly RutasCheckContext _context;
        public UserHelper(RutasCheckContext context)
        {
            _context = context;
        }

        public Usuario FindByUserName(string userName)
        {
            var verifyUser = _context.Usuarios.Where(u => u.UserNameLowered == userName.ToLower())
                .FirstOrDefault();
            if (verifyUser != null)
            {
                return verifyUser;
            }

            return null;
        }

        public async  Task<List<UsuarioHasRol>> GetRoles(Usuario usuario){
           var usuariosRoles = await _context.UsuariosHasRoles.Include(ur => ur.RolesIdRolNavigation)
                                            .Where(ur => ur.IdUsuario == usuario.IdUsuario)
                                            .ToListAsync();
            return usuariosRoles;
        }


        public async Task SigInAsyc(Controller controller, Usuario usuairo,bool isPersistentCoockie)
        {
            // usuario para buscar los roles
            var u = usuairo;

            //roles del usuario
            var roles = await this.GetRoles(u);

            // lista de roles para las claims
            List<Claim> claimsRoles = new List<Claim>();
            roles.ForEach(r => {
                claimsRoles.Add(new Claim(ClaimTypes.Role,r.RolesIdRolNavigation.Nombre));
            });

            var claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name,usuairo.Nombre),
                    new Claim("UserName",usuairo.UserName),
                };

            claims.AddRange(claimsRoles);


            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);

            await controller.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
            claimsPrincipal,
            new AuthenticationProperties {
                IsPersistent = isPersistentCoockie
            }
            );


        }

        public async Task Update(Usuario newDataUser)
        {
            var user = _context.Usuarios.Find(newDataUser.IdUsuario);
            user.Nombre = newDataUser.Nombre;
            user.UserName = newDataUser.UserName;
            user.IdRuta = newDataUser.IdRuta;
            user.Activo = newDataUser.Activo;

            user.transformUserNameLowered();

            _context.Entry<Usuario>(user).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task AddRole (Usuario usuario, string rol) 
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Nombre.ToUpper() == rol.ToUpper());
            var usuarioRol = new UsuarioHasRol(){
                IdRol = role.IdRol,
                IdUsuario = usuario.IdUsuario
            };
        }

        public async Task RemoveRole (Usuario usuario, string rol) 
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Nombre.ToUpper() == rol.ToUpper());
            var usuarioRol = await _context.UsuariosHasRoles.FirstOrDefaultAsync(hr => 
            hr.IdUsuario == usuario.IdUsuario && hr.IdRol == role.IdRol
            );

            _context.UsuariosHasRoles.Remove(usuarioRol);
        }


    }
}
