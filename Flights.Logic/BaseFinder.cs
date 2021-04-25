using Flights.Logic.Filters;
using Flights.Logic.Models;
using System.Collections.Generic;
using System.Linq;

namespace Flights.Logic
{
    public abstract class BaseFinder
    {
        internal readonly IEnumerable<IFilterStrategy> _filters;

        public BaseFinder(IEnumerable<IFilterStrategy> filters)
        {
            _filters = filters;
        }

        internal IResponse<IFilterStrategy> SelectFilters(IRequest request)
        {
            // Use the list of filters in the request to get the loaded filters. 
            var missingFilters = request.Filters.Where(s => !_filters.Select(f => f.GetType().Name).Contains(s)).Select(m => $"Filter '{m}' either does not exist or has not been loaded.");

            var result = new Response<IFilterStrategy>()
            {
                Results = _filters.Where(f => request.Filters.Contains(f.GetType().Name)).ToList(),
                Errors = missingFilters.ToList()
            };

            return result;
        }
    }


}