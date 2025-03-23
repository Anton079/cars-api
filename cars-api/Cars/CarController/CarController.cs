using cars_api.Cars.Dtos;
using cars_api.Cars.Exceptions;
using cars_api.Cars.Models;
using cars_api.Cars.Service;
using Microsoft.AspNetCore.Mvc;

namespace cars_api.Cars.CarController
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CarController : ControllerBase
    {
        private ICarCommandService _carCommandService;
        private ICarQueryService _carQueryService;

        public CarController(ICarCommandService carCommandService, ICarQueryService carQueryService)
        {
            _carCommandService = carCommandService;
            _carQueryService = carQueryService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<CarResponse>>> GetCarsAsync()
        {
            var cars = await _carQueryService.GetAllCars();

            return Ok(cars);
        }

        [HttpPost("addCar")]
        public async Task<ActionResult<List<CarResponse>>> AddCarAsync([FromBody] AddCarRequest carReq)
        {
            var cars = await _carCommandService.AddCar(carReq);

            return Ok(cars);
        }

        [HttpDelete("deteleCar")]
        public async Task<ActionResult<List<CarResponse>>> DeleteCar([FromQuery]int id)
        {
            var car = await _carCommandService.DeleteCarById(id);

            return Ok(car);
        }

        [HttpPut("updateCar")]
        public async Task<ActionResult<List<CarResponse>>> UpdateCar([FromQuery]int id, [FromBody]EditCarRequest carReq)
        {
                var car = await _carCommandService.EditCar(id, carReq);

                return Ok(car);
        }
    }
}
