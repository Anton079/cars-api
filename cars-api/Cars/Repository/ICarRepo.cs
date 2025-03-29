using cars_api.Cars.Dtos;
using cars_api.Cars.Models;
using cars_api.Data.Migrations;

namespace cars_api.Cars.Repository
{
    public interface ICarRepo
    {
        
        Task<List<CarResponse>> GetCarsAsync();

        Task<CarResponse>CreateCarsAsync(AddCarRequest car);

        Task<CarResponse> DeleteCarByBrand(string brandName);

        Task<CarResponse> DeleteCarById(int id);

        Task<CarResponse> UpdateCar(int id, EditCarRequest carRequest);

        Task<CarResponse> FindCarByIdAsync(int id);

        Task<CarResponse> FindCarByBrandAsync(string brand);
        
        //------

        Task<List<CarResponse>> GetCarsByMinHP(int minHP);

        Task<List<CarResponse>> GetCarsByMinSpeed(int maxSpped);

        Task<List<CarResponse>> GetCarByMinMaxSpeed(int minSpeed, int maxSpeed);

        Task<List<CarResponse>> GetCarsByBrand(string brand);

    }
}
