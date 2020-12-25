using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using dotNet5781_01_6077_5711;
//netanel bashan 0323056077
//chananel zaguri 206275711

namespace dotNet_5781_02_6077_5711
{
  
    /// <summary>
    /// collection of routs
    /// </summary>
    public class BusCollection : dotNet5781_01_6077_5711.BusLine, IEnumerable
    {
        private List<int> BusKeysList;
        /// <summary>
        /// get and set
        /// </summary>
        public List<int> m_BusKeysList
        {
            get { return BusKeysList; }
            set { BusKeysList = value; }
        }
        /// <summary>
        /// list of busRoutes
        /// </summary>
        List<BusRoute> BusCollectionList;
        /// <summary>
        /// getter
        /// </summary>
        public List<BusRoute> m_BusCollectionList
        {
            get { return BusCollectionList; }
        }
        /// <summary>
        /// constructor of bus collection
        /// </summary>
        public BusCollection()
        {
            BusKeysList = new List<int>();
            BusCollectionList = new List<BusRoute>();
        }
        /// <summary>
        /// making busCollection to allow indexing
        /// </summary>
        /// <param name="i">index to be returned</param>
        /// <returns></returns>
        public BusRoute this[int i]
        {
            get { 
                if (i >= 0 && i < m_BusCollectionList.Count())
                {
                    return BusCollectionList[i];
                }
                return null;
            }
            set { BusCollectionList[i] = value; }
        }
        /// <summary>
        /// Funcion that uses indexer to return an argument
        /// </summary>
        /// <param name="x">index</param>
        /// <returns></returns>
        public BusRoute findIndexRoute(int x)
        {
            if (this[x] != null)
                return this[x];
            throw new NullReferenceException("no such index");
        }
        /// <summary>
        /// make class enumarable
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)BusCollectionList).GetEnumerator();
        }
        /// <summary>
        /// checkes if a key exists
        /// </summary>
        /// <param name="key">check key</param>
        /// <returns></returns>
        public bool keyExist(int key)
        {
            if (!(BusKeysList == null))
            {
                foreach (int myKey in BusKeysList)
                {
                    if (myKey == key)
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// add a busRoute to busCollectionList
        /// </summary>
        /// <param name="toAdd"></param>
        public void addBusRoute(BusRoute busLine)
        {
            int index = 0;
            if (!(busLineExist(busLine)))
            {
                    foreach (BusRoute myBusRoute in this)
                    {
                        if (busLine.CompareTo(myBusRoute) == 1)
                        {
                            break;
                        }
                        index++;
                    }
                BusCollectionList.Insert(index, busLine);
            }
        }
       
        /// <summary>
        /// checks if busLine exists
        /// </summary>
        /// <param name="busLine">bus line check</param>
        /// <returns>true - if this bus exist ; false - if this bus not exist </returns>
        public bool busLineExist(BusRoute busLine)
        {
            bool back = false;
            bool forth = false;
            foreach (BusRoute myBusRoute in m_BusCollectionList)
            {
                if (myBusRoute.m_BusLine == busLine.m_BusLine && !((myBusRoute.m_FirstStation == busLine.m_LastStation && myBusRoute.m_LastStation == busLine.m_FirstStation) || (myBusRoute.m_FirstStation == busLine.m_FirstStation && myBusRoute.m_LastStation == busLine.m_LastStation)))
                    return true;
                if (myBusRoute.m_BusLine == busLine.m_BusLine && (myBusRoute.m_FirstStation == busLine.m_LastStation && myBusRoute.m_LastStation == busLine.m_FirstStation))
                {
                    back = true;
                }
                if (myBusRoute.m_BusLine == busLine.m_BusLine && (myBusRoute.m_FirstStation == busLine.m_FirstStation && myBusRoute.m_LastStation == busLine.m_LastStation))
                {
                    forth = true;
                }
            }
            return back && forth;
        }
        /// <summary>
        /// find all the BusRoute that pass in a specific Station
        /// </summary>
        /// <param name="code">the bus station Key </param>
        /// <returns>list of all the BusRoute that pass in a specific Station</returns>
        public List<BusRoute> BusStopList(int code)
        {
            //int code = check.m_mylocation.m_busStationKey;
            List<BusRoute> m_list = new List<BusRoute>();
            int count = 0;
            foreach (BusRoute myBusRoute in this)
            {
                foreach (BusStop myBusStop in myBusRoute.m_Stations)
                {
                    if (myBusStop.m_mylocation.m_busStationKey == code)
                    {
                        m_list.Add(myBusRoute);
                        count++;
                        break;
                    }
                }
            }

            if (count == 0) // no BusRoute that pass in that Station
            {
                Console.WriteLine("exception");
            }

            return m_list;
        }
        /// <summary>
        /// busRoute for two ways added to collection
        /// </summary>
        /// <param name="myBusRoute">bus to be added</param>
        public void addFirstBusRoute(BusRoute myBusRoute)
        {
            BusRoute reverse = new BusRoute();
            BusRoute help = new BusRoute();
            foreach (BusStop myStop in myBusRoute.m_Stations)
            {
                BusStop adDStop = new BusStop();
                adDStop.m_duration = myStop.m_duration;
                adDStop.m_mylocation.m_busStationKey = myStop.m_mylocation.m_busStationKey;
                adDStop.m_mylocation.m_latitude = myStop.m_mylocation.m_latitude;
                adDStop.m_mylocation.m_longitude = myStop.m_mylocation.m_longitude;
                adDStop.m_mylocation.m_location = myStop.m_mylocation.m_location;
                help.add(adDStop, help.m_Stations.Count());
            }
            foreach (BusStop busStop in help.m_Stations.Reverse<BusStop>())
            {
                reverse.add(busStop, reverse.m_Stations.Count());
            }
            reverse.m_FirstStation = myBusRoute.m_LastStation;
            reverse.m_LastStation = myBusRoute.m_FirstStation;
            reverse.m_Area = myBusRoute.m_Area;
            reverse.m_BusLine = myBusRoute.m_BusLine;
            myBusRoute.m_direction = "A";
            reverse.m_direction = "B";
            addBusRoute(myBusRoute);
            addBusRoute(reverse);
        }
        
        /// <summary>
        /// delete Bus Route Key
        /// </summary>
        /// <param name="key">key to be deleted</param>
        public void deleteBusRouteKey(int key)
        {
            bool foundFirst = false;
            int first = 0;
            int second = 0;
            foreach (BusRoute route in m_BusCollectionList)
            {
                if (key == route.m_BusLine)
                {
                    if (!foundFirst)
                    {
                        foundFirst = true;
                        first = second;
                    }
                    else
                    {
                        break;
                    }
                }
                second++;
            }
            m_BusCollectionList.RemoveAt(first);
            m_BusCollectionList.RemoveAt(second -  1);
        }

        /// <summary>
        /// find spesipic stop
        /// </summary>
        /// <param name="key">key to be find</param>
        public BusStop retStop(int key)
        {
            BusStop empty = new BusStop();
            foreach(BusRoute route in m_BusCollectionList)
            {
                foreach(BusStop stop in route.m_Stations)
                {
                    if(stop.m_mylocation.m_busStationKey == key)
                    {
                        return stop;
                    }
                }
            }
            throw  new NotFoundkey("no stope with this key");          
        }
        public BusRoute FindBusRouteByFullName(string name)
        {
            string[] worDS = name.Split(' ');
            int BusLineNumber = int.Parse(worDS[1]);
            string AOrB = worDS[2];
            foreach(BusRoute route in m_BusCollectionList)
            {
                if (route.m_BusLine == BusLineNumber && route.m_direction == AOrB)
                    return route;
            }
            return null;
        }
    }   
}