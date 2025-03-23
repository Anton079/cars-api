using cars_api.System;

namespace cars_api.Cars.Exceptions
{
    public class NullSpeedException:Exception
    {
        public NullSpeedException() :base(ExceptionMessages.NullSpeedException) { }
    }
}
