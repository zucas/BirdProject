using Bird.Shared.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using System;


namespace Bird.Flights.Domain.Commands
{
    public class DeleteFlightCommand : Notifiable, ICommand

    
    {
        public DeleteFlightCommand() { }
        public DeleteFlightCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(Id, "Id", "Id is required")
            );
        }
    }
}
