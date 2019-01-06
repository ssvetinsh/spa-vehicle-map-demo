using Newtonsoft.Json;

namespace SpaVehicleMapDemo.BusinessLogic.Models
{
    public class Vehicle
    {
        [JsonProperty(PropertyName = "vehicleid")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "make")]
        public string Manufacturer { get; set; }

        public string Model { get; set; }
        public int Year { get; set; }
        public string Vin { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string ColorCode { get; set; }                    

        [JsonProperty(PropertyName = "foto")]
        public string PhotoUrl { get; set; }
    }
}