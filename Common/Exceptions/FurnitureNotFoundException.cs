using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Exceptions
{
    public class FurnitureNotFoundException: Exception
    {
        public FurnitureNotFoundException()
        {
        }

        public FurnitureNotFoundException(string message)
            : base(message)
        {
        }

        public FurnitureNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
