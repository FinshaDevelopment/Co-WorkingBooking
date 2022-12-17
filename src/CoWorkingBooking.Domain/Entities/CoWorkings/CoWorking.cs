using CoWorkingBooking.Domain.Commons;

namespace CoWorkingBooking.Domain.Entities.CoWorkings
{
    public class CoWorking : Auditable
    {
        public long BranchId { get; set; }
        public Branch Branch { get; set; }
        public byte Floor { get; set; }
        public decimal Price { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
