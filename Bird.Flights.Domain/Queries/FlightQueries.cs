using System;
using System.Linq.Expressions;
using Bird.Flights.Domain.Entities;

namespace Bird.Flights.Domain.Queries {
    public static class FlightQueries {
        public static Expression<Func<Flight, bool>> GetByCompany(string company)
        {
            return x => x.IcaoCode == company;
        }

        public static Expression<Func<Flight, bool>> GetByStdPeriod(DateTime begin, DateTime end)
        {
            return x => x.Std >= begin && x.Std <= end;
        }
        public static Expression<Func<Flight, bool>> GetByDeparture(string departure)
        {
            return x => x.Departure == departure;
        }

        public static Expression<Func<Flight, bool>> GetByArrival(string arrival)
        {
            return x => x.Arrival == arrival;
        }
    }
}