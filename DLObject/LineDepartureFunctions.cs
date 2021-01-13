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
        /// add new line departure to database
        /// </summary>
        /// <param name="lineDeparture"></param>
        public void CreateLineDeparture(LineDeparture lineDeparture) 
        {
            DataSource.LineDepartureList.Add(lineDeparture);
        }
        /// <summary>
        /// request a LineDeparture according to a predicate
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public LineDeparture RequestLineDeparture(Predicate<LineDeparture> pr = null) // ++
        {
            LineDeparture ret = DataSource.LineDepartureList.Find(lineDeparture => pr(lineDeparture));
            if (ret == null)
                throw new Exception("no lineDeparture that meets these conditions!");
            if (ret.Valid == false)
                throw new Exception("lineDeparture that meets these conditions is not valid");
            return ret.GetPropertiesFrom<LineDeparture, LineDeparture>();
        }
        /// <summary>
        /// request a LineDeparture according to a predicate
        /// </summary>
        /// <param name="id"></param>
        /// <param name="time_Start"></param>
        /// <returns></returns>
        public LineDeparture GetLineDeparture(long id, DateTime time_Start) //++
        {
            var t = from lineDeparture in DataSource.LineDepartureList
                    where (lineDeparture.Id == id)
                    select lineDeparture;
            if (t.ToList().Count == 0)
                throw new Exception("no LineDeparture with such license number!!");
            if (!t.First().Valid)
                throw new Exception("LineDeparture is not valid!!");

            return t.ToList().First();
        }
        /// <summary>
        /// update linedepartuer frquency in database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="time_Start"></param>
        /// <param name="frequency"></param>
        public void UpdateLineDepartureFrequency(long id, DateTime time_Start ,int frequency)//++
        {
            GetLineDeparture(id, time_Start).Frequency = frequency;
        }
        /// <summary>
        /// update time_End in database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="time_Start"></param>
        /// <param name="time_End"></param>
        public void UpdateLineDepartureTime_End(long id, DateTime time_Start , DateTime time_End)//++
        {
            GetLineDeparture(id, time_Start).TimeEnd = time_End;
        }
        /// <summary>
        /// delete line departure in database acording to id and timestart
        /// </summary>
        /// <param name="id">id of lineDeparture</param>
        /// <param name="time_Start"></param>
        public void DeleteLineDeparture(long id, DateTime time_Start) //++
        {
            GetLineDeparture(id, time_Start).Valid = false;
        }
        /// <summary>
        /// get all line departures tha responde to this predicate
        /// </summary>
        /// <param name="pr">predicate</param>
        /// <returns>Ienumarble of line departures that responde to the predicate</returns>
        public IEnumerable<LineDeparture> GetAllLineDepartures(Predicate<LineDeparture> pr = null)
        {
            if (pr == null)
                return DataSource.LineDepartureList;
            else
                return from ld in DataSource.LineDepartureList
                   where (pr(ld))
                   select ld;
        }
    }
}
