using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class LineStation
    {
        public bool Valid { get; set; }
        public long Line_Id { get; set; }
        public long Code { get; set; }
        public long Number_In_Line { get; set; }
        public LineStation()//not implemented
        {

        }
        public LineStation(LineStation line_Station)//not implemented
        {
            Valid = line_Station.Valid;
            Line_Id = line_Station.Line_Id;
            Code = line_Station.Code;
            Number_In_Line = line_Station.Number_In_Line;
        }
        public override string ToString()
        {
            return "Valid:" + Valid + "line id: " + Line_Id + "code: " + Code + "number in line: " + Number_In_Line;
        }
        public static string ConvertToString(bool[,] matrix) { return ""; }// not implemented
        public static bool[,] ConvertFromSring(string matrix) { return new bool[1, 1]; }//not implemented

    }
}
