using AutoMapper;
using cars_api.Cars.Dtos;
using cars_api.Cars.Exceptions;
using cars_api.Cars.Models;
using cars_api.Cars.Repository;
using cars_api.Data.Migrations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.CodeDom;

namespace cars_api.Cars.Service
{
    public class CarCommandService : ICarCommandService
    {
        private ICarRepo _carRepo;
        private IMapper _mapper;

        public CarCommandService(ICarRepo carRepo, IMapper mapper)
        {
            this._carRepo = carRepo;
            this._mapper = mapper;
        }

        public async Task<CarResponse> AddCar(AddCarRequest carReq)
        {
            if (carReq == null) { throw new NullCarException(); }

            if (await _carRepo.IsDuplicatedAsync(carReq)) throw new CarExistException();

            CarResponse resp =await _carRepo.CreateCarsAsync(carReq);
            
            return resp;
        }

        public async Task<CarResponse> EditCar(int id, EditCarRequest carReq)
        {
            var existingCar = await _carRepo.FindCarByIdAsync(id);

            if (existingCar == null) { throw new IdCarNotFound(); }

            if (existingCar.HorsePower == null) { throw new NullHorsePowerException(); }
            if (existingCar.ModelType == null) { throw new NullModelTypeException(); }
            if (existingCar.MaxSpeed == null) { throw new NullSpeedException(); }
            if (existingCar.Brand == null) { throw new NullBrandException(); }
            if (existingCar.Range == null) { throw new NullRangeException(); }

            CarResponse resp = await _carRepo.UpdateCar(id, carReq);

            return resp;
        }

        public async Task<CarResponse> DeleteCarById(int id)
        {
            if(id <= 0) { throw new IdCarNotFound(); }

            var car = await _carRepo.FindCarByIdAsync(id);

            if (car == null) { throw new NullCarException(); }

            car = await _carRepo.DeleteCarById(id);

            return _mapper.Map<CarResponse>(car);
        }
    }
}
