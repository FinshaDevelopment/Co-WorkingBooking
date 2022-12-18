using System.ComponentModel.DataAnnotations;

namespace CoWorkingBooking.Service.DTOs.CoWorkings
{
    public class CoWorkingForCreationDTO
    {
        [Required]
        public long BranchId { get; set; }
        [Required]
        public byte Floor { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
    }
}
