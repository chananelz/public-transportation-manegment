using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_5781_02_6077_5711
{
    public class BusException : Exception
    {
        public BusException()
        {
        }

        public BusException(string message)
            : base(message)
        {
        }

        public BusException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class NotFoundkey : BusException
    {
        public NotFoundkey()
        {
        }

        public NotFoundkey(string message)
            : base(message)
        {
        }

        public NotFoundkey(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
