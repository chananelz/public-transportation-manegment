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
        public void CreateLine(long number, string area, List<Stop> stopList)
        {
            string exception = "";
            bool foundException = false;
            try
            {
                valid.GoodLong(number);
            }
            catch (BOLineException ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                valid.GoodString(area);
            }
            catch (BOLineException ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            //try
            //{
            //    //valid.stopListExist;
            //}
            //catch (Exception ex)
            //{
            //    exception += ex.Message;
            //    foundException = true;
            //}
            if (foundException)
                throw new BOLineException(exception);
            Line lineBO = new Line(number, area, stopList[0].StopCode,stopList[stopList.Count() - 1].StopCode );
            DO.Line lineDO = lineBO.GetPropertiesFrom<DO.Line, BO.Line>();
            try
            {
                dal.CreateLine(lineDO);
            }
            catch (DO.DOBadLineIdException ex )
            {

                throw  new BODOBadLineIdException ("cant create this line" , ex);
            }
           
            UpdateLineStations(stopList, GetIdByNumber(number));
        }

        public void CreateOppositeDirectionLine(long number, string area, List<Stop> stopList)
        {
            string exception = "";
            bool foundException = false;
            try
            {
                valid.GoodLong(number);
            }
            catch (BOLineException ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                valid.GoodString(area);
            }
            catch (BOLineException ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            //try
            //{
            //    //valid.stopListExist;
            //}
            //catch (Exception ex)
            //{
            //    exception += ex.Message;
            //    foundException = true;
            //}
            if (foundException)
                throw new BOLineException(exception);
            Line lineBO = new Line(number, area, stopList[0].StopCode, stopList[stopList.Count() - 1].StopCode);
            DO.Line lineDO = lineBO.GetPropertiesFrom<DO.Line, BO.Line>();
            try
            {
                dal.CreateOppositeDirectionLine(lineDO);
            }
            catch (DO.DOBadLineIdException ex)
            {

                throw new BODOBadLineIdException("cant create this line", ex);
            }

            UpdateLineStations(stopList, GetIdByNumber(number));
        }

        
        public Line RequestLine(Predicate<Line> pr = null)
        {
            if (pr == null)
                throw new Exception("can't request a line with no predicate");
            return dal.RequestLine(line => pr(line.GetPropertiesFrom<BO.Line, DO.Line>())).GetPropertiesFrom<BO.Line, DO.Line>();
        }
        public Line RequestLineById(long id)
        {
            return RequestLine(line => line.Id == id);
        }
        public void UpdateLineNumber(long number, long id)
        {
            valid.GoodLong(number);
            dal.UpdateLineNumber(number, id);
        }

        public void UpdateLineArea(string area, long id)
        {
            valid.GoodString(area);
            dal.UpdateLineArea(area, id);
        }

        public void UpdateLineFirstStop(long firstStop, long id)
        {
            valid.GoodInt(firstStop);
            dal.UpdateLineFirstStop(firstStop, id);
        }
        public void UpdateLineLastStop(long lastStop, long id)
        {
            valid.GoodInt(lastStop);
            dal.UpdateLineLastStop(lastStop, id);
        }
        public void UpdateLineStations(List<Stop>stopLines,long id)
        {
            //valid.stopListExist;
            if(GetAllLineById(id).ToList().Count() != 0)
            {
                var a = GetAllLineStations(line => line.LineId == id).ToList();
                var b = GetAllLineStations().ToList();
                foreach (LineStation lineStation in a)
                {
                    DeleteLineStation(lineStation.Code, lineStation.LineId,lineStation.NumberInLine);
                }
            }
            long i = 1;
            foreach(Stop stop in stopLines)
            {
                var a = GetAllLineStations(line => line.LineId == id).ToList();
                if (i == 1)
                    UpdateLineFirstStop(stop.StopCode,id);
                if (i == stopLines.Count())
                    UpdateLineLastStop(stop.StopCode, id);
                CreateLineStation(id, i, stop.StopCode);
                i++;
            }
        }

        public void DeleteLine(long id)
        {
            if (GetAllLineById(id).ToList().Count() != 0)
            {
                foreach (LineStation lineStation in GetAllLineStationsByLineNumber(RequestLine(line => line.Id == id).Number))
                {
                    DeleteLineStation(lineStation.Code, lineStation.LineId,lineStation.NumberInLine);
                }
                foreach (BusTravel busTravel in GetAllBusseseByLineNumber(RequestLine(line => line.Id == id).Number))
                {
                    DeleteBusTravel(busTravel.Id);
                }
            }
            dal.DeleteLine(id);
        }

        public long GetIdByNumber(long number)
        {
            return RequestLine(line => line.Number == number).Id;
        }

        public IEnumerable<Line> GetAllLines(Predicate<Line> pr = null)
        {
            if (pr == null)
            {
                return dal.GetAllLines().Select(line => line.GetPropertiesFrom<BO.Line, DO.Line>()).ToList(); ;
            }
            return dal.GetAllLines().Select(line => line.GetPropertiesFrom<BO.Line, DO.Line>()).Where(b => pr(b));
        }

        public IEnumerable<Stop> GetAllStopsByLineNumber(long number)
        {
            long lineId = GetIdByNumber(number);
            var myList = GetAllLineStations(lineStation => lineStation.LineId == lineId).ToList();
            List<Stop> li = new List<Stop>();
            //convert lineStations to Stops
            foreach (LineStation lineStation in myList)
            {
                li.Add(RequestStop(stop => stop.StopCode == lineStation.Code));
            }
            return li;
        }
        public IEnumerable<LineStation> GetAllLineStationsByLineNumber(long number)
        {
            long lineId = GetIdByNumber(number);
           return GetAllLineStations(lineStation => lineStation.LineId == lineId && lineStation.Valid == true).ToList(); 
        }

        public IEnumerable<Line> GetAllLineByLineNumber(long number)
        {
            long lineId = GetIdByNumber(number);
            return GetAllLineById(lineId);
        }

        public IEnumerable<BusTravel> GetAllBusseseByLineNumber(long number)
        {

            return GetAllBusTravels().Where(busT => exist(busT, number));

        }

        public bool exist(BusTravel mbus , long number)
        {
            bool flag = false;
            List<long> mList = new List<long>();
            foreach (var item in GetAllLines())
            {
                if (item.Number == number)
                {
                    mList.Add(item.Id);
                }
            }

            foreach (var item in mList)
            {
                if (item == mbus.LineId)
                {
                    flag = true;
                }
            }

            return flag;
        }
        public Line GetLine(long id)
        {
            //ddd
            return dal.GetLine(id).GetPropertiesFrom<BO.Line, DO.Line>();
        }
        public IEnumerable<IEnumerable<Line>> GetAllLineGroupByArea()
        {
            return from line in GetAllLines()
                   group line by line.Area
                   into list
                   select list;
        }
        public IEnumerable<string> GetAllAreas()
        {
            return (from line in GetAllLines()
                    select line.Area).Distinct();
        }

    }
}
