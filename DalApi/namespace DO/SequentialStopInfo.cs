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
        public int stationCodeF { get; set; }
        public int stationCodeS { get; set; }
        public float distance { get; set; }
        public TimeSpan averageTime { get; set; }
        public TimeSpan travelTime { get; set; }

        public SequentialStopInfo()//not implemented
        {
            
        }
        public SequentialStopInfo(SequentialStopInfo m_stop)//not implemented
        {
            Valid = m_stop.Valid;
            stationCodeF = m_stop.stationCodeF;
            stationCodeS = m_stop.stationCodeS;
            distance = m_stop.distance;
            averageTime = m_stop.averageTime;
            travelTime = m_stop.travelTime;
        }
        public override string ToString()
        {
            return ("Valid:" + Valid + "stationCodeF:" + stationCodeF + "stationCodeS:" + stationCodeS + "distance" + distance + "onStopId:" + averageTime + "averageTime:" + travelTime + "travelTime");
        }

    }


    

}



