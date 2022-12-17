using System;

namespace CoWorkingBooking.Service.Exceptions
{
    public class CoWorkingException : Exception
    {
        public int Code { get; set; }
        public CoWorkingException(int code, string message) : base(message) 
        {
            this.Code = code;
        }
    }
}
