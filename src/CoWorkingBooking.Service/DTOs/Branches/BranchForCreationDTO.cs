using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Service.DTOs.Branchs
{
    public class BranchForCreationDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
