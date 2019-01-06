using SpaVehicleMapDemo.BusinessLogic.Constants;
using SpaVehicleMapDemo.BusinessLogic.Helpers;
using SpaVehicleMapDemo.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaVehicleMapDemo.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        public List<User> GetUsers()
        {
            var result = new List<User>();

            try
            {
                result = JsonHelper.GetFirstInstance<List<User>>("data", WebRequestHelper.GetUrlResponseData(ApiUrls.UserListUrl))?.Where(s => s.Id != default(int)).ToList();
            }
            catch (Exception ex)
            {
                // TODO: add error handling
            }

            return result;
        }
    }

    public interface IUserService
    {
        List<User> GetUsers();
    }
}