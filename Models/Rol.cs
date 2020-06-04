using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RutasCheck.Models
{
    public partial class Rol
    {
        public Rol()
        {
            UsuariosHasRoles = new HashSet<UsuarioHasRol>();
        }
        [Key]
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public bool IsDelte { get; set; } = false;

        public virtual ICollection<UsuarioHasRol> UsuariosHasRoles { get; set; }
    }
}
