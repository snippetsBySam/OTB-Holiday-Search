using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OTB_Holiday_Search.Models
{
    public class Flight
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("airline")]
        public string Airline { get; set; }
        [JsonPropertyName("from")]
        public string From { get; set; }
        [JsonPropertyName("to")]
        public string To { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("departure_date")]
        public DateTime DepartureDate { get; set; }

        public Flight() { }
        public Flight(int id, string airline, string from, string to, decimal price, DateTime departureDate)
        {
            Id = id;
            Airline = airline;
            From = from;
            To = to;
            Price = price;
            DepartureDate = departureDate;
        }

    }
}
