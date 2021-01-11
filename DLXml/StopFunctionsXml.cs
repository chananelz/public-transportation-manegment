using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalApi;
using DO;


namespace DL
{
    public partial class DLXML : IDal
    {
        #region Stop

        /// <summary>
        /// add new stop to database
        /// </summary>
        /// <param name="stop"></param>
        public void CreateStop(Stop stop)
        {
            List<Stop> StopList = XMLTools.LoadListFromXMLSerializer<Stop>(stopsPath);
            stop.Valid = true;
            try
            {
                GetStop(stop.StopCode);
            }
            catch (DOStopException ex)
            {
                if (ex.Message == "no stop with such license number!!")
                    StopList.Add(stop);
                else if (ex.Message == "stop is not valid!!")
                {
                    StopList.Find(stopInput => stopInput.StopCode == stop.StopCode).Valid = true;
                }
                XMLTools.SaveListToXMLSerializer(StopList, stopsPath);
                return;
            }
            throw new DOBadStopIdException(stop.StopCode, "stop already exists!!!");


        }

        /// <summary>
        /// request a Stop according to a predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public Stop RequestStop(Predicate<Stop> pr = null)
        {
            List<Stop> StopList = XMLTools.LoadListFromXMLSerializer<Stop>(stopsPath);
            Stop ret = StopList.Find(stop => pr(stop));
            if (ret == null)
                throw new DOStopException("no stop that meets these conditions!");
            if (ret.Valid == false)
                throw new DOStopException("stop that meets these conditions is not valid");
            return ret;

        }

        /// <summary>
        /// update name in database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="licenseNumber"></param>
        public void UpdateStopName(string name, long code)
        {
            List<Stop> StopList = XMLTools.LoadListFromXMLSerializer<Stop>(stopsPath);

            try
            {
                Stop temp = RequestStop(myStop => myStop.StopName == name);
            }
            catch (DOStopException exc)
            {
                if (exc.Message == "no stop that meets these conditions!")
                {
                    try
                    {
                        StopList.Find(stopInput => stopInput.StopCode == code).StopName = name;
                        XMLTools.SaveListToXMLSerializer(StopList, stopsPath);
                        return;
                    }
                    catch (DOStopException ex)
                    {
                        throw new DOBadStopIdException(code, ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// update longitude in database
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="licenseNumber"></param>
        public void UpdateStopLongitude(double longitude, long code)
        {
            List<Stop> StopList = XMLTools.LoadListFromXMLSerializer<Stop>(stopsPath);

            try
            {
                GetStop(code);
                StopList.Find(stopInput => stopInput.StopCode == code).Longitude = longitude;
                XMLTools.SaveListToXMLSerializer(StopList, stopsPath);

            }
            catch (DOStopException ex)
            {

                throw new DOBadStopIdException(code, ex.Message);
            }
        }

        /// <summary>
        /// update latitude in database
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="licenseNumber"></param>
        public void UpdateStopLatitude(double latitude, long code)
        {
            List<Stop> StopList = XMLTools.LoadListFromXMLSerializer<Stop>(stopsPath);

            try
            {
                GetStop(code);
                StopList.Find(stopInput => stopInput.StopCode == code).Latitude = latitude;
                XMLTools.SaveListToXMLSerializer(StopList, stopsPath);

            }
            catch (DOStopException ex)
            {

                throw new DOBadStopIdException(code, ex.Message);
            }
        }

        /// <summary>
        /// helper function to get a stop
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Stop GetStop(long code)
        {
            List<Stop> StopList = XMLTools.LoadListFromXMLSerializer<Stop>(stopsPath);

            var t = from stop in StopList
                    where (stop.StopCode == code)
                    select stop;
            if (t.ToList().Count == 0)
                throw new DOStopException("no stop with such license number!!");
            if (!t.First().Valid)
                throw new DOStopException("stop is not valid!!");
            return t.ToList().First();
        }

        /// <summary>
        /// sets a stop valid to false
        /// </summary>
        /// <param name="code"></param>
        public void DeleteStop(long code)
        {
            List<Stop> StopList = XMLTools.LoadListFromXMLSerializer<Stop>(stopsPath);

            try
            {
                GetStop(code);
                StopList.Find(stopInput => stopInput.StopCode == code).Valid = false;
                XMLTools.SaveListToXMLSerializer(StopList, stopsPath);

            }
            catch (DOStopException ex)
            {

                throw new DOBadStopIdException(code, ex.Message);
            }
        }

        /// <summary>
        /// gets all stops
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Stop> GetAllStops()
        {
            List<Stop> StopList = XMLTools.LoadListFromXMLSerializer<Stop>(stopsPath);

            var myList = new List<Stop>();
            foreach (Stop stop in StopList)
            {
                if (stop.Valid == true)
                    myList.Add(stop);
            }
            return myList;
        }





        #endregion

    }
}
