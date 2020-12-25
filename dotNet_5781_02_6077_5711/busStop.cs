using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNet5781_01_6077_5711;


namespace dotNet_5781_02_6077_5711
{
    /// <summary>
    /// bus stop info class
    /// </summary>
    public class BusStop
    {
        /// <summary>
        /// duration in minutes(time from last stop)
        /// </summary>
        private float duration;
        /// <summary>
        /// get and set
        /// </summary>
        public float m_duration
        {
            get { return duration; }
            set { duration = value; }
        }
        /// <summary>
        /// distance in km(from last stop)
        /// </summary>
        private float distance;
        /// <summary>
        /// get and set
        /// </summary>
        public float m_distance
        {
            get { return distance; }
            set { distance = value; }
        }
        /// <summary>
        /// stop location details 
        /// </summary>
        private stopLocation mylocation;
        /// <summary>
        /// get and set
        /// </summary>
        public stopLocation m_mylocation
        {
            get { return mylocation; }
            set { mylocation = value; }
        }
        /// <summary>
        /// constructor of BusStop
        /// </summary>
        public BusStop()
        {
            duration = -1;
            distance = 0;
            mylocation = new stopLocation();
        }
        public override string ToString()
        {
            return string.Format("code: {0} \nLocation:   {1}N,   {2}E\n", this.m_mylocation.m_busStationKey,this.m_mylocation.m_latitude,this.m_mylocation.m_longitude);
        }
    }
}
