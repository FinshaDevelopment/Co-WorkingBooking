using System.ComponentModel.DataAnnotations;

namespace CoWorkingBooking.Service.DTOs.Branches
{
    public class BranchForCreationDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
