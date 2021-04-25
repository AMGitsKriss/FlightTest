using Flights.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flights.Logic.Filters
{
    /// <summary>
    /// Filter out flights that depart before the current date/time
    /// </summary>
    public class PastFlightsFilter : IFilterStrategy
    {
        public IEnumerable<Flight> Filter(IEnumerable<Flight> flights)
        {
            var result = flights.Where(f => IsNextDepartureInFuture(f.Segments));

            return result;
        }

        public bool IsNextDepartureInFuture(IList<Segment> segments)
        {
            return !segments.Any(s => s.DepartureDate < DateTime.Now);
        }
    }
}
