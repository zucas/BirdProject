using System;
using System.Collections.Generic;
using Bird.Flights.Domain.Entities;
using Bird.Flights.Domain.Repositories;

namespace Bird.Flights.Tests.Repositories
{
    public class FakeFlightRepository : IFlightRepository
    {
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetBy(List<string> atributes, List<string> payload)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetByCompany(string company, DateTime? beginDate , DateTime? endDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetByCompanyAndArrival(string company, string arrival, DateTime? beginDate, DateTime? endDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetByCompanyAndDeparture(string company, string departure,  DateTime? beginDate , DateTime? endDate)
        {
            throw new NotImplementedException();
        }

        void IFlightRepository.Create(Flight flight)
        {
            
        }

        IEnumerable<Flight> IFlightRepository.GetAll(DateTime? beginDate , DateTime? endDate)
        {
            throw new NotImplementedException();
        }

        Flight IFlightRepository.GetById(Guid id)
        {
            return new Flight("LA", "3000", "TAM3000", "1600", "0100","SBCT", "SBSP", DateTime.Now.AddHours(-1), "A320");
        }

        IEnumerable<Flight> IFlightRepository.GetByPeriod(DateTime beginDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        void IFlightRepository.Update(Flight flight)
        {
            
        }
    }
}
