using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNet5781_01_6077_5711;
//netanel bashan 0323056077
//chananel zaguri 206275711


namespace dotNet_5781_02_6077_5711
{
    /// <summary>
    /// a bus rout
    /// </summary>
    public class BusRoute : dotNet5781_01_6077_5711.Bus, IComparable<BusRoute>
    {
        public List<BusStop> Stations;
        /// <summary>
        ///  get and set for the list of the bus
        /// </summary>
        public List<BusStop> m_Stations
        {
            get { return Stations; }
            set { Stations = value; }
        }
        private string FirstStation;
        /// <summary>
        /// get and set for First station name
        /// </summary>
        public string m_FirstStation
        {
            get { return FirstStation; }
            set { FirstStation = value; }
        }
        private string LastStation;
        /// <summary>
        /// get and set for last station name
        /// </summary>
        public string m_LastStation
        {
            get { return LastStation; }
            set { LastStation = value; }
        }
        /// <summary>
        /// back or forth
        /// </summary>
        private string direction;
        /// <summary>
        /// get and set for direction
        /// </summary>
        public string m_direction
        {
            get { return direction; }
            set { direction = value; }
        }

        private string Area;
        /// <summary>
        /// get and set for area
        /// </summary>
        public string m_Area
        {
            get { return Area; }
            set { Area = value; }
        }
        private int BusLine;
        /// <summary>
        /// get and set for bus line
        /// </summary>
        public int m_BusLine
        {
            get { return BusLine; }
            set { BusLine = value; }
        }
        /// <summary>
        /// constructor of a new BusRout
        /// </summary>
        public BusRoute() : base(0, 0, 0, new DateTime())
        {
            Stations = new List<BusStop>();
            LastStation = "";
            FirstStation = "";
            Area = "";
            BusLine = 0;
            direction = "A";
        }
        public BusRoute(List<BusStop> Stations, string Area, int BusLine, int licenseNum, float fuel, int yearStart, DateTime timeTreat, string direction) : base(licenseNum, fuel, yearStart, timeTreat)
        {
            this.Stations = Stations;
            this.LastStation = Stations[0].m_mylocation.m_location;
            this.FirstStation = Stations[Stations.Count - 1].m_mylocation.m_location;
            this.Area = Area;
            this.BusLine = BusLine;
            this.direction = direction;
        }
        /// <summary>
        /// compare one item to another.
        /// </summary>
        /// <param name="other">item to compare</param>
        /// <returns>(1:) -  if this < other ; (-1:) if this > other ; (0:) if this == other </returns>
        public int CompareTo(BusRoute other)
        {
            if (other.m_Stations.Count > 0 && m_Stations.Count > 0)
            {
                if (this.travelTime(this.m_Stations[0], this.m_Stations[this.m_Stations.Count - 1]) < other.travelTime(other.m_Stations[0], other.m_Stations[other.m_Stations.Count - 1]))
                {
                    return 1;
                }
                if (this.travelTime(this.m_Stations[0], this.m_Stations[this.m_Stations.Count - 1]) > other.travelTime(other.m_Stations[0], other.m_Stations[other.m_Stations.Count - 1]))
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else return 2;
        }
        /// <summary>
        /// print all BusStop details
        /// </summary>
        public void toString()
        {
            Console.WriteLine("bus line number:,{0},\narea:,{1},\n", BusLine, Area);
            foreach (BusStop myBusStop in m_Stations)
            {
                myBusStop.ToString();//chananel hamelech!!!!
            }
        }
        public override string ToString()
        {
            string ret = string.Format("{0} {1}", this.m_BusLine, this.direction);
            return ret;
        }

        /// <summary>
        /// updating the distance
        /// </summary>
        /// <param name="place"> place to Updating</param>
        /// <param name="bus">bus stop to Updating </param>
        /// <returns></returns>
        public float distanceUpdate(int place, BusStop bus)
        {
            return (float)gteDistance(Stations[place - 1].m_mylocation.m_latitude, Stations[place - 1].m_mylocation.m_longitude, bus.m_mylocation.m_latitude, bus.m_mylocation.m_longitude);
        }
        /// <summary>
        /// adDS a stop in a certain index in the route
        /// </summary>
        /// <param name="myBusStop"><stop to be added/param>
        /// <param name="place">place to be inserted</param>
        public void add(BusStop myBusStop, int place)
        {
            if (place >= 0 && place <= m_Stations.Count())
            {
                if (place >= 2)
                {
                    if (myBusStop.m_mylocation.m_busStationKey == m_Stations[place - 2].m_mylocation.m_busStationKey)
                    {
                        return;
                    }
                }
                if (m_Stations.Count == 0)
                {
                    myBusStop.m_distance = 0;
                    myBusStop.m_duration = 0;
                }
                if (place != 0)
                {
                    myBusStop.m_distance = distanceUpdate(place, myBusStop);
                    myBusStop.m_duration = myBusStop.m_distance / 80;
                }
                Stations.Insert(place, myBusStop);
            }
            else
                throw new IndexOutOfRangeException("place out of range!!");

        }
        /// <summary>
        /// delete bus
        /// </summary>
        /// <param name="place">place deleted</param>
        public void delete(int place)
        {
            //if (place < 0 || place > m_Stations.Count())
            //{
            //    throw new IndexOutOfRangeException("place out of range");
            //}
            float myDistance = Stations[place].m_distance;
            Stations.RemoveAt(place);
            if (place != m_Stations.Count())
            {
                Stations[place].m_distance = myDistance;
            }
        }
        /// <summary>
        ///  return true if the BusStop exists
        /// </summary>
        /// <param name="m_stop">busStop check</param>
        /// <returns>true - if the stop exist</returns>
        public bool stopExist(BusStop m_stop)
        {
            bool flag = false;
            if (!(Stations == null))
            {
                foreach (BusStop stopCheck in Stations)
                {
                    if (stopCheck.m_mylocation.m_busStationKey == m_stop.m_mylocation.m_busStationKey)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }
        /// <summary>
        ///calculate the distance between two busStops
        /// </summary>
        /// <param name="fStop">the first stop</param>
        /// <param name="lStop">the last stop stop</param>
        /// <returns></returns>
        public float distance(BusStop fStop, BusStop lStop)
        {
            return help(fStop, lStop, true);
        }
        /// <summary>
        /// calculate the duration of time between two busStops
        /// </summary>
        /// <param name="fStop">first stop</param>
        /// <param name="sStop">last stop</param>
        /// <returns>travelTime</returns>
        public float travelTime(BusStop fStop, BusStop sStop)
        {
            return help(fStop, sStop, false);
        }
        /// <summary>
        /// return BusStop section between two busStop
        /// </summary>
        /// <param name="fStop">first stop</param>
        /// <param name="sStop">last stop</param>
        /// <returns>the  section between two busStop</returns>
        public BusRoute Section(BusStop fStop, BusStop sStop)
        {
            BusRoute ret = new BusRoute();
            ret.m_Area = m_Area;
            ret.m_BusLine = m_BusLine;
            ret.m_FirstStation = m_FirstStation;
            ret.m_LastStation = m_LastStation;
            bool startFlag = false;
            if (stopExist(fStop) && stopExist(sStop))
            {
                foreach (BusStop m_Stations in Stations)
                {
                    if (m_Stations.m_mylocation.m_busStationKey == fStop.m_mylocation.m_busStationKey)
                    {
                        startFlag = true;
                    }
                    if (m_Stations.m_mylocation.m_busStationKey == sStop.m_mylocation.m_busStationKey)
                    {
                        ret.Stations.Add(m_Stations);
                        break;
                    }
                    if (startFlag)
                    {
                        ret.Stations.Add(m_Stations);
                    }
                }
            }
            return ret;
        }
        /// <summary>
        /// calculate the distance / duration of time between two busStops
        /// </summary>
        /// <param name="fStop">first stop</param>
        /// <param name="lStop">last stop</param>
        /// <param name="choice">th ; -sum of time </param>
        /// <returns></returns>
        public float help(BusStop fStop, BusStop lStop, bool choice)
        {
            float sum = 0;
            bool startFlag = false;
            if (stopExist(fStop) && stopExist(lStop))
            {
                foreach (BusStop m_Stations in Stations)
                {
                    if (m_Stations.m_mylocation.m_busStationKey == fStop.m_mylocation.m_busStationKey)
                    {
                        startFlag = true;
                    }
                    if (m_Stations.m_mylocation.m_busStationKey == lStop.m_mylocation.m_busStationKey)
                    {
                        if (choice)//choice = true means sum of distance
                            sum += m_Stations.m_distance;
                        else
                            sum += m_Stations.m_duration;
                        break;
                    }
                    if (startFlag)
                    {
                        if (choice)//choice = true means sum of distance
                            sum += m_Stations.m_distance;
                        else
                            sum += m_Stations.m_duration;
                    }
                }
            }
            return sum;
        }
        /// <summary>
        /// calculate which BusRoute takes less time
        /// </summary>
        /// <param name="myBus"> the first BusRoute</param>
        /// <param name="fStop">first stop</param>
        /// <param name="sStop">last stop</param>
        /// <returns>the BusRoute that takes less time</returns>
        public int BestRoute(BusRoute myBus, BusStop fStop, BusStop sStop)
        {
            BusRoute mySection = myBus.Section(fStop, sStop);
            return this.CompareTo(mySection);
        }
        /// <summary>
        /// print Details of bus route
        /// </summary>
        public void print()
        {
            if (this != null)
            {
                Console.WriteLine("first station: {0}", this.m_FirstStation);
                Console.WriteLine("last station: {0}", this.m_LastStation);
                Console.WriteLine("area: {0}", this.m_Area);
                Console.WriteLine("bus line number: {0}", this.m_BusLine);
            }
            else
                throw new NullReferenceException("can't print bus rout null");
        }
        /// <summary>
        /// print Details of bus stop
        /// </summary>
        public void printStops()
        {
            int count = 0;
            foreach (BusStop stop in Stations)
            {

                if (count != 0 && stop.m_distance == 0)
                {

                }
                else
                    Console.WriteLine("stop number {0}", count);
                Console.WriteLine("distance from last station: {0}", stop.m_distance);
                stop.m_mylocation.print();
                count++;
            }
        }
        /// <summary>
        /// calculate the distance between tow point 
        /// </summary>
        /// <param name="fLatitude">Latitude</param>
        /// <param name="fLongitude">Longitude</param>
        /// <param name="sLatitude">Latitude</param>
        /// <param name="sLongitude">sLongitude</param>
        /// <returns></returns>
        public static double gteDistance(float fLatitude, float fLongitude, float sLatitude, float sLongitude)
        {
            double d = fLatitude * 0.017453292519943295;
            double num3 = fLongitude * 0.017453292519943295;
            double num4 = sLatitude * 0.017453292519943295;
            double num5 = sLongitude * 0.017453292519943295;
            double num6 = num5 - num3;
            double num7 = num4 - d;
            double num8 = Math.Pow(Math.Sin(num7 / 2.0), 2.0) + ((Math.Cos(d) * Math.Cos(num4)) * Math.Pow(Math.Sin(num6 / 2.0), 2.0));
            double num9 = 2.0 * Math.Atan2(Math.Sqrt(num8), Math.Sqrt(1.0 - num8));
            return 6376500.0 * num9;
        }
    }
}
