using FlujoAereo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Models
{
    public sealed class Flight
    {
        public int ID { get; set; }
     
        public string Type { get; set; }

        public string Origin { get; set; }

        public string Destiny { get; set; }

        public int Pist { get; set; }

        public DateTime Departure { get; set; }

        public DateTime Arrival { get; set; }

        public string FlightStatus { get; set; }
        public int Enabled { get; set; }
    }
}
