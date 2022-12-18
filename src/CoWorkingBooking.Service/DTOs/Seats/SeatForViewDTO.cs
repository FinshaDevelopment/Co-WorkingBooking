using CoWorkingBooking.Service.DTOs.CoWorkings;
using System;

namespace CoWorkingBooking.Service.DTOs.Seats
{
    public class SeatForViewDTO
    {
        public long Id { get; set; }
        public int Number { get; set; }
        public long CoworkingId { get; set; }
        public CoWorkingForViewDTO CoWorking { get; set; }
        public DateTime FromDate { get; set; }
        public TimeSpan Time { get; set; }
        public bool IsBooked
        {
            get
            {
                return FromDate + Time < DateTime.UtcNow;
            }
        }
    }
}
