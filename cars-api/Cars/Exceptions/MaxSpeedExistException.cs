using cars_api.System;

namespace cars_api.Cars.Exceptions
{
    public class MaxSpeedExistException:Exception
    {
        public MaxSpeedExistException():base(ExceptionMessages.SpeedExistException) { }
    }
}
