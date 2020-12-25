using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class BusTravel
    {
        public bool Valid { get; set; }
        public int Id { get; set; }
        public long License_Number { get; set; }
        public long Line_Id { get; set; }
        public DateTime Formal_Departure_Time { get; set; }
        public DateTime Real_Departure_Time { get; set; }
        public int Last_Passed_Stop { get; set; }
        public DateTime Last_Passed_Stop_Time { get; set; }
        public DateTime Next_Stop_Time { get; set; }
        public long DriverId { get; set; }
        public BusTravel()//not implemented
        {

        }
        public BusTravel(BusTravel busTravel)//not implemented
        {
            Valid = busTravel.Valid;
            Id = busTravel.Id;
            License_Number = busTravel.License_Number;
            Line_Id = busTravel.Line_Id;
            Formal_Departure_Time = new DateTime();
            Formal_Departure_Time = busTravel.Formal_Departure_Time;
            Real_Departure_Time = new DateTime();
            Real_Departure_Time = busTravel.Real_Departure_Time;
            Last_Passed_Stop = busTravel.Last_Passed_Stop;
            Last_Passed_Stop_Time = new DateTime();
            Last_Passed_Stop_Time = busTravel.Last_Passed_Stop_Time;
            Next_Stop_Time = new DateTime();
            Next_Stop_Time = busTravel.Next_Stop_Time;
            DriverId = busTravel.DriverId;
        }
        public override string ToString()
        {
            return "Valid:" + Valid + "license number: " + License_Number + "line id: " + Line_Id + "Formal Departure Time:" + Formal_Departure_Time + "Real Departure Time:" + Real_Departure_Time + 
                "last passed stop: " + Last_Passed_Stop + "last passed stop time: " + Last_Passed_Stop + "next stop time: " + Next_Stop_Time + " DriverId" + DriverId;
        }
        public static string ConvertToString(bool[,] matrix) { return ""; }// not implemented
        public static bool[,] ConvertFromSring(string matrix) { return new bool[1, 1]; }//not implemented
    }
}
