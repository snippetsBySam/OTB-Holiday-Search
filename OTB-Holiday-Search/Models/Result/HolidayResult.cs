using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTB_Holiday_Search.Models.Result
{
    public class HolidayResult
    {
        public Flight Flight { get; set; }
        public Hotel Hotel { get; set; }
        public decimal TotalHotelPrice
        {
            get => Hotel.PricePerNight * Hotel.Nights;
        }
        public decimal HolidayPrice
        {
            get => Flight.Price + TotalHotelPrice;
        }

        public HolidayResult(Flight flight, Hotel hotel)
        {
            Flight = flight;
            Hotel = hotel;
        }

        public override string ToString()
        {
            return $"Flight {Flight.Id} and Hotel {Hotel.Id}. Total Cost {HolidayPrice:C2}";
        }
    }
}
