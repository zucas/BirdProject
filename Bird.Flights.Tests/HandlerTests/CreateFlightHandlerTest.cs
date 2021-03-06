  
using System;
using Bird.Flights.Domain.Commands;
using Bird.Flights.Domain.Handlers;
using Bird.Flights.Tests.Repositories;
using Bird.Shared.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bird.Flights.Tests.HandlerTest
{
    [TestClass]
    public class CreateFlightCommandTest
    {
        private readonly CreateFlightCommand _invalidFlight = new CreateFlightCommand("TAM", "3000", "TAM3000", "1600", "0100","", "SBSP", DateTime.Now.AddHours(-1), "A320");
        private readonly CreateFlightCommand _validFlight = new CreateFlightCommand("TAM", "3000", "TAM3000", "1600", "0100","SBCT", "SBSP", DateTime.Now.AddHours(-1), "A320");
        private readonly FlightHandler _handler = new FlightHandler(new FakeFlightRepository());
        private GenericCommandResult _result = new GenericCommandResult();
        public CreateFlightCommandTest()
        {

        }

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidFlight);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_o_voo()
        {
            _result = (GenericCommandResult)_handler.Handle(_validFlight);
            Assert.AreEqual(_result.Success, true);
        }
    }
}
