using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{

    #region Bus Exceptions
    [Serializable]
    public class DOBusException : Exception
    {
        public DOBusException()
        {
        }

        public DOBusException(string message)
            : base(message)
        {
        }

        public DOBusException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public override string ToString() => "bus Exception: ";
    }

    [Serializable]

    public class DOBadBusIdException : DOBusException
    {
        public long ID;
        public DOBadBusIdException(long id) : base() => ID = id;
        public DOBadBusIdException(long id, string message) : base(message) => ID = id;
        public DOBadBusIdException(long id, string message, Exception innerException) : base(message, innerException) => ID = id;
        public override string ToString() => base.ToString() + $", DOBad Bus id: {ID}";
    }

    #endregion













    public class DOBadBusTravelIdException : Exception
    {
        public long ID;
        public DOBadBusTravelIdException(long id) : base() => ID = id;
        public DOBadBusTravelIdException(long id, string message) : base(message) => ID = id;
        public DOBadBusTravelIdException(long id, string message, Exception innerException) : base(message, innerException) => ID = id;
        public override string ToString() => base.ToString() + $", DOBad BusTravel id: {ID}";
    }





    #region Line Exception
    public class DOBadLineIdException : Exception
    {
        public long ID;
        public DOBadLineIdException(long id) : base() => ID = id;
        public DOBadLineIdException(long id, string message) : base(message) => ID = id;
        public DOBadLineIdException(long id, string message, Exception innerException) : base(message, innerException) => ID = id;
        public override string ToString() => base.ToString() + $", DOBad Line id: {ID}";
    }

    public class DOLineException : Exception
    {
        public DOLineException()
        {
        }

        public DOLineException(string message)
            : base(message)
        {
        }

        public DOLineException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public override string ToString() => "Stop Exception:  ";
    }
    #endregion



    #region Stop Exception

    public class DOBadStopIdException : Exception
    {
        public long ID;
        public DOBadStopIdException(long id) : base() => ID = id;
        public DOBadStopIdException(long id, string message) : base(message) => ID = id;
        public DOBadStopIdException(long id, string message, Exception innerException) : base(message, innerException) => ID = id;
        public override string ToString() => base.ToString() + $", DOBad Stop id: {ID}";
    }

    public class DOStopException : Exception
    {
        public DOStopException()
        {
        }

        public DOStopException(string message)
            : base(message)
        {
        }

        public DOStopException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public override string ToString() => "Stop Exception:  ";
    }
    #endregion


    public class DOBadLineDepartureIdException : Exception
        {
            public long ID;
            public DOBadLineDepartureIdException(long id) : base() => ID = id;
            public DOBadLineDepartureIdException(long id, string message) : base(message) => ID = id;
            public DOBadLineDepartureIdException(long id, string message, Exception innerException) : base(message, innerException) => ID = id;
            public override string ToString() => base.ToString() + $", DOBad LineDeparture id: {ID}";
        }

        public class DOBadLineStationIdException : Exception
        {
            public long ID;
            public DOBadLineStationIdException(long id) : base() => ID = id;
            public DOBadLineStationIdException(long id, string message) : base(message) => ID = id;
            public DOBadLineStationIdException(long id, string message, Exception innerException) : base(message, innerException) => ID = id;
            public override string ToString() => base.ToString() + $", DOBad LineStation id: {ID}";
        }

        public class DOBadSequentialStopInfoIdException : Exception
        {
            public long ID;
            public DOBadSequentialStopInfoIdException(long id) : base() => ID = id;
            public DOBadSequentialStopInfoIdException(long id, string message) : base(message) => ID = id;
            public DOBadSequentialStopInfoIdException(long id, string message, Exception innerException) : base(message, innerException) => ID = id;
            public override string ToString() => base.ToString() + $", DOBad SequentialStopInfo id: {ID}";
        }

        public class DOBadUserIdException : Exception
        {
            public long ID;
            public DOBadUserIdException(long id) : base() => ID = id;
            public DOBadUserIdException(long id, string message) : base(message) => ID = id;
            public DOBadUserIdException(long id, string message, Exception innerException) : base(message, innerException) => ID = id;
            public override string ToString() => base.ToString() + $", DOBad User id: {ID}";
        }

        public class DOBadUserTravelIdException : Exception
        {
            public long ID;
            public DOBadUserTravelIdException(long id) : base() => ID = id;
            public DOBadUserTravelIdException(long id, string message) : base(message) => ID = id;
            public DOBadUserTravelIdException(long id, string message, Exception innerException) : base(message, innerException) => ID = id;
            public override string ToString() => base.ToString() + $", DOBad UserTravel id: {ID}";
        }
}

