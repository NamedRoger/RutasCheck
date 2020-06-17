using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RutasCheck.Models
{
    public class Parada
    {
        [Key]
        public int IdParada {get;set;}
        public string NombreParada {get;set;}
        [ScaffoldColumn(false)]
        public string NombreNormalizado {get;set;}
        public bool Borrado {get;set;} = false;

        public virtual ICollection<ParadaDetalleRuta> ParadaDetallesRuta {get;set;}
    }
}