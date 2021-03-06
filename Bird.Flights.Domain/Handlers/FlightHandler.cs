﻿using System;
using Bird.Flights.Domain.Commands;
using Bird.Flights.Domain.Entities;
using Bird.Flights.Domain.Repositories;
using Bird.Shared.Commands;
using Bird.Shared.Commands.Contracts;
using Bird.Shared.Handlers.Contracts;
using Bird.Shared.Utils;
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

            var flight = new Flight(command.IcaoCode, command.FlightNumber, command.IcaoCode + command.FlightNumber, command.Eet, command.Eobt, command.Departure, command.Arrival, ConvertTimes.EobtToDateTime(command.Eobt, DateTime.Now.AddDays(1)), command.AircraftType);
            _repository.Create(flight);
            return new GenericCommandResult(true, "Flight save!", flight);
        }

        

        public ICommandResult Handle(CreateFlightFromMachCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, this flight is wrong!", command.Notifications);
            var flight = new Flight(command.company, command.callsign.Substring(3) ,command.callsign, command.eet, command.eobt, command.departure, command.arrival, ConvertTimes.EobtToDateTime(command.eobt, DateTime.Now.AddDays(1)), command.aircraft);
            _repository.Create(flight);
            return new GenericCommandResult(true, "Flight save!", flight);
        }

        public ICommandResult Handle(UpdateFlightCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, this flight is wrong!", command.Notifications);

            var flight = new Flight(command.IcaoCode, command.FlightNumber, command.IcaoCode + command.FlightNumber, command.Eet, command.Eobt, command.Departure, command.Arrival, ConvertTimes.EobtToDateTime(command.Eobt, DateTime.Now.AddDays(1)), command.AircraftType);
            _repository.Update(flight);
            return new GenericCommandResult(true, "Flight updated!", flight);
        }

        public ICommandResult Handle(DeleteFlightCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, this flight is wrong!", command.Notifications);
            _repository.Delete(command.Id);
            return new GenericCommandResult(true, "Flight Deleted!", null);
        }
    }
}
