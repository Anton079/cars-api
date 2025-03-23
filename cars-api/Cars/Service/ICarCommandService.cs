using cars_api.Cars.Dtos;
using cars_api.Cars.Models;

namespace cars_api.Cars.Service
{
    public interface ICarCommandService
    {
        Task<CarResponse> AddCar(AddCarRequest carReq);

        Task<CarResponse> EditCar(int id, EditCarRequest carReq);

        Task<CarResponse> DeleteCarById(int id);

    }
}
