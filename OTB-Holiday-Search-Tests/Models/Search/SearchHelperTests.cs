using FluentAssertions;
using OTB_Holiday_Search.Models;
using OTB_Holiday_Search.Models.Query;
using OTB_Holiday_Search.Models.Result;
using OTB_Holiday_Search.Models.Search;
using OTB_Holiday_Search.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTB_Holiday_Search_Tests.Models.Search
{
    public class SearchHelperTests
    {
        private HolidayQuery _testQuery;
        private HolidaySearch _testSearch;

        [SetUp]
        public void Setup()
        {            
        }

        [Test]
        public void FlightsSearch_Returns_Correct_Type()
        {
            _testQuery = new HolidayQuery(new[] { "MAN" }, "AGP", DateTime.Parse("2023/07/01"), 7);
            _testSearch = new HolidaySearch(_testQuery);
            SearchHelper.FlightsSearch(new FlightService().GetFlightsFromJson(), _testQuery).Should().BeOfType<List<Flight>>();
        }

        [Test]
        public void FlightsSearch_Returns_Correct_Count()
        {
            _testQuery = new HolidayQuery(new[] { "MAN" }, "AGP", DateTime.Parse("2023/07/01"), 7);
            _testSearch = new HolidaySearch(_testQuery);
            SearchHelper.FlightsSearch(new FlightService().GetFlightsFromJson(), _testQuery).Count.Should().Be(1);
        }

        [Test]
        public void FlightsSearch_Returns_Correct_Count_When_Any_Is_Used()
        {
            _testQuery = new HolidayQuery(new[] { "any" }, "AGP", DateTime.Parse("2023/07/01"), 7);
            _testSearch = new HolidaySearch(_testQuery);
            SearchHelper.FlightsSearch(new FlightService().GetFlightsFromJson(), _testQuery).Count.Should().Be(3);
        }

        [Test]
        public void HotelsSearch_Returns_Correct_Type()
        {
            _testQuery = new HolidayQuery(new[] { "MAN" }, "AGP", DateTime.Parse("2023/07/01"), 7);
            _testSearch = new HolidaySearch(_testQuery);
            SearchHelper.HotelsSearch(new HotelService().GetHotelsFromJson(), _testQuery).Should().BeOfType<List<Hotel>>();
        }

        [Test]
        public void HotelsSearch_Returns_Correct_Count()
        {
            _testQuery = new HolidayQuery(new[] { "MAN" }, "AGP", DateTime.Parse("2023/07/01"), 7);
            _testSearch = new HolidaySearch(_testQuery);
            SearchHelper.HotelsSearch(new HotelService().GetHotelsFromJson(), _testQuery).Count.Should().Be(2);
        }

    }
}
