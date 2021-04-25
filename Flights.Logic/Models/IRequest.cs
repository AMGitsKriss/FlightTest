using System.Collections.Generic;

namespace Flights.Logic.Models
{
    public interface IRequest
    {
        IList<string> Filters { get; set; }
    }
}