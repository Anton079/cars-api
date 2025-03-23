using cars_api.System;
using System.ComponentModel.DataAnnotations;

namespace cars_api.Cars.Dtos
{
    public class AddCarRequest
    {
        [Required(ErrorMessage = "Model este null, trebuie sa il completezi")]
        [StringLength(100, ErrorMessage ="Trebuie sa aiba maxim 100 de caractere")]
        public string Brand { get; set; }

        [Required(ErrorMessage ="Model Type este null, trebuie sa il completezi")]
        [StringLength(100, ErrorMessage ="Trebuie sa aiba maxim 100 de caractere")]
        public string ModelType {  get; set; }

        [Required(ErrorMessage ="Horse Power este null, trebuie sa il completezi")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Trebuie o valoare mai mare de 0")]
        public int HorsePower {  get; set; }

        [Required(ErrorMessage ="Range este null, trebuie sa il compltezi")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Trebuie o valoare mai mare de 0")]
        public int Range {  get; set; }

        [Required(ErrorMessage = "Max Speed este null, trebuie sa il completezi")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Trebuie o valoare mai mare de 0")]
        public int MaxSpeed { get; set; }

    }
}
