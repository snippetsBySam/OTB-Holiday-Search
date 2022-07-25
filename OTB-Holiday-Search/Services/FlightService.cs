using OTB_Holiday_Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OTB_Holiday_Search.Services
{
    public class FlightService
    {
        public List<Flight> GetFlightsFromJson(string jsonString = "")
        {
            string jsonToParse;
            if (string.IsNullOrEmpty(jsonString))
            {
                if (File.Exists("../../../../flights.json"))
                {
                    jsonToParse = GetFileString("../../../../flights.json"); 
                }
                else
                {
                    return new List<Flight>();
                }
                
            }
            else
            {
                jsonToParse = jsonString;
            }
            return JsonSerializer.Deserialize<List<Flight>>(jsonToParse)!;
        }

        public string GetFileString(string fileLocation)
        {
            string flightsJsonString = File.ReadAllText(fileLocation);
            return flightsJsonString;
        }
    }
}
