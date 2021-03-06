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
        public void DeleteLineStation(long code, long lineId, long numberInLine)
        {
            var allLineStatoins = GetAllLineStations(line => line.LineId == lineId).ToList();
            long codeBefore = -1;
            long codeAfter = -1;
            int counter = 0;
            foreach (LineStation lineStation in allLineStatoins)
            {
                if (lineStation.NumberInLine < numberInLine)
                    codeBefore = lineStation.Code;
                if (lineStation.NumberInLine > numberInLine)
                {

                    if (counter == 0)
                    {
                        codeAfter = lineStation.Code;
                        counter++;
                    }
                    UpdateLineStationNumberInLine(lineStation.NumberInLine - 1, lineStation.LineId, lineStation.Code);
                }
            }
            if (codeBefore != -1 && codeAfter != -1)
            {
                try
                {
                    CreateSequentialStopInfo(codeBefore, codeAfter);
                }
                catch
                {

                }
            }
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




        public Line GetBestRoute(long fid, long sid)
        {
            double bestDistance = -1;
            double tempDistance = -1;
            Line ret = new Line();
            foreach (Line line in GetAllLines())
            {
                tempDistance = DistanceCalculate(line.Number, fid, sid);
                if (tempDistance != -1 && tempDistance < bestDistance)
                {
                    bestDistance = tempDistance;
                    ret = line;
                }
            }
            if (bestDistance != -1)
                return ret;
            else
                throw new Exception("no such route!!");

        }




        /// <summary>
        /// if line is currently driving return linestation in current time
        /// </summary>
        /// <param name="time"></param>
        /// <param name="lineId"></param>
        /// <returns></returns>
        public LineStation GetStationByTime(TimeSpan check, TimeSpan time, long lineId)
        {
            LineStation ret = new LineStation();
            Line currentLine = GetLine(lineId);
            var stations = GetAllLineStationsByLineNumber(currentLine.Number);
            foreach (LineStation lineStation in stations)
            {
                if (currentLine.FirstStop != lineStation.Code)
                {
                    if (check + TravelTimeCalculate(currentLine.Number, currentLine.FirstStop, lineStation.Code) > time)
                        return ret;
                }
                ret = lineStation;
            }
            return null;
        }




        public TimeSpan GetPassedStopTime(TimeSpan check, TimeSpan time, long lineId)
        {
            LineStation ret = new LineStation();
            Line currentLine = GetLine(lineId);
            TimeSpan temp = new TimeSpan();
            foreach (LineStation lineStation in GetAllLineStationsByLineNumber(currentLine.Number))
            {
                if (currentLine.FirstStop != lineStation.Code)
                {
                    check += TravelTimeCalculate(currentLine.Number, currentLine.FirstStop, lineStation.Code);
                    if (check > time)
                        return (time - temp);
                }
                temp = check;
            }
            return new TimeSpan();
        }





        public TimeSpan GetNextStopTime(TimeSpan check, TimeSpan time, long lineId)
        {
            LineStation ret = new LineStation();
            Line currentLine = GetLine(lineId);
            foreach (LineStation lineStation in GetAllLineStationsByLineNumber(currentLine.Number))
            {
                if (currentLine.FirstStop != lineStation.Code)
                {
                    check += TravelTimeCalculate(currentLine.Number, currentLine.FirstStop, lineStation.Code);
                    if (check > time)
                        return (check - time);
                }
            }
            return new TimeSpan();
        }
    }
}






