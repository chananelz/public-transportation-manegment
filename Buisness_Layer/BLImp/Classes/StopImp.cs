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
            Random a = new Random();
            Stop stopBO = new Stop(latitude, longitude, stopName);
            stopBO.StopCode = a.Next(0, 500);
            DO.Stop stopDO = stopBO.GetPropertiesFrom<DO.Stop, BO.Stop>();
            try
            {
                dal.CreateStop(stopDO);
            }
            catch (DO.DOBadStopIdException ex)
            {

                throw new BODOStopBadIdException("cant creat this stop :", ex) ;
            }
  
        }
        public Stop RequestStop(Predicate<Stop> pr = null)
        {
            if (pr == null)
                throw new BOStopException("can't request a line with no predicate");
            return dal.RequestStop(stop => pr(stop.GetPropertiesFrom<BO.Stop, DO.Stop>())).GetPropertiesFrom<BO.Stop, DO.Stop>();
        }
        public void UpdateStopName(string name, long code)
        {

            valid.GoodString(name);
            try
            {
                dal.UpdateStopName(name, code);
            }
            catch (DO.DOBadStopIdException ex)
            {

                throw new BODOStopBadIdException("cant Update This Stop Name", ex); 
            }
           
        }
        public void UpdateStopLongitude(double longitude, long code)
        {
            valid.GoodLongitude(longitude);
            try
            {
                dal.UpdateStopLongitude(longitude, code);
            }
            catch (DO.DOBadStopIdException ex)
            {

                throw new BODOStopBadIdException("cant Update This Stop Name", ex); 
            }
            
           
        }
        public void UpdateStopLatitude(double latitude, long code)
        {
            valid.GoodLatitude(latitude);
            try
            {
                dal.UpdateStopLatitude(latitude, code);
            }
            catch (DO.DOBadStopIdException ex)
            {

                throw new BODOStopBadIdException("cant Update This Stop Name", ex); 
            }
            
           
        }
        public void DeleteStop(long code)
        {
            try
            {
                RequestStop(stop1 => stop1.StopCode == code);
                dal.DeleteStop(code);
            }
            catch (DO.DOStopException ex)
            {

                throw new BODOStopBadIdException("cant delete This Stop Name", ex);
            }
        }

        public void updateNumberInLine(Line line, long code,int increase)
        {
            //ooo
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
            for (int i = 0; i < line.Stops.Count -1 ; i++)
            {
                try
                {
                    GetSequentialStopInfo(line.Stops[i].Code, line.Stops[i + 1].Code);
                }
                catch (Exception)
                {

                   CreateSequentialStopInfo(line.Stops[i].Code, line.Stops[i + 1].Code);
                }
            }
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
