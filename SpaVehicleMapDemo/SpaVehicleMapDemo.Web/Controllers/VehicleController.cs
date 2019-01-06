using AutoMapper;
using SpaVehicleMapDemo.BusinessLogic.Services;
using SpaVehicleMapDemo.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SpaVehicleMapDemo.Web.Controllers
{
    public class VehicleController : Controller
    {
        private IUserService userService { get; }
        private IVehicleService vehicleService { get; }

        public VehicleController(IUserService userService, IVehicleService vehicleService)
        {
            this.userService = userService;
            this.vehicleService = vehicleService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetVehicleUserList()
        {
            var vehicleUserList = Mapper.Map<List<OwnerViewModel>>(userService.GetUsers());

            return Json(vehicleUserList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUserVehicleLocations(int userId)
        {
            var userVehicleLocations = Mapper.Map<List<VehicleLocationViewModel>>(vehicleService.GetVehicleLocations(userId));
            
            return Json(userVehicleLocations, JsonRequestBehavior.AllowGet);
        }
    }
}