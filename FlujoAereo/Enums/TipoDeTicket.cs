using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlujoAereo.Enums
{
    public class TipoDeTicket
    {
        enum Ticket
        {
            OneWay,
            RoundTrip,
            NonStop,
            DirectFly,
            CircleTrip,

            // Promociones
            OpenJaw,

            // SMR-BOG MED-SMR
            DoubleOpenJaw
            // SMR-BOG NVA-CLO

        }

        // Eg
        // SMR-BOG
        // SMR-BOG-SMR

        // Circle trip
        // SMR-BOG-BGA-MED-SMR
    }
}
