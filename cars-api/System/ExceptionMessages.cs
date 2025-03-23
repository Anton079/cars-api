namespace cars_api.System
{
    public  class ExceptionMessages
    {
        //AddCar Exception
        public static readonly string NullCarException ="Obiectul car este null!";

        //Car Atribute Exceptions
        public static readonly string NullIdException = "Atributul id este null!";
        public static readonly string IdCarNotFound = "Atributul id nu a fost gasit";
        public static readonly string NullBrandException = "Atributul (Model) este null, trebuie sa il completezi";
        public static readonly string NullModelTypeException = "Atributul (Model Type) este null, trebuie sa il completezi";
        public static readonly string NullHorsePowerException = "Atributul (Horse Power) este null, trebuie sa il completezi";
        public static readonly string NullRangeException = "Atributul (Range) este null, trebuie sa il compltezi";
        public static readonly string NullSpeedException = "Atributul (Max Speed) este null, trebuie sa il completezi";

        //Car Exception Exist
        public static readonly string CarExistException = "Obiectul car deja exista!";

        public static readonly string IdExistException = "Atributul id exista deja";
        public static readonly string BrandExistException = "Atributul brand exista deja";
        public static readonly string ModeltypeExistException = "Atributul ModelType exista deja";
        public static readonly string HorsePowerExistException = "Atributul HorsePower exista deja";
        public static readonly string RangeExistException = "Atributul Range exista deja";
        public static readonly string SpeedExistException = "Atributul Speed exista deja";
    }
}
