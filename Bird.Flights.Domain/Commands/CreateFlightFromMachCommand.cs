using Bird.Shared.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using System;


namespace Bird.Flights.Domain.Commands
{
    public class CreateFlightFromMachCommand : Notifiable, ICommand

    
    {

        public CreateFlightFromMachCommand() { }

        public string departure { get; set; }
        public string arrival { get; set; }
        public string callsign { get; set; }
        public string eobt { get; set; }
        public string eet { get; set; }



        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(callsign, 1, "callsign", "The Flight Number must be 1 or more chars")
            );
        }
    }
}
