using System;
using System.Collections.Generic;

namespace RutasCheck.Models
{
    public partial class UsuarioHasRol
    {
        public long IdUsuario { get; set; }
        public int IdRol { get; set; }

        public virtual Rol RolesIdRolNavigation { get; set; }
        public virtual Usuario UsuariosIdUsuarioNavigation { get; set; }
    }
}
