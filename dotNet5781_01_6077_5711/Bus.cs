using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// namespace for busline
/// </summary>

namespace dotNet5781_01_6077_5711
{
    /// <summary>
    /// Bus class
    /// </summary>
    public class Bus
    {
        /// <summary>
        /// save the fuel 
        /// </summary>
        private float fuel;
        /// <summary>
        /// get and set the fuel variable
        /// </summary>
        public float m_fuel
        {
            get  // get a value
            {
                return fuel;
            }
            set  // set a value
            {
                fuel = value;
            }
        }
        /// <summary>
        /// amount of km from start
        /// </summary>
        private static float sum_Tr;
        /// <summary>
        /// get and set
        /// </summary>
        public float m_sum_Tr
        {
            get  // get a value
            {
                return sum_Tr;
            }
            set  // set a value
            {
                sum_Tr = value;
            }
        }
        /// <summary>
        /// amount of km since last treatment
        /// </summary>
        private static float sum_Tr_Treat;
        /// <summary>
        /// get and set
        /// </summary>
        public float m_sum_Tr_Treat
        {
            get  // get a value
            {
                return sum_Tr_Treat;
            }
            set  // set a value
            {
                sum_Tr_Treat = value;
            }
        }
        /// <summary>
        /// bus license number
        /// </summary>
        private int licenseNum;
        /// <summary>
        /// get and set
        /// </summary>
        public int m_licenseNum
        {
            get  // get a value
            {
                return licenseNum;
            }
            set  // set a value
            {
                licenseNum = value;
            }
        }
        /// <summary>
        /// year start
        /// </summary>
        private int yearStart;
        /// <summary>
        /// get and set
        /// </summary>
        public int m_yearStart
        {
            get   // get a value
            {
                return yearStart;
            }
            set  // set a value
            {
                yearStart = value;
            }
        }
        /// <summary>
        /// date since last treatment
        /// </summary>
        private DateTime time_Treat;
        /// <summary>
        /// get and set
        /// </summary>
        public DateTime m_time_Treat
        {
            get  // get a value
            {
                return time_Treat;
            }
            set  // set a value
            {
                time_Treat = value;
            }
        }
        /// <summary>
        /// default constructor
        /// </summary>
        public Bus()
        {
            m_yearStart = -1;
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="lisNum">license number</param>
        /// <param name="yearSt">year start</param>
        /// <param name="timeTreatment">date from last treatement</param>
        public Bus(int lisNum, float fuel, int yearSt, DateTime timeTreatment)
        {
            m_licenseNum = lisNum;
            m_yearStart = yearSt;
            m_time_Treat.AddYears(timeTreatment.Year);
            m_time_Treat.AddMonths(timeTreatment.Month);
            m_time_Treat.AddDays(timeTreatment.Day);
            m_fuel = fuel;
        }

    }
}
