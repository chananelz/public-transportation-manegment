using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace BO
{
    [Serializable]
    public class BoBadBusIdException : Exception
    {
        public long ID;
        public BoBadBusIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.Exceptions.DOBadBusIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }

    [Serializable]
    public class BoBadBusTravelBusFaultIdException : Exception
    {
        public long ID;
        public BoBadBusTravelBusFaultIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.Exceptions.DOBadBusIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }

    [Serializable]
    public class BoBadBusTravelLineFaultIdException : Exception
    {
        public long ID;
        public BoBadBusTravelLineFaultIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.Exceptions.DOBadLineIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }


    [Serializable]
    public class BoStopBadIdException : Exception
    {
        public long ID;
        public BoStopBadIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.Exceptions.DOBadStopIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }

    [Serializable]
    public class BOBadLineIdException : Exception
    {
        public long ID;
        public BOBadLineIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.Exceptions.DOBadLineIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }

    [Serializable]
    public class BOBadLineDepartureLineDepartureFaultIdException : Exception
    {
        public long ID;
        public BOBadLineDepartureLineDepartureFaultIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.Exceptions.DOBadLineDepartureIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }

    [Serializable]
    public class BOBadLineDepartureLineFaultIdException : Exception
    {
        public long ID;
        public BOBadLineDepartureLineFaultIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.Exceptions.DOBadLineIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }

    [Serializable]
    public class BOBadSequentialStopInfoIdException : Exception
    {
        public long ID;
        public BOBadSequentialStopInfoIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.Exceptions.DOBadSequentialStopInfoIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }

    public class BOBadLineStationLineFaultIdException : Exception
    {
        public long ID;
        public BOBadLineStationLineFaultIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.Exceptions.DOBadLineIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }

    public class BOBadLineStationStopFaultIdException : Exception
    {
        public long ID;
        public BOBadLineStationStopFaultIdException(string message, Exception innerException) : base(message, innerException) => ID = ((DO.Exceptions.DOBadStopIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }


}

