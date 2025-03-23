using AutoMapper;
using cars_api.Cars.Dtos;
using cars_api.Cars.Models;
using cars_api.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Validation;

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

        public async Task<List<CarResponse>> GetCarsAsync()
        {
            var cars = await _appdbContext.Cars.ToListAsync();

            var carsReponse = cars.Select(car => _mapper.Map<CarResponse>(car)).ToList();

            return carsReponse;
        }

        public async Task<CarResponse> CreateCarsAsync(AddCarRequest carReq)
        {
            Car car = _mapper.Map<Car>(carReq);

            _appdbContext.Cars.Add(car);

            await _appdbContext.SaveChangesAsync();

            CarResponse response = _mapper.Map<CarResponse>(car);

            return response;
        }

        public async Task<CarResponse> GetCarsByMinSpeed(int minSpeed)
        {
            var cars = await _appdbContext.Cars.Where(car => car.maxSpeed > minSpeed).ToListAsync();

            return _mapper.Map<CarResponse>(cars);
        }

        public async Task<CarResponse> GetCarByMinMaxSpeed(int minSpeed, int maxSpeed)
        {
            var cars = await _appdbContext.Cars.Where(car => car.maxSpeed > minSpeed && car.maxSpeed < maxSpeed).ToListAsync();

            return _mapper.Map<CarResponse>(cars);
        }

        public async Task<CarResponse> DeleteCarByBrand(string brandName)
        {
            var cars = await _appdbContext.Cars.Where(car => car.brand == brandName).ToListAsync();

            return _mapper.Map<CarResponse>(cars);
        }

        public async Task<CarResponse> GetCarsByMinHP(int minHP)
        {
            var cars = await _appdbContext.Cars.Where(car => car.horsePower > minHP).ToListAsync();

            return _mapper.Map<CarResponse>(cars);
        }

        public async Task<CarResponse> GetAllCarsWitchOutABrand(string brandName)
        {
            var cars = await _appdbContext.Cars.Where(car => car.brand != brandName).ToListAsync();

            return _mapper.Map<CarResponse>(cars);
        }

        public async Task<CarResponse> DeleteCarById(int id)
        {
            Car car =  await _appdbContext.Cars.FindAsync(id);

             CarResponse carResponse= _mapper.Map<CarResponse>(car);

            _appdbContext.Cars.Remove(car);

            await _appdbContext.SaveChangesAsync();

            return carResponse;
        }

        public async Task<CarResponse> UpdateCar(int id,EditCarRequest carRequest)
        {
            var car = await _appdbContext.Cars.FindAsync(id);
            
            car.brand = carRequest.Brand ?? car.brand;
            car.modelType = carRequest.ModelType ?? car.modelType;
            car.horsePower = carRequest.HorsePower ?? car.horsePower;
            car.range = carRequest.Range ?? car.range;
            car.maxSpeed = carRequest.MaxSpeed ?? car.maxSpeed;

            _appdbContext.Cars.Update(car);
            await _appdbContext.SaveChangesAsync();

            return _mapper.Map<CarResponse>(car);


        }

        public async Task<CarResponse> FindCarByIdAsync(int id)
        {
            var car = await _appdbContext.Cars.FirstOrDefaultAsync(car => car.id == id);

            return _mapper.Map<CarResponse>(car);
        }

        public async Task<bool> IsDuplicatedAsync(AddCarRequest carReq)
        {
            return await _appdbContext.Cars.AnyAsync(c => c.modelType == carReq.ModelType &&
                                                          c.brand == carReq.Brand);
        }
    }
}
