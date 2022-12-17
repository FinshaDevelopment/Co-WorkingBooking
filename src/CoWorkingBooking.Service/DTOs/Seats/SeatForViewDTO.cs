using CoWorkingBooking.Service.DTOs.CoWorkings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.DTOs.Seats
{
    public class SeatForViewDTO
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public long CoworkingId { get; set; }
        public CoWorkingForViewDTO CoWorking { get; set; }
        public bool IsBooked { get; set; }
    }
}
