using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.DTOs.Seats
{
    public class SeatForCreationDTO
    {
        public int Number { get; set; }
        public long CoworkingId { get; set; }
        public bool IsBooked { get; set; }
    }
}
