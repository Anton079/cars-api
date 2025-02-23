using cars_api.Cars.Dtos;
using cars_api.Cars.Models;

namespace cars_api.Cars.Repository
{
    public interface ICarRepo
    {
        
        Task<List<Car>> GetCarsAsync();

        Task<CarResponse>CreateCarsAsync(CarRequest car);

        Task<List<Car>> GetCarsByMinSpeed(int maxSpped);

        Task<List<Car>> GetCarByMinMaxSpeed(int minSpeed, int maxSpeed);
    }
}
