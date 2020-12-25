using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;

namespace BO
{
    public class Stop
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string StopName { get; set; }

        public string Address { get; set; }
        private IEnumerable<Line> lines;

        public IEnumerable<Line> Lines
        {
            get 
            {
                return null;
            }//query
        }

        public Stop( double latitude, double longitude, string stopName)
        {
            Latitude = latitude;
            Longitude = longitude;
            StopName = stopName;
        }

        public Stop() { }

        public override string ToString()
        {
            return ("latitude" + Latitude + "longitude" + Longitude + "stopName" + StopName + "Address" + Address);
        }
       

    }
}
