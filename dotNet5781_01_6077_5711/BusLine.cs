using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dotNet5781_01_6077_5711
{
    /// <summary>
    /// class for bus managment
    /// </summary>
    public class BusLine
    {
        /// <summary>
        /// amount of all busses travel 
        /// </summary>
        private static double totalTravel = 0;
        /// <summary>
        /// get and set to totalTravel
        /// </summary>
        public float m_totalTravel
        {
            get // get a value
            {
                return (float)totalTravel;
            }
            set   // set a value
            {
                totalTravel = value;
            }
        }
        /// <summary>
        /// the list of all the bus
        /// </summary>
        private List<Bus> busList;
        /// <summary>
        /// get and set to the list
        /// </summary>
        public List<Bus> m_busList
        {
            get { return busList; }
            set { busList = value; }
        }
        /// <summary>
        /// empty constructor
        /// </summary>
        public BusLine() { }
        /// <summary>
        /// add a bus to bus line
        /// </summary>
        /// <param name="b1">adding bus</param>
        public void add(Bus b1)
        {
            
            busList.Add(b1);
            m_totalTravel += b1.m_sum_Tr;
        }
    }
    
}
