using Bird.Flights.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bird.Flights.Domain.Repositories
{
    public interface IFlightRepository
    {
        void Create(Flight flight);
    }
}
