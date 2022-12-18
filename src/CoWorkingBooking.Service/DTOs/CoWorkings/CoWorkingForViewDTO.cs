using CoWorkingBooking.Service.DTOs.Branches;

namespace CoWorkingBooking.Service.DTOs.CoWorkings
{
    public class CoWorkingForViewDTO
    {
        public long Id { get; set; }
        public long BranchId { get; set; }
        public BranchForViewDTO Branch { get; set; }
        public byte Floor { get; set; }
        public decimal Price { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
