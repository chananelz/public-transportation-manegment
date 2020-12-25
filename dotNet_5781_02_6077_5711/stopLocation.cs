using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNet5781_01_6077_5711;
//netanel bashan 0323056077
//chananel zaguri 206275711

namespace dotNet_5781_02_6077_5711
{
   
    /// <summary>
    /// class for location info
    /// </summary>
    public class stopLocation
    {
        /// <summary>
        /// stop name
        /// </summary>
        private string location;
        /// <summary>
        ///get and set
        /// </summary>
        public string m_location
        {
            get { return location; }
            set { location = value; }
        }
        /// <summary>
        /// unique key for station
        /// </summary>
        private int busStationKey;
        /// <summary>
        /// get and set
        /// </summary>
        public int m_busStationKey
        {
            get { return busStationKey; }
            set { busStationKey = value; }
        }
        /// <summary>
        /// number between 31 - 33.3
        /// </summary>
        private float latitude;
        /// <summary>
        /// get and set
        /// </summary>
        public float m_latitude
        {
            get { return latitude; }
            set
            {
                if (value < -90 || value > 90)
                    Console.WriteLine("ERROR!!");
                else
                    latitude = value;
            }
        }
        /// <summary>
        /// number between 34.3 - 35.5
        /// </summary>
        private float longitude;
        /// <summary>
        /// get and set
        /// </summary>
        public float m_longitude
        {
            get { return longitude; }
            set
            {
                if (value < -180 || value > 180)
                    Console.WriteLine("ERROR!!");
                else
                    longitude = value;
            }
        }
        /// <summary>
        /// print details of stop
        /// </summary>
        public void print()
        {
            if (this != null)
            {
                Console.WriteLine("location: {0}", this.m_location);
                Console.WriteLine("busStationKey: {0}", this.m_busStationKey);
            }
            else
                throw new NullReferenceException("bus location is NULL!!");

        }
    }
}