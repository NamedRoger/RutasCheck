using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RutasCheck.Models.ViewModels
{
    public class ViewModelUser : Usuario
    {
        public new string Password { get; set; }
        public new string ConfirmPassword { get; set; }

    }
}
