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
        public void CreateLineStation(long lineId, long numberInLine,long code)
        {
            string exception = "";
            bool foundException = false;
            try
            {
                valid.LineIdExist(lineId); 
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                valid.NumberInLineExist(lineId,numberInLine);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                valid.StopCodeExist(code);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            if (foundException)
                throw new Exception(exception);
            LineStation lineStationBO = new LineStation(code, numberInLine,lineId);
            DO.LineStation lineStationDO = lineStationBO.GetPropertiesFrom<DO.LineStation, BO.LineStation>();
            dal.CreateLineStation(lineStationDO);
        }
        public LineStation RequestLineStation(Predicate<LineStation> pr = null)
        {
            if (pr == null)
                throw new Exception("can't request a lineStation with no predicate");
            return dal.RequestLineStation(line => pr(line.GetPropertiesFrom<BO.LineStation, DO.LineStation>())).GetPropertiesFrom<BO.LineStation, DO.LineStation>();

        }
        public void UpdateLineStationNumberInLine(long numberInLine, long lineId,long code)
        {
            string exception = "";
            bool foundException = false;
            try
            {
                valid.LineIdExist(lineId);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                valid.NumberInLineExist(lineId, numberInLine);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                valid.StopCodeExist(code);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            if (foundException)
                throw new Exception(exception);
            dal.UpdateLineStationNumberInLine(numberInLine, code, lineId);
        }
        public void DeleteLineStation(long code,long lineId)
        {
            dal.DeleteLineStation(code, lineId);
        }
        public IEnumerable<LineStation> GetAllLineStations(Predicate<LineStation> pr = null)
        {
            if (pr == null)
            {
                return dal.GetAllLineStations().Select(line => line.GetPropertiesFrom<BO.LineStation, DO.LineStation>()).ToList(); ;
            }
            return dal.GetAllLineStations().Select(line => line.GetPropertiesFrom<BO.LineStation, DO.LineStation>()).Where(b => pr(b));

        }
        public IEnumerable<Stop> GetAllStopsByLineNumber(long number)
        {
            long lineId = GetIdByNumber(number);
            var myList = GetAllLineStations(lineStation => lineStation.LineId == lineId).ToList() ;
            List<Stop> li = new List<Stop>();
            //convert lineStations to Stops
            foreach(LineStation lineStation in myList)
            {
                li.Add(RequestStop(stop => stop.StopCode == lineStation.Code));
            }
            return li;
        }

        //public IEnumerable<Line> GetAllLinesByStopsNumber(long stopCoder)
        //{
        //    var myLineDeList = get


        //    long lineId = GetIdByNumber(number);
        //    var myList = GetAllLineStations(lineStation => lineStation.LineId == lineId).ToList();
        //    List<Stop> li = new List<Stop>();
        //    //convert lineStations to Stops
        //    foreach (LineStation lineStation in myList)
        //    {
        //        li.Add(RequestStop(stop => stop.StopCode == lineStation.Code));
        //    }
        //    return li;
        //}


    }
}
