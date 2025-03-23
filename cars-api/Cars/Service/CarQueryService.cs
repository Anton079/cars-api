using AutoMapper;
using cars_api.Cars.Dtos;
using cars_api.Cars.Models;
using cars_api.Cars.Repository;

namespace cars_api.Cars.Service
{
    public class CarQueryService : ICarQueryService
    {
        private ICarRepo _carRepo;
        private IMapper _mapper;

        public CarQueryService(ICarRepo carRepo,IMapper mapper)        
        {
            this._carRepo = carRepo;
            this._mapper = mapper;
        }

        public async Task<List<CarResponse>> GetAllCars()
        {
            var cars= await _carRepo.GetCarsAsync();

            return _mapper.Map<List<CarResponse>>(cars);
        }

        

    }
}
