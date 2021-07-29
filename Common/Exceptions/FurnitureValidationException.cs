using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class FurnitureValidationException : Exception
    {
        public FurnitureValidationException()
        {
        }

        public FurnitureValidationException(string message)
            : base(message)
        {
        }

        public FurnitureValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
