using cars_api.Cars.Models;
using cars_api.Cars.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cars_api.Cars.CarController
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CarController : ControllerBase
    {
        private ICarRepo _carRepo;

        public CarController(ICarRepo carRepo)
        {
            this._carRepo = carRepo;
        }

        [HttpGet("all")]

        public async Task<ActionResult<List<Car>>> GetCarsAsync()
        {
            var cars = await _carRepo.GetCarsAsync();

            return Ok(cars);
        }
    }
}
