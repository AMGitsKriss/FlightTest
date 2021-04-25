using Flights.Logic.Filters;
using Flights.Repository;
using NUnit.Framework;
using System.Collections.Generic;

namespace Flights.Logic.Test
{
    public class FilterTests
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

        [Test]
        public void FlightsMustBeInPast()
        {
            //Given
            var expectedResultCount = 5;
            List<IFilterStrategy> filters = new List<IFilterStrategy>()
            {
                new PastFlightsFilter()
            };
            var flightRepository = new FlightBuilder();
            var flightfinder = new FlightFinder(flightRepository, filters);

            //When
            var results = flightfinder.FindFlights();

            //Then
            Assert.AreEqual(expectedResultCount, results.Count);
        }

        [Test]
        public void FlightsMustDepartBeforeArriving()
        {
            //Given
            var expectedResultCount = 5;
            List<IFilterStrategy> filters = new List<IFilterStrategy>()
            {
                new ArrivesBeforeDepartingFilter()
            };
            var flightRepository = new FlightBuilder();
            var flightfinder = new FlightFinder(flightRepository, filters);

            //When
            var results = flightfinder.FindFlights();

            //Then
            Assert.AreEqual(expectedResultCount, results.Count);
        }

        [Test]
        public void ApplyAllFilters()
        {
            //Given
            var expectedResultCount = 2;
            List<IFilterStrategy> filters = new List<IFilterStrategy>()
            {
                new MaxLayoverFilter(2),
                new PastFlightsFilter(),
                new ArrivesBeforeDepartingFilter()
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