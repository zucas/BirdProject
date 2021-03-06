﻿  
using System;
using Bird.Flights.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bird.Flights.Tests.CommandTests
{
    [TestClass]
    public class CreateFlightCommandTest
    {
        private readonly CreateFlightCommand _invalidFlight = new CreateFlightCommand("TAM", "3000", "TAM3000", "1600", "0100", "", "SBSP", DateTime.Now.AddHours(-1), "A320");
        private readonly CreateFlightCommand _validFlight = new CreateFlightCommand("TAM", "3000", "TAM3000", "1600", "0100","SBCT", "SBSP", DateTime.Now.AddHours(-1), "A320");

        public CreateFlightCommandTest()
        {
            _invalidFlight.Validate();
            _validFlight.Validate();
        }

        [TestMethod]
        public void Dado_um_voo_invalido()
        {
            Assert.AreEqual(_invalidFlight.Invalid, true);
        }

        [TestMethod]
        public void Dado_um_voo_valido()
        {
            Assert.AreEqual(_validFlight.Valid, true);
        }

    }
}
