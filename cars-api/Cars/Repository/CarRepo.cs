using AutoMapper;
using cars_api.Cars.Dtos;
using cars_api.Cars.Models;
using cars_api.Data.Migrations;
using Microsoft.EntityFrameworkCore;

namespace cars_api.Cars.Repository
{
    public class CarRepo : ICarRepo
    {
        private readonly AppDbContext _appdbContext;
        private readonly IMapper _mapper;

        public CarRepo(AppDbContext appdbContext, IMapper mapper)
        {
            this._appdbContext = appdbContext;
            this._mapper = mapper;
        }

        public async Task<CarResponse> CreateCarsAsync(CarRequest carReq)
        {
            Car car = _mapper.Map<Car>(carReq);

            _appdbContext.Cars.Add(car);

            await _appdbContext.SaveChangesAsync();

            CarResponse response = _mapper.Map<CarResponse>(car);

            return response;
        }

        public async Task<List<Car>> GetCarsByMinSpeed(int minSpeed)
        {
            return await _appdbContext.Cars.Where(car => car.maxSpeed > minSpeed).ToListAsync();
        }

        public async Task<List<Car>> GetCarByMinMaxSpeed(int minSpeed, int maxSpeed)
        {
            return await _appdbContext.Cars.Where(car => car.maxSpeed > minSpeed && car.maxSpeed < maxSpeed).ToListAsync();
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            return await _appdbContext.Cars.ToListAsync();
        }
    }
}
