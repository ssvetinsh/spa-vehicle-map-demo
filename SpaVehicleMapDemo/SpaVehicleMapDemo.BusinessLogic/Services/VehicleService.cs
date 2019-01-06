using SpaVehicleMapDemo.BusinessLogic.Constants;
using SpaVehicleMapDemo.BusinessLogic.Helpers;
using SpaVehicleMapDemo.BusinessLogic.Models;
using System;
using System.Collections.Generic;

namespace SpaVehicleMapDemo.BusinessLogic.Services
{
    public class VehicleService : IVehicleService
    {
        public List<VehicleLocation> GetVehicleLocations(int userId)
        {
            var result = new List<VehicleLocation>();

            try
            {
                result = JsonHelper.GetFirstInstance<List<VehicleLocation>>("data", WebRequestHelper.GetUrlResponseData(string.Format(ApiUrls.VehicleLocationUrl, userId)));
            }
            catch (Exception ex)
            {
                // TODO: add error handling
            }          

            return result;
        }
    }

    public interface IVehicleService
    {
        List<VehicleLocation> GetVehicleLocations(int userId);
    }
}
