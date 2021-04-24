using Flights.Logic.Filters;
using Flights.Repository;
using NUnit.Framework;
using System.Collections.Generic;

namespace Flights.Logic.Test
{
    public class Tests
    {
        private IFlightRepository flightRepository;

        [SetUp]
        public void Setup()
        {
            flightRepository = new FlightBuilder();
            // TODO - New up some filters
        }

        [Test]
        public void MaxLayover()
        {
            //Given
            var expectedResultCount = 4;
            List<IFilterStrategy> filters = new List<IFilterStrategy>()
            {
                new MaxLayoverFilter(2)
            };
            var flightRepository = new FlightBuilder();
            var flightfinder = new FlightFinder(flightRepository, filters);

            //When
            var results = flightfinder.FindFlights();
            
            //Then
            Assert.AreEqual(expectedResultCount, results.Count);
        }
    }
}