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


    }
}
