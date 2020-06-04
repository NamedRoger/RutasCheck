using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RutasCheck.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Recorridos = new HashSet<Recorrido>();
        }

        [Key]
        public long IdCarrera { get; set; }
        public int IdChofer { get; set; }
        public int IdDetalleRuta { get; set; }
        public int IdUnidad { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public bool IsDelete { get; set; } = false;

        public virtual DetalleRuta IdDetalleRutaNavigation { get; set; }
        public virtual Unidad IdUnidadNavigation { get; set; }
        public virtual ICollection<Recorrido> Recorridos { get; set; }
    }
}
