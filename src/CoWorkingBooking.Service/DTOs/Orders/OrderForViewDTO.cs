using CoWorkingBooking.Service.DTOs.Seats;
using CoWorkingBooking.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.DTOs.Orders
{
    public class OrderForViewDTO
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public UserForViewDTO User { get; set; }
        public long SeatId { get; set; }
        public SeatForViewDTO Seat { get; set; }
        public DateTime FromDate { get; set; }
        public TimeSpan Time { get; set; }
    }
}
