using System.Collections.Generic;

namespace RutasCheck.Models.ViewModels
{
    public class AgregarRuta
    {
        public string NombreRuta {get;set;}
        public string ColorRuta {get;set;}
        public List<Parada> Paradas {get;set;}
    }
}