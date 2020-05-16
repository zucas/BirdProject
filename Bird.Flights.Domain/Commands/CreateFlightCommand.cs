using Bird.Shared.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using System;


namespace Bird.Flights.Domain.Commands
{
    public class CreateFlightCommand : Notifiable, ICommand

    
    {

        public CreateFlightCommand() { }
        public CreateFlightCommand(string iataCode, string flightNumber, string departure, string arrival, DateTime std, DateTime sta, string aircraftType)
        {
            IataCode = iataCode;
            FlightNumber = flightNumber;
            Departure = departure;
            Arrival = arrival;
            Std = std;
            Sta = sta;
            AircraftType = aircraftType;
        }

        public string IataCode { get; set; }
        public string FlightNumber { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public DateTime Std { get; set; }
        public DateTime Sta { get; set; }
        public string AircraftType { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(FlightNumber, 1, "FlightNumber", "The Flight Number must be 1 or more chars")
                    .HasMaxLen(FlightNumber, 4, "FlightNumber", "The Flight Number must be 4 or less chars")
                    .HasLen(IataCode, 2, "IataCode", "The IATA Code is incorrect")
                    .HasLen(Departure, 3, "Departure", "The Departure IATA Code is incorrect")
                    .HasLen(Arrival, 3, "Arrival", "The Arrival IATA Code is incorrect")
                    .IsGreaterThan(Sta, Std, "Sta", "STA must be after STD")
                    .IsNotNull(AircraftType, "Aircraft", "Select the Aircraft")
            );
        }
    }
}
