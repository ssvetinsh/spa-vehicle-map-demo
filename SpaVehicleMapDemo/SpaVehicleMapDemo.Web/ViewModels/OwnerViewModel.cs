using System.Collections.Generic;

namespace SpaVehicleMapDemo.Web.ViewModels
{
    public class OwnerViewModel
    {
        public int UserId;
        public string Name;
        public string Surname;
        public string PhotoUrl;

        public List<VehicleViewModel> Vehicles;
    }
}