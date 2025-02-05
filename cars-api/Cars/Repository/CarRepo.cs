using AutoMapper;
using cars_api.Cars.Models;
using cars_api.Data.Migrations;
using Microsoft.EntityFrameworkCore;

namespace cars_api.Cars.Repository
{
    public class CarRepo: ICarRepo
    {
        private readonly AppDbContext _appdbContext;
        private readonly IMapper _mapper;

        public CarRepo(AppDbContext appdbContext, IMapper mapper)
        {
            this._appdbContext = appdbContext;
            this._mapper = mapper;
        }

        public async Task<List<Car>> GetCarsAsync()
        {
            return await _appdbContext.Cars.ToListAsync();
        }
    }
}
