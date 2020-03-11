using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Models
{
    public sealed class Airport
    {
        public const int Pist = 10;
        private const string Operador = "DGAC";

        public string Name { get; set; }

        public string Address { get; set; }
        
        public string Country { get; set; }

        public int MetersLarge { get; set; }
    }
}
