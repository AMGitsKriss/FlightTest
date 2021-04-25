using Flights.DTO;
using Flights.Logic.Filters;
using Flights.Logic.Models;
using Flights.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flights.Logic
{
    public class FlightFinder : BaseFinder, IFlightFinder
    {
        private readonly IFlightRepository _flightRepository;

        public FlightFinder(IFlightRepository flightRepository, IList<IFilterStrategy> filters) : base(filters)
        {
            _flightRepository = flightRepository;
        }

        public IResponse<Flight> FindFlights(IRequest request)
        {
            IEnumerable<Flight> flightList = _flightRepository.GetFlights();
            var selectedFilters = SelectFilters(request);

            foreach (var filter in selectedFilters.Results)
            {
                flightList = filter.Filter(flightList);
            }

            return new Response<Flight>()
            {
                Results = flightList.ToList(),
                RequestedFilters = request.Filters,
                Errors = selectedFilters.Errors
            };
        }
    }
}
