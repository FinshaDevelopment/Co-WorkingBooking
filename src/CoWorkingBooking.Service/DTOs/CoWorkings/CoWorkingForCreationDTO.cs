using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.DTOs.CoWorkings
{
    public class CoWorkingForCreationDto
    {
        public long BranchId { get; set; }
        public byte Floor { get; set; }
        public decimal Price { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
