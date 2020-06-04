using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutasCheck.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuariosHasRoles = new HashSet<UsuarioHasRol>();
        }

        [Key]
        public long IdUsuario { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string UserName { get; set; }
        public string UserNameLowered { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Ruta")]
        public int? IdRuta { get; set; }
        public bool Activo { get; set; } = true;

        [ScaffoldColumn(false)]
        public bool IsDelete { get; set; } = false;

        [Display(Name = "Ruta")]
        public virtual Ruta IdRutaNavigation { get; set; }
        public virtual ICollection<UsuarioHasRol> UsuariosHasRoles { get; set; }

        public void transformUserNameLowered()
        {
            this.UserNameLowered = this.UserName.ToLower();
        }
        
    }
}
