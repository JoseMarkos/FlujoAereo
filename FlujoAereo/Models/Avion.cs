using FlujoAereo.Enums;

namespace FlujoAereo.Models
{
    public sealed class Avion
    {
        public int ID { get; set; }
        public Airplane Model { get; set; }
        public int MaximunPassengers { get; set; }
        public int MaximunCargo { get; set; }
        public string ICAO { get; set; }
        public string IATA { get; set; }
        public string AircraftRegistration { get; set; }
        private long Flights { get; set; }
        private long HoursCount { get; set; }
        public Status AirplaneStatus { get; set; }
        public int Enabled { get; set; }
    }
}
