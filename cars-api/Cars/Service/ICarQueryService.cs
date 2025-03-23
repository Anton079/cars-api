using cars_api.Cars.Dtos;
using cars_api.Cars.Models;

namespace cars_api.Cars.Service
{
    public interface ICarQueryService
    {
        Task<List<CarResponse>> GetAllCars();

    }
}
