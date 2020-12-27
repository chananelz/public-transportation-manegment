using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class SequentialStopInfo
    {
        public bool Valid { get; set; }
        public int StationCodeF { get; set; }
        public int StationCodeS { get; set; }
        public float Distance { get; set; }
        public TimeSpan AverageTime { get; set; }
        public TimeSpan TravelTime { get; set; }

        public SequentialStopInfo(int stationCodeF, int stationCodeS, float distance, TimeSpan averageTime, TimeSpan travelTime)
        {
            Valid = true;
            StationCodeF = stationCodeF;
            Distance = distance;
            AverageTime = averageTime;
            TravelTime = travelTime;
        }
        public SequentialStopInfo()
        {
        }
        public override string ToString()
        {
            return ("stationCodeF" + StationCodeF + "stationCodeS:" + StationCodeS + "distance" + Distance  + "averageTime:" + AverageTime  + "travelTime" + TravelTime + "valid" + Valid);
        }

    }
}
