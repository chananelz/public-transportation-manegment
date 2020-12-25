using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_03_B_6077_5711
{
    public class SuperBusException : Exception
    {
        public SuperBusException()
        {
        }

        public SuperBusException(string message)
            : base(message)
        {
        }

        public SuperBusException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    public class operationException : SuperBusException
    {
        public operationException()
        {
        }

        public operationException(string message)
            : base(message)
        {
        }

        public operationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
