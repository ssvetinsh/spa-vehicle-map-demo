using Newtonsoft.Json;

namespace SpaVehicleMapDemo.BusinessLogic.Models
{
    public class VehicleLocation
    {
        public int VehicleId { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "lon")]
        public double Longitude { get; set; }
    }
}