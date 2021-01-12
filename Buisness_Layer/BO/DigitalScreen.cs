using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    class DigitalScreen
    {
        BusTravel CurrentBusTravel { get; set; }
        LineStation CurrentLineStation { get; set; }
        public DigitalScreen(BusTravel currentBusTravel, LineStation currentLineStation)
        {
            CurrentBusTravel = currentBusTravel;
            CurrentLineStation = currentLineStation;
        }
    }
}
