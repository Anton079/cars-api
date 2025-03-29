using cars_api.Cars.Dtos;
using cars_api.Cars.Exceptions;
using cars_api.Cars.Models;
using cars_api.Cars.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Linq.Expressions;

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
            try
            {
                var cars = await _carCommandService.AddCar(carReq);

                return Created("", cars);
            }
            catch (CarExistException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deteleCar")]
        public async Task<ActionResult<List<CarResponse>>> DeleteCar([FromQuery] int id)
        {
            try
            {
                var car = await _carCommandService.DeleteCarById(id);

                return Accepted(car);
            }
            catch (CarNotFoundException ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("updateCar")]
        public async Task<ActionResult<List<CarResponse>>> UpdateCar([FromQuery] int id, [FromBody] EditCarRequest carReq)
        {
            try
            {
                var car = await _carCommandService.EditCar(id, carReq);

                return Accepted(car);
            }
            catch (BrandExistException ex) { return BadRequest(ex.Message); }
            catch (CarNotFoundException ex) { return BadRequest(ex.Message); }
        }


        //4 endpointuri filtrari ordonari

        [HttpGet("getMinHP")]
        public async Task<ActionResult<List<CarResponse>>> GetMinHp([FromQuery] int minHp)
        {
            try
            {
                var car = await _carCommandService.FiltrationByMinHorsePower(minHp);
                return Ok(car);
            } catch (CarNotFoundException ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("getMinMaxSpeed")]
        public async Task<ActionResult<List<CarResponse>>> GetCarsMinMaxSpeed([FromQuery] int minSpeed, [FromQuery] int maxSpeed)
        {
            try
            {
                var car = await _carCommandService.GetCarByMinMaxSpeed(minSpeed, maxSpeed);
                return Ok(car);
            }
            catch (CarNotFoundException ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("getMinSpeed/{minSpeed}")]
        public async Task<ActionResult<List<CarResponse>>> GetCarsByMinSpeed([FromRoute] int minSpeed)
        {
            try
            {
                var car = await _carCommandService.GetCarsByMinSpeed(minSpeed);
                return Ok(car);
            }
            catch (CarNotFoundException ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("getCarsByBrand/{brand}")]
        public async Task<ActionResult<List<CarResponse>>> GetCarsByBrand([FromRoute]string brand)
        {
            try
            {
                var car = await _carCommandService.GetCarsByBrand(brand);
                return Ok(car);
            }
            catch (CarNotFoundException ex) { return BadRequest(ex.Message); }
        }

    }
}
