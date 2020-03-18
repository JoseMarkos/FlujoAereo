using FlujoAereo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Models
{
    public sealed class Piloto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Gender Sex { get; set; }
        public int PilotStatus { get; set; }
    }
}
