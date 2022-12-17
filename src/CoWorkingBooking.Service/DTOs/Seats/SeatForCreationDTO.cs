using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.DTOs.Seats
{
    public class SeatForCreationDTO
    {
        [Required]
        public int Number { get; set; }
        [Required]
        public long CoworkingId { get; set; }
        [Required]
        public bool IsBooked { get; set; }
    }
}
