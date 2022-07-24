using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTB_Holiday_Search.Models.Query
{
    public class HolidayQuery
    {
        internal string[] DepartingFrom;
        internal string TravellingTo;
        internal DateTime DepartureDate;
        internal int Duration;
        public HolidayQuery(string[] departingFrom, string travellingTo, DateTime departureDate, int duration)
        {
            DepartingFrom = departingFrom;
            TravellingTo = travellingTo;
            DepartureDate = departureDate;
            Duration = duration;
        }
    }
}
