using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;
using DS;
using DO;





namespace DL
{
    public partial class DLObject : IDal
    {
        /// <summary>
        /// add new stop to database
        /// </summary>
        /// <param name="stop"></param>
        public void CreateStop(Stop stop)
        {
            stop.Valid = true;
            try
            {
                GetBus(stop.StopCode);
            }
            catch (Exception ex)
            {
                if (ex.Message == "no bus with such license number!!")
                    DataSource.StopList.Add(stop);
                else if (ex.Message == "bus is not valid!!")
                {
                    var t = from stopInput in DataSource.StopList
                            where (stopInput.StopCode == stop.StopCode)
                            select stopInput;
                    t.ToList().First().Valid = true;
                }
                return;
            }
            throw new Exception("bus already exists!!!");
        }
        /// <summary>
        /// request a Stop according to a predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public Stop RequestStop(Predicate<Stop> pr = null)
        {
            Stop ret = DataSource.StopList.Find(stop => pr(stop));
            if (ret == null)
                throw new Exception("no bus that meets these conditions!");
            if (ret.Valid == false)
                throw new Exception("bus that meets these conditions is not valid");
            return ret.GetPropertiesFrom<Stop, Stop>();
        }
        /// <summary>
        /// update name in database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="licenseNumber"></param>
        public void UpdateStopName(string name, long licenseNumber)
        {
            GetStop(licenseNumber).StopName = name;
        }
        /// <summary>
        /// update longitude in database
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="licenseNumber"></param>
        public void UpdateStopLongitude(double longitude, long licenseNumber)
        {
            GetStop(licenseNumber).Longitude = longitude;
        }
        /// <summary>
        /// update latitude in database
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="licenseNumber"></param>
        public void UpdateStopLatitude(double latitude, long licenseNumber)
        {
            GetStop(licenseNumber).Latitude = latitude;
        }
        /// <summary>
        /// sets a stop valid to false
        /// </summary>
        /// <param name="code"></param>
        public void DeleteStop(long code)
        {
            GetStop(code).Valid = false;
           
        }
        /// <summary>
        /// helper function to get a stop
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Stop GetStop(long code)
        {
            var t = from stop in DataSource.StopList
                    where (stop.StopCode == code)
                    select stop;
            if (t.ToList().Count == 0)
                throw new Exception("no stop with such license number!!");
            if (!t.First().Valid)
                throw new Exception("stop is not valid!!");
            return t.ToList().First();
        }
        /// <summary>
        /// gets all stops
        /// </summary>
        /// <returns></returns>

        public IEnumerable<Stop> GetAllStops()
        {
            var cloneList = new List<Stop>();
            foreach (Stop stop in DataSource.StopList)
            {
                if (stop.Valid == true)
                    cloneList.Add(stop.GetPropertiesFrom<Stop, Stop>());
            }
            return cloneList;
        }
    }
}
