using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaVehicleMapDemo.BusinessLogic.Models
{
    public class User
    {
        [JsonProperty(PropertyName = "userid")]
        public int Id { get; set; }

        public virtual Owner Owner { get; set; }
        public virtual List<Vehicle> Vehicles { get; set; }
    }
}
