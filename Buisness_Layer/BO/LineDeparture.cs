using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LineDeparture
    {
        public bool Valid { get; set; }
        public long Id { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Frequency { get; set; }
        public LineDeparture()//not implemented
        {

        }
        public LineDeparture(DateTime timeStart, DateTime timeEnd, int frequency, long id)
        {
            Valid = true;
            Id = id;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            Frequency = frequency;
        }
        public override string ToString()
        {
            return "time start: " + TimeStart + "frequency: " + Frequency + "valid" + Valid + "time end: " + TimeEnd + "valid" + Valid + "time end: " + TimeEnd + "id " + Id;
        }
        public static string ConvertToString(bool[,] matrix) { return ""; }// not implemented
        public static bool[,] ConvertFromSring(string matrix) { return new bool[1, 1]; }//not implemented

    }
}
