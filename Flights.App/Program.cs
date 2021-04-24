using Flights.Logic;
using Flights.Logic.Filters;
using Flights.Repository;
using System;
using System.Collections.Generic;

namespace Flights.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // TODO - Dependency Injection
            // TODO - Print results

            IFlightRepository flightRepository = new FlightBuilder();

            List<IFilterStrategy> filters = new List<IFilterStrategy>()
            {
                new MaxLayoverFilter(2) // TODO - Load this "2" from a config
            };

            var flightfinder = new FlightFinder(flightRepository, filters);
            var results = flightfinder.FindFlights();
        }
    }
}
