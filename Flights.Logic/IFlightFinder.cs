using Flights.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flights.Logic
{
    interface IFlightFinder
    {
        IList<Flight> FindFlights();
    }
}
