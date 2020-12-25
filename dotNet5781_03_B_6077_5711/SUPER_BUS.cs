using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNet5781_01_6077_5711;
using System.ComponentModel;
using System.Diagnostics;


using dotNet_5781_02_6077_5711;

namespace dotNet5781_03_B_6077_5711
{
    /// <summary>
    /// SUPER_BUS is a complete definition to bus in this solution
    /// </summary>
    public class SUPER_BUS : dotNet_5781_02_6077_5711.BusRoute
    {
        bool readyForDrive = false;
        bool inTravel = false;
        bool inRefueling = false;
        bool inTreatment = false;
        public BackgroundWorker refuling;
        public BackgroundWorker treating;
        public BackgroundWorker traveling;


        public bool m_ReadyForDrive { get => readyForDrive; set => readyForDrive = value; }
        public bool m_InTravel { get => inTravel; set => inTravel = value; }
        public bool m_InRefueling { get => inRefueling; set => inRefueling = value; }
        public bool m_InTretment { get => inTreatment; set => inTreatment = value; }

        /// <summary>
        /// constractor of SUPER_BUS
        /// </summary>
        /// <param name="license_Num"></param>
        /// <param name="fuel"></param>
        /// <param name="year_Start"></param>
        /// <param name="time_Treat"></param>
        /// <param name="Stations"></param>
        /// <param name="Direction"></param>
        /// <param name="M_Area"></param>
        /// <param name="m_Bus_Line"></param>
        public SUPER_BUS
            (/*bus*/int license_Num, float fuel, int year_Start, DateTime time_Treat,/*busRoute*/List<BusStop> Stations, string Direction, string M_Area, int m_Bus_Line) : base(Stations, M_Area, m_Bus_Line, license_Num, fuel, year_Start, time_Treat, Direction)
        {
            DateTime currentDateTime = DateTime.Now;
            if (fuel < 1200 && time_Treat >= currentDateTime && m_sum_Tr_Treat < 20000 )
            {
                this.readyForDrive = true;
            }
            this.m_InTravel = false;
            this.m_InRefueling = false;
            this.m_InTretment = false;
        }
        public SUPER_BUS()
        {
        }

        /// <summary>
        /// initialization of SUPER_BUS object
        /// </summary>
        public void restart()
        {
            Random r = new Random();
            this.m_licenseNum = r.Next(100000000);
            this.m_sum_Tr = (float)r.NextDouble();
            this.m_sum_Tr += r.Next(1200);
            this.m_yearStart = r.Next(1950, 2020);
            //int a = r.Next(this.m_yearStart, 2022);
            //this.m_time_Treat.AddYears(r.Next(this.m_yearStart, 2022));
            //this.m_time_Treat.AddMonths(r.Next(0, 13));
            //this.m_time_Treat.AddDays(r.Next(0, 13));
            this.m_sum_Tr_Treat = r.Next(20000);
            this.m_fuel = r.Next(1200);

        }
        //print SUPER_BUS object
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
