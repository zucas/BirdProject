using Bird.Flights.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bird.Flights.Domain.Repositories
{
    public interface IFlightRepository
    {
        void Create(Flight flight);
        void Update(Flight flight);
        Flight GetById(Guid id);
        IEnumerable<Flight> GetAll(string id);
        IEnumerable<Flight> GetByPeriod(DateTime date);
    }
}
