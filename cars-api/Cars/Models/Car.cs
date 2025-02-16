using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cars_api.Cars.Models
{
    [Table("car")]

    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }

        [Required]
        [Column("brand")]
        public string brand { get; set; }

        [Required]
        [Column("modelType")]
        public string modelType { get; set; }

        [Required]
        [Column("horsePower")]
        public int horsePower {  get; set; }
        
        [Required]
        [Column("range")]
        public int range { get; set; }

        [Required]
        [Column("maxSpeed")]
        public int maxSpeed { get; set; }

    }
}
