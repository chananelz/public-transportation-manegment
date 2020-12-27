using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class Stop
    {
        public bool Valid { get; set; }
        public long StopCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string StopName { get; set; }

        public string Address { get; set; }

        public Stop()//not implemented
        {

        }
        public Stop(Stop stop)//not implemented
        {
            Valid = stop.Valid;
            StopCode = stop.StopCode;
            Latitude = stop.Latitude;
            Longitude = stop.Longitude;
            StopName = stop.StopName;
            Address = stop.Address;
        }

        public override string ToString()
        {
            return ("Valid:" + Valid + "stop Code:" + StopCode + "latitude" + Latitude + "longitude" + Longitude + "stopName" + StopName + "Address" + Address);
        }

    }
}
