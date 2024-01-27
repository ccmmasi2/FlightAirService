using System.ComponentModel.DataAnnotations;

namespace Flight.AirService.DTOObjects.Models
{
    public class Journey
    {
        [Key]
        public int ID { get; set; }


        [Required(ErrorMessage = "Required field")]
        [MaxLength(100, ErrorMessage = "The length of the field should be less than 100")]
        public string Client { get; set; }


        [Required(ErrorMessage = "Required field")]
        public DateTime Date { get; set; }


        [Required(ErrorMessage = "Required field")]
        [MaxLength(3, ErrorMessage = "The length of the field should be less than 3")]
        public string Origin { get; set; }


        [Required(ErrorMessage = "Required field")]
        [MaxLength(3, ErrorMessage = "The length of the field should be less than 3")]
        public string Destination { get; set; }


        [Required(ErrorMessage = "Required field")]
        public int TotalPrice { get; set; }
    }
}

