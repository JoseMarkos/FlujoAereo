using FlujoAereo.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Models
{
    public sealed class Pilot
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int PilotStatus { get; set; }
        public int AirlineID { get; set; }
    }
}
