using cars_api.System;

namespace cars_api.Cars.Exceptions
{
    public class RangeExistException:Exception
    {
        public RangeExistException() :base(ExceptionMessages.RangeExistException) { }
    }
}
