using Bird.Shared.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using System;


namespace Bird.Flights.Domain.Commands
{
    public class UpdateFlightCommand : Notifiable, ICommand

    
    {

        public UpdateFlightCommand() { }
        public UpdateFlightCommand(string icaoCode, string flightNumber, string callsing, string eet, string eobt, string departure, string arrival, DateTime std, string aircraftType)
        {
            IcaoCode = icaoCode;
            FlightNumber = flightNumber;
            Eet = eet;
            Eobt = eobt;
            Departure = departure;
            Arrival = arrival;
            Std = std;
            AircraftType = aircraftType;
        }

        public string IcaoCode { get; set; }
        public string FlightNumber { get; set; }
        public string Eet { get; set; }
        public string Eobt { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public DateTime Std { get; set; }
        public string AircraftType { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(FlightNumber, 1, "FlightNumber", "The Flight Number must be 1 or more chars")
                    .HasMaxLen(FlightNumber, 4, "FlightNumber", "The Flight Number must be 4 or less chars")
                    .HasLen(IcaoCode, 3, "IcaoCode", "The ICAO Code is incorrect")
                    .HasLen(Departure, 4, "Departure", "The Departure ICAO Code is incorrect")
                    .HasLen(Arrival, 4, "Arrival", "The Arrival ICAO Code is incorrect")
                    .IsNotNull(AircraftType, "Aircraft", "Select the Aircraft")
                    .IsNotNull(Eobt, "Eobt", "Eobt is required")
            );
        }
    }
}
