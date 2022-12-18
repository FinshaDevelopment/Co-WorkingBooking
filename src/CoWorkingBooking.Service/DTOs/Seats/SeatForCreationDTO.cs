using System.ComponentModel.DataAnnotations;

namespace CoWorkingBooking.Service.DTOs.Seats
{
    public class SeatForCreationDTO
    {
        [Required]
        public int Number { get; set; }
        [Required]
        public long CoworkingId { get; set; }
    }
}
