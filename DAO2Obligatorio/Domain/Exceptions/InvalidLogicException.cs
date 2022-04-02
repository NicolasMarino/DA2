using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class InvalidLogicException : Exception
    {
        public InvalidLogicException()
        {
        }

        public InvalidLogicException(string message) : base(message)
        {
        }

        public InvalidLogicException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
