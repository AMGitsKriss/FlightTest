using Flights.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flights.Logic.Filters
{
    class ArrivesBeforeDepartingFilter : IFilterStrategy
    {
        // TODO - Filter out flights that have any segment with an arrival date before the departure date

        public IEquatable<Flight> Filter()
        {
            throw new NotImplementedException();
        }
    }
}
