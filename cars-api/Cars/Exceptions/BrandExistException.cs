using cars_api.System;

namespace cars_api.Cars.Exceptions
{
    public class BrandExistException:Exception
    {
        public BrandExistException():base(ExceptionMessages.BrandExistException) {}
    }
}
