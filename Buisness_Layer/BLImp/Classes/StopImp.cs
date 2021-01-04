using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLApi;
using BO;
using BL;

//aaa


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
            var myLineStationList = GetAllLineStations(lineStation => lineStation.Code == code).ToList();
            var mySequentialStopInfoList = GetAllSequentialStopsInfo(seqStop => seqStop.StationCodeF == code || seqStop.StationCodeS == code);
            var lineList = GetAllLinesByStopCode(code).ToList();
            foreach(Line line in lineList)
            {
                updateNumberInLine(line, code,-1);
            }
            foreach (LineStation lineStation in myLineStationList)
            {
                dal.DeleteLineStation(lineStation.LineId, lineStation.Code,lineStation.NumberInLine);
            }
            foreach (SequentialStopInfo seqStop in mySequentialStopInfoList)
            {
                dal.DeleteSequentialStopInfo(seqStop.StationCodeF,seqStop.StationCodeS);
            }
            dal.DeleteStop(code);
        }

        public void updateNumberInLine(Line line, long code,int increase)
        {
            bool found = false;
            foreach (LineStation lineStation in line.Stops)
            {
                if (lineStation.Code == code)
                    found = true;
                else if (found)
                {
                    UpdateLineStationNumberInLine(lineStation.NumberInLine + increase, line.Id, lineStation.Code);
                }
            }
        }

        public void AddStopInLine(long lineId,long code,long numberInLine)
        {
            //lets see you now
            var line = GetLine(lineId);
            updateNumberInLine(line, code, 1);
            CreateLineStation(lineId, numberInLine, code);
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
        {//aaa
            return dal.GetStop(code).GetPropertiesFrom<BO.Stop, DO.Stop>();
        }

    }
}
