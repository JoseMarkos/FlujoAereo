using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Models
{
    public sealed class Pist
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public Status StatusPist { get; set; }
    }
}
