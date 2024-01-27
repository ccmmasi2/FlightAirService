using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Flight.AirService.DTOObjects.Models
{
    public class FlightDTL
    {
        [Key]
        public int ID { get; set; }


        public int IDTransport { get; set; }
        [ForeignKey("IDTransport")]
        public Transport Transport { get; set; }


        public int IDJourney{ get; set; }
        [ForeignKey("IDJourney")]
        public Journey Journey { get; set; }


        [Required(ErrorMessage = "Required field")]
        [MaxLength(3, ErrorMessage = "The length of the field should be less than 3")]
        public string Origin { get; set; }


        [Required(ErrorMessage = "Required field")]
        [MaxLength(3, ErrorMessage = "The length of the field should be less than 3")]
        public string Destination { get; set; }


        [Required(ErrorMessage = "Required field")]
        public decimal Price { get; set; }
    }
}

