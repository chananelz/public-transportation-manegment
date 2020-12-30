using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using BLImp;

namespace BO
{
    public class Stop
    {
        public bool Valid { get; set; }
        public long StopCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string StopName { get; set; }

        public string Address { get; set; }

        private List<Line> lines;
        public List<Line> Lines
        {
            get
            {
                return Factory.GetBL("1").GetAllLinesByStopCode(StopCode).ToList();
            }
        }



        //private IEnumerable<Line> lines;

        //public IEnumerable<Line> Lines
        //{
        //    get 
        //    {
        //        return null;
        //    }//query
        //}

        public Stop( double latitude, double longitude, string stopName)
        {
            Valid = true;
            Latitude = latitude;
            Longitude = longitude;
            StopName = stopName;
        }

        public Stop() { }

        public override string ToString()
        {
            return ("latitude" + Latitude + "longitude" + Longitude + "stopName" + StopName + "Address" + Address + "valid" + Valid);
        }
       

    }
}
