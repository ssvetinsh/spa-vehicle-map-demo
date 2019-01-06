using AutoMapper;
using SpaVehicleMapDemo.BusinessLogic.Models;
using SpaVehicleMapDemo.Web.ViewModels;

namespace SpaVehicleMapDemo.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, OwnerViewModel>()
                .ForMember(d => d.UserId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Owner.Name))
                .ForMember(d => d.Surname, o => o.MapFrom(s => s.Owner.Surname))
                .ForMember(d => d.PhotoUrl, o => o.MapFrom(s => s.Owner.PhotoUrl));

                cfg.CreateMap<Vehicle, VehicleViewModel>();
                cfg.CreateMap<VehicleLocation, VehicleLocationViewModel>();
            });
        }
    }
}