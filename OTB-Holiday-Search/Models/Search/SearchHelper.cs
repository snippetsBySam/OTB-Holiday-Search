using OTB_Holiday_Search.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTB_Holiday_Search.Models.Search
{
    public static class SearchHelper
    {
        public static List<Hotel> HotelsSearch(List<Hotel> hotels, HolidayQuery query)
        {
            var result = hotels.Where(hotel =>
                hotel.LocalAirports.Any(airports => airports == query.TravellingTo) &&
                query.DepartureDate == hotel.ArrivalDate).ToList();
            return result;
        }

        public static List<Flight> FlightsSearch(List<Flight> flights, HolidayQuery query)
        {
            List<Flight> result;
            if (query.DepartingFrom.Any(location => location.ToLower().Contains("any")))
            {
                result = flights.Where(flight =>
                query.TravellingTo == flight.To &&
                query.DepartureDate == flight.DepartureDate).ToList();
            }
            else
            {
                result = flights.Where(flight =>
                query.DepartingFrom.Any(location => location == flight.From) &&
                query.TravellingTo == flight.To &&
                query.DepartureDate == flight.DepartureDate).ToList();
            }
            return result;
        }
    }
}
