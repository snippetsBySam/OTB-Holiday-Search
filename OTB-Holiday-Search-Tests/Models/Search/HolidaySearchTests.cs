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
    public class HolidaySearchTests
    {
        private HolidayQuery _testQuery;
        private HolidaySearch _testSearch;

        [SetUp]
        public void Setup()
        {
            _testQuery = new HolidayQuery(new[] { "MAN" }, "AGP", DateTime.Parse("2023/07/01"), 7);
            _testSearch = new HolidaySearch(_testQuery);
        }

        [Test]
        public void Result_Returns_Correct_Type()
        {
            _testSearch.Results().Should().BeOfType<List<HolidayResult>>();
        }

        [Test]
        public void Result_Returns_Correct_Count()
        {
            _testSearch.Results().Count().Should().Be(2);
        }

        [Test]
        public void Customer1_Case_Returns_Correct_Result()
        {
            _testQuery = new HolidayQuery(new[] { "MAN" }, "AGP", DateTime.Parse("2023/07/01"), 7);
            _testSearch = new HolidaySearch(_testQuery);
            _testSearch.Results().First().Flight.Id.Should().Be(2);
            _testSearch.Results().First().Hotel.Id.Should().Be(9);
        }

        [Test]
        public void Customer2_Case_Returns_Correct_Result()
        {
            _testQuery = new HolidayQuery(new[] { "LTN", "LGW" }, "PMI", DateTime.Parse("2023/06/15"), 107);
            _testSearch = new HolidaySearch(_testQuery);
            _testSearch.Results().First().Flight.Id.Should().Be(6);
            _testSearch.Results().First().Hotel.Id.Should().Be(5);
        }

        [Test]
        public void Customer3_Case_Returns_Correct_Result()
        {
            _testQuery = new HolidayQuery(new[] { "any" }, "LPA", DateTime.Parse("2022/11/10"), 14);
            _testSearch = new HolidaySearch(_testQuery);
            _testSearch.Results().First().Flight.Id.Should().Be(7);
            _testSearch.Results().First().Hotel.Id.Should().Be(6);
        }


    }
}
