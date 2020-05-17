using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Bird.Flights.Domain.Commands;
using Bird.Flights.Domain.Entities;
using Bird.Flights.Domain.Handlers;
using Bird.Flights.Domain.Repositories;
using Bird.Shared.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bird.Flights.Api.Controllers {

    [ApiController]
    [Route("api/v2/flights")]
    public class FlightsController : ControllerBase {
        static readonly HttpClient client = new HttpClient();

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
        
        [Route("import/mach")]
        [HttpGet]
        public async Task<GenericCommandResult> ImportFromMachAsync(
            [FromServices]FlightHandler handler
        )
        {

            HttpResponseMessage response = await client.GetAsync("http://us-central1-mach-app.cloudfunctions.net/api/flights");
            var data = await response.Content.ReadAsStreamAsync();
            var commands = await JsonSerializer.DeserializeAsync<List<CreateFlightFromMachCommand>>(data);
            foreach(var command in commands)
            {
                handler.Handle(command);
            }
            return new GenericCommandResult(true, "The Flights has been imported", commands);
        }
    }
}