using Newtonsoft.Json;

namespace SpaVehicleMapDemo.BusinessLogic.Models
{
    public class Owner
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        [JsonProperty(PropertyName = "foto")]
        public string PhotoUrl { get; set; }
    }
}