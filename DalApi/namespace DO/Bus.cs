using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public enum status
    {
         TRAVELING,
         READY_FOR_DRIVE,
         TREATING,
         REFULING
    }
    public class Bus
    {
        public bool Valid { get; set; }
        public long LicenseNumber { get; set; }
        public DateTime LicenseDate { get; set; }
        public float KM { get; set; }
        public float Fuel { get; set; }
        public status Status { get; set; }//should this be static?
        public Bus()//not implemented
        {

        }
        public Bus(Bus bus)//not implemented
        {
            Valid = bus.Valid;
            LicenseNumber = bus.LicenseNumber;
            LicenseDate = new DateTime();
            LicenseDate = bus.LicenseDate;
            KM = bus.KM;
            Fuel = bus.Fuel;
            Status = bus.Status;
        }
        public override string ToString()
        {
            return "Valid:" + Valid + "license number: " + LicenseNumber + "licensing date: " + LicenseDate + "kilometer: " + KM + 
                "fuel: " + Fuel + "status: " + Status;
        }
        public static string ConvertToString(bool[,] matrix) { return ""; }// not implemented
        public static bool[,] ConvertFromSring(string matrix) { return new bool[1,1]; }//not implemented
    }
}