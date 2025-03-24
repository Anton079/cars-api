using cars_api.System;

namespace cars_api.Cars.Exceptions
{
    public class IdToLowException:Exception
    {
        public IdToLowException() : base(ExceptionMessages.IdToLowException) { }

    }
}
