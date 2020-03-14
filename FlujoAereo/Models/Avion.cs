using FlujoAereo.Enums;

namespace FlujoAereo.Models
{
    public sealed class Avion
    {
        public int ID { get; set; }
        public Airplane Model { get; set; }
        public int Capacity { get; set; }
        public string ICAO { get; set; }
        public string IATA { get; set; }
        private long Flights { get; set; }
        private long HoursCount { get; set; }
        public Status AirplaneStatus { get; set; }
    }
}
