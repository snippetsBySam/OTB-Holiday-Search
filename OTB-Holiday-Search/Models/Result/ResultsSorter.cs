using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTB_Holiday_Search.Models.Result
{
    public static class ResultsSorter
    {
        public static List<HolidayResult> BestValue(List<HolidayResult> resultsToSort)
        {
            return resultsToSort.OrderBy(holidayResult => holidayResult.HolidayPrice).ToList();
        }
    }
}
