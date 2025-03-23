using cars_api.System;

namespace cars_api.Cars.Exceptions
{
    public class NullHorsePowerException:Exception
    {
        public NullHorsePowerException() : base(ExceptionMessages.NullHorsePowerException)
        {

        }
    }
}
