using cars_api.Cars.Dtos;
using cars_api.Cars.Models;

namespace cars_api.Cars.Service
{
    public interface ICarCommandService
    {
        Task<CarResponse> AddCar(AddCarRequest carReq);

        Task<CarResponse> EditCar(int id, EditCarRequest carReq);

        Task<CarResponse> DeleteCarById(int id);

        Task<List<CarResponse>> FiltrationByMinHorsePower(int minHp);

        Task<List<CarResponse>> GetCarsByMinSpeed(int minSpeed);

        Task<List<CarResponse>> GetCarByMinMaxSpeed(int minSpeed, int maxSpeed);

        Task<List<CarResponse>> GetCarsByBrand(string brand);

    }
}
