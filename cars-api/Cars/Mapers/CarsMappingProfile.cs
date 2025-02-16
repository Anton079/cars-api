using AutoMapper;
using cars_api.Cars.Dtos;
using cars_api.Cars.Models;

namespace cars_api.Cars.Mapers
{
    public class CarsMappingProfile:Profile
    {


        public CarsMappingProfile() {
            CreateMap<CarRequest, Car>();
            CreateMap<Car, CarResponse>();
        }
    }
}
