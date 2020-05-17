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
            
        }

        IEnumerable<Flight> IFlightRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        Flight IFlightRepository.GetById(Guid id)
        {
            return new Flight("LA", "3000", "TAM3000", "1600", "0100","CWB", "CGH", DateTime.Now.AddHours(-1), "A320");
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
