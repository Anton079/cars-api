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
        [Column("model_type")]
        public string model_type { get; set; }

        [Required]
        [Column("horse_power")]
        public int horse_power {  get; set; }
        
        [Required]
        [Column("range")]
        public int range { get; set; }

        [Required]
        [Column("max_speed")]
        public int max_speed { get; set; }

    }
}
