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
        /// add new lineStation to database
        /// </summary>
        /// <param name="lineStation"></param>
        public void CreateLineStation(LineStation lineStation)
        {

            DataSource.LineStationList.Add(lineStation);
        }
        /// <summary>
        /// request a LineStation according to a predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public LineStation RequestLineStation(Predicate<LineStation> pr = null)
        {
            LineStation ret = DataSource.LineStationList.Find(line => pr(line));
            if (ret == null)
                throw new Exception("no line that meets these conditions!");
            if (ret == null)
                throw new Exception("line that meets these conditions is not valid");
            return ret.GetPropertiesFrom<LineStation, LineStation>();
        }
        /// <summary>
        /// update numberInLine in database
        /// </summary>
        /// <param name="numberInLine"></param>
        /// <param name="code"></param>
        /// <param name="lineId"></param>
        public void UpdateLineStationNumberInLine(long numberInLine, long code, long lineId)
        {
            GetLineStation(lineId, code, numberInLine).NumberInLine = numberInLine;
        }


        /// <summary>
        /// sets line station valid to false
        /// </summary>
        /// <param name="lineId"></param>
        /// <param name="code"></param>
        /// <param name="numberInLine"></param>
        public void DeleteLineStation(long lineId, long code, long numberInLine)
        {
            try
            {
                GetLineStation(lineId, code, numberInLine).Valid = false;
            }
            catch { GetLineStation(lineId, code, numberInLine).Valid = false; }
        }
        /// <summary>
        /// helper function to get a linestation
        /// </summary>
        /// <param name="lineId"></param>
        /// <param name="code"></param>
        /// <param name="numberInLine"></param>
        /// <returns></returns>
        public LineStation GetLineStation(long lineId, long code,long numberInLine)
        {
            LineStation t = DataSource.LineStationList.Find(lineStation => lineStation.Code == code && lineStation.LineId == lineId);
            if (t == null)
                throw new Exception("no such line!!");
            if (!t.Valid)
                throw new Exception("line is not valid!!");
            return t;
        }
        /// <summary>
        /// gets all line stations
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
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
