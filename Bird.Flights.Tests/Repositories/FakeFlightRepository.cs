using System;
using System.Collections.Generic;
using Bird.Flights.Domain.Entities;
using Bird.Flights.Domain.Repositories;

namespace Bird.Flights.Tests.Repositories
{
    public class FakeFlightRepository : IFlightRepository
    {
        void IFlightRepository.Create(Flight flight)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Flight> IFlightRepository.GetAll(string id)
        {
            throw new NotImplementedException();
        }

        Flight IFlightRepository.GetById(Guid id)
        {
            return new Flight("3000", "CWB", "CGH", DateTime.Now.AddHours(-1), DateTime.Now, "A320");
        }

        IEnumerable<Flight> IFlightRepository.GetByPeriod(DateTime date)
        {
            throw new NotImplementedException();
        }

        void IFlightRepository.Update(Flight flight)
        {
            
        }
    }
}
