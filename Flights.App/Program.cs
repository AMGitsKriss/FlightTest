using Flights.DTO;
using Flights.Logic;
using Flights.Logic.Filters;
using Flights.Logic.Models;
using Flights.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Flights.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = LoadServiceCollection();

            var flightfinder = serviceProvider.GetService<IFlightFinder>();
            var options = serviceProvider.GetService<IOptions<FilterSettingsConfig>>();

            var request = new FlightsRequest()
            {
                Filters = options.Value.FiltersToUse
            };

            var results = flightfinder.FindFlights(request);

            PrintResults(results.Results);
        }

        static ServiceProvider LoadServiceCollection()
        {
            var configuration = LoadConfiguration(); 
            return new ServiceCollection()
                .AddOptions()
                .Configure<FilterSettingsConfig>(configuration.GetSection("FilterSettings"))
                .AddScoped<IFilterStrategy, MaxLayoverFilter>()
                .AddScoped<IFilterStrategy, PastFlightsFilter>()
                .AddScoped<IFilterStrategy, ArrivesBeforeDepartingFilter>()
                .AddScoped<IFlightRepository, FlightBuilder>()
                .AddScoped<IFlightFinder, FlightFinder>()
                .BuildServiceProvider();
        }

        static IConfigurationRoot LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("config.json", optional: false, reloadOnChange: true);

            return builder.Build();

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
