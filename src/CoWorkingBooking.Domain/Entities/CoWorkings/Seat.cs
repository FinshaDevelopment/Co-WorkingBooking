using CoWorkingBooking.Domain.Commons;

namespace CoWorkingBooking.Domain.Entities.CoWorkings
{
    public class Seat : Auditable
    {
        public int Number { get; set; }
        public long CoworkingId { get; set; }
        public CoWorking CoWorking { get; set; }
        public bool IsBooked { get; set; }
    }
}
