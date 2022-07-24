using FluentAssertions;
using NUnit.Framework;
using OTB_Holiday_Search.Models;
using OTB_Holiday_Search.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTB_Holiday_Search_Tests.Services
{
    internal class FlightServiceTests
    {
        private FlightService _mockFlightService;
        private string _dummyFileData;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _mockFlightService = new FlightService();
            _dummyFileData = @"[{""id"": 1,""airline"": ""First Class Air"",""from"": ""MAN"",""to"": ""TFS"",""price"": 470,""departure_date"": ""2023-07-01""},{""id"": 2,""airline"": ""Oceanic Airlines"",""from"": ""MAN"",""to"": ""AGP"",""price"": 245,""departure_date"": ""2023-07-01""},{""id"": 3,""airline"": ""Trans American Airlines"",""from"": ""MAN"",""to"": ""PMI"",""price"": 170,""departure_date"": ""2023-06-15""},{""id"": 4,""airline"": ""Trans American Airlines"",""from"": ""LTN"",""to"": ""PMI"",""price"": 153,""departure_date"": ""2023-06-15""},{""id"": 5,""airline"": ""Fresh Airways"",""from"": ""MAN"",""to"": ""PMI"",""price"": 130,""departure_date"": ""2023-06-15""},{""id"": 6,""airline"": ""Fresh Airways"",""from"": ""LGW"",""to"": ""PMI"",""price"": 75,""departure_date"": ""2023-06-15""},{""id"": 7,""airline"": ""Trans American Airlines"",""from"": ""MAN"",""to"": ""LPA"",""price"": 125,""departure_date"": ""2022-11-10""},{""id"": 8,""airline"": ""Fresh Airways"",""from"": ""MAN"",""to"": ""LPA"",""price"": 175,""departure_date"": ""2023-11-10""},{""id"": 9,""airline"": ""Fresh Airways"",""from"": ""MAN"",""to"": ""AGP"",""price"": 140,""departure_date"": ""2023-04-11""},{""id"": 10,""airline"": ""First Class Air"",""from"": ""LGW"",""to"": ""AGP"",""price"": 225,""departure_date"": ""2023-07-01""},{""id"": 11,""airline"": ""First Class Air"",""from"": ""LGW"",""to"": ""AGP"",""price"": 155,""departure_date"": ""2023-07-01""},{""id"": 12,""airline"": ""Trans American Airlines"",""from"": ""MAN"",""to"": ""AGP"",""price"": 202,""departure_date"": ""2023-10-25""}]";
        }

        [Test]
        public void GetFlightsFromJson_Returns_List_Of_Flight_Type()
        {
            var returnedFlights = _mockFlightService.GetFlightsFromJson();
            returnedFlights.Should().BeOfType<List<Flight>>();
        }

        [Test]
        public void GetFlightsFromJson_Returns_Correct_Count_Of_Flights()
        {
            var returnedFlights = _mockFlightService.GetFlightsFromJson(_dummyFileData);
            returnedFlights.Count.Should().Be(12);
        }

        [Test]
        public void GetFlightsFromJson_Returns_Correct_Data()
        {
            var returnedFlights = _mockFlightService.GetFlightsFromJson(_dummyFileData);

            var testFlight1 = new Flight(1, "First Class Air", "MAN", "TFS", 470, DateTime.Parse("2023-07-01"));
            var testFlight2 = new Flight(2, "Oceanic Airlines", "MAN", "AGP", 245, DateTime.Parse("2023-07-01"));

            returnedFlights[0].Should().BeEquivalentTo(testFlight1);
            returnedFlights[1].Should().BeEquivalentTo(testFlight2);
        }
    }
}
