using Flights.DTO;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flights.Logic.Filters
{
    /// <summary>
    /// Filter out those that spend more than 2 (n) hours on the ground.
    /// i.e. those with a total combined gap of *over two hours* between the arrival date of one segment and the departure date of the next.
    /// </summary>
    public class MaxLayoverFilter : IFilterStrategy
    {
        private readonly int _hours;

        public MaxLayoverFilter (IOptions<FilterSettingsConfig> config)
        {
            _hours = config.Value.MaxLayoverHours;
        }

        public IEnumerable<Flight> Filter(IEnumerable<Flight> flights)
        {
            var result = flights.Where(f => IsLayoverWithinRange(f.Segments));

            return result;
        }

        private bool IsLayoverWithinRange(IList<Segment> segments)
        {
            TimeSpan totalLayoverTime = new TimeSpan();

            for (int i = 0; i < segments.Count-1; i++)
            {
                var previousArrivalTime = segments[i].ArrivalDate;
                var nextDepartureTime = segments[i+1].DepartureDate;

                var subtotal = nextDepartureTime - previousArrivalTime;
                totalLayoverTime += subtotal;
            }

            return totalLayoverTime.TotalHours <= _hours;
        }
    }
}
