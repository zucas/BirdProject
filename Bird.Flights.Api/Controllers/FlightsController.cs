using System.Collections.Generic;
using Bird.Flights.Domain.Commands;
using Bird.Flights.Domain.Entities;
using Bird.Flights.Domain.Handlers;
using Bird.Flights.Domain.Repositories;
using Bird.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Bird.Flights.Api.Controllers {

    [ApiController]
    [Route("api/v2/flights")]
    public class FlightsController : ControllerBase {

        [Route("")]
        [HttpGet]
        public IEnumerable<Flight> GetAll(
            [FromServices]IFlightRepository repository
        )
        {
            return repository.GetAll();
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody]CreateFlightCommand command,
            [FromServices]FlightHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }
        
    }
}