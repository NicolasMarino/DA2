using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidNotAlphaNumericOrNullException : Exception
    {
        public InvalidNotAlphaNumericOrNullException()
        {
        }

        public InvalidNotAlphaNumericOrNullException(string message) : base(message)
        {
        }

        public InvalidNotAlphaNumericOrNullException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
