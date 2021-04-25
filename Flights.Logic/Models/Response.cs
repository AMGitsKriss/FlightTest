using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flights.Logic.Models
{
    public class Response<T> : IResponse<T>
    {
        public IList<T> Results { get; set; }
        public IList<string> RequestedFilters { get; set; }
        public IList<string> Errors { get; set; }
        public bool HasErrors => Errors?.Any() ?? false;
    }
}
