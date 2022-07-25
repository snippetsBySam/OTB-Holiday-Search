using FluentAssertions;
using OTB_Holiday_Search.Models;
using OTB_Holiday_Search.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTB_Holiday_Search_Tests.Models.Result
{
    internal class HolidayResultTests
    {
        private HolidayResult _holidayResult;
        private Flight _testFlight;
        private Hotel _testHotel;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _testFlight = new Flight(1, "First Class Air", "MAN", "TFS", 470, DateTime.Parse("2023-07-01"));
            var testFlight2 = new Flight(2, "Oceanic Airlines", "MAN", "AGP", 245, DateTime.Parse("2023-07-01"));
            _testHotel = new Hotel(2, "Laguna Park 2", DateTime.Parse("2022-11-05"), 50, new string[] { "TFS" }, 7);
            var testHotel2 = new Hotel(3, "Sol Katmandu Park & Resort", DateTime.Parse("2023-06-15"), 59, new string[] { "PMI" }, 14);
            _holidayResult = new HolidayResult(_testFlight, _testHotel);
            var holidayResult2 = new HolidayResult(testFlight2, testHotel2);
        }

        [Test]
        public void TotalHotelPrice_Returns_Correct_Type()
        {
            _holidayResult.TotalHotelPrice.Should().BeOfType(typeof(decimal));
        }

        [Test]
        public void TotalHotelPrice_Returns_Correct_Value()
        {
            var expectedHotelPrice = _testHotel.PricePerNight * _testHotel.Nights;
            var result = _holidayResult.TotalHotelPrice;
            expectedHotelPrice.Should().Be(result);
        }

        [Test]
        public void TotalHolidayPrice_Returns_Correct_Type()
        {            
            _holidayResult.HolidayPrice.Should().BeOfType(typeof(decimal));
        }
        [Test]
        public void TotalHolidayPrice_Returns_Correct_Value()
        {
            var expectedHolidayPrice = (_testHotel.PricePerNight * _testHotel.Nights) + _testFlight.Price;
            var result = _holidayResult.HolidayPrice;
            expectedHolidayPrice.Should().Be(result);
        }
    }
}
