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
        public void CreateLineStation(LineStation lineStation)
        {

            lineStation.Valid = true;
            try
            {
                GetLineStation(lineStation.LineId, lineStation.Code);
            }
            catch (Exception ex)
            {
                if (ex.Message == "no such line!!")
                    DataSource.LineStationList.Add(lineStation);
                else if (ex.Message == "line is not valid!!")
                {
                    var t = from lineS in DataSource.LineStationList
                            where (lineS.Code == lineStation.Code)
                            select lineStation;
                    t.ToList().First().Valid = true;
                }
                return;
            }
            throw new Exception("lineStation already exists!!!");

        }
        public LineStation RequestLineStation(Predicate<LineStation> pr = null)
        {
            LineStation ret = DataSource.LineStationList.Find(line => pr(line));
            if (ret == null)
                throw new Exception("no line that meets these conditions!");
            ret = DataSource.LineStationList.Find(line => line.Valid == true);
            if (ret == null)
                throw new Exception("line that meets these conditions is not valid");
            return ret.GetPropertiesFrom<LineStation, LineStation>();
        }

        public void UpdateLineStationNumberInLine(long numberInLine, long code, long lineId)
        {
            GetLineStation(lineId, code).NumberInLine = numberInLine;
        }



        public void DeleteLineStation(long lineId, long code)
        {
            GetLineStation(lineId, code).Valid = false;
        }

        public LineStation GetLineStation(long lineId, long code)
        {
            LineStation t = DataSource.LineStationList.Find(lineStation => lineStation.Code == code && lineStation.LineId == lineId);
            if (t == null)
                throw new Exception("no such line!!");
            if (!t.Valid)
                throw new Exception("line is not valid!!");
            return t;
        }
        public IEnumerable<LineStation> GetAllLineStations(Predicate<LineStation> pr = null)
        {
            var cloneList = new List<LineStation>();
            foreach (LineStation lineStation in DataSource.LineStationList)
            {
                if (lineStation.Valid == true)
                    cloneList.Add(lineStation.GetPropertiesFrom<LineStation, LineStation>());
            }
            return cloneList;
        }
    }
}
