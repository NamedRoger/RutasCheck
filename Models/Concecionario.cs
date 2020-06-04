using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RutasCheck.Models
{
    public class Concecionario
    {
        [Key]
        public int IdConcecionario { get; set; }
        public string Nombre { get; set; }

        public bool IsDelete { get; set; } = false;

        public virtual ICollection<Unidad> UnidadesConcecionarios { get; set; }
        public virtual ICollection<Unidad> UnidadesPropietarios { get; set; }

        public Concecionario()
        {
            UnidadesConcecionarios = new HashSet<Unidad>(); 
            UnidadesPropietarios = new HashSet<Unidad>(); 
        }
    }
}
