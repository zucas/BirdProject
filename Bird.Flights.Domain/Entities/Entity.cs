using System;
using System.Collections.Generic;
using System.Text;

namespace Bird.Flights.Domain.Entities
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
