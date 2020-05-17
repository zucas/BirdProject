  
using System;
using Bird.Flights.Domain.Commands;
using Bird.Flights.Domain.Handlers;
using Bird.Flights.Tests.Repositories;
using Bird.Shared.Commands;
using Bird.Shared.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bird.Flights.Tests.UtilTests
{
    [TestClass]
    public class ConvertTimeTests
    {
        public ConvertTimeTests()
        {

        }

        [TestMethod]
        public void DadoUmEetHHMMComApenasMinutosAConversaoDeveEstarCorretaParaMinutos()
        {
            Assert.AreEqual(ConvertTimes.EetToMinutes("0001"), 1);
        }

        [TestMethod]
        public void DadoUmEetHHMMComApenasHorasAConversaoDeveEstarCorretaParaMinutos()
        {
            Assert.AreEqual(ConvertTimes.EetToMinutes("0300"), 180);
        }

        [TestMethod]
        public void DadoUmEetHHMMComHoraEMinutoAConversaoDeveEstarCorretaParaMinutos()
        {
            Assert.AreEqual(ConvertTimes.EetToMinutes("0401"), 241);
        }
    }
}
