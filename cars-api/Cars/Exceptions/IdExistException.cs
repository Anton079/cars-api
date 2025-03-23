using cars_api.System;

namespace cars_api.Cars.Exceptions
{
    public class IdExistException:Exception
    {
        public IdExistException() : base(ExceptionMessages.IdExistException) { }
    }
}
