using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using BLImp;

namespace BO
{
    public class Line
    {
        public long Id { get; set; }
        public bool Valid { get; set; }
        public  long Number { get; set; }
        public string Area { get; set; }
        public long FirstStop { get; set; }
        public long LastStop { get; set; }

        private List<LineStation> stops;
        public List<LineStation> Stops
        {
            get { return Factory.GetBL("1").GetAllLineStationsByLineNumber(Number).ToList(); }
        }

        private List<BusTravel> buses;
        public List<BusTravel> Bines
        {
            get
            {

                //List <Line> = Factory.GetBL("1").GetAllLineByLineNumber(Number).ToList();
                return Factory.GetBL("1").GetAllBusseseByLineNumber(Number).ToList();
            }
        }



        public Bus CurrentBus { get; set; }
        public Line()//not implemented
        {
            
        }
        public Line(long number, string area, long firstStop, long lastStop )
        {
            Id = 0;
            Valid = true;
            Number = number;
            Area = area;
            FirstStop = firstStop;
            LastStop = lastStop;
        }
        public override string ToString()
        {
            return "number: " + Number + "area: " + Area + "first stop: " + FirstStop + "last stop:" + LastStop + "valid" + Valid;
        }
        public static string ConvertToString(bool[,] matrix) { return ""; }// not implemented
        public static bool[,] ConvertFromSring(string matrix) { return new bool[1, 1]; }//not implemented

    }
}
