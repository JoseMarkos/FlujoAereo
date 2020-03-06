using FlujoAereo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Models
{
    public class Avion
    {
        public TipoDeAvion Model { get; set; }
        public Piloto Piloto { get; set; }

        public int Capacity { get; set; }
        public int TotalPasangers { get; set; }
    }
}
