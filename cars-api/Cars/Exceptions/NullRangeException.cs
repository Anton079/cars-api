using cars_api.System;

namespace cars_api.Cars.Exceptions
{
    public class NullRangeException:Exception
    {
        public NullRangeException() : base(ExceptionMessages.NullRangeException) { }
    }
}
