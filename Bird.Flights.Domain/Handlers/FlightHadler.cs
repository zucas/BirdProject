using Bird.Flights.Domain.Commands;
using Bird.Flights.Domain.Repositories;
using Bird.Shared.Commands;
using Bird.Shared.Commands.Contracts;
using Bird.Shared.Handlers.Contracts;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bird.Flights.Domain.Handlers
{
    class FlightHadler :
        Notifiable,
        IHandler<CreateFlightCommand>
    {
        private readonly IFlightRepository _repository;

        public FlightHadler(IFlightRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateFlightCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, this flight is wrong!", command.Notifications);

            var todo = new TodoItem(command.Title, command.User, command.Date);

            // Salva no banco
            _repository.Create(todo);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", todo);
        }
    }
}
