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
        ///add new line to database
        /// </summary>
        /// <param name="line"></param>
        public void CreateLine(Line line)
        {
            line.Valid = true;
            line.Id = Configuration.LineCounter;
            try
            {
                GetLineByNumber(line.Number);
            }
            catch (DOBadLineIdException ex)
            {
                if (ex.Message == "line doesn't  exist!!")
                    DataSource.LineList.Add(line);
                else if (ex.Message == "line is not valid!!")
                {
                    var t = from line1 in DataSource.LineList
                            where (line1.Id == line.Id)
                            select line1;
                    t.ToList().First().Valid = true;
                }
                return;
            }
            throw new DOBadLineIdException(line.Id , "line already exists!!!");
        }

        public void CreateOppositeDirectionLine(Line line)
        {
            line.Valid = true;
            line.Id = Configuration.LineCounter;
            DataSource.LineList.Add(line);
        }
       
        /// <summary>
        /// request a Line according to a predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public Line RequestLine(Predicate<Line> pr = null)
        {
            Line ret = DataSource.LineList.Find(line => pr(line));
            if (ret == null)
                throw new DOLineException("no line that meets these conditions!");
            if (ret.Valid == false)
                throw new DOLineException("line that meets these conditions is not valid");
            return ret.GetPropertiesFrom<Line, Line>();
        }



        /// <summary>
        /// update in database
        /// </summary>
        /// <param name="number"></param>
        /// <param name="id"></param>
        public void UpdateLineNumber(long number, long id)
        {
            GetLine(id).Number = number;
        }

        public void UpdateLineArea(string area, long id)
        {
            GetLine(id).Area = area;
        }
        /// <summary>
        /// update firstStop in database
        /// </summary>
        /// <param name="firstStop"></param>
        /// <param name="id"></param>
        public void UpdateLineFirstStop(long firstStop, long id)
        {
            //***************************CONVERT INT TO STATUS!!!!!!!!!!!!!************
            GetLine(id).FirstStop = firstStop;
        }
        /// <summary>
        /// update lastStop in database
        /// </summary>
        /// <param name="lastStop"></param>
        /// <param name="id"></param>
        public void UpdateLineLastStop(long lastStop, long id)
        {
            //***************************CONVERT INT TO STATUS!!!!!!!!!!!!!************
            GetLine(id).LastStop = lastStop;
        }
        /// <summary>
        /// deletes a line
        /// </summary>
        /// <param name="id"></param>
        public void DeleteLine(long id)
        {
            GetLine(id).Valid = false;
        }
        /// <summary>
        /// request a Line according to id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Line GetLine(long id)
        {
            //aaa
            var t = (from line in DataSource.LineList
                    where (line.Id == id)
                    select line).ToList();
            if (t.ToList().Count == 0)
                throw new DOBadLineIdException( id,"line doesn't  exist!!");
            if (!t.First().Valid)
                throw new DOBadLineIdException(id, "line is not valid!!");
            return t.ToList().First();
        }
        /// <summary>
        /// gets all lines
        /// </summary>
        /// <returns></returns>

        public IEnumerable<Line> GetAllLines()
        {
            var cloneList = new List<Line>();
            foreach (Line line in DataSource.LineList)
            {
                if (line.Valid == true)
                    cloneList.Add(line.GetPropertiesFrom<Line, Line>());
            }
            return cloneList;
        }

        public Line GetLineByNumber(long number)
        {
            var t = from line in DataSource.LineList
                    where (line.Number == number)
                    select line;
            if (t.ToList().Count == 0)
                throw new DOBadLineIdException(number, "line doesn't  exist!!");
            if (!t.First().Valid)
                throw new DOBadLineIdException(number, "line is not valid!!");
            return t.ToList().First();
        }
    }
}
