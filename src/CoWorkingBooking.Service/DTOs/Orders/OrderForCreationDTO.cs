using System;
using System.ComponentModel.DataAnnotations;

namespace CoWorkingBooking.Service.DTOs.Orders
{
    public class OrderForCreationDTO
    {
        [Required]
        public long SeatId { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
    }
}
