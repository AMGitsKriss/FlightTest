using Flights.DTO;
using Flights.Logic.Filters;
using Flights.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flights.Logic
{
    public class FlightFinder : IFlightFinder
    {
        private readonly IFlightRepository _flightReepository;
        private readonly IList<IFilterStrategy> _filters;

        public FlightFinder(IFlightRepository flightReepository, IList<IFilterStrategy> filters)
        {
            _flightReepository = flightReepository;
            _filters = filters;
        }

        public IList<Flight> FindFlights()
        {
            IEnumerable<Flight> flightList = _flightReepository.GetFlights();

            foreach (var filter in _filters)
            {
                flightList = filter.Filter(flightList);
            }

            return flightList.ToList();
        }
    }
}
