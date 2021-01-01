using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace BO
{

    #region Bus Exception
    public class BOBadBusIdException : DOBusException
    {
        public long ID;
        public BOBadBusIdException(long id) : base() => ID = id;
        public BOBadBusIdException(long id, string message) : base(message) => ID = id;
        public BOBadBusIdException(long id, string message, Exception innerException) : base(message, innerException) => ID = id;
        public override string ToString() => base.ToString() + $", BOBad Bus id: {ID}";
    }


    [Serializable]
    public class BOBusException : Exception
    {
        public BOBusException()
        {
        }

        public BOBusException(string message)
            : base(message)
        {
        }

        public BOBusException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public override string ToString() => "bus general Exception";
    }

    [Serializable]
    public class BODOBadBusIdException : Exception
    {
        public long ID;
        public BODOBadBusIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.DOBadBusIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad bus id: {ID}";
    }

    #endregion





















    [Serializable]
    public class BoBadBusTravelBusFaultIdException : Exception
    {
        public long ID;
        public BoBadBusTravelBusFaultIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.DOBadBusIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }

    [Serializable]
    public class BoBadBusTravelLineFaultIdException : Exception
    {
        public long ID;
        public BoBadBusTravelLineFaultIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.DOBadLineIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }


    [Serializable]
    public class BoStopBadIdException : Exception
    {
        public long ID;
        public BoStopBadIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.DOBadStopIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }

    [Serializable]
    public class BOBadLineIdException : Exception
    {
        public long ID;
        public BOBadLineIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.DOBadLineIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }

    [Serializable]
    public class BOBadLineDepartureLineDepartureFaultIdException : Exception
    {
        public long ID;
        public BOBadLineDepartureLineDepartureFaultIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.DOBadLineDepartureIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }

    [Serializable]
    public class BOBadLineDepartureLineFaultIdException : Exception
    {
        public long ID;
        public BOBadLineDepartureLineFaultIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.DOBadLineIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }

    [Serializable]
    public class BOBadSequentialStopInfoIdException : Exception
    {
        public long ID;
        public BOBadSequentialStopInfoIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.DOBadSequentialStopInfoIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }

    public class BOBadLineStationLineFaultIdException : Exception
    {
        public long ID;
        public BOBadLineStationLineFaultIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.DOBadLineIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }

    public class BOBadLineStationStopFaultIdException : Exception
    {
        public long ID;
        public BOBadLineStationStopFaultIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.DOBadStopIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }


}

