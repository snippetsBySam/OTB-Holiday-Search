using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTB_Holiday_Search.Models.Result
{
    public class HolidayResult
    {
        public int FlightId { get; set; }
        public string FlightDepartingFrom { get; set; }
        public string FlightTravellingTo { get; set; }
        public decimal FlightPrice { get; set; }
        public DateTime FlightDate { get; set; }
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public DateTime ArrivalDate { get; set; }
        public decimal HotelPricePerNight { get; set; }
        public int HotelDuration { get; set; }
        public decimal TotalHotelPrice
        {
            get => HotelPricePerNight * HotelDuration;
        }
        public decimal HolidayPrice
        {
            get => FlightPrice + TotalHotelPrice;
        }

        public HolidayResult(Flight flight, Hotel hotel)
        {
            FlightId = flight.Id;
            FlightDepartingFrom = flight.From;
            FlightTravellingTo = flight.To;
            FlightPrice = flight.Price;
            FlightDate = flight.DepartureDate;
            HotelId = hotel.Id;
            HotelName = hotel.Name;
            ArrivalDate = hotel.ArrivalDate;
            HotelPricePerNight = hotel.PricePerNight;
            HotelDuration = hotel.Nights;
        }
    }
}
