using CoWorkingBooking.Domain.Commons;
using CoWorkingBooking.Domain.Entities.Orders;
using CoWorkingBooking.Domain.Enums;

namespace CoWorkingBooking.Domain.Entities.Users
{
    public class Payment : Auditable
    {
        public PaymentType Type { get; set; }
        public decimal TotalPrice { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}
