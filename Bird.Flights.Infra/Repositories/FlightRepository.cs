using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Bird.Flights.Domain.Entities;
using Bird.Flights.Domain.Queries;
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

        public void Delete(Guid id)
        {
            var flight =_context.Flights.FirstOrDefault(f => f.Id == id);
            _context.Flights.Remove(flight);
            _context.SaveChanges();
        }

        public IEnumerable<Flight> GetAll(DateTime? beginDate , DateTime? endDate)
        {
            return _context.Flights.Where(FlightQueries.GetByStdPeriod(beginDate ?? DateTime.Now.AddHours(-6), endDate ?? DateTime.Now.AddHours(6) ));
        }

        public IEnumerable<Flight> GetBy(List<string> atributes, List<string> payload)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetByCompany(string company, DateTime? beginDate , DateTime? endDate)
        {
            return _context.Flights.Where(FlightQueries.GetByCompany(company)).Where(FlightQueries.GetByStdPeriod(beginDate ?? DateTime.Now.AddHours(-6), endDate ?? DateTime.Now.AddHours(6) ));
        }

        public IEnumerable<Flight> GetByCompanyAndArrival(string company, string arrival, DateTime? beginDate , DateTime? endDate)
        {
            return _context.Flights
            .Where(FlightQueries.GetByStdPeriod(beginDate ?? DateTime.Now.AddHours(-6), endDate ?? DateTime.Now.AddHours(6) ))
            .Where(FlightQueries.GetByCompany(company))
            .Where(FlightQueries.GetByArrival(arrival))
            .AsNoTracking();
        }

        public IEnumerable<Flight> GetByCompanyAndDeparture(string company, string departure, DateTime? beginDate , DateTime? endDate)
        {
            return _context.Flights
            .Where(FlightQueries.GetByCompany(company))
            .Where(FlightQueries.GetByDeparture(departure))
            .Where(FlightQueries.GetByStdPeriod(beginDate ?? DateTime.Now.AddHours(-6), endDate ?? DateTime.Now.AddHours(6) ))
            .AsNoTracking();
        }

        public Flight GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetByPeriod(DateTime beginDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void Update(Flight flight)
        {
            _context.Entry(flight).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}