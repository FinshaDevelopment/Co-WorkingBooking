using CoWorkingBooking.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorkingBooking.Domain.Entities.CoWorkings
{
    public class Branch : Auditable
    {
        public string Name { get; set; }
    }
}
