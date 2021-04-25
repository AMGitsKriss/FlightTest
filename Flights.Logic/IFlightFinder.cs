using Flights.DTO;
using Flights.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flights.Logic
{
    interface IFlightFinder
    {
        IResponse<Flight> FindFlights(IRequest request);
    }
}
