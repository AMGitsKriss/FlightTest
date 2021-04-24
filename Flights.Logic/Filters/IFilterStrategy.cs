using Flights.DTO;
using System;
using System.Collections.Generic;

namespace Flights.Logic.Filters
{
    public interface IFilterStrategy
    {
        IEnumerable<Flight> Filter(IEnumerable<Flight> flights);
    }
}
