using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.DTOs.CoWorkings
{
    public class CoWorkingForCreationDto
    {
        [Required]
        public long BranchId { get; set; }
        [Required]
        public byte Floor { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
    }
}
