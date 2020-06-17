using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RutasCheck.Models;
using RutasCheck.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RutasCheck.Helpers
{
    public interface IUserHelper
    {
        Task AddRole(Usuario usuario, string rol);
        Usuario FindByUserName(string userName);
        Task RemoveRole(Usuario usuario, string rol);
        Task SigInAsyc(Controller controller, Usuario usuario, bool isPersistentCoockie);
        Task Update(Usuario usuario);

    }
}
