using Flights.DTO;
using System;

namespace Flights.Logic.Filters
{
    public interface IFilterStrategy
    {
        IEquatable<Flight> Filter();
    }
}
