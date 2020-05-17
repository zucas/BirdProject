using System;
using Bird.Shared.Utils;

namespace Bird.Flights.Domain.Entities
{
    public class Flight : Entity
    {
        public Flight () {}

        public Flight(string icaoCode, string flightNumber, string callsing, string eet, string eobt, string departure, string arrival, DateTime std, string aircraftType)
        {
            IcaoCode = icaoCode;
            FlightNumber = flightNumber;
            Callsing = callsing;
            Eet = ConvertTimes.EetToMinutes(eet);
            Eobt = eobt;
            Departure = departure;
            Arrival = arrival;
            Std = std;
            Sta = this.Std.AddMinutes(this.Eet);
            AircraftType = aircraftType;
        }

        public string IcaoCode { get; private set; }
        public string FlightNumber { get; private set; }
        public string Callsing { get; private set; }
        public int Eet { get; private set; }
        public string Eobt { get; private set; }
        public string Departure { get; private set; }
        public string Arrival { get; private set; }
        public DateTime Std { get; private set; }
        public DateTime Sta { get; private set; }
        public string AircraftType { get; private set; }
    }
}
