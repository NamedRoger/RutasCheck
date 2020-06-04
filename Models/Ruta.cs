using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RutasCheck.Models
{
    public partial class Ruta
    {
        public Ruta()
        {
            DetallesRutas = new HashSet<DetalleRuta>();
            Usuarios = new HashSet<Usuario>();
        }
        [Key]
        public int IdRuta { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual ICollection<DetalleRuta> DetallesRutas { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
