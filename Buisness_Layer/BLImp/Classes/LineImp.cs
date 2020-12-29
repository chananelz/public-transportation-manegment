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
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                valid.GoodString(area);
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            try
            {
                //valid.stopListExist;
            }
            catch (Exception ex)
            {
                exception += ex.Message;
                foundException = true;
            }
            if (foundException)
                throw new Exception(exception);
            Line lineBO = new Line(number, area, stopList[0].StopCode,stopList[stopList.Count() - 1].StopCode );
            DO.Line lineDO = lineBO.GetPropertiesFrom<DO.Line, BO.Line>();
            dal.CreateLine(lineDO);
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
            long i = 1;
            foreach(Stop stop in stopLines)
            {
                if (i == 0)
                    UpdateLineFirstStop(stop.StopCode,id);
                if (i == stopLines.Count() - 1)
                    UpdateLineFirstStop(stop.StopCode, id);
                CreateLineStation(id, i, stop.StopCode);
            }
        }

        public void DeleteLine(long id)
        {
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
    }
}
