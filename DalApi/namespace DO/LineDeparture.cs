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
        public DateTime Time_Start { get; set; }
        public int Frequency { get; set; }
        public DateTime Time_End { get; set; }
        public LineDeparture()//not implemented
        {

        }
        public LineDeparture(LineDeparture line_Departure)//not implemented
        {
            Valid = line_Departure.Valid;
            Id = line_Departure.Id;
            Time_Start = new DateTime();
            Time_Start = line_Departure.Time_Start;
            Frequency = line_Departure.Frequency;
            Time_End = new DateTime();
            Time_End = line_Departure.Time_End;
        }
        public override string ToString()
        {
            return "Valid:" + Valid + "id: " + Id + "time start: " + Time_Start + "frequency: " + Frequency;
        }
        public static string ConvertToString(bool[,] matrix) { return ""; }// not implemented
        public static bool[,] ConvertFromSring(string matrix) { return new bool[1, 1]; }//not implemented

    }
}
