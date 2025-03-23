using cars_api.System;

namespace cars_api.Cars.Exceptions
{
    public class HorsePowerExistException:Exception
    {
        public HorsePowerExistException() : base(ExceptionMessages.HorsePowerExistException) { }
    }
}
