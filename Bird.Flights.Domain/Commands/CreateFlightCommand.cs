using Bird.Shared.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bird.Flights.Domain.Commands
{
    public class CreateFlightCommand : Notifiable, ICommand
    {
        public CreateFlightCommand(string flightNumber, string departure, string arrival, DateTime std, DateTime sta, string aircraft)
        {
            FlightNumber = flightNumber;
            Departure = departure;
            Arrival = arrival;
            Std = std;
            Sta = sta;
            Aircraft = aircraft;
        }

        public string FlightNumber { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public DateTime Std { get; set; }
        public DateTime Sta { get; set; }
        public string Aircraft { get; set; }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(FlightNumber, 1, "FlightNumber", "The Flight Number must be 1 or more chars")
                    .HasMaxLen(FlightNumber, 4, "FlightNumber", "The Flight Number must be 4 or less chars")
                    .HasLen(Departure, 3, "Departure", "The Departure IATA Code is incorrect")
                    .HasLen(Arrival, 3, "Arrival", "The Arrival IATA Code is incorrect")
                    .IsGreaterThan(Sta, Std, "Sta", "STA must be after STD")
                    .IsNotNull(Aircraft, "Aircraft", "Select the Aircraft")
            );
        }
    }
}
