using cars_api.Cars.Dtos;
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

        [HttpGet("GetCarsByMinSpeed/{minSpeed}")]

        public async Task<ActionResult<List<Car>>> GetCarsByMinSpeed([FromRoute] int minSpeed)
        {
            var cars = await _carRepo.GetCarsByMinSpeed(minSpeed);

            return Ok(cars);
        }

        [HttpGet("GetCarsByMinMaxSpeed")]

        public async Task<ActionResult<List<Car>>> GetCarsMinMaxSpeed([FromQuery]int minSpeed, int maxSpeed)
        {
            var cars = await _carRepo.GetCarByMinMaxSpeed(minSpeed, maxSpeed);

            return Ok(cars);
        }

        [HttpPost("addCar")]

        public async Task<ActionResult<CarResponse>> CreatesAsync([FromBody]CarRequest carReq)
        {
            CarResponse carSaved = await _carRepo.CreateCarsAsync(carReq);

            return Ok(carSaved);
        }
    }
}
