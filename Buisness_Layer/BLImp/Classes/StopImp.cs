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
        public void CreateStop(double latitude, double longitude, string stopName)
        {

            string exception = "";
            bool foundException = false;
            try
            {
                valid.GoodLatitude(latitude);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                valid.GoodLongitude(longitude);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                valid.GoodString(stopName);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            if (foundException)
                throw new Exception(exception);
            Stop stopBO = new Stop(latitude, longitude, stopName);
            DO.Stop stopDO = stopBO.GetPropertiesFrom<DO.Stop, BO.Stop>();
            dal.CreateStop(stopDO);
        }
        public Stop RequestStop(Predicate<Stop> pr = null)
        {
            if (pr == null)
                throw new Exception("can't request a line with no predicate");
            return dal.RequestStop(stop => pr(stop.GetPropertiesFrom<BO.Stop, DO.Stop>())).GetPropertiesFrom<BO.Stop, DO.Stop>();
        }
        public void UpdateStopName(string name, long code)
        {

            valid.GoodString(name);
            dal.UpdateStopName(name, code);
        }
        public void UpdateStopLongitude(double longitude, long code)
        {
            valid.GoodLongitude(longitude);
            dal.UpdateStopLongitude(longitude, code);
        }
        public void UpdateStopLatitude(double latitude, long code)
        {
            valid.GoodLatitude(latitude);
            dal.UpdateStopLatitude(latitude, code);
        }
        public void DeleteStop(long code)
        {
            var stop = RequestStop(stop1 => stop1.StopCode == code);
            var myList = GetAllLineStations(lineStation => lineStation.Code == code).ToList();
            var lineList = GetAllLinesByStopCode(code).ToList();
            bool found = false;
            foreach(Line line in lineList)
            {
                foreach(LineStation lineStation in line.Stops)
                {
                    if (lineStation.Code == stop.StopCode)
                        found = true;
                    else if (found)
                    {
                        UpdateLineStationNumberInLine(lineStation.NumberInLine - 1, line.Id, lineStation.Code);
                    }
                }
                found = false;
            }
            foreach (LineStation lineStation in myList)
            {
                //DeleteLineStation(lineStation.Code, lineStation.LineId);
            }
            dal.DeleteStop(code);
        }

        public IEnumerable<Stop> GetAllStops(Predicate<Stop> pr = null)
        {
            if (pr == null)
            {
                return dal.GetAllStops().Select(stop => stop.GetPropertiesFrom<BO.Stop, DO.Stop>()).ToList(); ;
            }
            return dal.GetAllStops().Select(stop => stop.GetPropertiesFrom<BO.Stop, DO.Stop>()).Where(b => pr(b));
        }
        public IEnumerable<Line> GetAllLinesByStopCode(long id)
        {

            var myList = GetAllLineStations(lineStation => lineStation.Code == id).ToList();
            List<Line> li = new List<Line>();
            //convert lineStations to Stops
            foreach (LineStation lineStation in myList)
            {
                li.Add(RequestLine(line => line.Id == lineStation.LineId));
            }
            return li;
        }
        public string GetNameByStopCode(long code)
        {
            return RequestStop(stop => stop.StopCode == code).StopName;
        }
        public Stop GetStop(long code)
        {
            return dal.GetStop(code).GetPropertiesFrom<BO.Stop, DO.Stop>();
        }

    }
}
