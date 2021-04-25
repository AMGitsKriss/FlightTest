using Flights.DTO;
using Flights.Logic.Filters;
using Flights.Logic.Models;
using Flights.Repository;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System.Collections.Generic;

namespace Flights.Logic.Test
{
    public class FilterTests
    {
        private IFlightRepository _flightRepository;
        private IOptions<FilterSettingsConfig> _options;

        [SetUp]
        public void Setup()
        {
            _flightRepository = new FlightBuilder();
            _options = Options.Create(new FilterSettingsConfig() { MaxLayoverHours = 2 }); // Could also use Moq

        }

        [Test]
        public void MaxLayover()
        {
            //Given
            var expectedResultCount = 4;
            List<IFilterStrategy> filters = new List<IFilterStrategy>()
            {
                new MaxLayoverFilter(_options)
            };
            var flightfinder = new FlightFinder(_flightRepository, filters);
            var request = new FlightsRequest()
            {
                Filters = new List<string> { "MaxLayoverFilter" }
            };

            //When
            var results = flightfinder.FindFlights(request);

            //Then
            Assert.AreEqual(expectedResultCount, results.Results.Count);
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
            var flightfinder = new FlightFinder(_flightRepository, filters);
            var request = new FlightsRequest()
            {
                Filters = new List<string> { "PastFlightsFilter" }
            };

            //When
            var results = flightfinder.FindFlights(request);

            //Then
            Assert.AreEqual(expectedResultCount, results.Results.Count);
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
            var flightfinder = new FlightFinder(_flightRepository, filters);
            var request = new FlightsRequest()
            {
                Filters = new List<string> { "ArrivesBeforeDepartingFilter"}
            };

            //When
            var results = flightfinder.FindFlights(request);

            //Then
            Assert.AreEqual(expectedResultCount, results.Results.Count);
        }

        [Test]
        public void ApplyAllFilters()
        {
            //Given
            var expectedResultCount = 2;
            List<IFilterStrategy> filters = new List<IFilterStrategy>()
            {
                new MaxLayoverFilter(_options),
                new PastFlightsFilter(),
                new ArrivesBeforeDepartingFilter()
            };
            var flightfinder = new FlightFinder(_flightRepository, filters);
            var request = new FlightsRequest()
            {
                Filters = new List<string> { "ArrivesBeforeDepartingFilter", "PastFlightsFilter", "MaxLayoverFilter" }
            };

            //When
            var results = flightfinder.FindFlights(request);

            //Then
            Assert.AreEqual(expectedResultCount, results.Results.Count);
            Assert.IsFalse(results.HasErrors);
        }

        [Test]
        public void IncludeErrorWithInvalidFilterRequest()
        {
            //Given
            List<IFilterStrategy> filters = new List<IFilterStrategy>()
            {
                new MaxLayoverFilter(_options),
                new PastFlightsFilter(),
                new ArrivesBeforeDepartingFilter()
            };
            var flightfinder = new FlightFinder(_flightRepository, filters);
            var request = new FlightsRequest()
            {
                Filters = new List<string> { "FakeFilter", "ArrivesBeforeDepartingFilter", "PastFlightsFilter", "MaxLayoverFilter" }
            };

            //When
            var results = flightfinder.FindFlights(request);

            //Then
            Assert.IsTrue(results.HasErrors);
        }
    }
}