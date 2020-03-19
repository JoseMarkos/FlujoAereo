using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Models
{
    public sealed class Airport
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Operator { get; set; }// DGAC fot GT
        public string Owner { get; set; }
        public string ICAO { get; set; }
        public string IATA { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string Serves { get; set; }
        public int Large { get; set; }
        public int Elevation { get; set; }
        public int Status { get; set; }
    }
}
