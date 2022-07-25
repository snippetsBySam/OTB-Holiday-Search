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
            List<Hotel> result;
            string jsonToParse;
            if (string.IsNullOrEmpty(jsonString))
            {
                if (File.Exists("../../../../hotels.json"))
                {
                    jsonToParse = GetFileString("../../../../hotels.json");
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
            try
            {
                result = JsonSerializer.Deserialize<List<Hotel>>(jsonToParse)!;
            }
            catch (System.Text.Json.JsonException)
            {

                throw new Exception("Invalid hotel JSON file");
            }
            return result;
        }

        public string GetFileString(string fileLocation)
        {
            string hotelsJsonString = File.ReadAllText(fileLocation);
            return hotelsJsonString;
        }
    }
}
