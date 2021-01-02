using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class SequentialStopInfo
    {
        public bool Valid { get; set; }
        public long StationCodeF { get; set; }
        public long StationCodeS { get; set; }
        public double Distance { get; set; }
        public TimeSpan AverageTime { get; set; }
        public TimeSpan TravelTime { get; set; }

        public SequentialStopInfo()//not implemented
        {
            
        }
        public SequentialStopInfo(SequentialStopInfo m_stop)//not implemented
        {
            Valid = m_stop.Valid;
            StationCodeF = m_stop.StationCodeF;
            StationCodeS = m_stop.StationCodeS;
            Distance = m_stop.Distance;
            AverageTime = m_stop.AverageTime;
            TravelTime = m_stop.TravelTime;
        }
        public override string ToString()
        {
            return ("Valid:" + Valid + "stationCodeF:" + StationCodeF + "stationCodeS:" + StationCodeS + "distance" + Distance + "onStopId:" + AverageTime + "averageTime:" + TravelTime + "travelTime");
        }

    }


    

}



