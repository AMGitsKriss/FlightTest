using Flights.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flights.Logic.Filters
{
    class PastFlightsFilter : IFilterStrategy
    {
        // TODO - Filter out flights that depart before the current date/time
        public IEnumerable<Flight> Filter(IEnumerable<Flight> flights)
        {
            throw new NotImplementedException();
        }
    }
}
