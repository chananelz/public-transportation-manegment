using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNet5781_01_6077_5711;
using dotNet_5781_02_6077_5711;
//netanel bashan 0323056077
//chananel zaguri 206275711


namespace dotNet5781_03_B_6077_5711
{
    /// <summary>
    /// SUPER_BUS_LIST is a complete definition to list of bus in this solution
    /// </summary>
    public class SUPER_BUS_LIST : dotNet_5781_02_6077_5711.BusCollection
    {
        static public int num = 0;
        private List<BusStop> myUniqueStops = new List<BusStop>();
        public List<SUPER_BUS> comprehensiveCollection = new List<SUPER_BUS>();
        private BusCollection m_BusCollection;
        public List<SUPER_BUS> m_comprehensiveCollection
        {
            get { return comprehensiveCollection; }
        }
        public List<Bus> m_List = new List<Bus>();

        /// <summary>
        /// constractor of SUPER_BUS_LIST
        /// </summary>
        public SUPER_BUS_LIST()
        {
            m_BusCollection = (BusCollection)this;
            m_BusCollection.m_busList = new List<Bus>();
            Program_6077_5711_02.initializeBusRoute(ref m_BusCollection, ref myUniqueStops);
            Random r = new Random();
            foreach (BusRoute bus in m_BusCollection)
            {
                int i = 0;
                SUPER_BUS newMbus = new SUPER_BUS(0, 0, 0, new DateTime(), bus.m_Stations, bus.m_direction, bus.m_Area, bus.m_BusLine);
                comprehensiveCollection.Add(new SUPER_BUS(0, 0, 0, new DateTime(), bus.m_Stations, bus.m_direction, bus.m_Area, bus.m_BusLine)
                {
                    m_fuel = r.Next(1200),
                    m_licenseNum = r.Next(100000000),
                    m_sum_Tr = ((float)r.NextDouble() + r.Next(1200)),
                    m_yearStart = r.Next(1950, 2020),
                    m_sum_Tr_Treat = r.Next(20000)
                });
            }
            foreach (SUPER_BUS bus in comprehensiveCollection)
            {
                int a = r.Next( 2020,2024);
                int b = r.Next(11) + 1;
                int c = r.Next(29) + 1;
                bus.m_time_Treat = new DateTime(a, b, c);
                bus.m_fuel = r.Next(1200);
                m_BusCollection.m_busList.Add(bus);
            }
            SpecialInit();
        }
        /// <summary>
        /// initialize a Special SUPER_BUS
        /// </summary>
        private void SpecialInit()
        {
            Random r = new Random();
            int fTemp = r.Next(comprehensiveCollection.Count);
            int sTemp = r.Next(comprehensiveCollection.Count);
            int tTemp = r.Next(comprehensiveCollection.Count);

            while (fTemp == sTemp || sTemp == tTemp || tTemp == fTemp)
            {
                fTemp = r.Next(comprehensiveCollection.Count);
                sTemp = r.Next(comprehensiveCollection.Count);
                tTemp = r.Next(comprehensiveCollection.Count);
            }
            TimeSpan aday = new System.TimeSpan(1, 0, 0, 0);
            comprehensiveCollection[fTemp].m_time_Treat = DateTime.Now.Subtract(aday);
            comprehensiveCollection[sTemp].m_time_Treat = DateTime.Now.AddDays(1);                 
            comprehensiveCollection[tTemp].m_fuel = 1150;
        }

        /// <summary>
        /// Function to initialize the properties of project 1 randomly and add 4 unique busses
        /// </summary>
        /// <param name="myBusCollection"></param>
        //private void project1Init(ref BusCollection myBusCollection)
        //{
        //    Random r = new Random();
        //    foreach (BusRoute bus in myBusCollection)
        //    {
        //        SUPER_BUS newMbus = new SUPER_BUS(0,0,0,new DateTime(), bus.m_Stations,bus.m_direction,bus.m_Area,bus.m_BusLine);
        //        comprehensiveCollection.Add(new SUPER_BUS(0, 0, 0, new DateTime(), bus.m_Stations, bus.m_direction, bus.m_Area, bus.m_BusLine) { m_fuel = r.Next(1200)});
        //    }
        //}

        /// <summary>
        /// remove a  SUPER_BUS from  SUPER_BUS_LIST
        /// </summary>
        /// <param name="sbus"></param>
        /// <returns></returns>
        public string remove(SUPER_BUS sbus)
        {
            string messeg = "";
            int i = 0;

            for (; i < comprehensiveCollection.Count; i++)
            {
                if (sbus.m_licenseNum == comprehensiveCollection[i].m_licenseNum)
                {
                    break;
                }
            }
            comprehensiveCollection.RemoveAt(i);

            return messeg;
        }

        /// <summary>
        /// manage the fueling of a  SUPER_BUS
        /// </summary>
        /// <param name="sbus"></param>
        /// <returns></returns>
        public string checkupF(SUPER_BUS sbus)
        {
            string messeg = "";
            sbus.m_fuel = 0;
            messeg = "success";
            return messeg;
        }

        /// <summary>
        /// manage the treatment of a SUPER_BUS
        /// </summary>
        /// <param name="sbus"></param>
        /// <returns></returns>
        public string checkupT(SUPER_BUS sbus)
        {
            string messeg = "";
            sbus.m_time_Treat = DateTime.Now;
            messeg = "success";
            return messeg;
        }
        /// manage the travel of a SUPER_BUS
        public string travel(int numKm, SUPER_BUS sbus)
        {
            string messeg = "";
            if ((sbus.m_sum_Tr_Treat + numKm) > 20000 || (sbus.m_fuel + numKm) > 1200)
            {
                messeg = "can't do this travel - passed your limit!";
            }

            else
            {
                messeg = "can't do this travel - passed your limit!";
                sbus.m_sum_Tr_Treat += numKm;
                sbus.m_fuel += numKm;
                //update total travel
                sbus.m_sum_Tr += numKm;
            }
            return messeg;
        }

        /// <summary>
        /// find a super bus by his full name 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SUPER_BUS FinDSuperBusByFullName(string name)
        {
            string[] worDS = name.Split(' ');
            int BusLineNumber = int.Parse(worDS[1]);
            string AOrB = worDS[2];
            foreach (SUPER_BUS bus in comprehensiveCollection)
            {
                if (bus.m_BusLine == BusLineNumber && bus.m_direction == AOrB)
                    return bus;
            }
            return null;
        }






        /// <summary>
        /// find if we can start a travel
        /// </summary>
        /// <param name="realLicenseNum"></param>
        /// <param name="numKm"></param>
        /// <returns></returns>
        public bool SuperStartTravel(int realLicenseNum, float numKm)
        {
            bool canStart = false;
            foreach (Bus CBus in this.m_BusCollection.m_busList)
            {

                if (CBus.m_licenseNum == realLicenseNum)
                {

                    //if (!((CBus.m_sum_Tr_Treat + numKm) > 20000 || (CBus.m_fuel + numKm) > 1200))
                    //{
                    //    //how do we use throw in C#
                    //    Console.WriteLine("can't do this travel - passed your limit!");
                    //}
                    if (!((CBus.m_sum_Tr_Treat + numKm) > 20000 || (CBus.m_fuel + numKm) > 1200))
                    {
                        CBus.m_sum_Tr_Treat += numKm;
                        CBus.m_fuel += numKm;
                        this.m_totalTravel += numKm;
                        CBus.m_sum_Tr += numKm;
                        canStart = true;
                        // Console.WriteLine("success!!");
                    }
                    else
                    {
                       
                    }
                    break;
                }
            }

            return canStart;
        }
    }
}