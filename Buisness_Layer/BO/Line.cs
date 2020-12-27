using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;

namespace BO
{
    public class Line
    {
        public int Id { get; set; }
        public bool Valid { get; set; }
        public  long Number { get; set; }
        public string Area { get; set; }
        public int FirstStop { get; set; }
        public int LastStop { get; set; }

        private List<Stop> stops;
        //public List<LineStation> Stops
        //{
        //    get { return BLApi.Factory.GetBL("1").GetAllStopsByLineNumber(Number).ToList(); }
        //}
        public Bus CurrentBus { get; set; }
        public Line()//not implemented
        {

        }
        public Line(long number, string area, int firstStop, int lastStop )
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
