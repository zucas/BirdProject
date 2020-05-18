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
        IEnumerable<Flight> GetAll( DateTime? beginDate , DateTime? endDate);
        IEnumerable<Flight> GetByCompany(string company,  DateTime? beginDate , DateTime? endDate);
        IEnumerable<Flight> GetByPeriod(DateTime beginDate, DateTime endDate);
        IEnumerable<Flight> GetBy(List<string> atributes, List<string> payload);
        IEnumerable<Flight> GetByCompanyAndDeparture(string company, string departure, DateTime? beginDate , DateTime? endDate);
        IEnumerable<Flight> GetByCompanyAndArrival(string company, string arrival, DateTime? beginDate, DateTime? endDate);
    }
}
