using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class DigitalScreen
    {
        public BusTravel CurrentBusTravel { get; set; }
        public LineStation CurrentLineStation { get; set; }
        public TimeSpan CurrentTime { get; set; }
        public DigitalScreen(BusTravel currentBusTravel, LineStation currentLineStation,TimeSpan currentTime)
        {
            CurrentBusTravel = currentBusTravel;
            CurrentLineStation = currentLineStation;
            CurrentTime = currentTime;
        }
    }
}
