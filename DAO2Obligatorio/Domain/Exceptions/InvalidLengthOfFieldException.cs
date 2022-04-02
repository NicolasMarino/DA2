using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidLengthOfFieldException : Exception
    {
        public InvalidLengthOfFieldException()
        {
        }

        public InvalidLengthOfFieldException(string message) : base(message)
        {
        }

        public InvalidLengthOfFieldException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
