using Flights.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flights.Logic.Filters
{
    /// <summary>
    /// Filter out flights that have any segment with an arrival date before the departure date
    /// </summary>
    public class ArrivesBeforeDepartingFilter : IFilterStrategy
    {
        public IEnumerable<Flight> Filter(IEnumerable<Flight> flights)
        {
            var result = flights.Where(f => IsDepartureBeforeARrival(f.Segments));

            return result;
        }

        public bool IsDepartureBeforeARrival(IList<Segment> segments)
        {
            return segments.Any(s => s.DepartureDate < s.ArrivalDate);
        }
    }
}
