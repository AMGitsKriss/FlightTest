using Flights.DTO;
using System.Collections.Generic;

namespace Flights.Repository
{
    public interface IFlightRepository
    {
        IList<Flight> GetFlights();
    }
}