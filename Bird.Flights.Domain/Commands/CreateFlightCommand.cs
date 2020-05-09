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
        public CreateFlightCommand(string departure, string arrival, DateTime std, DateTime sta, string aircraft)
        {
            Departure = departure;
            Arrival = arrival;
            Std = std;
            Sta = sta;
            Aircraft = aircraft;
        }

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
                    .HasLen(Departure, 3, "Departure", "The Departure IATA Code is incorrect")
                    .HasLen(Arrival, 3, "Arrival", "The Arrival IATA Code is incorrect")
                    .IsGreaterThan(Sta, Std, "Sta", "STA must be after STD")
                    .IsNotNull(Aircraft, "Aircraft", "Select the Aircraft")
            );
        }
    }
}
