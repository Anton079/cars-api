using cars_api.System;

namespace cars_api.Cars.Exceptions
{
    public class NullCarException : Exception
    {
        public NullCarException() : base(ExceptionMessages.NullCarException)
        {

        }
    }
}
