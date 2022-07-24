using OTB_Holiday_Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OTB_Holiday_Search.Services
{
    public class HotelService
    {
        public List<Hotel> GetHotelsFromJson(string jsonString = "")
        {
            string jsonToParse;
            if (string.IsNullOrEmpty(jsonString))
            {
                if (File.Exists("hotels.json"))
                {
                    jsonToParse = GetFileString("hotels.json");
                }
                else
                {
                    return new List<Hotel>();
                }

            }
            else
            {
                jsonToParse = jsonString;
            }
            return JsonSerializer.Deserialize<List<Hotel>>(jsonToParse)!;
        }

        public string GetFileString(string fileLocation)
        {
            string hotelsJsonString = File.ReadAllText(fileLocation);
            return hotelsJsonString;
        }
    }
}
