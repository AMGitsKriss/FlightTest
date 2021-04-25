using System;
using System.Collections.Generic;
using System.Text;

namespace Flights.Logic.Models
{
    public class FlightsRequest : IRequest
    {
        public IList<string> Filters { get; set; }
    }
}
