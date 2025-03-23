using cars_api.System;

namespace cars_api.Cars.Exceptions
{
    public class IdCarNotFound:Exception
    {
        public IdCarNotFound() :base(ExceptionMessages.IdCarNotFound) {}
    }
}
