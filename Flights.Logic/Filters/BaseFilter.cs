using Flights.DTO;
using System.Collections.Generic;

namespace Flights.Logic.Filters
{
    public abstract class BaseFilter
    {
        /// <summary>
        /// Other filters would potentially need [LGW -> CDG] and [CDG -> FCO] segment pairs. So let's just have a base function for it.
        /// Also, readability.
        /// </summary>
        internal IEnumerable<(Segment, Segment)> GetSegmentPairs(IList<Segment> segments)
        {
            for (int i = 0; i < segments.Count - 1; i++)
            {
                yield return (segments[i], segments[i + 1]);
            }
        }
    }
}