using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.DTOs.Payments
{
    public class PaymentForCreationDTO
    {
        public decimal TotalPrice { get; set; }
        public long OrderId { get; set; }
    }
}
