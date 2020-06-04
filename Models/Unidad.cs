using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RutasCheck.Models
{
    public partial class Unidad
    {
        public Unidad()
        {
            Carreras = new HashSet<Carrera>();
        }
        [Key]
        public int IdUnidad { get; set; }
        [Required]
        [Display(Name = "Concecionario")]
        [ForeignKey("IdConcecionarioNavigation")]
        public int IdConcecionario { get; set; }
        [Required]
        [Display(Name = "Número Económico")]
        public string NumeroEconomico { get; set; }
        [Required]
        [Display(Name = "Propietario")]
        [ForeignKey("IdPropietarioNavigation")]
        public int IdPropiedatrio { get; set; }
        [Required]
        public string Placa { get; set; }
        [ScaffoldColumn(false)]
        public bool IsDelete { get; set; } = false;

        [Display(Name = "Concecionario")]
        public virtual Concecionario IdConcecionarioNavigation { get; set; }
        [Display(Name = "Propietario")]
        public virtual Concecionario IdPropietarioNavigation { get; set; }
        public virtual ICollection<Carrera> Carreras { get; set; }
    }
}
