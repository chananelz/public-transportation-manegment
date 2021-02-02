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
        #region Line

        /// <summary>
        ///add new line to database
        /// </summary>
        /// <param name="line"></param>
        public void CreateLine(Line line)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
             //line.Id = Configuration.LineCounter + 10;//בקובץ אקסממל יש כבר 
            line.Id = LineList.Count() + 11;
            try
            {
                GetLineByNumber(line.Number);
            }
            catch (DOBadLineIdException ex)
            {
                if (ex.Message == "line doesn't  exist!!")
                {
                    LineList.Add(line);
                }

                else if (ex.Message == "line is not valid!!")
                {
                    LineList.Find(line1 => line1.Number == line.Number).Valid = true;
                }
                XMLTools.SaveListToXMLSerializer(LineList, linesPath);
                return;
            }
            throw new DOBadLineIdException(line.Id, "line already exists!!!");
        }

        public Line GetLineByNumber(long number)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);

            var t = from line in LineList
                    where (line.Number == number)
                    select line;
            if (t.ToList().Count == 0)
                throw new DOBadLineIdException(number, "line doesn't  exist!!");
            if (!t.First().Valid)
                throw new DOBadLineIdException(number, "line is not valid!!");
            return t.ToList().First();
        }

        public void CreateOppositeDirectionLine(Line line)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            line.Valid = true;
            line.Id = Configuration.LineCounter + 10;
            LineList.Add(line);
            XMLTools.SaveListToXMLSerializer(LineList, linesPath);
        }

        /// <summary>
        /// request a Line according to a predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public Line RequestLine(Predicate<Line> pr = null)
        {
            Console.WriteLine(pr.ToString());
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            Line ret = LineList.Find(line => pr(line));
            if (ret == null)
                throw new DOLineException("no line that meets these conditions!");
            if (ret.Valid == false)
                throw new DOLineException("line that meets these conditions is not valid");
            return ret;
        }

        /// <summary>
        /// update in database
        /// </summary>
        /// <param name="number"></param>
        /// <param name="id"></param>
        public void UpdateLineNumber(long number, long id)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            GetLine(id);
            LineList.Find(p => p.Id == id).Number = number;

            XMLTools.SaveListToXMLSerializer(LineList, linesPath);
        }

        public void UpdateLineArea(string area, long id)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            GetLine(id);
            LineList.Find(p => p.Id == id).Area = area;

            XMLTools.SaveListToXMLSerializer(LineList, linesPath);
        }

        /// <summary>
        /// update firstStop in database
        /// </summary>
        /// <param name="firstStop"></param>
        /// <param name="id"></param>
        public void UpdateLineFirstStop(long firstStop, long id)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            GetLine(id);
            LineList.Find(p => p.Id == id).FirstStop = firstStop;

            XMLTools.SaveListToXMLSerializer(LineList, linesPath);
        }

        /// <summary>
        /// update lastStop in database
        /// </summary>
        /// <param name="lastStop"></param>
        /// <param name="id"></param>
        public void UpdateLineLastStop(long lastStop, long id)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            GetLine(id);
            LineList.Find(p => p.Id == id).LastStop = lastStop;

            XMLTools.SaveListToXMLSerializer(LineList, linesPath);
        }

        /// <summary>
        /// request a Line according to id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Line GetLine(long id)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            var t = (from line in LineList
                     where (line.Id == id)
                     select line).ToList();
            if (t.ToList().Count == 0)
                throw new DOBadLineIdException(id, "line doesn't  exist!!");
            if (!t.First().Valid)
                throw new DOBadLineIdException(id, "line is not valid!!");
            return t.ToList().First();
        }

        /// <summary>
        /// deletes a line
        /// </summary>
        /// <param name="id"></param>
        public void DeleteLine(long id)
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
            GetLine(id);
            LineList.Find(p => p.Id == id).Valid = false;

            XMLTools.SaveListToXMLSerializer(LineList, linesPath);
        }

        /// <summary>
        /// gets all lines
        /// </summary>
        /// <returns></returns>

        public IEnumerable<Line> GetAllLines()
        {
            List<Line> LineList = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);

            var temList = new List<Line>();

            foreach (Line line in LineList)
            {
                if (line.Valid == true)
                    temList.Add(line);
            }
            return temList;

        }
        #endregion
    }
}
