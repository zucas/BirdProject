using System;
using System.Collections.Generic;
using Bird.Flights.Domain.Entities;
using Bird.Flights.Domain.Repositories;
using Bird.Flights.Infra.Contexts;

namespace Bird.Flights.Infra.Repositories {
    public class FlightRepository : IFlightRepository
    {

        private readonly FlightDataContext _context;

        public FlightRepository(FlightDataContext context)
        {
            _context = context;
        }


        public void Create(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
        }

        public IEnumerable<Flight> GetAll()
        {
            return _context.Flights;
        }

        public Flight GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetByPeriod(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Update(Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}