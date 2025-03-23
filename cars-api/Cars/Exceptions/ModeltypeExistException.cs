using cars_api.System;

namespace cars_api.Cars.Exceptions
{
    public class ModeltypeExistException:Exception
    {
        public ModeltypeExistException():base(ExceptionMessages.ModeltypeExistException) {}
    }
}
