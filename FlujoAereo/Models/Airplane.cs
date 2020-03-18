using FlujoAereo.Enums;

namespace FlujoAereo.Models
{
    public sealed class Airplane
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public int MaximunPassengers { get; set; }
        public int MaximunCargo { get; set; }
        public string ICAO { get; set; }
        public string IATA { get; set; }
        public long Flights { get; set; }
        public long HoursCount { get; set; }
        public Status AirplaneStatus { get; set; }
        public int Enabled { get; set; }
        public string AircraftRegistration { get; set; }
        public int AirlineID { get; set; }
    }
}
