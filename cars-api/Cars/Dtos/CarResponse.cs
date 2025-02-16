namespace cars_api.Cars.Dtos
{
    public class CarResponse
    {
        public  int Id { get; set; }
        public string Brand { get; set; }
        public string ModelType { get; set; }
        public int HorsePower { get; set; }
        public int Range { get; set; }
        public int MaxSpeed { get; set; }
    }
}
