using FlujoAereo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Models
{
    public sealed class Vuelo
    {
        public Flight Type { get; set; }

        public int Pist { get; set; }

        public string Origin { get; set; }

        public string Destiny { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime Departure { get; set; }
    }
}
