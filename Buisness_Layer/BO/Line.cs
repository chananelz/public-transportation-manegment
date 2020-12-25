using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Line
    {
        public long Number { get; set; }
        public string Area { get; set; }
        public int FirstStop { get; set; }
        public int LastStop { get; set; }
        public Line()//not implemented
        {

        }
        public Line(long number, string area, int firstStop, int lastStop)
        {
            Number = number;
            Area = area;
            FirstStop = firstStop;
            LastStop = lastStop;
        }
        public override string ToString()
        {
            return "number: " + Number + "area: " + Area + "first stop: " + FirstStop + "last stop: " + LastStop;
        }
        public static string ConvertToString(bool[,] matrix) { return ""; }// not implemented
        public static bool[,] ConvertFromSring(string matrix) { return new bool[1, 1]; }//not implemented

    }
}
