using FlujoAereo.Enums;

namespace FlujoAereo.Models
{
    public sealed class Airplane
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public int MaxPASS { get; set; }
        public int MaxCargo { get; set; }
        public string ICAO { get; set; }
        public string IATA { get; set; }
        public long Flights { get; set; }
        public long Hours { get; set; }
        public Status Status { get; set; }
        public int Enabled { get; set; }
        public string Aircraft { get; set; }
        public int AirlineID { get; set; }
    }
}
