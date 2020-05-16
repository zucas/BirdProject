using System;

namespace Bird.Flights.Domain.Entities
{
    public class Flight : Entity
    {
        public Flight(string iataCode, string flightNumber, string departure, string arrival, DateTime std, DateTime sta, string aircraftType)
        {
            IataCode = iataCode;
            FlightNumber = flightNumber;
            Departure = departure;
            Arrival = arrival;
            Std = std;
            Sta = sta;
            AircraftType = aircraftType;
        }

        public string IataCode { get; private set; }
        public string FlightNumber { get; private set; }
        public string Departure { get; private set; }
        public string Arrival { get; private set; }
        public DateTime Std { get; private set; }
        public DateTime Sta { get; private set; }
        public string AircraftType { get; private set; }
    }
}
