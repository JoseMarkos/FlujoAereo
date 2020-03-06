using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Models
{
    public sealed class Aerolinea
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ICAO { get; set; }
        public string IATA { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Country { get; set; }
        // public Journal journal { get; set; }
    }
}
