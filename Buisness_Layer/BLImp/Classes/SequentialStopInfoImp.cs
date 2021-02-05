using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using BO;
using BL;






namespace BLImp
{
    public partial class BL : IBL
    {


        public void CreateSequentialStopInfo(long stationCodeF, long stationCodeS)
        {
            string exception = "";
            bool foundException = false;
            try
            {
                //goodCode
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                //goodCode
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            if (foundException)
                throw new Exception(exception);
            Stop stopA = GetStop(stationCodeF);
            Stop stopB = GetStop(stationCodeS);
            double distance = GteDistance(stopA.Latitude, stopA.Longitude, stopB.Latitude, stopB.Longitude);
            SequentialStopInfo SequentialStopInfoBO = new SequentialStopInfo(stationCodeF, stationCodeS, distance, TimeSpan.FromSeconds(distance / 50));  //@@@@ /
            DO.SequentialStopInfo SequentialStopInfoDO = SequentialStopInfoBO.GetPropertiesFrom<DO.SequentialStopInfo, BO.SequentialStopInfo>();
            dal.CreateSequentialStopInfo(SequentialStopInfoDO);
        }
        public SequentialStopInfo RequestSequentialStopInfo(Predicate<SequentialStopInfo> pr)
        {
            if (pr == null)
                throw new Exception("can't request a line with no predicate");
            return dal.RequestSequentialStopInfo(sequentialStopInfo => pr(sequentialStopInfo.GetPropertiesFrom<BO.SequentialStopInfo, DO.SequentialStopInfo>())).GetPropertiesFrom<BO.SequentialStopInfo, DO.SequentialStopInfo>();
        }
        public void UpdateSequentialStopInfoDistance(long firstId, long secondId, double distance)
        {
            //validate
            dal.UpdateSequentialStopInfoDistance(firstId, secondId, distance);
        }
        public void UpdateSequentialStopInfoTravelTime(long firstId, long secondId, TimeSpan travelTime)
        {
            //validate
            dal.UpdateSequentialStopInfoTravelTime(firstId, secondId, travelTime);
        }
        public void DeleteSequentialStopInfo(long firstId, long secondId)
        {
            dal.DeleteSequentialStopInfo(firstId, secondId);
        }
        public SequentialStopInfo GetSequentialStopInfo(long fCode, long sCode)
        {
            var a =  dal.GetSequentialStopInfo(fCode, sCode).GetPropertiesFrom<BO.SequentialStopInfo, DO.SequentialStopInfo>();
            return a;
        }
        /// <summary>
        /// calculate the distance between tow point 
        /// </summary>
        /// <param name="fLatitude">Latitude</param>
        /// <param name="fLongitude">Longitude</param>
        /// <param name="sLatitude">Latitude</param>
        /// <param name="sLongitude">sLongitude</param>
        /// <returns></returns>
        double GteDistance(double fLatitude, double fLongitude, double sLatitude, double sLongitude)
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



        /// <summary>
        ///calculate the distance between two busStops
        /// </summary>
        /// <param name="fStop">the first stop</param>
        /// <param name="lStop">the last stop stop</param>
        /// <returns></returns>
        public double DistanceCalculate(long number, long fStop, long lStop)
        {
            return helpDistance(number, fStop, lStop);
        }
        /// <summary>
        /// calculate the distance / duration of time between two busStops
        /// </summary>
        /// <param name="fStop">first stop</param>
        /// <param name="lStop">last stop</param>
        /// <param name="choice">th ; -sum of time </param>
        /// <returns></returns>
        public double helpDistance(long number, long firstCode, long secondCode)
        {
            var lineStations = GetAllLineStationsByLineNumber(number);
            long fid = 0;
            long sid = 0;
            bool foundFirst = false;
            double sum = -1;
            //var my = lineStations.OrderBy(st => st.NumberInLine).ToList();
            foreach (LineStation ls in lineStations.OrderBy(st => st.NumberInLine))
            {
                if (!foundFirst && ls.Code == firstCode)
                {
                    fid = firstCode;
                    sum = 0;
                    foundFirst = true;
                }
                else if (foundFirst)
                {
                    sum += GetSequentialStopInfo(fid, ls.Code).Distance;
                    fid = ls.Code;
                }
                if (ls.Code == secondCode)
                    break;
            }
            return sum;
        }
        public TimeSpan helpTime(long number, long firstCode, long secondCode)
        {
            var lineStations = GetAllLineStationsByLineNumber(number);
            long fid = 0;
            long sid = 0;
            bool foundFirst = false;
            TimeSpan sum = new TimeSpan();
            foreach (LineStation ls in lineStations.OrderBy(st => st.NumberInLine))
            {
                if (!foundFirst && ls.Code == firstCode)
                {
                    fid = firstCode;
                    foundFirst = true;
                }
                else if (foundFirst)
                {
                    sum += GetSequentialStopInfo(fid, ls.Code).TravelTime;
                    fid = ls.Code;
                }
                if (ls.Code == secondCode)
                    break;
            }
            return sum;
        }
        public TimeSpan TravelTimeCalculate(long number, long fStop, long sStop)
        {
            return helpTime(number, fStop, sStop);
        }

        public IEnumerable<SequentialStopInfo> GetAllSequentialStopsInfo(Predicate<SequentialStopInfo> pr = null)
        {
            if (pr == null)
            {
                return dal.GetAllSequentialStopInfo().Select(bus => bus.GetPropertiesFrom<BO.SequentialStopInfo, DO.SequentialStopInfo>()).ToList(); ;
            }
            return dal.GetAllSequentialStopInfo().Select(seqStop => seqStop.GetPropertiesFrom<BO.SequentialStopInfo, DO.SequentialStopInfo>()).Where(b => pr(b));
        }

    }
}




