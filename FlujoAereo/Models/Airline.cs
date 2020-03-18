using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Models
{
    public sealed class Airline
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public int AirlineStatus { get; set; }
        private List<Airplane> AircraftList { get; set; }
        // public Journal journal { get; set; }
    }
}
