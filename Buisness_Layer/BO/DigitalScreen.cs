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
        public DigitalScreen(BusTravel currentBusTravel, LineStation currentLineStation)
        {
            CurrentBusTravel = currentBusTravel;
            CurrentLineStation = currentLineStation;
        }
    }
}
