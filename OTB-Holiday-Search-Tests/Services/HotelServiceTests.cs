using FluentAssertions;
using OTB_Holiday_Search.Models;
using OTB_Holiday_Search.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTB_Holiday_Search_Tests.Services
{
    internal class HotelServiceTests
    {
        private HotelService _mockHotelService;
        private string _dummyFileData;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _mockHotelService = new HotelService();
            _dummyFileData = @"[{""id"": 1,""name"": ""Iberostar Grand Portals Nous"",""arrival_date"": ""2022-11-05"",""price_per_night"": 100,""local_airports"": [""TFS""],""nights"": 7},{""id"": 2,""name"": ""Laguna Park 2"",""arrival_date"": ""2022-11-05"",""price_per_night"": 50,""local_airports"": [""TFS""],""nights"": 7},{""id"": 3,""name"": ""Sol Katmandu Park & Resort"",""arrival_date"": ""2023-06-15"",""price_per_night"": 59,""local_airports"": [""PMI""],""nights"": 14},{""id"": 4,""name"": ""Sol Katmandu Park & Resort"",""arrival_date"": ""2023-06-15"",""price_per_night"": 59,""local_airports"": [""PMI""],""nights"": 14},{""id"": 5,""name"": ""Sol Katmandu Park & Resort"",""arrival_date"": ""2023-06-15"",""price_per_night"": 60,""local_airports"": [""PMI""],""nights"": 10},{""id"": 6,""name"": ""Club Maspalomas Suites and Spa"",""arrival_date"": ""2022-11-10"",""price_per_night"": 75,""local_airports"": [""LPA""],""nights"": 14},{""id"": 7,""name"": ""Club Maspalomas Suites and Spa"",""arrival_date"": ""2022-09-10"",""price_per_night"": 76,""local_airports"": [""LPA""],""nights"": 14},{""id"": 8,""name"": ""Boutique Hotel Cordial La Peregrina"",""arrival_date"": ""2022-10-10"",""price_per_night"": 45,""local_airports"": [""LPA""],""nights"": 7},{""id"": 9,""name"": ""Nh Malaga"",""arrival_date"": ""2023-07-01"",""price_per_night"": 83,""local_airports"": [""AGP""],""nights"": 7},{""id"": 10,""name"": ""Barcelo Malaga"",""arrival_date"": ""2023-07-05"",""price_per_night"": 45,""local_airports"": [""AGP""],""nights"": 10},{""id"": 11,""name"": ""Parador De Malaga Gibralfaro"",""arrival_date"": ""2023-10-16"",""price_per_night"": 100,""local_airports"": [""AGP""],""nights"": 7},{""id"": 12,""name"": ""MS Maestranza Hotel"",""arrival_date"": ""2023-07-01"",""price_per_night"": 45,""local_airports"": [""AGP""],""nights"": 14},{""id"": 13,""name"": ""Jumeirah Port Soller"",""arrival_date"": ""2023-06-15"",""price_per_night"": 295,""local_airports"": [""PMI""],""nights"": 10}]";
        }

        [Test]
        public void GetHotelsFromJson_Returns_List_Of_Hotel_Type()
        {
            var returnedHotels = _mockHotelService.GetHotelsFromJson();
            returnedHotels.Should().BeOfType<List<Hotel>>();
        }

        [Test]
        public void GetHotelsFromJson_Returns_Correct_Count_Of_Hotels()
        {
            var returnedHotels = _mockHotelService.GetHotelsFromJson(_dummyFileData);
            returnedHotels.Count.Should().Be(13);
        }

        [Test]
        public void GetHotelsFromJson_Returns_Correct_Data()
        {
            var returnedHotels = _mockHotelService.GetHotelsFromJson(_dummyFileData);

            var testHotel1 = new Hotel(1, "Iberostar Grand Portals Nous", DateTime.Parse("2022-11-05"), 100, new string[] { "TFS" }, 7);
            var testHotel2 = new Hotel(2, "Laguna Park 2", DateTime.Parse("2022-11-05"), 50, new string[] { "TFS" }, 7);
            var testHotel3 = new Hotel(3, "Sol Katmandu Park & Resort", DateTime.Parse("2023-06-15"), 59, new string[] { "PMI" }, 14);

            returnedHotels[0].Should().BeEquivalentTo(testHotel1);
            returnedHotels[1].Should().BeEquivalentTo(testHotel2);
            returnedHotels[2].Should().BeEquivalentTo(testHotel3);
        }
    }
}
