using System;
using System.Collections.Generic;
using System.Text;

namespace Flights.DTO
{
    public class FilterSettingsConfig
    {
        public int MaxLayoverHours { get; set; }
        public IList<string> FiltersToUse { get; set; }
    }
}
