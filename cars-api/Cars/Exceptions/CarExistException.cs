using cars_api.System;

namespace cars_api.Cars.Exceptions
{
    public class CarExistException : Exception
    {
        public CarExistException() : base(ExceptionMessages.CarExistException)
        {

        }
    }
}
