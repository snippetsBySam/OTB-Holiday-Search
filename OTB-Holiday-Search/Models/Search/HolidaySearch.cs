using OTB_Holiday_Search.Models.Query;
using OTB_Holiday_Search.Models.Result;
using OTB_Holiday_Search.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTB_Holiday_Search.Models.Search
{
    public class HolidaySearch
    {
        private List<HolidayResult> _holidayResult = new List<HolidayResult>();
        private List<Flight> _matchingFlights = new List<Flight>();
        private List<Hotel> _matchingHotels = new List<Hotel>();

        public HolidaySearch(HolidayQuery query)
        {

            this._matchingFlights = new FlightService().GetFlightsFromJson().Where(flight =>
                query.DepartingFrom.Any(location => location == flight.From) &&
                query.TravellingTo == flight.To &&
                query.DepartureDate == flight.DepartureDate).ToList();
            this._matchingHotels = new HotelService().GetHotelsFromJson().Where(hotel =>
                hotel.LocalAirports.Any(airports => airports == query.TravellingTo) &&
                query.DepartureDate == hotel.ArrivalDate).ToList();
            BuildResult();
        }

        public List<HolidayResult> Results()
        {
            return ResultsSorter.BestValue(this._holidayResult);
        }
        private void BuildResult()
        {
            if (_matchingFlights.Count > 0 && _matchingHotels.Count > 0)
            {
                _matchingFlights.ForEach(flight =>
                    _matchingHotels.ForEach(hotel =>
                        _holidayResult.Add(new HolidayResult(flight, hotel))));
            }
            else
            {
                throw new Exception("Not enough Results");
            }
        }
    }
}
