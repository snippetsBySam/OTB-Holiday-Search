using FluentAssertions;
using NUnit.Framework;
using OTB_Holiday_Search.Models;
using OTB_Holiday_Search.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTB_Holiday_Search_Tests.Models.Result
{
    public class ResultSorterTests
    {
        private List<HolidayResult> _testResults = new List<HolidayResult>();

        [SetUp]
        public void Setup()
        {
            var testFlight1 = new Flight(1, "First Class Air", "MAN", "TFS", 470, DateTime.Parse("2023-07-01"));
            var testFlight2 = new Flight(2, "Oceanic Airlines", "MAN", "AGP", 245, DateTime.Parse("2023-07-01"));
            var testHotel1 = new Hotel(2, "Laguna Park 2", DateTime.Parse("2022-11-05"), 50, new string[] { "TFS" }, 7);
            var testHotel2 = new Hotel(3, "Sol Katmandu Park & Resort", DateTime.Parse("2023-06-15"), 59, new string[] { "PMI" }, 14);
            _testResults.Add(new HolidayResult(testFlight1, testHotel1));
            _testResults.Add(new HolidayResult(testFlight2, testHotel2));
        }

        [Test]
        public void BestValue_Returns_Correct_Type()
        {
            ResultsSorter.BestValue(_testResults).Should().BeOfType<List<HolidayResult>>();
        }

        [Test]
        public void BestValue_Returns_Correct_Count()
        {
            ResultsSorter.BestValue(_testResults).Count.Should().Be(2);
        }


    }
}
