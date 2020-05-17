using System;

namespace Bird.Flights.Domain.Entities
{
    public class AircraftType : Entity
    {
        public AircraftType(string manufacturer, string model, string departure, string arrival, DateTime std, DateTime sta)
        {
            Manufacturer = manufacturer;
            Model = model;
        }

        public string Manufacturer { get; private set; }
        public string Model { get; private set; }
    }
}
