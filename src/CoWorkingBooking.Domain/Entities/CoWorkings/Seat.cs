using CoWorkingBooking.Domain.Commons;
using System;

namespace CoWorkingBooking.Domain.Entities.CoWorkings
{
    public class Seat : Auditable
    {
        public int Number { get; set; }
        public long CoworkingId { get; set; }
        public CoWorking CoWorking { get; set; }
        public DateTime FromDate { get; set; }
        public TimeSpan Time { get; set; }
    }
}
