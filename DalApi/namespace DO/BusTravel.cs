using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
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
        public BusTravel()//not implemented
        {

        }
        public BusTravel(BusTravel busTravel)//not implemented
        {
            Valid = busTravel.Valid;
            Id = busTravel.Id;
            LicenseNumber = busTravel.LicenseNumber;
            LineId = busTravel.LineId;
            FormalDepartureTime = new DateTime();
            FormalDepartureTime = busTravel.FormalDepartureTime;
            RealDepartureTime = new DateTime();
            RealDepartureTime = busTravel.RealDepartureTime;
            LastPassedStop = busTravel.LastPassedStop;
            LastPassedStopTime = new DateTime();
            LastPassedStopTime = busTravel.LastPassedStopTime;
            NextStopTime = new DateTime();
            NextStopTime = busTravel.NextStopTime;
            DriverId = busTravel.DriverId;
        }
        public override string ToString()
        {
            return "Valid:" + Valid + "license number: " + LicenseNumber + "line id: " + LineId + "Formal Departure Time:" + FormalDepartureTime + "Real Departure Time:" + RealDepartureTime + 
                "last passed stop: " + LastPassedStop + "last passed stop time: " + LastPassedStop + "next stop time: " + NextStopTime + " DriverId" + DriverId;
        }
        public static string ConvertToString(bool[,] matrix) { return ""; }// not implemented
        public static bool[,] ConvertFromSring(string matrix) { return new bool[1, 1]; }//not implemented
    }
}
