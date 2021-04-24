using Flights.DTO;
using System;
using System.Collections.Generic;

namespace Flights.Logic.Filters
{
    class ArrivesBeforeDepartingFilter : IFilterStrategy
    {
        // TODO - Filter out flights that have any segment with an arrival date before the departure date

        public IEnumerable<Flight> Filter(IEnumerable<Flight> flights)
        {
            throw new NotImplementedException();
        }
    }
}
