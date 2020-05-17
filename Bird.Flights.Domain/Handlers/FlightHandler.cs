using Bird.Flights.Domain.Commands;
using Bird.Flights.Domain.Entities;
using Bird.Flights.Domain.Repositories;
using Bird.Shared.Commands;
using Bird.Shared.Commands.Contracts;
using Bird.Shared.Handlers.Contracts;
using Flunt.Notifications;

namespace Bird.Flights.Domain.Handlers
{
    public class FlightHandler :
        Notifiable,
        IHandler<CreateFlightCommand>
    {
        private readonly IFlightRepository _repository;

        public FlightHandler(IFlightRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateFlightCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, this flight is wrong!", command.Notifications);

            var flight = new Flight(command.IataCode, command.FlightNumber, command.Callsing, command.Eet, command.Eobt, command.Departure, command.Arrival, command.Std, command.Sta, command.AircraftType);

            // Salva no banco
            _repository.Create(flight);

            // Retorna o resultado
            return new GenericCommandResult(true, "Flight save!", flight);
        }

        public ICommandResult Handle(CreateFlightFromMachCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, this flight is wrong!", command.Notifications);

            var flight = new Flight();

            // Salva no banco
            _repository.Create(flight);

            // Retorna o resultado
            return new GenericCommandResult(true, "Flight save!", flight);
        }
    }
}
