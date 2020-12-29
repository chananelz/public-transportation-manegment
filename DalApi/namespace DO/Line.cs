using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class Line
    {
        public bool Valid { get; set; }
        public long Id { get; set; }
        public long Number { get; set; }
        public string Area { get; set; }
        public long FirstStop{ get; set; }
        public long LastStop { get; set; }
        public Line()//not implemented
        {

        }
        public Line(Line line)//not implemented
        {
            Valid = line.Valid;
            Id = line.Id;
            Number = line.Number;
            Area = line.Area;
            FirstStop = line.FirstStop;
            LastStop = line.LastStop;
        }
        public override string ToString()
        {
            return "Valid:" + Valid + "id: " + Id + "number: " + Number + "area: " + Area + "first stop: " + FirstStop + "last stop: " + LastStop;
        }
        public static string ConvertToString(bool[,] matrix) { return ""; }// not implemented
        public static bool[,] ConvertFromSring(string matrix) { return new bool[1, 1]; }//not implemented
    }
}
