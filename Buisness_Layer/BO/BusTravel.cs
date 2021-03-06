using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;

namespace BO
{
    public class BusTravel
    {
        public bool Valid { get; set; }
        public long Id { get; set; }
        public long LicenseNumber { get; set; }
        public long LineId { get; set; }
        public DateTime FormalDepartureTime { get; set; }
        public DateTime RealDepartureTime { get; set; }
        public long LastPassedStop { get; set; }
        public DateTime LastPassedStopTime { get; set; }
        public DateTime NextStopTime { get; set; }
        public string DriverId { get; set; }




        private long number;

        public long Number
        {
            get { return BLApi.Factory.GetBL("1").GetLine(LineId).Number; }
        }


        public BusTravel()//not implemented
        {

        }
        public BusTravel(long licenseNumber,long lineId, DateTime formalDepartureTime, DateTime realDepartureTime, long lastPassedStop, DateTime lastPassedStopTime, DateTime nextStopTime,string driverId)
        {
            Valid = true;
            LineId = lineId;
            LicenseNumber = licenseNumber;
            FormalDepartureTime = formalDepartureTime;
            RealDepartureTime = realDepartureTime;
            LastPassedStop = lastPassedStop;
            LastPassedStopTime = lastPassedStopTime;
            NextStopTime = nextStopTime;
            DriverId = driverId;
        }
        public override string ToString()
        {
            return "license number: " + LicenseNumber + "Formal Departure Time:" + FormalDepartureTime + "Real Departure Time:" + RealDepartureTime +
                "last passed stop: " + LastPassedStop + "last passed stop time: " + LastPassedStop + "next stop time: " + NextStopTime;
        }
        public static string ConvertToString(bool[,] matrix) { return ""; }// not implemented
        public static bool[,] ConvertFromSring(string matrix) { return new bool[1, 1]; }//not implemented
    }
}
