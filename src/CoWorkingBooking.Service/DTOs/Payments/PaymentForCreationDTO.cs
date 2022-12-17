using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.DTOs.Payments
{
    public class PaymentForCreationDTO
    {
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public long OrderId { get; set; }
    }
}
