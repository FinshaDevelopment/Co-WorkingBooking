using CoWorkingBooking.Domain.Commons;
using CoWorkingBooking.Domain.Entities.CoWorkings;
using CoWorkingBooking.Domain.Entities.Users;
using CoWorkingBooking.Domain.Enums;
using System;

namespace CoWorkingBooking.Domain.Entities.Orders
{
    public class Order : Auditable
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long SeatId { get; set; }
        public Seat Seat { get; set; }
        public DateTime FromDate { get; set; }
        public TimeSpan Time { get; set; }
        public PaymentType Type { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
