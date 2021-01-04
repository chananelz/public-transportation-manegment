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
        public void CreateLineStation(long lineId, long numberInLine, long code)
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
            try
            {
                var checkIfAlreadyExists = RequestLineStation(line => line.LineId == lineId && line.NumberInLine == numberInLine && line.Code == code);
                if (checkIfAlreadyExists == null)
                {
                    checkIfAlreadyExists.Valid = true;
                    return;
                }
            }
            catch { }
            var allLineStatoins = GetAllLineStations(line => line.LineId == lineId);
            foreach (LineStation lineStation in allLineStatoins)
            {
                if (lineStation.NumberInLine >= numberInLine)
                    UpdateLineStationNumberInLine(lineStation.NumberInLine + 1, lineStation.LineId, lineStation.Code);
            }
            LineStation lineStationBO = new LineStation(code, numberInLine, lineId);
            DO.LineStation lineStationDO = lineStationBO.GetPropertiesFrom<DO.LineStation, BO.LineStation>();
            lineStationDO.Valid = true;
            dal.CreateLineStation(lineStationDO);
           
        }
        public LineStation RequestLineStation(Predicate<LineStation> pr = null)
        {
            if (pr == null)
                throw new Exception("can't request a lineStation with no predicate");
            var ret = dal.RequestLineStation(line => pr(line.GetPropertiesFrom<BO.LineStation, DO.LineStation>()));
            if (ret != null)
                return ret.GetPropertiesFrom<BO.LineStation, DO.LineStation>();
            return null;
        }
        public void UpdateLineStationNumberInLine(long numberInLine, long lineId, long code)
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
        public void DeleteLineStation(long code, long lineId,long numberInLine)
        {
            dal.DeleteLineStation(lineId, code, numberInLine);
        }
        public IEnumerable<LineStation> GetAllLineStations(Predicate<LineStation> pr = null)
        {
            if (pr == null)
            {
                return dal.GetAllLineStations().Select(line => line.GetPropertiesFrom<BO.LineStation, DO.LineStation>()).ToList(); ;
            }
            return dal.GetAllLineStations().Select(line => line.GetPropertiesFrom<BO.LineStation, DO.LineStation>()).Where(b => pr(b));

        }

        public LineStation GetLineStation(long code, long lineId, long numberInLine)
        {
            //aaa
            return dal.GetLineStation(code, lineId, numberInLine).GetPropertiesFrom<BO.LineStation, DO.LineStation>();
        }



    }
}
