using FlujoAereo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Models
{
    public sealed class Avion
    {
        public Airplane Model { get; set; }
        public Piloto Pilot { get; set; }

        public int Capacity { get; set; }
        public int TotalPasangers { get; set; }
    }
}
