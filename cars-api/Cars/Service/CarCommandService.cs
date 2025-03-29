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
            
            
            if (await _carRepo.FindCarByBrandAsync(carReq.Brand) != null) 
                throw new CarExistException();

            CarResponse resp =await _carRepo.CreateCarsAsync(carReq);
            
            return resp;
        }

        public async Task<CarResponse> EditCar(int id, EditCarRequest carReq)
        {
            var existingCar = await _carRepo.FindCarByIdAsync(id);

          

            if (existingCar == null)
            {
                throw new CarNotFoundException();
            }


            if (carReq.Brand is not null)
            {

                existingCar = await _carRepo.FindCarByBrandAsync(carReq.Brand);


                if (existingCar is not null)
                {
                    throw new BrandExistException();
                }
            }
        


            CarResponse resp = await _carRepo.UpdateCar(id, carReq);

            return resp;
        }

        public async Task<CarResponse> DeleteCarById(int id)
        {

            var car = await _carRepo.FindCarByIdAsync(id);

            if (car == null) { throw new CarNotFoundException(); }

            car = await _carRepo.DeleteCarById(id);

            return car;
        }

        public async Task<List<CarResponse>> FiltrationByMinHorsePower(int minHp)
        {
            var car = await _carRepo.GetCarsByMinHP(minHp);

            if (car == null) { throw new CarNotFoundException(); }

            return _mapper.Map<List<CarResponse>>(car);
        }

        public async Task<List<CarResponse>> GetCarsByMinSpeed(int minSpeed)
        {
            var car = await _carRepo.GetCarsByMinSpeed(minSpeed);

            if (car == null) { throw new CarNotFoundException(); }

            return _mapper.Map<List<CarResponse>>(car);
        }

        public async Task<List<CarResponse>> GetCarByMinMaxSpeed(int minSpeed, int maxSpeed)
        {
            var car = await _carRepo.GetCarByMinMaxSpeed(minSpeed, maxSpeed);

            if (car == null) { throw new CarNotFoundException(); }

            return _mapper.Map<List<CarResponse>>(car);
        }

        public async Task<List<CarResponse>> GetCarsByBrand(string brand)
        {
            var car = await _carRepo.GetCarsByBrand(brand);

            if (car == null) { throw new CarNotFoundException(); }

            return _mapper.Map<List<CarResponse>>(car);
        }

    }
}
