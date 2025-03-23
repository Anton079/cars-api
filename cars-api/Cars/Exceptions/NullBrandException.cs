using cars_api.System;

namespace cars_api.Cars.Exceptions
{
    public class NullBrandException : Exception
    {
        public NullBrandException() :base(ExceptionMessages.NullBrandException)
        {

        }
    }
}
