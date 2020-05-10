using System;

namespace Bird.Flights.Domain.Entities
{
    public class Flight : Entity
    {
        public Flight(string flightNumber, string departure, string arrival, DateTime std, DateTime sta, string aircraft)
        {
            FlightNumber = flightNumber;
            Departure = departure;
            Arrival = arrival;
            Std = std;
            Sta = sta;
            Aircraft = aircraft;
        }

        public string FlightNumber { get; private set; }
        public string Departure { get; private set; }
        public string Arrival { get; private set; }
        public DateTime Std { get; private set; }
        public DateTime Sta { get; private set; }
        public string Aircraft { get; private set; }
    }
}
