using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Models
{
    public class Aerolinea
    {
        public int id { get; set; }
        public string code { get; set; }
        public string icao { get; set; }
        public string iata { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public string country { get; set; }
        // public Journal journal { get; set; }
    }
}
