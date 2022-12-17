using System.ComponentModel.DataAnnotations;

namespace CoWorkingBooking.Service.DTOs.Payments
{
    public class PaymentForCreationDTO
    {
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public long OrderId { get; set; }
    }
}
