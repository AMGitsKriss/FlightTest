using Flights.DTO;
using Flights.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flights.Logic
{
    public interface IFlightFinder
    {
        IResponse<Flight> FindFlights(IRequest request);
    }
}
