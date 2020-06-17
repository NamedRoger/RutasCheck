using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RutasCheck.Models
{
    public partial class ParadaDetalleRuta
    {
        public ParadaDetalleRuta()
        {
            InverseIdParadaOrigenNavigation = new HashSet<ParadaDetalleRuta>();
            Recorridos = new HashSet<Recorrido>();
        }
        [Key]
        public long IdParadaDetalleRuta { get; set; }
        public int IdDetalleRuta { get; set; }
        public int IdParada {get;set;}
        public Parada Parada { get; set; }
        public TimeSpan TiempoEstimado { get; set; }
        public long? IdParadaOrigen { get; set; }

        public virtual DetalleRuta IdDetalleRutaNavigation { get; set; }
        public virtual ParadaDetalleRuta IdParadaOrigenNavigation { get; set; }
        public virtual ICollection<ParadaDetalleRuta> InverseIdParadaOrigenNavigation { get; set; }
        public virtual ICollection<Recorrido> Recorridos { get; set; }
    }
}
