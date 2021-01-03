using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using BLImp;

namespace BO
{
    public class SequentialStopInfo
    {
        public bool Valid { get; set; }
        public long StationCodeF { get; set; }
        public long StationCodeS { get; set; }
       
        private double distance;

        public double Distance
        {
            get {
                //return (bl.DistanceCalculate(bl.RequestLineStation(line => line.Code == StationCodeF && line.Valid), bl.RequestLineStation(line => line.Code == StationCodeS && line.Valid)));          
                return distance;
            }
            set { distance = value; }
        }

        


        private TimeSpan travelTime;

        public TimeSpan TravelTime
        {
            get { return travelTime; }
            set { travelTime = value; }
        }
      

        public SequentialStopInfo(long stationCodeF, long stationCodeS, double distanceInput, TimeSpan travelTime)
        {
            Valid = true;
            StationCodeF = stationCodeF;
            distance = distanceInput;
           
            TravelTime = new TimeSpan();
            TravelTime = travelTime;
        }
        public SequentialStopInfo()
        {
        }
        public override string ToString()
        {
            return ("stationCodeF" + StationCodeF + "stationCodeS:" + StationCodeS + "distance" + Distance   + "travelTime" + TravelTime + "valid" + Valid);
        }

    }
}
