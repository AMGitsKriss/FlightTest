using System.Collections.Generic;

namespace Flights.Logic.Models
{
    public interface IResponse<T>
    {
        IList<T> Results { get; set; }
        IList<string> RequestedFilters { get; set; }
        IList<string> Errors { get; set; }
        bool HasErrors { get; }
    }
}