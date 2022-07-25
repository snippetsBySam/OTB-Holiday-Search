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

            this._matchingFlights = SearchHelper.FlightsSearch(new FlightService().GetFlightsFromJson(), query)
;
            this._matchingHotels = SearchHelper.HotelsSearch(new HotelService().GetHotelsFromJson(), query);
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
