using CoWorkingBooking.Domain.Enums;
using CoWorkingBooking.Service.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.DTOs.Payments
{
    public class PaymentForViewDTO
    {
        public long Id { get; set; }
        public PaymentType Type { get; set; }
        public decimal TotalPrice { get; set; }
        public long OrderId { get; set; }
        public OrderForViewDTO Order { get; set; }
    }
}
