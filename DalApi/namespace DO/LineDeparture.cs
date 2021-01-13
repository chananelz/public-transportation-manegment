using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class LineDeparture
    {
        public bool Valid { get; set; }
        public long Id { get; set; }
        public DateTime TimeStart { get; set; }
        public int Frequency { get; set; }
        public DateTime TimeEnd { get; set; }
        public LineDeparture()//not implemented
        {

        }
     
        public override string ToString()
        {
            return "Valid:" + Valid + "id: " + Id + "time start: " + TimeStart + "frequency: " + Frequency;
        }
        public static string ConvertToString(bool[,] matrix) { return ""; }// not implemented
        public static bool[,] ConvertFromSring(string matrix) { return new bool[1, 1]; }//not implemented

    }
}
