using System.ComponentModel.DataAnnotations;

namespace Flight.AirService.DTOObjects.Models
{
    public class Transport
    {
        [Key]
        public int ID { get; set; }


        [Required(ErrorMessage = "Required field")]
        [MaxLength(4, ErrorMessage = "The length of the field should be less than 4")]
        public string FlightCarrier { get; set; }


        [Required(ErrorMessage = "Required field")]
        [MaxLength(4, ErrorMessage = "The length of the field should be less than 4")]
        public int FlightNumber { get; set; }
    }
}
