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
        public string company { get; set; }
        public string arrival { get; set; }
        public string callsign { get; set; }
        public string eobt { get; set; }
        public string eet { get; set; }
        public string aircraft { get; set; }



        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .Requires()
                    .HasLen(company, 3, "company", "The company must be 3 chars")
                    .HasLen(departure, 4, "departure", "The departure must be 4 chars")
                    .HasLen(arrival, 4, "arrival", "The arrival must be 4 chars")
                    .HasMaxLen(callsign, 7, "callsign", "The callsign must be 7 or less chars")
                    .HasMinLen(callsign, 4, "callsign", "The callsign must be 4 or more chars")
            );
        }
    }
}
