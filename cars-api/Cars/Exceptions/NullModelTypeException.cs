using cars_api.System;

namespace cars_api.Cars.Exceptions
{
    public class NullModelTypeException:Exception
    {
        public NullModelTypeException() :base(ExceptionMessages.NullModelTypeException) { }
    }
}
