using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class StringUtils
    {
        public static void IsNullOrEmpty(string value, string field)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new InvalidNotAlphaNumericOrNullException("La/el " + field + " no puede ser vacía/o.");
            }
        }

        public static void IsAlphaNumeric(string value, string field)
        {
            if (!value.All(Char.IsLetterOrDigit))
            {
                throw new InvalidNotAlphaNumericOrNullException("El/la " + field + " debe ser alfanumérico, no puede contener espacios o caracteres.");
            }
        }
    }
}
