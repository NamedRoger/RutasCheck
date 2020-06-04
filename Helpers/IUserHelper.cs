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
        Usuario FindByUserName(string userName);
        Task SigInAsyc(Controller controller, Usuario usuario);
        Task Update(Usuario usuario);

    }
}
