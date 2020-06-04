using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RutasCheck.ViewComponents
{
    public class AlertViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string claseAlerta, string mensaje)
        {
            return View(new AlerViewComponentProperties {Clase = claseAlerta, Mensaje = mensaje });
        }
    }

    public class AlerViewComponentProperties
    {
        public string Clase { get; set; }
        public string Mensaje { get; set; }
    }
}
