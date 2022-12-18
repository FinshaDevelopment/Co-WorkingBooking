using System.ComponentModel.DataAnnotations;

namespace CoWorkingBooking.Service.DTOs.Branchs
{
    public class BranchForCreationDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
