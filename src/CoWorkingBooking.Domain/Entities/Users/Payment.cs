using CoWorkingBooking.Domain.Commons;
using CoWorkingBooking.Domain.Entities.Orders;
using CoWorkingBooking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
