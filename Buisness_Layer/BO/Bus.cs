using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;

namespace BO
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
        public long LicenseNumber { get; set; }
        public bool Valid { get; set; }
        public DateTime LicenseDate { get; set; }
        public float KM { get; set; }
        public float Fuel { get; set; }
        public status Status { get; set; }
        
        private Line lineList;
        public Line LineList
        {
            //try
            get { return Factory.GetBL("1").GetAllLinesByLicenseNumber(LicenseNumber).ToList().First(); }
        }

        public string Show { get => show; set => show = value; }

        private string show;

        public Bus()//not implemented
        {

        }
        public Bus(long licenseNumber, DateTime dateTime, float kM, float fuel, int statusInput)
        {
            Valid = true;
            LicenseNumber = licenseNumber;
            LicenseDate = dateTime;
            KM = kM;
            Fuel = fuel;
            switch (statusInput)
            {
                case 0:
                    Status = status.TRAVELING;
                    break;
                case 1:
                    Status = status.READY_FOR_DRIVE;
                    break;
                case 2:
                    Status = status.TREATING;
                    break;
                case 3:
                    Status = status.REFULING;
                    break;
                default:
                    throw new Exception("status not good");
            }
            Status = (status)statusInput;
        }
        public override string ToString()
        {
            return "license number: " + LicenseNumber + "licensing date: " + LicenseDate + "kilometer: " + KM +
                "fuel: " + Fuel + "status: " + Status + "valid" + Valid;
        }
        public static string ConvertToString(bool[,] matrix) { return ""; }// not implemented
        public static bool[,] ConvertFromSring(string matrix) { return new bool[1, 1]; }//not implemented
    }
}
