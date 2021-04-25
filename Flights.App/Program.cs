using Flights.DTO;
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
            // TODO - Dependency Injection

            IFlightRepository flightRepository = new FlightBuilder();

            List<IFilterStrategy> filters = new List<IFilterStrategy>()
            {
                new MaxLayoverFilter(2), // TODO - Load this "2" from a config
                new PastFlightsFilter(),
                new ArrivesBeforeDepartingFilter()
            };

            var flightfinder = new FlightFinder(flightRepository, filters);
            var results = flightfinder.FindFlights();

            PrintResults(results);
        }

        static void PrintResults(IList<Flight> results)
        {
            foreach (var flight in results)
            {
                Console.Write($"Segments: {flight.Segments.Count} ");
                foreach (var segment in flight.Segments)
                {
                    Console.Write($"Journey: [Depart: {segment.DepartureDate} Arrive: {segment.ArrivalDate}] ");
                }
                Console.WriteLine();
            }
        }
    }
}
