using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RutasCheck.Models
{
    public partial class Recorrido
    {
        [Key]
        public long IdRecorrido { get; set; }
        public long? IdParadaDetalleRuta { get; set; }
        public long? IdCarrera { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? HoraSalida { get; set; }

        public virtual Carrera IdCarreraNavigation { get; set; }
        public virtual ParadaDetalleRuta IdParadaNavigation { get; set; }
    }
}
