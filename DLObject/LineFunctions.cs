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
                GetBus(line.Id);
            }
            catch (Exception ex)
            {
                if (ex.Message == "no bus with such license number!!")
                    DataSource.LineList.Add(line);
                else if (ex.Message == "bus is not valid!!")
                {
                    var t = from line1 in DataSource.LineList
                            where (line1.Id == line.Id)
                            select line1;
                    t.ToList().First().Valid = true;
                }
                return;
            }
            throw new Exception("line already exists!!!");
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
                throw new Exception("no bus that meets these conditions!");
            if (ret.Valid == false)
                throw new Exception("line that meets these conditions is not valid");
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
            var t = from line in DataSource.LineList
                    where (line.Id == id)
                    select line;
            if (t.ToList().Count == 0)
                throw new Exception("line doesn't  exist!!");
            if (!t.First().Valid)
                throw new Exception("line is not valid!!");
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
    }
}
