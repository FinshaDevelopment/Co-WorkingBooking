using CoWorkingBooking.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace CoWorkingBooking.Domain.Entities.CoWorkings
{
    public class Branch : Auditable
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
