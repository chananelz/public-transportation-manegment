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
        public DateTime Time_Start { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Frequency { get; set; }
        public LineDeparture()//not implemented
        {

        }
        public LineDeparture(DateTime time_Start, DateTime timeEnd, int frequency, long id)
        {
            Valid = true;
            Id = id;
            Time_Start = time_Start;
            TimeEnd = time_Start;
            Frequency = frequency;
        }
        public override string ToString()
        {
            return "time start: " + Time_Start + "frequency: " + Frequency + "valid" + Valid + "time end: " + TimeEnd + "valid" + Valid + "time end: " + TimeEnd + "id " + Id;
        }
        public static string ConvertToString(bool[,] matrix) { return ""; }// not implemented
        public static bool[,] ConvertFromSring(string matrix) { return new bool[1, 1]; }//not implemented

    }
}
