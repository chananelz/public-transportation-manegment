using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DalApi;
using DO;


namespace DL
{
    public partial class DLXML : IDal
    {

        #region LineStation
        /// <summary>
        /// add new lineStation to database
        /// </summary>
        /// <param name="lineStation"></param>
        public void CreateLineStation(LineStation lineStation)
        {
            List<LineStation> LineStationList = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);
            LineStationList.Add(lineStation);
            XMLTools.SaveListToXMLSerializer(LineStationList, lineStationsPath);

        }

        /// <summary>
        /// request a LineStation according to a predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public LineStation RequestLineStation(Predicate<LineStation> pr = null)
        {
            List<LineStation> LineStationList = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);

            LineStation ret = LineStationList.Find(line => pr(line));
            if (ret == null)
                throw new Exception("no line that meets these conditions!");
            if (ret == null)
                throw new Exception("line that meets these conditions is not valid");
            return ret;
        }

        /// <summary>
        /// update numberInLine in database
        /// </summary>
        /// <param name="numberInLine"></param>
        /// <param name="code"></param>
        /// <param name="lineId"></param>
        public void UpdateLineStationNumberInLine(long numberInLine, long code, long lineId) //?
        {
            List<LineStation> LineStationList = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);
            GetLineStation(code, lineId, numberInLine);
            LineStationList.Find(p => (p.Code == code) && (p.LineId == lineId)).NumberInLine = numberInLine;
            XMLTools.SaveListToXMLSerializer(LineStationList, lineStationsPath);

        }

        /// <summary>
        /// sets line station valid to false
        /// </summary>
        /// <param name="lineId"></param>
        /// <param name="code"></param>
        /// <param name="numberInLine"></param>
        public void DeleteLineStation(long code, long lineId, long numberInLine) //?
        {
            long temp;
            if (code < lineId)
            {
                temp = code;
                code = lineId;
                lineId = temp;
            }
            List<LineStation> LineStationList = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);
            GetLineStation(code, lineId, numberInLine);
            LineStationList.Find(p => (p.Code == code) && (p.LineId == lineId)).Valid = false;
            XMLTools.SaveListToXMLSerializer(LineStationList, lineStationsPath);
        }

        /// <summary>
        /// helper function to get a linestation
        /// </summary>
        /// <param name="lineId"></param>
        /// <param name="code"></param>
        /// <param name="numberInLine"></param>
        /// <returns></returns>
        public LineStation GetLineStation(long code, long lineId, long numberInLine)
        {
            long temp;
            if (code < lineId)
            {
                temp = code;
                code = lineId;
                lineId = temp;
            }
            List<LineStation> LineStationList = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);
           // GetLineStation(lineId, code, numberInLine);
            LineStation t = LineStationList.Find(p => (p.Code == code) && (p.LineId == lineId));
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
            List<LineStation> LineStationList = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);
            var temList = new List<LineStation>();

            foreach (LineStation lineStation in LineStationList)
            {
                if (lineStation.Valid == true)
                    temList.Add(lineStation);
            }
            return temList;

        }

        #endregion
    }
}
