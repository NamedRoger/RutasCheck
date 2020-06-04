using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RutasCheck.Models
{
    public partial class DetalleRuta
    {
        public DetalleRuta()
        {
            Carreras = new HashSet<Carrera>();
            ParadaDetallesRuta = new HashSet<ParadaDetalleRuta>();
        }
        [Key]
        public int IdDetalleRuta { get; set; }
        public int IdRuta { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Activo { get; set; } = true;

        public virtual Ruta IdRutaNavigation { get; set; }
        public virtual ICollection<Carrera> Carreras { get; set; }
        public virtual ICollection<ParadaDetalleRuta> ParadaDetallesRuta { get; set; }
    }
}
