using cars_api.System;

namespace cars_api.Cars.Exceptions
{
    public class CarNotFoundException:Exception
    {
        public CarNotFoundException() : base(ExceptionMessages.CarNotFoundException) { }
    }
}
