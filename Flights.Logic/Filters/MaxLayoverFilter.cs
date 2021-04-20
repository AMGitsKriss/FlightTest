using Flights.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flights.Logic.Filters
{
    class MaxLayoverFilter : IFilterStrategy
    {
        // TODO - Filter out those that spend more than 2 hours on the ground 
        // i.e. those with a total combined gap of over two hours between the arrival date of one segment and the departure date of the next

        public MaxLayoverFilter (int hours)
        {
            // TODO - Expect this value from a config
        }

        public IEquatable<Flight> Filter()
        {
            throw new NotImplementedException();
        }
    }
}
