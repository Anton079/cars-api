using cars_api.Cars.Models;

namespace cars_api.Cars.Repository
{
    public interface ICarRepo
    {
        
        Task<List<Car>> GetCarsAsync();
    }
}
